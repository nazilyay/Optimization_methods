using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;

namespace Optimization_methods
{
    public partial class GraphForm_Bit : Form
    {
        private Chart chart;
        private Panel chartPanel;
        private Point mouseDownPoint;
        private bool isDragging;
        private ChartArea chartArea; // Объявляем chartArea как поле класса
        private Series currentPositionSeries; // Серия для текущей позиции
        private Series minimumSeries; // Серия для точки минимума
        private System.Windows.Forms.Timer timer; // Таймер для анимации
        private double currentX; // Текущее значение X
        private double accuracy; // Размер шага перебора
        private double minX; // X-координата минимума
        private double a;
        private double b;
        private double minResult; // Значение функции в минимуме
        private bool isPaused; // Флаг для паузы
        private string functionExpression; // Поле для хранения выражения функции                              

        private double[] xValues;
        private double[] fxValues;
        private int animationStep = 0; // Переменная для отслеживания текущего шага анимации


        public GraphForm_Bit(string functionExpression, double accuracy, double a, double b, double minX, double minResult)
        {
            InitializeComponent();

            // Инициализация переменных
            currentX = a;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.minX = minX;
            this.minResult = minResult;
            isPaused = false;
            this.functionExpression = functionExpression; // Сохраняем выражение функции

            // Однократное вычисление массивов значений x и f(x)
            (xValues, fxValues) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

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
            DisplayFunctionGraph(functionExpression, accuracy, a, b, minX, minResult);

            // Инициализация таймера для анимации
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 400; // Задаем интервал в 200 миллисекунд

            // Привязываем обработчик события закрытия формы
            this.FormClosing += GraphForm_Search_FormClosing;
            chart.MouseMove += chart_MouseMove;
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop(); // Приостанавливаем таймер
                isPaused = true;

                // Отображаем текущие координаты при нажатии на паузу
                UpdateCoordinateLabel(currentX, CalculateFunctionValue(currentX));
            }
            exit_button_search.Enabled = true;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            currentX = xValues[animationStep]; // Обновляем текущее значение X
            // Проверяем, что текущий шаг анимации находится в пределах массива xValues
            if (animationStep < xValues.Length - 1)
            {
                // Получаем текущее значение x и f(x) из массивов
                double currentX = xValues[animationStep];
                double currentY = fxValues[animationStep];

                // Обновляем координаты точки текущей позиции
                currentPositionSeries.Points.Clear();
                currentPositionSeries.Points.AddXY(currentX, currentY);

                // Если текущая позиция достигла минимума или нажата кнопка паузы, останавливаем анимацию
                if (isPaused)
                {
                    timer.Stop();
                    animationStep = 0;
                    // Отображаем текущие координаты при достижении минимума
                    UpdateCoordinateLabel(currentX, currentY);
                }

                // Увеличиваем шаг анимации для следующего вызова
                animationStep++;
                UpdateCoordinateLabel(currentX, currentY);
            }
            else
            {
                // Если все значения анимации были использованы, останавливаем таймер
                timer.Stop();
                animationStep = 0;
            }
        }

        private (double[], double[]) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            // Начальный шаг
            double h = (b - a) / 4.0;
            // Начальное значение x
            double x = a;
            double prevResult = CalculateFunctionValue(x);

            List<double> xValues = new List<double>(); // Создаем список для хранения значений x
            List<double> fxValues = new List<double>(); // Создаем список для хранения значений f(x)

            // Цикл поиска минимума
            while (true)
            {
                // Вычисление значения функции в следующей точке
                double nextX = x + h;
                double nextResult = CalculateFunctionValue(nextX);
                xValues.Add(nextX); // Добавляем значение x в список
                fxValues.Add(nextResult); // Добавляем значение f(x) в список

                // Сравнение значений функции
                if (prevResult > nextResult)
                {
                    x = nextX;
                    prevResult = nextResult;

                    // Проверка условия a < x < b
                    if (a < x && x < b)
                        continue;
                    else
                    {  // Проверка условия окончания поиска
                        if (Math.Abs(h) <= accuracy)
                            break;
                        // Изменение направления и шага поиска
                        h = -h / 4.0;

                        x = nextX;
                        prevResult = nextResult;
                    }
                }
                else
                {
                    // Проверка условия окончания поиска
                    if (Math.Abs(h) <= accuracy)
                        break;
                    // Изменение направления и шага поиска
                    h = -h / 4.0;

                    x = nextX;
                    prevResult = nextResult;
                }
            }

            // Возвращаем массивы значений x и f(x)
            return (xValues.ToArray(), fxValues.ToArray());
        }

        // Метод для обновления метки с координатами
        private void UpdateCoordinateLabel(double x, double y)
        {
            x_coordinateLabel.Text = $"X: {x}";
            y_coordinateLabel.Text = $"Y: {y}";
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
        
        private void DisplayFunctionGraph(string functionExpression, double accuracy, double a, double b, double minX, double minResult)
        {
            // Создание области для графика
            chartArea = new ChartArea(); // Используем поле класса
            chartArea.AxisX.Minimum = a - 2;
            chartArea.AxisX.Maximum = b + 2;
            chartArea.AxisY.Minimum = Math.Round(minResult - 5); // Начальное значение для оси Y

            double maxY = CalculateMaxY(functionExpression, accuracy, a, b);

            // Установка максимального значения для оси Y
            chartArea.AxisY.Maximum = Math.Round(maxY + 5); // Увеличиваем максимальное значение на 5 для отступа

            // Остальной код остается без изменений
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
            series.LegendText = "Function";

            // Добавление точек на график
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                series.Points.AddXY(x, y);
            }

            double currentY = CalculateFunctionValue(currentX);

            // Добавление серии данных на график
            chart.Series.Add(series);

            // Добавление точки минимума на график
            minimumSeries = new Series();
            minimumSeries.ChartType = SeriesChartType.Point;
            minimumSeries.Points.AddXY(minX, minResult);
            minimumSeries.Color = System.Drawing.Color.Red;
            minimumSeries.MarkerSize = 10;
            minimumSeries.MarkerStyle = MarkerStyle.Circle;
            minimumSeries.LegendText = "Minimum";
            chart.Series.Add(minimumSeries);

            // Инициализация серии для текущей позиции
            currentPositionSeries = new Series();
            currentPositionSeries.ChartType = SeriesChartType.Point;
            currentPositionSeries.Points.AddXY(currentX, currentY); // Начальная позиция - точка минимума
            currentPositionSeries.Color = System.Drawing.Color.Blue;
            currentPositionSeries.MarkerSize = 10;
            currentPositionSeries.MarkerStyle = MarkerStyle.Circle;
            currentPositionSeries.LegendText = "Current Position";
            chart.Series.Add(currentPositionSeries);
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
        private void exit_button_search_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void stop_button_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Останавливаем таймер
            animationStep = 0;
            currentX = a; // Устанавливаем текущую позицию в начало
            currentPositionSeries.Points.Clear();
            currentPositionSeries.Points.AddXY(currentX, CalculateFunctionValue(currentX)); // Обновляем точку текущей позиции
            isPaused = false;
            exit_button_search.Enabled = true;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // Проверяем, достигла ли текущая позиция минимума или анимация была приостановлена
            if (currentX >= minX)
            {
                currentX = a; // Сбрасываем текущую позицию до минимума
            }

            // Перезапуск таймера
            if (!timer.Enabled)
            {
                timer.Start(); // Запускаем таймер для анимации
                isPaused = false;
            }
            exit_button_search.Enabled = false;
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
