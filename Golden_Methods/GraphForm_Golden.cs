using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;
namespace Optimization_methods.Golden_Methods
{
    public partial class GraphForm_Golden : Form
    {
        private Chart chart;
        private Panel chartPanel;
        private Point mouseDownPoint;
        private ChartArea chartArea;
        private Series currentASeries, currentBSeries, currentX1Series, currentX2Series, series_new; // Серия для текущей позиции
        private System.Windows.Forms.Timer timer; // Таймер для анимации
        private double a, b, accuracy, minX, minF, currentA_X, currentB_X, currentX_1, currentX_2;
        private bool isPaused; // Флаг для паузы
        private string functionExpression; // Поле для хранения выражения функции                              

        private double[] aValues;
        private double[] bValues;
        private double[] x_1_Values;
        private double[] x_2_Values;
        private int animationStep = 0; // Переменная для отслеживания текущего шага анимации


        public GraphForm_Golden(string functionExpression, double accuracy, double a, double b)
        {
            InitializeComponent();
            // Инициализация переменных
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.functionExpression = functionExpression; // Сохраняем выражение функции

            // Однократное вычисление массивов значений x и f(x)
            (aValues, bValues, x_1_Values, x_2_Values, minX, minF) = CalculateFunctionOnInterval(a, b, accuracy);
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
        }
        private (double[] aValues, double[] bValues, double[] x_1Values, double[] x_2Values, double minX, double minResult) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> x_1Values = new List<double>();
            List<double> x_2Values = new List<double>();

            double tau = (Math.Sqrt(5) - 1) / 2; // Golden ratio

            double x1 = a + (3 - Math.Sqrt(5)) / 2 * (b - a);
            double x2 = a + tau * (b - a);

            double f1 = CalculateFunctionValue(x1);
            double f2 = CalculateFunctionValue(x2);

            double epsilon = (b - a) / 2;

            while (epsilon > accuracy)
            {
                aValues.Add(a);
                bValues.Add(b);
                x_1Values.Add(x1);
                x_2Values.Add(x2);

                // Сравнение значений функции для определения нового отрезка
                if (f1 <= f2)
                {
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = b + a - x2;
                    f1 = CalculateFunctionValue(x1);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    x2 = b + a - x1;
                    f2 = CalculateFunctionValue(x2);
                }
                epsilon = tau * epsilon;
            }

            double minX = (a + b) / 2;
            double minResult = CalculateFunctionValue(minX);

            return (aValues.ToArray(), bValues.ToArray(), x_1Values.ToArray(), x_2Values.ToArray(), minX, minResult);
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop(); // Приостанавливаем таймер
                isPaused = true;

                // Отображаем текущие координаты при нажатии на паузу
                UpdateCoordinateLabel(currentA_X, currentB_X, currentX_1, currentX_2);
            }
            exit_button.Enabled = true;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Проверяем, что текущий шаг анимации находится в пределах массива 
            if (animationStep < aValues.Length - 1)
            {
                // Получаем текущее значение x и f(x) из массивов
                currentA_X = aValues[animationStep];
                currentB_X = bValues[animationStep];
                currentX_1 = x_1_Values[animationStep];
                currentX_2 = x_2_Values[animationStep];
                double currentA_Y = CalculateFunctionValue(currentA_X);
                double currentB_Y = CalculateFunctionValue(currentB_X);
                double currentY_1 = CalculateFunctionValue(currentX_1);
                double currentY_2 = CalculateFunctionValue(currentX_2);

                // Обновляем координаты точки текущей позиции
                currentASeries.Points.Clear();
                currentASeries.Points.AddXY(currentA_X, currentA_Y);

                currentBSeries.Points.Clear();
                currentBSeries.Points.AddXY(currentB_X, currentB_Y);

                currentX1Series.Points.Clear();
                currentX1Series.Points.AddXY(currentX_1, currentY_1);

                currentX2Series.Points.Clear();
                currentX2Series.Points.AddXY(currentX_2, currentY_2);

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
                    UpdateCoordinateLabel(currentA_X, currentB_X, currentX_1, currentX_2);
                }

