using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;

namespace Optimization_methods.Golden_Methods
{
    public partial class VisualizationForm : Form
    {
        private Chart chart;
        private double a, b, accuracy;
        private string functionExpression;
        private Series currentASeries, currentBSeries, currentX1Series, currentX2Series, series_new; // Серия для текущей позиции
        private double[] x_1_Values, x_2_Values, aValues, bValues, EpsValue;
        private double currentX_1, currentX_2, currentA_X, currentB_X;
        private double currentY_1, currentY_2, currentA_Y, currentB_Y, currentEps;
        private int iterationNumber;

        public VisualizationForm(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            // Инициализация массивов значений
            InitializeArrays();

            // Отображение функции на графике
            DisplayFunctionGraph();

            // Обновление меток
            UpdateLabels();

            // Заблокировать кнопки
            Stop_label.Visible = false;
            next_step_button.Enabled = false;
            yes_2_button.Enabled = false;
            no_2_button.Enabled = false;
            new_ab_label.Visible = false;
            new_x_1_label.Visible = false;
            new_f_1_label.Visible = false;
            new_x_2_label.Visible = false;
            new_f_2_label.Visible = false;
            new_epsilon_label.Visible = false;
        }

        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (aValues, bValues, x_1_Values, x_2_Values, EpsValue) = CalculateFunctionOnInterval(a, b, accuracy);

            // Инициализируем текущие значения как начальные значения из массива
            currentX_1 = a + (3 - Math.Sqrt(5)) / 2 * (b - a);
            currentX_2 = a + (Math.Sqrt(5) - 1) / 2 * (b - a);
            currentA_X = a;
            currentB_X = b;
            currentEps = (b - a) / 2;
            currentY_1 = CalculateFunctionValue(currentX_1);
            currentY_2 = CalculateFunctionValue(currentX_2);
            currentA_Y = CalculateFunctionValue(currentA_X);
            currentB_Y = CalculateFunctionValue(currentB_X);

            iterationNumber = 0;
        }

        private void DisplayFunctionGraph()
        {
            // Создание графика
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            panel_graph.Controls.Add(chart);

            // Создание области для графика
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Minimum = a - 2;
            chartArea.AxisX.Maximum = b + 2;

            // Вычисление максимального и минимального значения Y
            double minY = double.MaxValue; // Очень большое число
            double maxY = double.MinValue; // Очень маленькое число

            // Вычисление максимального и минимального значения Y на интервале [a, b]
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
            }
            chartArea.AxisY.Minimum = Math.Round(minY - 5);
            chartArea.AxisY.Maximum = Math.Round(maxY + 5);

            // Подписываем ось X
            chartArea.AxisX.Title = "X";
            // Подписываем ось Y
            chartArea.AxisY.Title = "Y";

            // Добавление области на график
            chart.ChartAreas.Add(chartArea);

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

            currentA_X = aValues[iterationNumber];
            currentA_Y = CalculateFunctionValue(currentA_X);

            // Инициализация a b
            currentASeries = new Series();
            currentASeries.ChartType = SeriesChartType.Point;
            currentASeries.Points.AddXY(currentA_X, currentA_Y);
            currentASeries.Color = System.Drawing.Color.Blue;
            currentASeries.MarkerSize = 5;
            currentASeries.MarkerStyle = MarkerStyle.Circle;
            currentASeries.LegendText = "a";
            chart.Series.Add(currentASeries);

            currentB_X = bValues[iterationNumber];
            currentB_Y = CalculateFunctionValue(currentB_X);

            currentBSeries = new Series();
            currentBSeries.ChartType = SeriesChartType.Point;
            currentBSeries.Points.AddXY(currentB_X, currentB_Y);
            currentBSeries.Color = System.Drawing.Color.Blue;
            currentBSeries.MarkerSize = 5;
            currentBSeries.MarkerStyle = MarkerStyle.Circle;
            currentBSeries.LegendText = "b";
            chart.Series.Add(currentBSeries);

            // Инициализация x_1, x_2
            currentX_1 = x_1_Values[iterationNumber];
            currentY_1 = CalculateFunctionValue(currentX_1);

            currentX1Series = new Series();
            currentX1Series.ChartType = SeriesChartType.Point;
            currentX1Series.Points.AddXY(currentX_1, currentY_1);
            currentX1Series.Color = System.Drawing.Color.Black;
            currentX1Series.MarkerSize = 5;
            currentX1Series.MarkerStyle = MarkerStyle.Circle;
            currentX1Series.LegendText = "x_1";
            chart.Series.Add(currentX1Series);

            currentX_2 = x_2_Values[iterationNumber];
            currentY_2 = CalculateFunctionValue(currentX_2);

