﻿using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;
namespace Optimization_methods.Middle_Methods
{
    public partial class GraphForm_Middle : Form
    {
        private Chart chart;
        private Panel chartPanel;
        private ChartArea chartArea;
        private TableLayoutPanel tableLayoutPanel;
        private Series currentABSeries, currentXSeries, series_new; // Серия для текущей позиции
        private System.Windows.Forms.Timer timer; // Таймер для анимации
        private double a, b, accuracy, minX, minF, currentA_X, currentB_X, currentX;
        private bool isPaused; // Флаг для паузы
        private string functionExpression; // Поле для хранения выражения функции                              

        private double[] aValues;
        private double[] bValues;
        private double[] xValues;
        private int animationStep = 0; // Переменная для отслеживания текущего шага анимации


        public GraphForm_Middle(string functionExpression, double accuracy, double a, double b)
        {
            InitializeComponent();
            // Инициализация переменных
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.functionExpression = functionExpression; // Сохраняем выражение функции

            // Однократное вычисление массивов значений x и f(x)
            (aValues, bValues, xValues, minX, minF) = CalculateFunctionOnInterval(a, b, accuracy);

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
            timer.Interval = 400; // Задаем интервал в 200 миллисекунд

            // Привязываем обработчик события закрытия формы
            this.FormClosing += GraphForm_Search_FormClosing;
            chart.MouseMove += chart_MouseMove;
            ab_coordinateLabel.Text = "";
            x_label.Text = "";
            y_label.Text = "";
            def_label.Text = "";
        }

        private (double[] aValues, double[] bValues, double[] xValues, double minX, double minF) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> xValues = new List<double>();
            double x_k = (a + b) / 2;
            double epsilon = (b - a) / 2; // Начальная половина длины интервала

            while (epsilon > accuracy)
            {
                aValues.Add(a);
                bValues.Add(b);
                xValues.Add(x_k);

                double f_x_k = CalculateDerivative(x_k);

                if (f_x_k > 0)
                    b = x_k;
                else
                    a = x_k;

                x_k = (a + b) / 2;
                epsilon = (b - a) / 2; // Новая половина длины интервала
            }
            aValues.Add(a);
            bValues.Add(b);
            xValues.Add(x_k);
            double minF = CalculateFunctionValue(x_k);
            double minX = x_k;
            return (aValues.ToArray(), bValues.ToArray(), xValues.ToArray(), minX, minF);
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
                return double.NaN;
            }
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

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop(); // Приостанавливаем таймер
                isPaused = true;

