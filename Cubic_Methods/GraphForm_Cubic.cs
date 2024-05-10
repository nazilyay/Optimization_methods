using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;

namespace Optimization_methods.Cubic_Methods
{
    public partial class GraphForm_Cubic : Form
    {
        private Chart chart;
        private Panel chartPanel;
        private Point mouseDownPoint;
        private ChartArea chartArea;
        private Series currentABSeries, currentX0Series, series_new, horizontalLineSeries; // Серия для текущей позиции
        private System.Windows.Forms.Timer timer; // Таймер для анимации
        private double a, b, accuracy, parameter, minX, minF, currentA_X, currentB_X, currentX_0;
        private bool isPaused; // Флаг для паузы
        private string functionExpression; // Поле для хранения выражения функции                              
        private TableLayoutPanel tableLayoutPanel;
        private double[] aValues;
        private double[] bValues;
        private double[] x_0_Values;
        private int animationStep = 0; // Переменная для отслеживания текущего шага анимации


        public GraphForm_Cubic(string functionExpression, double accuracy, double a, double b)
        {
            InitializeComponent();
            // Инициализация переменных
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.functionExpression = functionExpression; // Сохраняем выражение функции

            // Однократное вычисление массивов значений x и f(x)
            (aValues, bValues, x_0_Values, minX, minF) = CalculateFunctionOnInterval(a, b, accuracy);

            // Создаем панель для размещения графика
            chartPanel = new Panel();
            chartPanel.Dock = DockStyle.None; // Отменяем автоматическое занимание всей формы
            chartPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom; // Якорим панель слева, сверху и снизу
            chartPanel.Width = 500; // Устанавливаем ширину панели (по вашему усмотрению)
            chartPanel.Height = 350; // Устанавливаем высоту панели (по вашему усмотрению)
            chartPanel.BackColor = Color.White;
            Controls.Add(chartPanel);

            // Располагаем панель слева
            chartPanel.Left = 50; // Указываем отступ слева (по вашему усмотрению)
            chartPanel.Top = (this.ClientSize.Height - chartPanel.Height) / 2; // Центрируем по вертикали

            // Создание графика
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chartPanel.Controls.Add(chart);

            // Отображение функции на графике
            DisplayFunctionGraph(accuracy, a, b, minX, minF);

            // Инициализация таймера для анимации
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000; // Задаем интервал в 200 миллисекунд

            // Привязываем обработчик события закрытия формы
            this.FormClosing += GraphForm_Search_FormClosing;
            chart.MouseMove += chart_MouseMove;
        }
    
        private (double[] aValues, double[] bValues, double[] x_0Values, double minX, double minResult) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> x_0Values = new List<double>();
            double x1 = a;
            double x2 = b;
            double epsilon = Math.Abs(x2 - x1);
            double x0 = 0;
            while (epsilon > accuracy)
            {
                aValues.Add(x1);
                bValues.Add(x2);
                double y1 = CalculateFunctionValue(x1);
                double y2 = CalculateFunctionValue(x2);
                double y11 = CalculateDerivative(x1);
                double y12 = CalculateDerivative(x2);

                double z = y11 + y12 - 3 * (y2 - y1) / (x2 - x1);
                double omega = Math.Sqrt(Math.Pow(z, 2) - y11 * y12);
                double mu = (omega + z - y11) / (2 * omega - y11 + y12);
                x0 = x1 + mu * (x2 - x1);

                x_0Values.Add(x0);
                double y0_derivative = CalculateDerivative(x0);
                if (y0_derivative * y11 < 0)
                {
                    x1 = x0;
                }
                else if (y0_derivative * y12 < 0)
                {
                    x2 = x0;
                }
                
                epsilon = Math.Abs(x2 - x1);
            }
            double minX = x0;
            double minResult = CalculateFunctionValue(minX);

            return (aValues.ToArray(), bValues.ToArray(), x_0Values.ToArray(), minX, minResult);
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop(); // Приостанавливаем таймер
                isPaused = true;