            currentX2Series = new Series();
            currentX2Series.ChartType = SeriesChartType.Point;
            currentX2Series.Points.AddXY(currentX_2, currentY_2);
            currentX2Series.Color = System.Drawing.Color.Black;
            currentX2Series.MarkerSize = 5;
            currentX2Series.MarkerStyle = MarkerStyle.Circle;
            currentX2Series.LegendText = "x_2";
            chart.Series.Add(currentX2Series);

        }

        private void UpdateLabels()
        {
            step_out_label.Text = $"Шаг: {iterationNumber + 1}";
            ab_out_label.Text = $"Интервал: ({Math.Round(currentA_X, 4)}; {Math.Round(currentB_X, 4)})";
            x_1_out_label.Text = $"x_1 = {Math.Round(currentX_1, 4)}";
            f_1_out_label.Text = $"F(x_1) = {Math.Round(currentY_1, 4)}";
            x_2_out_label.Text = $"x_2 = {Math.Round(currentX_2, 4)}";
            f_2_out_label.Text = $"F(x_2) = {Math.Round(currentY_2, 4)}";
            epsilon_label.Text = $"Точность = {Math.Round(currentEps, 4)}";
        }

        private void newUpdateLabels()
        {
            new_ab_label.Text = $"Новый интервал: ({Math.Round(aValues[iterationNumber+ 1], 4)}; {Math.Round(bValues[iterationNumber+ 1], 4)})";
            new_x_1_label.Text = $"x_1 = {Math.Round(x_1_Values[iterationNumber + 1], 4)}";
            new_f_1_label.Text = $"F(x_1) = {Math.Round(CalculateFunctionValue(x_1_Values[iterationNumber + 1]), 4)}";
            new_x_2_label.Text = $"x_2 = {Math.Round(x_2_Values[iterationNumber+ 1], 4)}";
            new_f_1_label.Text = $"F(x_2) = {Math.Round(CalculateFunctionValue(x_2_Values[iterationNumber+ 1]), 4)}";
            new_epsilon_label.Text = $"Точность = {Math.Round(EpsValue[iterationNumber+ 1], 4)}";
        }
        private void stop_button_Click(object sender, EventArgs e)
        {
            // Переинициализация массивов значений и переменных
            InitializeArrays();

            // Проверяем, существует ли уже серия данных с таким именем
            if (chart.Series.IndexOf(series_new) != -1)
            {
                // Если существует, удаляем её перед добавлением новой серии данных
                chart.Series.Remove(series_new);
            }

            // Обновляем координаты точки текущей позиции
            currentASeries.Points.Clear();
            currentASeries.Points.AddXY(currentA_X, currentA_Y);

            currentBSeries.Points.Clear();
            currentBSeries.Points.AddXY(currentB_X, currentB_Y);

            currentX1Series.Points.Clear();
            currentX1Series.Points.AddXY(currentX_1, currentY_1);

            currentX2Series.Points.Clear();
            currentX2Series.Points.AddXY(currentX_2, currentY_2);

            // Обновляем значения на форме
            UpdateLabels();

            if (iterationNumber >= 1)
            {
                // Выводим вопрос f(x_1)<=f(x_2)?
                next_step_button.Enabled = false;
                yes_2_button.Enabled = true;
                no_2_button.Enabled = true;
            }

            // Обновление меток
            UpdateLabels();

            // Заблокировать кнопки
            Stop_label.Visible = false;
            next_step_button.Enabled = false;
            yes_2_button.Enabled = false;
            no_2_button.Enabled = false;
            yes_button_1.Enabled = true;
            no_button_1.Enabled = true;
            new_ab_label.Visible = false;
            new_x_1_label.Visible = false;
            new_f_1_label.Visible = false;
            new_x_2_label.Visible = false;
            new_f_2_label.Visible = false;
            new_epsilon_label.Visible = false;
        }

        private void Next_step_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
            new_ab_label.Visible = false;
            new_x_1_label.Visible = false;
            new_f_1_label.Visible = false;
            new_x_2_label.Visible = false;
            new_f_2_label.Visible = false;
            new_epsilon_label.Visible = false;
            // Переходим к следующему шагу
            iterationNumber++;

            // Проверяем, выходим ли за границы массива значений
            if (iterationNumber >= x_1_Values.Length)
            {
                next_step_button.Enabled = false;
                return;
            }
            currentA_X = aValues[iterationNumber];
            currentB_X = bValues[iterationNumber];
            currentX_1 = x_1_Values[iterationNumber];
            currentX_2 = x_2_Values[iterationNumber];
            currentEps = EpsValue[iterationNumber];
            currentA_Y = CalculateFunctionValue(currentA_X);
            currentB_Y = CalculateFunctionValue(currentB_X);
            currentY_1 = CalculateFunctionValue(currentX_1);
            currentY_2 = CalculateFunctionValue(currentX_2);

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

            // Обновляем значения на форме
            UpdateLabels();

            if (iterationNumber >= 1)
            {
                // Выводим вопрос о точности
                next_step_button.Enabled = false;
                yes_button_1.Enabled = true;
                no_button_1.Enabled = true;
            }
        }
        private void yes_button_1_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
            if (iterationNumber < aValues.Length)
            {
                // Проверяем, верно ли условие  окончания интервала
                bool conditionMet = EpsValue[iterationNumber] <= accuracy;

                // Ответ пользователя
                if (conditionMet)
                {
                    yes_button_1.Enabled = false;
                    no_button_1.Enabled = false;
                    yes_2_button.Enabled = false;
                    no_2_button.Enabled = false;
                    next_step_button.Enabled = false;
                    Stop_label.Visible = true;
                    Stop_label.Text = $"Минимум найден: x = {Math.Round((a + b) / 2, 4)}; F(x) = {Math.Round(CalculateFunctionValue((a + b) / 2), 4)}";
                }
                else
                {
                    question_1_label.BackColor = Color.Red;
                }
            }
        }

        private void no_button_1_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
            if (iterationNumber < aValues.Length)
            {
                // Проверяем, верно ли условие  окончания интервала
                bool conditionMet = EpsValue[iterationNumber] <= accuracy;

                // Ответ пользователя
                if (conditionMet)
                {
                    question_1_label.BackColor = Color.Red;
                }
                else
                {
                    yes_2_button.Enabled = true;
                    no_2_button.Enabled = true;
                    yes_button_1.Enabled = false;
                    no_button_1.Enabled = false;
                }
            }
        }
        private void yes_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = DefaultBackColor;
            // Проверяем, верно ли условие f(x_1)<=f(x_2)?
            bool conditionMet = currentY_1 <= currentY_2;

            // Ответ пользователя
            if (conditionMet)
            {
                yes_2_button.Enabled = false;
                no_2_button.Enabled = false;
                next_step_button.Enabled = true;
                newUpdateLabels();
                new_ab_label.Visible = true;
                new_x_1_label.Visible = true;
                new_f_1_label.Visible = true;
                new_x_2_label.Visible = true;
                new_f_2_label.Visible = true;
                new_epsilon_label.Visible = true;
            }
            else
            {
                question_2_label.BackColor = Color.Red;
            }

        }

        private void no_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = DefaultBackColor;

            // Проверяем, верно ли условие f(x_1)<=f(x_2)?
            bool conditionMet = currentY_1 <= currentY_2;

            // Ответ пользователя
            if (conditionMet)
            {
                question_2_label.BackColor = Color.Red;
            }
            else
            {
                yes_2_button.Enabled = false;
                no_2_button.Enabled = false;
                next_step_button.Enabled = true;
                newUpdateLabels();
                new_ab_label.Visible = true;
                new_x_1_label.Visible = true;
                new_f_1_label.Visible = true;
                new_x_2_label.Visible = true;
                new_f_2_label.Visible = true;
                new_epsilon_label.Visible = true;
            }
        }

        private (double[] aValues, double[] bValues, double[] x_1Values, double[] x_2Values, double[] EpsValue) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> x_1Values = new List<double>();
            List<double> x_2Values = new List<double>();
            List<double> EpsValue = new List<double>();

            double goldenRatio = (Math.Sqrt(5) - 1) / 2;

            double x1 = b - goldenRatio * (b - a);
            double x2 = a + goldenRatio * (b - a);

            double f1 = CalculateFunctionValue(x1);
            double f2 = CalculateFunctionValue(x2);

            double epsilon = (b - a) / 2;

            while (epsilon > accuracy)
            {
                aValues.Add(a);
                bValues.Add(b);
                x_1Values.Add(x1);
                x_2Values.Add(x2);
                EpsValue.Add(epsilon);
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
                 epsilon *= goldenRatio;
            }

            // Добавляем последние точки и значение минимума
            aValues.Add(a);
            bValues.Add(b);
            x_1Values.Add(x1);
            x_2Values.Add(x2);
            EpsValue.Add(epsilon);

            double minX = (a + b) / 2;
            double minResult = CalculateFunctionValue(minX);

            return (aValues.ToArray(), bValues.ToArray(), x_1Values.ToArray(), x_2Values.ToArray(), EpsValue.ToArray());
        }


        private double CalculateFunctionValue(double x)
        {
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = x;
            return Convert.ToDouble(exp.Evaluate());
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