                // Отображаем текущие координаты при нажатии на паузу
                UpdateCoordinateLabel(currentA_X, currentB_X, currentX);
            }
            exit_button.Enabled = true;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Проверяем, что текущий шаг анимации находится в пределах массива 
            if (animationStep < aValues.Length)
            {
                // Получаем текущее значение x и f(x) из массивов
                currentA_X = aValues[animationStep];
                currentB_X = bValues[animationStep];
                currentX = xValues[animationStep];
                double currentA_Y = CalculateFunctionValue(currentA_X);
                double currentB_Y = CalculateFunctionValue(currentB_X);
                double currentY = CalculateFunctionValue(currentX);
                double currentF = CalculateDerivative(currentX);

                // Обновляем координаты точки текущей позиции
                currentABSeries.Points.Clear();
                currentABSeries.Points.AddXY(currentA_X, currentA_Y);
                currentABSeries.Points.AddXY(currentB_X, currentB_Y);

                currentXSeries.Points.Clear();
                currentXSeries.Points.AddXY(currentX, currentY);
                currentXSeries.Points.AddXY(currentX, currentF);

                chart.Series.Remove(series_new);

                series_new = new Series();
                series_new.ChartType = SeriesChartType.Line;
                series_new.BorderWidth = 2;
                series_new.Color = System.Drawing.Color.Red;

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
                    UpdateCoordinateLabel(currentA_X, currentB_X, currentX);
                }

                // Увеличиваем шаг анимации для следующего вызова
                animationStep++;
                UpdateCoordinateLabel(currentA_X, currentB_X, currentX);
            }
            else
            {
                // Если все значения анимации были использованы, останавливаем таймер
                timer.Stop();
                animationStep = 0;
            }
        }


        // Метод для обновления метки с координатами
        private void UpdateCoordinateLabel(double a, double b, double x)
        {
            ab_coordinateLabel.Text = $"Интервал: ({Math.Round(a, 4)}; {Math.Round(b, 4)})";
            x_label.Text = $"X: {Math.Round(x, 4)}";
            y_label.Text = $"F(X): {Math.Round(CalculateFunctionValue(x), 4)}";
            def_label.Text = $"F'(X): {Math.Round(CalculateDerivative(x), 4)}";
        }

        private void UpdateCoordinateLabel(double x, double y)
        {
            ab_coordinateLabel.Text = $"X: {Math.Round(x, 4)}";
            x_label.Text = $"Y: {Math.Round(CalculateFunctionValue(x), 4)}";
            y_label.Text = $"";
            def_label.Text = $"";
        }

        void AddLineAndLabel(Color color, string labelText, int lineHeight, int topMargin, int bottomMargin, TableLayoutPanel panel, int columnIndex)
        {
            Panel linePanel = new Panel
            {
                BackColor = color,
                Height = lineHeight,
                Margin = new Padding(0, topMargin, 0, bottomMargin)
            };
            panel.Controls.Add(linePanel, columnIndex * 2 + 1, 0);

            Label label = new Label
            {
                Text = labelText,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None
            };
            panel.Controls.Add(label, columnIndex * 2, 0); 
        }


        private void DisplayFunctionGraph(double accuracy, double a, double b, double minX, double minResult)
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 2; // Добавляем 2 столбца
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); 
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tableLayoutPanel);

            // Добавляем текст и линии в соответствующие столбцы
            AddLineAndLabel(Color.Blue, "y = f(x)", 2, 15, 10, tableLayoutPanel, 0);
            AddLineAndLabel(Color.Black, "y = f'(x)", 1, 15, 10, tableLayoutPanel, 1);
            double minY = double.MaxValue;
            double maxY = double.MinValue;

            // Создание серии данных для графика функции
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;

            // Создание серии данных для производной функции
            Series Fseries = new Series();
            Fseries.ChartType = SeriesChartType.Line;
            Fseries.BorderWidth = 1;
            Fseries.Color = Color.Black;

            // Создание серии данных для горизонтальной линии y=0
            Series horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Red;

            // Добавление точек на график
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                double def = CalculateDerivative(x);
                series.Points.AddXY(x, y);
                Fseries.Points.AddXY(x, def);
                horizontalLineSeries.Points.AddXY(x, 0);
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
            }

            // Создание области для графика
            chartArea = new ChartArea(); // Используем поле класса
            chartArea.AxisX.Minimum = a - 2;
            chartArea.AxisX.Maximum = b + 2;
            chartArea.AxisY.Minimum = Math.Round(minY - 5); 
            chartArea.AxisY.Maximum = Math.Round(maxY + 5);

            chartArea.AxisX.LineColor = Color.Black;
            chartArea.AxisY.LineColor = Color.Black;

            // Добавление области на график
            chart.ChartAreas.Add(chartArea);

            // Подписываем ось X
            chartArea.AxisX.Title = "X";
            // Подписываем ось Y
            chartArea.AxisY.Title = "Y";

            // Добавление серии данных на график
            chart.Series.Add(series);

            // Добавление серии данных на график
            chart.Series.Add(horizontalLineSeries);

            // Добавление серии данных на график
            chart.Series.Add(Fseries);

            double currentA_X = aValues[animationStep];
            double currentA_Y = CalculateFunctionValue(currentA_X);

            double currentB_X = bValues[animationStep];
            double currentB_Y = CalculateFunctionValue(currentB_X);

            // Инициализация a b
            currentABSeries = new Series();
            currentABSeries.ChartType = SeriesChartType.Point;
            currentABSeries.Points.AddXY(currentA_X, currentA_Y); // Начальная позиция - точка минимума
            currentABSeries.Points.AddXY(currentB_X, currentB_Y); // Начальная позиция - точка минимума
            currentABSeries.Color = Color.Blue;
            currentABSeries.MarkerSize = 5;
            currentABSeries.MarkerStyle = MarkerStyle.Circle;
            chart.Series.Add(currentABSeries);

            // Инициализация x
            double currentX = xValues[animationStep];
            double currentY = CalculateFunctionValue(currentX);
            double currentF = CalculateDerivative(currentX);

            currentXSeries = new Series();
            currentXSeries.ChartType = SeriesChartType.Point;
            currentXSeries.Points.AddXY(currentX, currentY); 
            currentXSeries.Points.AddXY(currentX, currentF); 

            currentXSeries.Color = System.Drawing.Color.Black;
            currentXSeries.MarkerSize = 5;
            currentXSeries.MarkerStyle = MarkerStyle.Circle;
            chart.Series.Add(currentXSeries);
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Останавливаем таймер
            animationStep = 0;
            currentA_X = a; // Устанавливаем текущую позицию в начало
            currentB_X = b;
            currentX = xValues[0];

            currentABSeries.Points.Clear();
            currentABSeries.Points.AddXY(currentA_X, CalculateFunctionValue(currentA_X)); // Обновляем точку текущей позиции
            currentABSeries.Points.AddXY(currentB_X, CalculateFunctionValue(currentB_X)); // Обновляем точку текущей позиции

            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, CalculateFunctionValue(currentX)); // Обновляем точку текущей позиции
            currentXSeries.Points.AddXY(currentX, CalculateDerivative(currentX)); // Обновляем точку текущей позиции

            chart.Series.Remove(series_new);

            isPaused = false;
            exit_button.Enabled = true;
            UpdateCoordinateLabel(currentA_X, currentB_X, currentX);
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

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }
    }
}
