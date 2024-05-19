using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;

namespace Optimization_methods.Middle_Methods
{
    public partial class visualizationForm_Middle : Form
    {
        private Chart chart;
        private double a, b, accuracy;
        private string functionExpression;
        private TableLayoutPanel tableLayoutPanel;
        private Series currentABSeries, currentXSeries, series_new, series, Fseries, horizontalLineSeries; // Серия для текущей позиции
        private double[] xValues, aValues, bValues, EpsValue;
        private double currentX, currentA_X, currentB_X, currentF;
        private double currentY, currentA_Y, currentB_Y, currentEps;
        private int iterationNumber;
        private int mistake;
        private bool end;
        public visualizationForm_Middle(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            // Инициализация массивов значений
            InitializeArrays();
            this.FormClosing += VisualizationForm_Closing;

            // Отображение функции на графике
            DisplayFunctionGraph();

            // Обновление меток
            UpdateLabels();

            // Заблокировать кнопки
            next_step_button.Enabled = false;
            yes_2_button.Enabled = false;
            no_2_button.Enabled = false;

            Stop_label.Visible = false;
            new_ab_label.Visible = false;
            new_eps_label.Visible = false;
        }
        private void VisualizationForm_Closing(object sender, FormClosingEventArgs e)
        {
            double end_x = (aValues[aValues.Length - 1] + bValues[bValues.Length - 1]) / 2;
            End_Form endMethods = new End_Form(mistake, "Метода средней точки", end, end_x, CalculateFunctionValue(end_x));
            endMethods.Show();
        }
        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (aValues, bValues, xValues, EpsValue) = CalculateFunctionOnInterval(a, b, accuracy);
            mistake = 0;
            end = false;
            iterationNumber = 0;
            // Инициализируем текущие значения как начальные значения из массива
            currentA_X = aValues[iterationNumber];
            currentB_X = bValues[iterationNumber];
            currentX = xValues[iterationNumber];
            currentEps = EpsValue[iterationNumber];
            currentA_Y = CalculateFunctionValue(currentA_X);
            currentB_Y = CalculateFunctionValue(currentB_X);
            currentY = CalculateFunctionValue(currentX);
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

        private void DisplayFunctionGraph()
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

            // Создание серии данных для графика функции
            series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;

            // Создание серии данных для горизонтальной линии y=0
            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Red;

            // Создание серии данных для производной функции
            Fseries = new Series();
            Fseries.ChartType = SeriesChartType.Line;
            Fseries.BorderWidth = 1;
            Fseries.Color = Color.Black;

            // Добавление точек на график
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                series.Points.AddXY(x, y);
                horizontalLineSeries.Points.AddXY(x, 0);
                double def = CalculateDerivative(x);
                Fseries.Points.AddXY(x, def);
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
            }
          
            chartArea.AxisY.Minimum = Math.Round(minY - 5);
            chartArea.AxisY.Maximum = Math.Round(maxY + 5);

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

            double currentA_X = aValues[iterationNumber];
            double currentA_Y = CalculateFunctionValue(currentA_X);
            double currentB_X = bValues[iterationNumber];
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
            double currentX = xValues[iterationNumber];
            double currentY = CalculateFunctionValue(currentX);
            double currentF = CalculateDerivative(currentX);

