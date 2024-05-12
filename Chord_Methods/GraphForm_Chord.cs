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

namespace Optimization_methods.Chord_Methods
{
    public partial class GraphForm_Chord : Form
    {
        private Chart chart;
        private Panel chartPanel;
        private ChartArea chartArea;
        private Series currentXSeries, lineSeries, horizontalLineSeries, punct; // Серия для текущей позиции
        private System.Windows.Forms.Timer timer; // Таймер для анимации
        private double a, b, accuracy, minX, minF, currentX, x_0, extensionLength;
        private bool isPaused; // Флаг для паузы
        private string functionExpression; // Поле для хранения выражения функции                              
        private double[] xValues;
        private int animationStep = 2; // Переменная для отслеживания текущего шага анимации


        public GraphForm_Chord(string functionExpression, double accuracy, double a, double b)
        {
            InitializeComponent();
            // Инициализация переменных
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.functionExpression = functionExpression; // Сохраняем выражение функции
            this.x_0 = x_0;

            // Однократное вычисление массивов значений x и f(x)
            (xValues, minX, minF) = CalculateFunctionOnInterval(a, b, accuracy);
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

            chart.MouseWheel += Chart_MouseWheel;

            // Привязываем обработчик события закрытия формы
            this.FormClosing += GraphForm_Search_FormClosing;
            chart.MouseMove += chart_MouseMove;
            UpdateCoordinateLabel(xValues[2]);
        }