                // Отображаем текущие координаты при нажатии на паузу
                UpdateCoordinateLabel(currentA_X, currentB_X, currentX_0);
            }
            exit_button.Enabled = true;
        }
        private double CalculateDerivative(double x)
        {
            double h = 0.0001; // Шаг для численного дифференцирования
            double xPlusH = x + h;
            double xMinusH = x - h;

            double fPlusH = CalculateFunctionValue(xPlusH);
            double fMinusH = CalculateFunctionValue(xMinusH);

            return (fPlusH - fMinusH) / (2 * h);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            ab_coordinateLabel.Visible = true;
            x_0_label.Visible = true;
            f_0_label.Visible = true;
            // Проверяем, что текущий шаг анимации находится в пределах массива 
            if (animationStep < aValues.Length)
            {
                // Получаем текущее значение x и f(x) из массивов
                currentA_X = aValues[animationStep];
                currentB_X = bValues[animationStep];
                currentX_0 = x_0_Values[animationStep];
                double currentA_Y = CalculateFunctionValue(currentA_X);
                double currentB_Y = CalculateFunctionValue(currentB_X);
                double currentY_0 = CalculateFunctionValue(currentX_0);

                // Обновляем координаты точки текущей позиции
                currentABSeries.Points.Clear();
                currentABSeries.Points.AddXY(currentB_X, currentB_Y);
                currentABSeries.Points.AddXY(currentB_X, CalculateDerivative(currentB_X));
                currentABSeries.Points.AddXY(currentA_X, currentA_Y);
                currentABSeries.Points.AddXY(currentA_X, CalculateDerivative(currentA_X));

                currentX0Series.Points.Clear();
                currentX0Series.Points.AddXY(currentX_0, currentY_0);
                currentX0Series.Points.AddXY(currentX_0, CalculateDerivative(currentX_0));

                chart.Series.Remove(series_new);
                series_new = new Series();
                series_new.ChartType = SeriesChartType.Line;
                series_new.BorderWidth = 2;
                series_new.Color = System.Drawing.Color.Red;

                UpdateCoordinateLabel(currentA_X, currentB_X, currentX_0);
                // Добавление точек на график
                for (double x = currentA_X; x <= currentB_X; x += accuracy)
                {
                    double y = CalculateFunctionValue(x);
                    series_new.Points.AddXY(x, y);
                }

                // Добавление новой серии данных на график
                chart.Series.Add(series_new);

                // Если нажата кнопка паузы, останавливаем анимацию
                if (isPaused)
                {
                    timer.Stop();
                    animationStep = 0;
                    // Отображаем текущие координаты при достижении минимума
                    UpdateCoordinateLabel(currentA_X, currentB_X, currentX_0);
                }

                // Увеличиваем шаг анимации для следующего вызова
                animationStep++;
                UpdateCoordinateLabel(currentA_X, currentB_X, currentX_0);
            }
            else
            {
                // Если все значения анимации были использованы, останавливаем таймер
                timer.Stop();
                animationStep = 0;
            }
        }


        // Метод для обновления метки с координатами
        private void UpdateCoordinateLabel(double a, double b, double x0)
        {
            if (animationStep < aValues.Length)
            {
                ab_coordinateLabel.Text = $"Интервал: ({Math.Round(a, 4)}; {Math.Round(b, 4)})";
                x_0_label.Text = $"x_0: {Math.Round(x0, 4)}";
                f_0_label.Text = $"F(x_0): {Math.Round(CalculateFunctionValue(x0), 4)}";
            }
        }

        private void UpdateCoordinateLabel(double x, double y)
        {
            ab_coordinateLabel.Text = $"X: {Math.Round(x, 4)}";
            x_0_label.Text = $"Y: {Math.Round(y, 4)}";
            f_0_label.Text = $"";
        }

        private double CalculateMaxY(string functionExpression, double accuracy, double a, double b)
        {
            double maxY = double.MinValue; // Инициализация максимального значения Y

            // Вычисление максимального значения Y
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                if (y > maxY)
                {
                    maxY = y; // Обновляем максимальное значение, если текущее значение больше
                }
            }
            return maxY;
        }
        void AddLineAndLabel(Color color, string labelText, int lineHeight, int topMargin, int bottomMargin, TableLayoutPanel panel, int rowIndex)
        {
            Panel linePanel = new Panel
            {
                BackColor = color,
                Height = lineHeight,
                Margin = new Padding(0, topMargin, 0, bottomMargin)
            };
            panel.Controls.Add(linePanel, 1, rowIndex); // Добавляем линию во второй столбец

            Label label = new Label
            {
                Text = labelText,
                AutoSize = false,
                Font = new Font("Times New Roman", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None
            };
            panel.Controls.Add(label, 0, rowIndex); // Добавляем текст в первый столбец
        }
            private void DisplayFunctionGraph(double accuracy, double a, double b, double minX, double minResult)
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tableLayoutPanel);

            // Добавляем текст и линии в соответствующие строки
            AddLineAndLabel(Color.Blue, "y = f(x)", 2, 15, 10, tableLayoutPanel, 0);
            AddLineAndLabel(Color.Black, "y = f'(x)", 1, 15, 10, tableLayoutPanel, 1);

            // Создание области для графика
            chartArea = new ChartArea(); // Используем поле класса
            chartArea.AxisX.Minimum = a - 2;
            chartArea.AxisX.Maximum = b + 2;
            chartArea.AxisY.Minimum = Math.Round(minResult - 5); // Начальное значение для оси Y

            double maxY = CalculateMaxY(functionExpression, accuracy, a, b);

            // Установка максимального значения для оси Y
            chartArea.AxisY.Maximum = Math.Round(maxY + 5); // Увеличиваем максимальное значение на 5 для отступа

            chartArea.AxisX.LineColor = System.Drawing.Color.Black;
            chartArea.AxisY.LineColor = System.Drawing.Color.Black;

            // Добавление области на график
            chart.ChartAreas.Add(chartArea);

            // Подписываем ось X
            chartArea.AxisX.Title = "X";
            // Подписываем ось Y
            chartArea.AxisY.Title = "Y";

            // Создание серии данных для графика функции
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;

            // Добавление точек на график
            for (double x = a - 2; x <= b + 2; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                series.Points.AddXY(x, y);
            }

            // Добавление серии данных на график
            chart.Series.Add(series);

            double currentA_X = aValues[animationStep];
            double currentA_Y = CalculateFunctionValue(currentA_X);
            double currentB_X = bValues[animationStep];
            double currentB_Y = CalculateFunctionValue(currentB_X);

            // Инициализация a b
            currentABSeries = new Series();
            currentABSeries.ChartType = SeriesChartType.Point;
            currentABSeries.Points.AddXY(currentA_X, currentA_Y);
            currentABSeries.Points.AddXY(currentA_X, CalculateDerivative(currentA_X));
            currentABSeries.Color = System.Drawing.Color.Blue;
            currentABSeries.MarkerSize = 5;
            currentABSeries.MarkerStyle = MarkerStyle.Circle;
            currentABSeries.Points.AddXY(currentB_X, currentB_Y);
            currentABSeries.Points.AddXY(currentB_X, CalculateDerivative(currentB_X));

            chart.Series.Add(currentABSeries);

            // Инициализация x_0
            double currentX_0 = x_0_Values[animationStep];
            double currentY_0 = CalculateFunctionValue(currentX_0);

            currentX0Series = new Series();
            currentX0Series.ChartType = SeriesChartType.Point;
            currentX0Series.Points.AddXY(currentX_0, currentY_0);
            currentX0Series.Points.AddXY(currentX_0, CalculateDerivative(currentX_0));
            currentX0Series.Color = System.Drawing.Color.Red;
            currentX0Series.MarkerSize = 5;
            currentX0Series.MarkerStyle = MarkerStyle.Circle;
            chart.Series.Add(currentX0Series);

            // Создание серии данных для горизонтальной линии y=0
            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;

            // Добавление точек на график, чтобы создать линию y=0
            for (double x = chartArea.AxisX.Minimum; x <= chartArea.AxisX.Maximum; x += accuracy)
            {
                double y = 0; // y=0
                horizontalLineSeries.Points.AddXY(x, y);
            }

            // Добавление серии данных на график
            chart.Series.Add(horizontalLineSeries);

            // Создание серии данных для производной функции
            Series Fseries = new Series();
            Fseries.ChartType = SeriesChartType.Line;
            Fseries.BorderWidth = 1;

            // Добавление точек на график
            for (double x = a - 2; x <= b + 2; x += accuracy)
            {
                double y = CalculateDerivative(x);
                Fseries.Points.AddXY(x, y);
                Fseries.Color = Color.Black;
            }

            // Добавление серии данных на график
            chart.Series.Add(Fseries);
            UpdateCoordinateLabel(currentA_X, currentB_X, currentX_0);
        }
        private double CalculateFunctionValue(double x)
        {

            try
            {
                Expression exp = new Expression(functionExpression);
                exp.Parameters["x"] = x;
                double result = Convert.ToDouble(exp.Evaluate());
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                return double.NaN; // В случае ошибки возвращаем NaN
            }
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void stop_button_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Останавливаем таймер
            animationStep = 0;
            currentA_X = a; // Устанавливаем текущую позицию в начало
            currentB_X = b;
            currentX_0 = x_0_Values[0];
            chart.Series.Remove(series_new);

            currentABSeries.Points.Clear();
            currentABSeries.Points.AddXY(currentB_X, CalculateFunctionValue(currentB_X));
            currentABSeries.Points.AddXY(currentB_X, CalculateDerivative(currentB_X));
            currentABSeries.Points.AddXY(currentA_X, CalculateFunctionValue(currentA_X));
            currentABSeries.Points.AddXY(currentA_X, CalculateDerivative(currentA_X));

            currentX0Series.Points.Clear();
            currentX0Series.Points.AddXY(currentX_0, CalculateFunctionValue(currentX_0));
            currentX0Series.Points.AddXY(currentX_0, CalculateDerivative(currentX_0));

            isPaused = false;
            exit_button.Enabled = true;
            UpdateCoordinateLabel(currentA_X, currentB_X, currentX_0);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // Перезапуск таймера
            if (!timer.Enabled)
            {
                timer.Start(); // Запускаем таймер для анимации
                isPaused = false;
            }
            exit_button.Enabled = false;
        }
        private void GraphForm_Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Проверяем, активен ли таймер
            if (timer.Enabled)
            {
                // Если таймер активен, отменяем закрытие формы
                e.Cancel = true;
            }
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            // Получаем координаты курсора относительно области графика
            Point relativeMousePos = chart.PointToClient(MousePosition);

            // Проверяем, что курсор находится в пределах области графика
            if (chart.ChartAreas.Count > 0)
            {
                ChartArea area = chart.ChartAreas[0];
                try
                {
                    double xValue = area.AxisX.PixelPositionToValue(relativeMousePos.X);
                    double yValue = area.AxisY.PixelPositionToValue(relativeMousePos.Y);
                    UpdateCoordinateLabel(xValue, yValue);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
