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
        private Series currentXSeries, lineSeries, horizontalLineSeries; // Серия для текущей позиции
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

            // Привязываем обработчик события закрытия формы
            this.FormClosing += GraphForm_Search_FormClosing;
            chart.MouseMove += chart_MouseMove;
            UpdateCoordinateLabel(xValues[2]);
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

                    double derivative = CalculateDerivative(currentX);
                    double x1 = currentX - 10; // Левая граница от точки x
                    double y1 = currentY - derivative * 10; // Определяем y на основе производной и расстояния
                    double x2 = currentX + 10; // Правая граница от точки x
                    double y2 = currentY + derivative * 10; // Определяем y на основе производной и расстояния

                    // Добавляем точки для продолжения прямой
                    lineSeries.Points.AddXY(x1, y1);
                    lineSeries.Points.AddXY(x2, y2);

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
            chartArea.AxisX.Minimum = a;
            chartArea.AxisX.Maximum = b;
            chartArea.AxisY.Minimum = Math.Round(minF - 1);
            chartArea.AxisY.Maximum = Math.Round(CalculateMaxY(functionExpression, accuracy, a, b) + 1);

            // Очищаем серии данных
            currentXSeries.Points.Clear();
            lineSeries.Points.Clear();

            // Инициализация x
            double currentX = xValues[2];
            double currentY = CalculateFunctionValue(currentX);

            double derivative = CalculateDerivative(currentX);
            double x1 = currentX - 10;
            double y1 = currentY - derivative * 10;
            double x2 = currentX + 10;
            double y2 = currentY + derivative * 10;
            currentXSeries.Points.AddXY(currentX, currentY);
            lineSeries.Points.AddXY(x1, y1);
            lineSeries.Points.AddXY(x2, y2);

            animationStep = 3;
            isPaused = false;

            UpdateCoordinateLabel(currentY);
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
            // Создание области для графика
            chartArea = new ChartArea(); // Используем поле класса
            chartArea.AxisX.Minimum = a;
            chartArea.AxisX.Maximum = b;
            chartArea.AxisY.Minimum = Math.Round(minResult - 1); // Начальное значение для оси Y

            double maxY = CalculateMaxY(functionExpression, accuracy, a, b);

            // Установка максимального значения для оси Y
            chartArea.AxisY.Maximum = Math.Round(maxY + 1);

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
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                series.Points.AddXY(x, y);
            }

            // Добавление серии данных на график
            chart.Series.Add(series);

            // Инициализация x
            double currentX = xValues[2];
            double currentY = CalculateFunctionValue(currentX);

            currentXSeries = new Series();
            currentXSeries.ChartType = SeriesChartType.Point;
            currentXSeries.Points.AddXY(currentX, currentY); // Начальная позиция - точка минимума
            currentXSeries.Color = System.Drawing.Color.Black;
            currentXSeries.MarkerSize = 5;
            currentXSeries.MarkerStyle = MarkerStyle.Circle;
            currentXSeries.LegendText = "x";
            chart.Series.Add(currentXSeries);

            // Добавление продолжения прямой за текущей и следующей точками
            double derivative = CalculateDerivative(currentX);
            double x1 = currentX - 10; // Левая граница от точки x
            double y1 = currentY - derivative * 10; // Определяем y на основе производной и расстояния
            double x2 = currentX + 10; // Правая граница от точки x
            double y2 = currentY + derivative * 10; // Определяем y на основе производной и расстояния


            lineSeries = new Series();
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.BorderWidth = 1;
            lineSeries.Color = Color.Red; // Цвет прямой
            lineSeries.Points.AddXY(x1, y1);
            lineSeries.Points.AddXY(x2, y2);
            chart.Series.Add(lineSeries); // Добавляем прямую на график

            // Создание серии данных для горизонтальной линии y=0
            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Black; // Цвет линии можно выбрать по вашему усмотрению

            // Добавление точек на график, чтобы создать линию y=0
            for (double x = chartArea.AxisX.Minimum; x <= chartArea.AxisX.Maximum + 5; x += accuracy)
            {
                double y = 0; // y=0
                horizontalLineSeries.Points.AddXY(x, y);
            }

            // Добавление серии данных на график
            chart.Series.Add(horizontalLineSeries);

            UpdateCoordinateLabel(currentX);
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

    }
}