        private void Chart_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0)
                {
                    double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;

                    double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart - 1, posXFinish + 1);
                    chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart - 1, posYFinish + 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while zooming: " + ex.Message);
            }
        }
        private (double[] xValues, double minX, double minF) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> xValues = new List<double>();
            double x_prev = a;
            double x_curr = b;
            double epsilon = Math.Abs(x_curr - x_prev);
            double x_new = x_curr;
            xValues.Add(x_prev);
            xValues.Add(x_curr);
            while (epsilon > accuracy)
            {
                x_new = x_prev - (CalculateDerivative(x_prev) * (x_curr - x_prev)) / (CalculateDerivative(x_curr) - CalculateDerivative(x_prev));
                epsilon = Math.Abs(x_curr - x_prev);
                x_prev = x_curr;
                x_curr = x_new;
                xValues.Add(x_new);
            }
            double minResult = CalculateFunctionValue(x_new);
            return (xValues.ToArray(), x_new, minResult);
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

        private double CalculateFunctionValue(double x)
        {
            try
            {
                Expression e = new Expression(functionExpression);
                e.Parameters["x"] = x;
                object result = e.Evaluate();
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                return double.NaN; // В случае ошибки возвращаем NaN
            }
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop(); // Приостанавливаем таймер
                isPaused = true;

                // Отображаем текущие координаты при нажатии на паузу
                UpdateCoordinateLabel(this.currentX);
            }
            exit_button.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Проверяем, что текущий шаг анимации находится в пределах массива 
            if (animationStep < xValues.Length)
            {
                // Получаем текущее значение x и f(x) из массивов
                double currentX = xValues[animationStep];
                double currentY = CalculateFunctionValue(currentX);
                this.currentX = currentX; // Сохраняем текущее значение x
                currentY = CalculateFunctionValue(currentX);

                // Определение новых границ осей
                double minX = currentX;
                double minY = currentY;

                // Установка новых границ осей
                chartArea.AxisX.Minimum = Math.Round(minX) - 1; // Примерное новое минимальное значение по X
                chartArea.AxisX.Maximum = Math.Round(minX) + 1; // Примерное новое максимальное значение по X
                chartArea.AxisY.Minimum = Math.Round(minY) - 1; // Примерное новое минимальное значение по Y
                chartArea.AxisY.Maximum = Math.Round(minY) + 1; // Примерное новое максимальное значение по Y

                // Если нажата кнопка паузы, останавливаем анимацию
                if (isPaused)
                {
                    timer.Stop();
                    animationStep = 2;
                    // Отображаем текущие координаты при достижении минимума
                    UpdateCoordinateLabel(currentX);
                }
                else
                {

                    // Обновляем координаты точки текущей позиции
                    currentXSeries.Points.Clear();
                    currentXSeries.Points.AddXY(currentX, currentY);
                    if (animationStep % 2 == 1) currentXSeries.Color = System.Drawing.Color.Blue;
                    else currentXSeries.Color = System.Drawing.Color.Black;

                    // Очищаем точки серии данных прямой
                    lineSeries.Points.Clear();
                    punct.Points.Clear();

                    lineSeries.Points.AddXY(xValues[animationStep - 2], CalculateDerivative(xValues[animationStep - 2]));
                    lineSeries.Points.AddXY(xValues[animationStep - 1], CalculateDerivative(xValues[animationStep - 1]));
                    lineSeries.Points.AddXY(xValues[animationStep], 0);

                    punct.Points.AddXY(xValues[animationStep], CalculateFunctionValue(xValues[animationStep]));
                    punct.Points.AddXY(xValues[animationStep], 0);
                    // Увеличиваем шаг анимации для следующего вызова
                    animationStep++;

                    // Обновляем координаты на метке
                    UpdateCoordinateLabel(currentX);
                }
            }
            else
            {
                // Если все значения анимации были использованы, останавливаем таймер
                timer.Stop();
                animationStep = 2;
            }
        }

        private void UpdateCoordinateLabel(double x)
        {
            UpdateCoordinateLabel(x, CalculateFunctionValue(x));
        }

        private void UpdateCoordinateLabel(double x, double y)
        {
            x_label.Text = $"X: {Math.Round(x, 4)}";
            y_label.Text = $"Y: {Math.Round(y, 4)}";
        }

        private void ResetChart()
        {
            // Возвращаемся к первоначальным значениям графика
            chartArea.AxisX.Minimum = a - 1;
            chartArea.AxisX.Maximum = b + 1;
            chartArea.AxisY.Minimum = Math.Round(minF) - 1;
            chartArea.AxisY.Maximum = Math.Round(CalculateMaxY(functionExpression, accuracy, a, b)) + 1;

            // Очищаем серии данных
            currentXSeries.Points.Clear();
            lineSeries.Points.Clear();
            punct.Points.Clear();

            // Инициализация x
            currentX = xValues[2];
            double currentY = CalculateFunctionValue(currentX);

            currentXSeries.Points.AddXY(currentX, currentY);
            currentXSeries.Points.AddXY(currentX, 0);
            lineSeries.Points.AddXY(xValues[0], CalculateDerivative(xValues[0]));
            lineSeries.Points.AddXY(xValues[1], CalculateDerivative(xValues[1]));
            lineSeries.Points.AddXY(xValues[animationStep], 0);

            punct.Points.AddXY(xValues[2], CalculateFunctionValue(xValues[2]));
            punct.Points.AddXY(xValues[2], 0);

            animationStep = 3;
            isPaused = false;

            UpdateCoordinateLabel(currentX);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            StopAnimation();
        }

        private void StartAnimation()
        {
            if (!timer.Enabled)
            {
                timer.Start();
                isPaused = false;
                exit_button.Enabled = false;
            }
        }

        private void StopAnimation()
        {
            timer.Stop();
            ResetChart();
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
        private void DisplayFunctionGraph(double accuracy, double a, double b, double minX, double minResult)
        {
            chartArea = new ChartArea();
            chartArea.AxisX.Minimum = a - 1;
            chartArea.AxisX.Maximum = b + 1;
            chartArea.AxisY.Minimum = Math.Round(minResult - 1) - 1;
            chartArea.AxisY.Maximum = Math.Round(CalculateMaxY(functionExpression, accuracy, a, b) + 1) + 1;
            chartArea.AxisX.LineColor = Color.Black;
            chartArea.AxisY.LineColor = Color.Black;
            chart.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "Y";

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            for (double x = a; x <= b; x += accuracy)
                series.Points.AddXY(x, CalculateFunctionValue(x));
            chart.Series.Add(series);

            lineSeries = new Series();
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.BorderWidth = 1;
            lineSeries.Color = Color.Red;
            lineSeries.Points.AddXY(xValues[0], CalculateDerivative(xValues[0]));
            lineSeries.Points.AddXY(xValues[1], CalculateDerivative(xValues[1]));
            chart.Series.Add(lineSeries);

            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Black;
            for (double x = chartArea.AxisX.Minimum; x <= chartArea.AxisX.Maximum + 5; x += accuracy)
                horizontalLineSeries.Points.AddXY(x, 0);
            chart.Series.Add(horizontalLineSeries);

            currentXSeries = new Series();
            currentXSeries.ChartType = SeriesChartType.Point;
            currentXSeries.Points.AddXY(xValues[2], CalculateFunctionValue(xValues[2]));
            currentXSeries.Points.AddXY(xValues[2], 0);
            currentXSeries.Color = Color.Black;
            currentXSeries.MarkerSize = 5;
            currentXSeries.MarkerStyle = MarkerStyle.Circle;
            currentXSeries.LegendText = "x";
            chart.Series.Add(currentXSeries);

            UpdateCoordinateLabel(xValues[2]);

            punct = new Series();
            punct.ChartType = SeriesChartType.Line;
            punct.BorderWidth = 1;
            punct.Color = Color.Red;
            punct.BorderDashStyle = ChartDashStyle.Dot;
            punct.Points.AddXY(xValues[2], CalculateFunctionValue(xValues[2]));
            punct.Points.AddXY(xValues[2], 0);
            chart.Series.Add(punct);
            animationStep = 3;
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
