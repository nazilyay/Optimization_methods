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
        private Series currentASeries, currentBSeries, currentXSeries, series_new, currentFSeries; // Серия для текущей позиции
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
            End_Form endMethods = new End_Form(mistake, "Метода средней точки", true, end_x, CalculateFunctionValue(end_x));
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

        private void DisplayFunctionGraph()
        {
            // Создаем TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2; // Две строки
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Dock = DockStyle.Fill; // Заполняет всю доступную область panel1
            panel1.Controls.Add(tableLayoutPanel);

            // Создаем голубую линию
            Panel blueLinePanel = new Panel();
            blueLinePanel.BackColor = Color.Blue; // Цвет линии
            blueLinePanel.Height = 2; // Высота линии
            blueLinePanel.Margin = new Padding(0, 15, 0, 10); // Отступы сверху и снизу для центрирования
            tableLayoutPanel.Controls.Add(blueLinePanel, 0, 0); // Добавляем в первую ячейку

            // Создаем текст "y = f(x)"
            Label fLabel = new Label();
            fLabel.Text = "y = f(x)";
            fLabel.AutoSize = true;
            fLabel.Font = new Font("Segoe UI", 9, FontStyle.Regular); // Шрифт Segoe UI размером 9pt
            fLabel.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста по центру
            fLabel.Anchor = AnchorStyles.None; // Центрирует элемент внутри ячейки
            tableLayoutPanel.Controls.Add(fLabel, 0, 0); // Добавляем в первую ячейку

            // Создаем черную линию
            Panel blackLinePanel = new Panel();
            blackLinePanel.BackColor = Color.Black; // Цвет линии
            blackLinePanel.Height = 1; // Высота линии
            blackLinePanel.Margin = new Padding(0, 20, 0, 10); // Отступы сверху и снизу для центрирования
            tableLayoutPanel.Controls.Add(blackLinePanel, 1, 0); // Добавляем во вторую ячейку

            // Создаем текст "y = f'(x)"
            Label defLabel = new Label();
            defLabel.Text = "y = f'(x)";
            defLabel.AutoSize = true;
            defLabel.Font = new Font("Segoe UI", 9, FontStyle.Regular); // Шрифт Segoe UI размером 9pt
            defLabel.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста по центру
            defLabel.Anchor = AnchorStyles.None; // Центрирует элемент внутри ячейки
            tableLayoutPanel.Controls.Add(defLabel, 1, 0); // Добавляем во вторую ячейку


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

            // Создание серии данных для горизонтальной линии y=0
            Series horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Red; // Цвет линии можно выбрать по вашему усмотрению


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
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateDerivative(x);
                Fseries.Points.AddXY(x, y);
                Fseries.Color = Color.Black;
            }

            // Добавление серии данных на график
            chart.Series.Add(Fseries);

            double currentA_X = aValues[iterationNumber];
            double currentA_Y = CalculateFunctionValue(currentA_X);

            // Инициализация a b
            currentASeries = new Series();
            currentASeries.ChartType = SeriesChartType.Point;
            currentASeries.Points.AddXY(currentA_X, currentA_Y); // Начальная позиция - точка минимума
            currentASeries.Color = Color.Blue;
            currentASeries.MarkerSize = 5;
            currentASeries.MarkerStyle = MarkerStyle.Circle;
            currentASeries.LegendText = "a";
            chart.Series.Add(currentASeries);

            double currentB_X = bValues[iterationNumber];
            double currentB_Y = CalculateFunctionValue(currentB_X);

            currentBSeries = new Series();
            currentBSeries.ChartType = SeriesChartType.Point;
            currentBSeries.Points.AddXY(currentB_X, currentB_Y); // Начальная позиция - точка минимума
            currentBSeries.Color = Color.Blue;
            currentBSeries.MarkerSize = 5;
            currentBSeries.MarkerStyle = MarkerStyle.Circle;
            currentBSeries.LegendText = "b";
            chart.Series.Add(currentBSeries);

            // Инициализация x
            double currentX = xValues[iterationNumber];
            double currentY = CalculateFunctionValue(currentX);

            currentXSeries = new Series();
            currentXSeries.ChartType = SeriesChartType.Point;
            currentXSeries.Points.AddXY(currentX, currentY); // Начальная позиция - точка минимума
            currentXSeries.Color = System.Drawing.Color.Black;
            currentXSeries.MarkerSize = 5;
            currentXSeries.MarkerStyle = MarkerStyle.Circle;
            currentXSeries.LegendText = "x";
            chart.Series.Add(currentXSeries);


            // Инициализация F'
            double currentF = CalculateDerivative(currentX);

            currentFSeries = new Series();
            currentFSeries.ChartType = SeriesChartType.Point;
            currentFSeries.Points.AddXY(currentX, currentF); // Начальная позиция - точка минимума
            currentFSeries.Color = System.Drawing.Color.Black;
            currentFSeries.MarkerSize = 5;
            currentFSeries.MarkerStyle = MarkerStyle.Circle;
            currentFSeries.LegendText = "x";
            chart.Series.Add(currentFSeries);
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
            currentASeries.Points.Clear();
            currentASeries.Points.AddXY(currentA_X, currentA_Y);

            currentBSeries.Points.Clear();
            currentBSeries.Points.AddXY(currentB_X, currentB_Y);

            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, currentY);

            currentFSeries.Points.Clear();
            currentFSeries.Points.AddXY(currentX, CalculateDerivative(currentX));

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
            currentASeries.Points.Clear();
            currentASeries.Points.AddXY(currentA_X, currentA_Y);

            currentBSeries.Points.Clear();
            currentBSeries.Points.AddXY(currentB_X, currentB_Y);

            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, currentY);

            currentFSeries.Points.Clear();
            currentFSeries.Points.AddXY(currentX, CalculateDerivative(currentX));

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
