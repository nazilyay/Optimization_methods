using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using NCalc;

namespace Optimization_methods.Chord_Methods
{
    public partial class visualizationForm_Chord : Form
    {
        private Chart chart;
        private ChartArea chartArea;
        private double a, b, accuracy;
        private string functionExpression;
        private Series currentXSeries, lineSeries, series, Fseries, horizontalLineSeries, punct; // Серия для текущей позиции
        private double[] xValues, EpsValue;
        private double currentX;
        private double currentY, currentEps;
        private int iterationNumber;
        private TableLayoutPanel tableLayoutPanel;
        private int mistake;
        private bool end;

        public visualizationForm_Chord(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Инициализация массивов значений
            InitializeArrays();
            SetupUI();
            this.FormClosing += VisualizationForm_Closing;

            question_1_label.Text = $"Отрезок [{a}; {b}] \nвыбрано корректно?";
            question_1_label.TextAlign = ContentAlignment.MiddleCenter;

            FunctionGraph();
        }
        private void VisualizationForm_Closing(object sender, FormClosingEventArgs e)
        {
            End_Form endMethods = new End_Form(mistake, "Метода хорд", end, xValues[xValues.Length - 1], CalculateFunctionValue(xValues[xValues.Length - 1]));
            endMethods.Show();
        }
        private void SetupUI()
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240);
            question_2_label.BackColor = Color.FromArgb(245, 245, 240);
            yes_button_1.Enabled = no_button_1.Enabled = true;
            next_step_button.Enabled = yes_2_button.Enabled = no_2_button.Enabled = false;
            Stop_label.Visible = step_out_label.Visible = x_out_label.Visible = x_next.Visible = f_out_label.Visible = epsilon_label.Visible = prev_x_label.Visible = prev_def_label.Visible = def_label.Visible = false;
        }

        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (xValues, EpsValue) = CalculateFunctionOnInterval(a, b, accuracy);
            mistake = 0;
            end = false;
            iterationNumber = 2;
            // Инициализируем текущие значения как начальные значения из массива
            currentX = xValues[iterationNumber];
            currentEps = EpsValue[iterationNumber];
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
            panel.Controls.Add(linePanel, columnIndex * 2 + 1, 0); // Добавляем линию в четные столбцы

            Label label = new Label
            {
                Text = labelText,
                AutoSize = false,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None
            };
            panel.Controls.Add(label, columnIndex * 2, 0); // Добавляем текст в нечетные столбцы
        }

        private void FunctionGraph()
        {
            // Создание таблицы для размещения линий и меток
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tableLayoutPanel);

            // Добавление текста и линий в соответствующие столбцы
            string[] labelTexts = { "y = f(x)", "y = f'(x)", "y = f''(x)", "y = f'''(x)" };
            Color[] colors = { Color.Red, Color.Violet, Color.Green, Color.Aqua };
            int[] lineWidths = { 4, 2, 2, 2 };
            Func<double, double>[] derivativeFunctions = { CalculateFunctionValue, CalculateDerivative, CalculateSecondDerivative, CalculateThirdDerivative };

            for (int i = 0; i < labelTexts.Length; i++)
            {
                AddLineAndLabel(colors[i], labelTexts[i], i % 2 == 0 ? 4 : 2, 15, 10, tableLayoutPanel, i);
            }

            // Создание графика
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            panel_graph.Controls.Add(chart);

            // Создание области для графика
            chartArea = new ChartArea();
            chartArea.AxisX.Minimum = a;
            chartArea.AxisX.Maximum = b;

            // Вычисление максимального и минимального значения Y
            double minY = double.MaxValue; // Очень большое число
            double maxY = double.MinValue; // Очень маленькое число
         
            // Создание серии данных для горизонтальной линии y=0
            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Black;

            for (int i = 0; i < derivativeFunctions.Length; i++)
            {
                series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = lineWidths[i]; // Используем разные ширины линий
                series.Color = colors[i];

                // Добавление точек на график
                for (double x = a; x <= b; x += accuracy)
                {
                    double y = derivativeFunctions[i](x);
                    series.Points.AddXY(x, y);
                    minY = Math.Min(minY, y);
                    maxY = Math.Max(maxY, y);
                    horizontalLineSeries.Points.AddXY(x, 0);
                }

                // Добавление серии данных на график
                chart.Series.Add(series);
            }

            chartArea.AxisY.Minimum = Math.Round(minY - 5);
            chartArea.AxisY.Maximum = Math.Round(maxY + 5);
            chart.ChartAreas.Add(chartArea);

            // Подписываем оси
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "Y";

            chart.Series.Add(horizontalLineSeries);
        }
        private void ClearGraph()
        {
            // Очистка панели с таблицей
            if (tableLayoutPanel != null)
            {
                tableLayoutPanel.Controls.Clear();
                tableLayoutPanel.Dispose();
            }
            // Очистка графика и его области
            if (chart != null)
            {
                chart.Series.Clear();
                chart.ChartAreas.Clear();
                chart.Dispose();
            }

            currentXSeries?.Dispose();
            lineSeries?.Dispose();

            // Очистка панели, содержащей график
            panel_graph.Controls.Clear();
        }

        private void DisplayFunctionGraph()
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 4; // Добавляем 2 столбца
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tableLayoutPanel);

            // Добавляем текст и линии в соответствующие столбцы
            AddLineAndLabel(Color.DarkOrange, "y = f(x)", 2, 10, 10, tableLayoutPanel, 0);
            AddLineAndLabel(Color.Blue, "y = f'(x)", 3, 10, 10, tableLayoutPanel, 1);

            // Создание графика
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            panel_graph.Controls.Add(chart);

            // Создание области для графика
            chartArea = new ChartArea();
            chartArea.AxisX.Minimum = a;
            chartArea.AxisX.Maximum = b;

            // Вычисление максимального и минимального значения Y
            double minY = double.MaxValue; // Очень большое число
            double maxY = double.MinValue; // Очень маленькое число

            // Создание серии данных для графика функции
            series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = Color.DarkOrange;

            // Создание серии данных для графика производной
            Fseries = new Series();
            Fseries.ChartType = SeriesChartType.Line;
            Fseries.BorderWidth = 3;

            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Black;

            // Добавление точек на график
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                double def = CalculateDerivative(x);
                series.Points.AddXY(x, y);
                horizontalLineSeries.Points.AddXY(x, 0);
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
            chart.Series.Add(Fseries);
            chart.Series.Add(horizontalLineSeries);

            // Инициализация x
            double currentX = xValues[iterationNumber];
            double currentY = CalculateFunctionValue(currentX);
            double currentF = CalculateDerivative(currentX);

            currentXSeries = new Series();
            currentXSeries.ChartType = SeriesChartType.Point;
            currentXSeries.Points.AddXY(currentX, currentY);
            currentXSeries.Points.AddXY(currentX, 0);
            currentXSeries.Points.AddXY(currentX, currentF);
            currentXSeries.Color = System.Drawing.Color.Black;
            currentXSeries.MarkerSize = 5;
            currentXSeries.MarkerStyle = MarkerStyle.Circle;
            chart.Series.Add(currentXSeries);

            double X1 = xValues[iterationNumber - 1];
            double X2 = xValues[iterationNumber - 2];

            double Y1 = CalculateDerivative(xValues[iterationNumber - 1]);
            double Y2 = CalculateDerivative(xValues[iterationNumber - 2]);

            lineSeries = new Series();
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.BorderWidth = 1;
            lineSeries.Color = Color.Red;
            lineSeries.Points.AddXY(X1, Y1);
            lineSeries.Points.AddXY(X2, Y2);
            lineSeries.Points.AddXY(currentX, 0);
            chart.Series.Add(lineSeries); // Добавляем прямую на график

            punct = new Series();
            punct.ChartType = SeriesChartType.Line;
            punct.BorderWidth = 1;
            punct.Color = Color.Red;
            punct.BorderDashStyle = ChartDashStyle.Dot;
            punct.Points.AddXY(xValues[iterationNumber], CalculateFunctionValue(xValues[iterationNumber]));
            punct.Points.AddXY(xValues[iterationNumber], CalculateDerivative(xValues[iterationNumber ]));
            punct.Points.AddXY(xValues[iterationNumber], 0);
            chart.Series.Add(punct); // Добавляем прямую на график

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            step_out_label.Text = $"Шаг: {iterationNumber - 1}";
            prev_x_label.Text = $"x_(k-1) = {Math.Round(xValues[iterationNumber - 2], 6)}";
            x_out_label.Text = $"x_k = {Math.Round(xValues[iterationNumber - 1], 6)}";
            prev_def_label.Text = $"F'(x_(k-1)) = {Math.Round(CalculateDerivative(xValues[iterationNumber - 2]), 6)}";
            def_label.Text = $"F'(x_k) = {Math.Round(CalculateDerivative(xValues[iterationNumber - 1]), 6)}";
            x_next.Text = $"x_(k+1) = {Math.Round(xValues[iterationNumber], 6)}";
            f_out_label.Text = $"F(x_(k+1)) = {Math.Round(CalculateFunctionValue(xValues[iterationNumber]), 6)}";
            epsilon_label.Text = $"Точность = {Math.Round(EpsValue[iterationNumber - 2], 6)}";
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            InitializeArrays();
            ClearGraph();
            FunctionGraph();

            UpdateLabels();

            SetupUI();
        }

        private void Next_step_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240); ;
            // Переходим к следующему шагу
            iterationNumber++;

            // Проверяем, выходим ли за границы массива значений
            if (iterationNumber >= xValues.Length)
            {
                next_step_button.Enabled = false;
                return;
            }

            currentX = xValues[iterationNumber];
            currentEps = EpsValue[iterationNumber - 2];
            currentY = CalculateFunctionValue(currentX);
            double currentF = CalculateDerivative(currentX);

            // Обновляем координаты точки текущей позиции
            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, currentY);
            currentXSeries.Points.AddXY(currentX, 0);
            currentXSeries.Points.AddXY(currentX, currentF);

            lineSeries.Points.Clear();
            punct.Points.Clear();
            double X1 = xValues[iterationNumber - 1];
            double X2 = xValues[iterationNumber - 2];

            double Y1 = CalculateDerivative(xValues[iterationNumber - 1]);
            double Y2 = CalculateDerivative(xValues[iterationNumber - 2]);

            lineSeries.Points.AddXY(X1, Y1);
            lineSeries.Points.AddXY(X2, Y2);
            lineSeries.Points.AddXY(currentX, 0);

            punct.Points.AddXY(xValues[iterationNumber], CalculateFunctionValue(xValues[iterationNumber]));
            punct.Points.AddXY(xValues[iterationNumber], CalculateDerivative(xValues[iterationNumber]));
            punct.Points.AddXY(xValues[iterationNumber], 0);

            // Обновляем значения на форме
            UpdateLabels();

            if (iterationNumber >= 1)
            {
                // Выводим вопрос о точности
                next_step_button.Enabled = false;
                yes_2_button.Enabled = true;
                no_2_button.Enabled = true;
            }
        }
        private void yes_button_1_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240); ;

            yes_button_1.Enabled = false;
            no_button_1.Enabled = false;

            UpdateLabels();

            yes_2_button.Enabled = no_2_button.Enabled = true;
            step_out_label.Visible = x_out_label.Visible = x_next.Visible = f_out_label.Visible = epsilon_label.Visible = prev_x_label.Visible = prev_def_label.Visible = def_label.Visible = true;
            ClearGraph();
            DisplayFunctionGraph();
        }

        private void no_button_1_Click(object sender, EventArgs e)
        {
            mistake++;
            question_1_label.BackColor = Color.Red;
        }
        private void yes_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = Color.FromArgb(245, 245, 240); ;
            // Проверяем, верно ли условие окончания?
            bool conditionMet = EpsValue[iterationNumber - 2] <= accuracy;

            // Ответ пользователя
            if (conditionMet)
            {
                end = true;
                yes_2_button.Enabled = false;
                no_2_button.Enabled = false;
                Stop_label.Visible = true;
                Stop_label.Text = $"Минимум найден: x = {Math.Round(xValues[iterationNumber], 4)}; F(x) = {Math.Round(CalculateFunctionValue(xValues[iterationNumber]), 4)}";
            }
            else
            {
                mistake++;
                question_2_label.BackColor = Color.Red;
            }

        }

        private void no_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = Color.FromArgb(245, 245, 240); ;

            // Проверяем, верно ли условие окончания?
            bool conditionMet = EpsValue[iterationNumber - 2] <= accuracy;

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
        private (double[] xValues, double[] EpsValue) CalculateFunctionOnInterval(double a, double b, double accuracy)
        {
            List<double> xValues = new List<double>();
            List<double> EpsValue = new List<double>();

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
                xValues.Add(x_new);
                EpsValue.Add(epsilon);
                x_prev = x_curr;
                x_curr = x_new;
            }
            return (xValues.ToArray(), EpsValue.ToArray());
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

        private double CalculateSecondDerivative(double x)
        {
            double h = 0.0001; // Шаг для численного дифференцирования
            double xPlusH = x + h;
            double xMinusH = x - h;

            double fPlusH = CalculateDerivative(xPlusH);
            double fMinusH = CalculateDerivative(xMinusH);

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

        private double CalculateThirdDerivative(double x)
        {
            double h = 0.0001; // Шаг для численного дифференцирования
            double xPlusH = x + h;
            double xMinusH = x - h;

            double fPlusH = CalculateSecondDerivative(xPlusH);
            double fMinusH = CalculateSecondDerivative(xMinusH);

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
