using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;

namespace Optimization_methods
{
    public partial class GraphForm_Search : Form
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
        private double stepSize; // Размер шага перебора
        private double minX; // X-координата минимума
        private double a;
        private double minResult; // Значение функции в минимуме
        private bool isPaused; // Флаг для паузы
        private string functionExpression; // Поле для хранения выражения функции                              


        public GraphForm_Search(string functionExpression, double accuracy, double a, double b, double minX, double minResult)
        {
            InitializeComponent();

            // Инициализация переменных
            currentX = a;
            this.a = a;

            stepSize = accuracy;
            this.minX = minX;
            this.minResult = minResult;
            isPaused = false;
            this.functionExpression = functionExpression; // Сохраняем выражение функции

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
            timer.Interval = 100; // Интервал таймера в миллисекундах
            timer.Tick += Timer_Tick;

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
                UpdateCoordinateLabel(currentX, CalculateYValue(currentX));
            }
            exit_button_search.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Перемещаем текущую позицию на шаг вперед
            currentX += stepSize;

            // Обновляем координаты точки текущей позиции
            double y = CalculateYValue(currentX); // Вычисляем значение Y для текущей позиции
            currentPositionSeries.Points.Clear();
            currentPositionSeries.Points.AddXY(currentX, y);

            // Если текущая позиция достигла минимума или нажата кнопка паузы, останавливаем анимацию
            if (currentX >= minX || isPaused)
            {
                timer.Stop();

                // Отображаем текущие координаты при достижении минимума
                UpdateCoordinateLabel(currentX, y);
            }
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
                Expression exp = new Expression(functionExpression);
                exp.Parameters["x"] = x;
                double y = Convert.ToDouble(exp.Evaluate());
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
                Expression exp = new Expression(functionExpression);
                exp.Parameters["x"] = x;
                double y = Convert.ToDouble(exp.Evaluate());
                series.Points.AddXY(x, y);
            }

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
            currentPositionSeries.Points.AddXY(currentX, minResult); // Начальная позиция - точка минимума
            currentPositionSeries.Color = System.Drawing.Color.Blue;
            currentPositionSeries.MarkerSize = 10;
            currentPositionSeries.MarkerStyle = MarkerStyle.Circle;
            currentPositionSeries.LegendText = "Current Position";
            chart.Series.Add(currentPositionSeries);
        }

        private void exit_button_search_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void stop_button_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Останавливаем таймер
            currentX = minX; // Сбрасываем текущую позицию до минимума
            currentPositionSeries.Points.Clear();
            currentPositionSeries.Points.AddXY(currentX, minResult);
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

        private double CalculateYValue(double x)
        {
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = x;
            return Convert.ToDouble(exp.Evaluate());
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
