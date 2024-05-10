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
    public partial class visualizationForm_Cubic : Form
    {
        private Chart chart;
        private double a, b, accuracy;
        private string functionExpression;
        private Series currentABSeries, currentXSeries, series_new, currentFSeries; // Серия для текущей позиции
        private double[] xValues, aValues, bValues, EpsValue;
        private double currentX, currentA_X, currentB_X, currentF;
        private double currentY, currentA_Y, currentB_Y, currentEps;
        private int iterationNumber;
        private TableLayoutPanel tableLayoutPanel;

        public visualizationForm_Cubic(string functionExpression, double a, double b, double accuracy)
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
            next_step_button.Enabled = false;
            yes_2_button.Enabled = false;
            no_2_button.Enabled = false;

            Stop_label.Visible = false;
            new_eps_label.Visible = false;
        }

        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (aValues, bValues, xValues, EpsValue) = CalculateFunctionOnInterval(a, b, accuracy);

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

        private void DisplayFunctionGraph()
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tableLayoutPanel);

            // Добавляем текст и линии в соответствующие строки
            AddLineAndLabel(Color.Blue, "y = f(x)", 4, 15, 10, tableLayoutPanel, 0);
            AddLineAndLabel(Color.Red, "y = f'(x)", 2, 15, 10, tableLayoutPanel, 1);

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
            for (double x = a - 2; x <= b + 2; x += accuracy)
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
            horizontalLineSeries.Color = Color.Black; // Цвет линии можно выбрать по вашему усмотрению


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
                Fseries.Color = Color.Red;
            }

            // Добавление серии данных на график
            chart.Series.Add(Fseries);

            double currentA_X = aValues[iterationNumber];
            double currentA_Y = CalculateFunctionValue(currentA_X);
            double currentB_X = bValues[iterationNumber];
            double currentB_Y = CalculateFunctionValue(currentB_X);

            // Инициализация a b
            currentABSeries = new Series();
            currentABSeries.ChartType = SeriesChartType.Point;
            currentABSeries.Points.AddXY(currentA_X, currentA_Y);
            currentABSeries.Points.AddXY(currentB_X, currentB_Y);
            currentABSeries.Color = Color.Blue;
            currentABSeries.MarkerSize = 5;
            currentABSeries.MarkerStyle = MarkerStyle.Circle;
            chart.Series.Add(currentABSeries);

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
            currentFSeries.Points.AddXY(currentX, currentF);
            currentFSeries.Color = System.Drawing.Color.Black;
            currentFSeries.MarkerSize = 5;
            currentFSeries.MarkerStyle = MarkerStyle.Circle;
            currentFSeries.LegendText = "x";
            chart.Series.Add(currentFSeries);
        }

        private void UpdateLabels()
        {
            double x1 = currentA_X;
            double x2 = currentB_X;
            double y1 = currentA_Y;
            double y2 = currentB_Y;
            double x0 = currentX;
            double y11 = CalculateDerivative(currentA_X);
            double y12 = CalculateDerivative(currentB_X);


            double z = y11 + y12 - 3 * (y2 - y1) / (x2 - x1);
            double omega = Math.Sqrt(Math.Pow(z, 2) - y11 * y12);
            double mu = (omega + z - y11) / (2 * omega - y11 + y12);

            double a0 = y1;
            double a1 = (y2 - y1) / (x2 - x1);
            double a2 = Math.Pow((y2 - y1) / (x2 - x1), 2) - y11 / (x2 - x1);
            double a3 = (y12 - y11) / Math.Pow((x2 - x1), 2) - 2 * (y2 - y1) / Math.Pow((x2 - x1), 3);

            step_out_label.Text = $"Шаг: {iterationNumber + 1}";
            x_1_label.Text = $"x_1 = {Math.Round(x1, 4)}";
            x_2_label.Text = $"x_2 = {Math.Round(x2, 4)}";
            f_1_label.Text = $"F(x_1) = {Math.Round(y1, 4)}";
            f_2_label.Text = $"F(x_2)= {Math.Round(y2, 4)}";
            def_1_label.Text = $"F'(x_1) = {Math.Round(y11, 4)}";
            def_2_label.Text = $"F'(x_2) = {Math.Round(y12, 4)}";

            mu_label.Text = $"μ = {Math.Round(mu, 4)}";
            omega_label.Text = $"ω = {Math.Round(omega, 4)}";
            z_label.Text = $"z = {Math.Round(z, 4)}";
            x_0_label.Text = $"x_0 = {Math.Round(x0, 4)}";
            f_0_label.Text = $"F(x_0) = {Math.Round(CalculateFunctionValue(x0), 4)}";
            def_0_label.Text = $"F'(x_0) = {Math.Round(CalculateDerivative(x0), 4)}";
            
            cubic_label.TextAlign = ContentAlignment.MiddleCenter;

            cubic_label.Text = $"P_3(x) = {Math.Round(a0, 4)} + {Math.Round(a1, 4)}*(x - {Math.Round(x1, 4)}) \n+ {Math.Round(a2, 4)}*(x - {Math.Round(x1, 4)})*(x - {Math.Round(x2, 4)}) + \n{Math.Round(a3, 4)}*(x - {Math.Round(x1, 4)})^2*(x - {Math.Round(x2, 4)})";
        }

        private void newUpdateLabels()
        {
            new_eps_label.Text = $"Точность = {Math.Round(EpsValue[iterationNumber], 4)}";
        }
        private void stop_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
            question_2_label.BackColor = DefaultBackColor;
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
            new_eps_label.Visible = false;
        }

        private void Next_step_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
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
            question_1_label.BackColor = DefaultBackColor;
            if (iterationNumber < aValues.Length)
            {

                bool conditionMet = CalculateDerivative(currentX) * CalculateDerivative(currentB_X) < 0;
                // Ответ пользователя
                if (conditionMet)
                {
                    yes_button_1.Enabled = false;
                    no_button_1.Enabled = false;
                    yes_2_button.Enabled = true;
                    no_2_button.Enabled = true;
                    newUpdateLabels();
                    new_eps_label.Visible = true;
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
                bool conditionMet = CalculateDerivative(currentX) * CalculateDerivative(currentA_X) < 0;

                // Ответ пользователя
                if (conditionMet)
                {
                    yes_button_1.Enabled = false;
                    no_button_1.Enabled = false;
                    yes_2_button.Enabled = true;
                    no_2_button.Enabled = true;
                    newUpdateLabels();
                    new_eps_label.Visible = true;
                }
                else
                {
                    question_1_label.BackColor = Color.Red;
                }
            }
        }
        private void yes_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = DefaultBackColor;
            // Проверяем, верно ли условие окончания?
            bool conditionMet = EpsValue[iterationNumber] <= accuracy;

            // Ответ пользователя
            if (conditionMet)
            {
                yes_2_button.Enabled = false;
                no_2_button.Enabled = false;
                Stop_label.Visible = true;
                Stop_label.Text = $"Минимум найден: x = {Math.Round(xValues[iterationNumber], 4)}; F(x) = {Math.Round(CalculateFunctionValue(xValues[iterationNumber]), 4)}";
            }
            else
            {
                question_2_label.BackColor = Color.Red;
            }

        }

        private void no_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = DefaultBackColor;

            // Проверяем, верно ли условие окончания?
            bool conditionMet = EpsValue[iterationNumber] <= accuracy;

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
            }
        }
        private (double[] aValues, double[] bValues, double[] xValues, double[] EpsValue) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> xValues = new List<double>();
            List<double> EpsValue = new List<double>();

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

                xValues.Add(x0);
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
                EpsValue.Add(epsilon);
            }
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

    }
}