            currentXSeries = new Series();
            currentXSeries.ChartType = SeriesChartType.Point;
            currentXSeries.Points.AddXY(currentX, currentY);
            currentXSeries.Points.AddXY(currentX, currentF);// Начальная позиция - точка минимума
            currentXSeries.Color = System.Drawing.Color.Black;
            currentXSeries.MarkerSize = 5;
            currentXSeries.MarkerStyle = MarkerStyle.Circle;
            chart.Series.Add(currentXSeries);
        }

        private void UpdateLabels()
        {
            step_out_label.Text = $"Шаг: {iterationNumber + 1}";
            ab_out_label.Text = $"Интервал: ({Math.Round(currentA_X, 4)}; {Math.Round(currentB_X, 4)})";
            x_out_label.Text = $"x = {Math.Round(currentX, 4)}";
            f_out_label.Text = $"F(x) = {Math.Round(currentY, 4)}";
            def_out_label.Text = $"F'(x) = {Math.Round(CalculateDerivative(currentX), 4)}";
        }

        private void newUpdateLabels()
        {
            new_ab_label.Text = $"Новый интервал: ({Math.Round(aValues[iterationNumber + 1], 4)}; {Math.Round(bValues[iterationNumber + 1], 4)})";
            new_eps_label.Text = $"Точность = {Math.Round(EpsValue[iterationNumber + 1], 4)}";
        }
        private void stop_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240);
            question_2_label.BackColor = Color.FromArgb(245, 245, 240);
            // Переинициализация массивов значений и переменных
            InitializeArrays();

            // Проверяем, существует ли уже серия данных с таким именем
            if (chart.Series.IndexOf(series_new) != -1)
            {
                // Если существует, удаляем её перед добавлением новой серии данных
                chart.Series.Remove(series_new);
            }

            // Обновляем координаты точки текущей позиции
            currentABSeries.Points.Clear();
            currentABSeries.Points.AddXY(currentA_X, currentA_Y);
            currentABSeries.Points.AddXY(currentB_X, currentB_Y);

            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, currentY);
            currentXSeries.Points.AddXY(currentX, CalculateDerivative(currentX));

            // Обновляем значения на форме
            UpdateLabels();

            if (iterationNumber >= 1)
            {
                // Выводим вопрос f(x_1)<=f(x_2)?
                next_step_button.Enabled = false;
                yes_2_button.Enabled = true;
                no_2_button.Enabled = true;
            }


            // Заблокировать кнопки
            Stop_label.Visible = false;
            next_step_button.Enabled = false;
            yes_2_button.Enabled = false;
            no_2_button.Enabled = false;
            yes_button_1.Enabled = true;
            no_button_1.Enabled = true;
            new_ab_label.Visible = false;
            new_eps_label.Visible = false;
        }

        private void Next_step_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240);
            new_ab_label.Visible = false;
            new_eps_label.Visible = false;
            // Переходим к следующему шагу
            iterationNumber++;

            // Проверяем, выходим ли за границы массива значений
            if (iterationNumber >= xValues.Length)
            {
                next_step_button.Enabled = false;
                return;
            }
            currentA_X = aValues[iterationNumber];
            currentB_X = bValues[iterationNumber];
            currentX = xValues[iterationNumber];
            currentEps = EpsValue[iterationNumber];
            currentA_Y = CalculateFunctionValue(currentA_X);
            currentB_Y = CalculateFunctionValue(currentB_X);
            currentY = CalculateFunctionValue(currentX);

            // Обновляем координаты точки текущей позиции
            currentABSeries.Points.Clear();
            currentABSeries.Points.AddXY(currentA_X, currentA_Y);
            currentABSeries.Points.AddXY(currentB_X, currentB_Y);

            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, currentY);
            currentXSeries.Points.AddXY(currentX, CalculateDerivative(currentX));

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
            question_1_label.BackColor = Color.FromArgb(245, 245, 240);
            if (iterationNumber < aValues.Length)
            {
                // Проверяем знак производной
                bool conditionMet = CalculateDerivative(xValues[iterationNumber]) > 0;
                // Ответ пользователя
                if (conditionMet)
                {
                    yes_button_1.Enabled = false;
                    no_button_1.Enabled = false;
                    yes_2_button.Enabled = true;
                    no_2_button.Enabled = true;
                    newUpdateLabels();
                    new_ab_label.Visible = true;
                    new_eps_label.Visible = true;
                }
                else
                {
                    mistake++;
                    question_1_label.BackColor = Color.Red;
                }
            }
        }

        private void no_button_1_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240);
            if (iterationNumber < aValues.Length)
            {
                // Проверяем знак производной
                bool conditionMet = CalculateDerivative(xValues[iterationNumber]) > 0;

                // Ответ пользователя
                if (conditionMet)
                {
                    mistake++;
                    question_1_label.BackColor = Color.Red;
                }
                else
                {
                    yes_button_1.Enabled = false;
                    no_button_1.Enabled = false;
                    yes_2_button.Enabled = true;
                    no_2_button.Enabled = true;
                    newUpdateLabels();
                    new_ab_label.Visible = true;
                    new_eps_label.Visible = true;
                }
            }
        }
        private void yes_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = Color.FromArgb(245, 245, 240);
            // Проверяем, верно ли условие окончания?
            bool conditionMet = EpsValue[iterationNumber + 1] <= accuracy;

            // Ответ пользователя
            if (conditionMet)
            {
                end = true;
                yes_2_button.Enabled = false;
                no_2_button.Enabled = false;
                Stop_label.Visible = true;
                Stop_label.Text = $"Минимум найден: x = {Math.Round(((bValues[iterationNumber + 1] + aValues[iterationNumber + 1]) / 2), 4)}; F(x) = {Math.Round(CalculateFunctionValue((bValues[iterationNumber + 1] + aValues[iterationNumber + 1]) / 2), 4)}";
            }
            else
            {
                mistake++;
                question_2_label.BackColor = Color.Red;
            }

        }

        private void no_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = Color.FromArgb(245, 245, 240);

            // Проверяем, верно ли условие окончания?
            bool conditionMet = EpsValue[iterationNumber + 1] <= accuracy;

            // Ответ пользователя
            if (conditionMet)
            {
                mistake++;
                question_2_label.BackColor = Color.Red;
            }
            else
            {
                yes_2_button.Enabled = false;
                no_2_button.Enabled = false;
                next_step_button.Enabled = true;
            }
        }
        private (double[] aValues, double[] bValues, double[] xValues, double[] EpsValue) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> xValues = new List<double>();
            List<double> EpsValue = new List<double>();

            double x_k = (a + b) / 2;
            double epsilon = (b - a) / 2; // Начальная половина длины интервала

            while (epsilon > accuracy)
            {
                aValues.Add(a);
                bValues.Add(b);
                xValues.Add(x_k);
                EpsValue.Add(epsilon);

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
            EpsValue.Add(epsilon);

            double minF = CalculateFunctionValue(x_k);
            double minX = x_k;
            return (aValues.ToArray(), bValues.ToArray(), xValues.ToArray(), EpsValue.ToArray());
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


        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }

    }
}