                // Увеличиваем шаг анимации для следующего вызова
                animationStep++;
                UpdateCoordinateLabel(currentA_X, currentB_X, currentX_1, currentX_2);
            }
            else
            {
                // Если все значения анимации были использованы, останавливаем таймер
                timer.Stop();
                animationStep = 0;
            }
        }


        // Метод для обновления метки с координатами
        private void UpdateCoordinateLabel(double a, double b, double x1, double x2)
        {
            ab_coordinateLabel.Text = $"Интервал: ({Math.Round(a, 4)}; {Math.Round(b, 4)})";
            x_1_label.Text = $"x1: ({Math.Round(x1, 4)}, {Math.Round(CalculateFunctionValue(x1), 4)})";
            x_2_label.Text = $"x2: ({Math.Round(x2, 4)}, {Math.Round(CalculateFunctionValue(x2), 4)})";
        }

        private void UpdateCoordinateLabel(double x, double y)
        {
            ab_coordinateLabel.Text = $"X: {Math.Round(x, 4)}";
            x_1_label.Text = $"Y: {Math.Round(y, 4)}";
            x_2_label.Text = $"";
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
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                series.Points.AddXY(x, y);
            }

            // Добавление серии данных на график
            chart.Series.Add(series);

            double currentA_X = aValues[animationStep];
            double currentA_Y = CalculateFunctionValue(currentA_X);

            // Инициализация a b
            currentASeries = new Series();
            currentASeries.ChartType = SeriesChartType.Point;
            currentASeries.Points.AddXY(currentA_X, currentA_Y); // Начальная позиция - точка минимума
            currentASeries.Color = System.Drawing.Color.Blue;
            currentASeries.MarkerSize = 5;
            currentASeries.MarkerStyle = MarkerStyle.Circle;
            currentASeries.LegendText = "a";
            chart.Series.Add(currentASeries);

            double currentB_X = bValues[animationStep];
            double currentB_Y = CalculateFunctionValue(currentB_X);

            currentBSeries = new Series();
            currentBSeries.ChartType = SeriesChartType.Point;
            currentBSeries.Points.AddXY(currentB_X, currentB_Y); // Начальная позиция - точка минимума
            currentBSeries.Color = System.Drawing.Color.Blue;
            currentBSeries.MarkerSize = 5;
            currentBSeries.MarkerStyle = MarkerStyle.Circle;
            currentBSeries.LegendText = "b";
            chart.Series.Add(currentBSeries);

            // Инициализация x_1, x_2
            double currentX_1 = x_1_Values[animationStep];
            double currentY_1 = CalculateFunctionValue(currentX_1);

            currentX1Series = new Series();
            currentX1Series.ChartType = SeriesChartType.Point;
            currentX1Series.Points.AddXY(currentX_1, currentY_1); // Начальная позиция - точка минимума
            currentX1Series.Color = System.Drawing.Color.Black;
            currentX1Series.MarkerSize = 5;
            currentX1Series.MarkerStyle = MarkerStyle.Circle;
            currentX1Series.LegendText = "x_1";
            chart.Series.Add(currentX1Series);

            double currentX_2 = x_2_Values[animationStep];
            double currentY_2 = CalculateFunctionValue(currentX_2);

            currentX2Series = new Series();
            currentX2Series.ChartType = SeriesChartType.Point;
            currentX2Series.Points.AddXY(currentX_2, currentY_2); // Начальная позиция - точка минимума
            currentX2Series.Color = System.Drawing.Color.Black;
            currentX2Series.MarkerSize = 5;
            currentX2Series.MarkerStyle = MarkerStyle.Circle;
            currentX2Series.LegendText = "x_2";
            chart.Series.Add(currentX2Series);

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

        private void stop_button_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Останавливаем таймер
            animationStep = 0;
            currentA_X = a; // Устанавливаем текущую позицию в начало
            currentB_X = b;
            currentX_1 = x_1_Values[0];
            currentX_2 = x_2_Values[0];

            currentASeries.Points.Clear();
            currentASeries.Points.AddXY(currentA_X, CalculateFunctionValue(currentA_X)); // Обновляем точку текущей позиции

            currentBSeries.Points.Clear();
            currentBSeries.Points.AddXY(currentB_X, CalculateFunctionValue(currentB_X)); // Обновляем точку текущей позиции

            currentX1Series.Points.Clear();
            currentX1Series.Points.AddXY(currentX_1, CalculateFunctionValue(currentX_1)); // Обновляем точку текущей позиции

            currentX2Series.Points.Clear();
            currentX2Series.Points.AddXY(currentX_2, CalculateFunctionValue(currentX_2)); // Обновляем точку текущей позиции

            chart.Series.Remove(series_new);

            isPaused = false;
            exit_button.Enabled = true;
            UpdateCoordinateLabel(currentA_X, currentB_X, currentX_1, currentX_2);
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
