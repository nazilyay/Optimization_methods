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

namespace Optimization_methods.Dichotomies_Method
{
    public partial class VisualizationForm : Form
    {
        private Chart chart;
        private double a, b, accuracy, parameter;
        private string functionExpression;
        private Series currentASeries, currentBSeries, currentX1Series, currentX2Series, series_new; // Серия для текущей позиции
        private double[] x_1_Values, x_2_Values, aValues, bValues;
        private double currentX_1, currentX_2, currentA_X, currentB_X;
        private double currentY_1, currentY_2, currentA_Y, currentB_Y;
        private int iterationNumber;

        public VisualizationForm(string functionExpression, double a, double b, double accuracy, double parameter)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.parameter = parameter;

            // Инициализация массивов значений
            InitializeArrays();

            // Отображение функции на графике
            DisplayFunctionGraph();

            // Обновление меток
            UpdateLabels();

            // Заблокировать кнопки
            Stop_label.Visible = false;
            new_ab_label.Visible = false;
            next_step_button.Enabled = false;
            yes_button_2.Enabled = false;
            no_button_2.Enabled = false;
            new_eps_label.Visible = false;
        }

        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (aValues, bValues, x_1_Values, x_2_Values) = CalculateFunctionOnInterval(a, b, accuracy, parameter);

            // Инициализируем текущие значения как начальные значения из массива
            currentX_1 = (a + b - parameter) / 2;
            currentX_2 = (a + b + parameter) / 2;
            currentA_X = a;
            currentB_X = b;
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
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            // Переинициализация массивов значений и переменных
            InitializeArrays();

            // Обновляем координаты точки текущей позиции
            currentASeries.Points.Clear();
            currentASeries.Points.AddXY(currentA_X, currentA_Y);

            currentBSeries.Points.Clear();
            currentBSeries.Points.AddXY(currentB_X, currentB_Y);

            currentX1Series.Points.Clear();
            currentX1Series.Points.AddXY(currentX_1, currentY_1);

            currentX2Series.Points.Clear();
            currentX2Series.Points.AddXY(currentX_2, currentY_2);

            // Добавление новой серии данных на график
            chart.Series.Add(series_new);

            // Обновляем значения на форме
            UpdateLabels();

            if (iterationNumber >= 1)
            {
                // Выводим вопрос f(x_1)<=f(x_2)?
                next_step_button.Enabled = false;
                yes_button.Enabled = true;
                no_button.Enabled = true;
            }

            // Обновление меток
            UpdateLabels();

            // Заблокировать кнопки
            Stop_label.Visible = false;
            next_step_button.Enabled = false;
            yes_button.Enabled = true;
            no_button.Enabled = true;
            yes_button_2.Enabled = false;
            no_button_2.Enabled = false;
            new_ab_label.Visible = false;
        }

        private void Next_step_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
            new_ab_label.Visible = false;

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
                // Выводим вопрос f(x_1)<=f(x_2)?
                next_step_button.Enabled = false;
                yes_button.Enabled = true;
                no_button.Enabled = true;
            }
        }

        private void yes_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;
            // Проверяем, верно ли условие f(x_1)<=f(x_2)?
            bool conditionMet = currentY_1 <= currentY_2;
            
            // Ответ пользователя
            if (conditionMet)
            {
                if (iterationNumber < aValues.Length - 1)
                {
                    double a = aValues[iterationNumber + 1];
                    double b = bValues[iterationNumber + 1];

                    new_ab_label.Visible = true;
                    // Выводим результаты 
                    new_ab_label.Text = $"Новый интервал: ({Math.Round(a, 4)}; {Math.Round(b, 4)})";
                    new_eps_label.Text = $"Достигнутая точность: {Math.Round((b - a) / 2, 4)}";
                }
                else if (iterationNumber == aValues.Length)
                {
                    currentB_X = currentX_2;

                    new_ab_label.Visible = true;
                    // Выводим результаты 
                    new_ab_label.Text = $"Новый интервал: ({Math.Round(currentA_X, 4)}; {Math.Round(currentB_X, 4)})";
                    new_eps_label.Text = $"Достигнутая точность: {Math.Round((currentB_X - currentA_X) / 2, 4)}";
                }

                // Переходим к следующему шагу
                yes_button.Enabled = false;
                no_button.Enabled = false;
                yes_button_2.Enabled = true;
                no_button_2.Enabled = true;
                new_ab_label.Visible = true;
            }
            else
            {
                question_1_label.BackColor = Color.Red;
            }

        }

        private void no_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = DefaultBackColor;

            // Проверяем, верно ли условие f(x_1)<=f(x_2)?
            bool conditionMet = currentY_1 <= currentY_2;
         
            // Ответ пользователя
            if (conditionMet)
            {
                question_1_label.BackColor = Color.Red;
            }
            else
            {
                if (iterationNumber < aValues.Length - 1)
                {
                    double a = aValues[iterationNumber + 1];
                    double b = bValues[iterationNumber + 1];

                    new_ab_label.Visible = true;
                    // Выводим результаты 
                    new_ab_label.Text = $"Новый интервал: ({Math.Round(a, 4)}; {Math.Round(b, 4)})";
                    new_eps_label.Text = $"Достигнутая точность: {Math.Round((b - a) / 2, 4)}";
                }
                else if (iterationNumber == aValues.Length)
                {
                    currentA_X = currentX_1;
                    new_ab_label.Visible = true;
                    // Выводим результаты 
                    new_ab_label.Text = $"Новый интервал: ({Math.Round(currentA_X, 4)}; {Math.Round(currentB_X, 4)})";
                    new_eps_label.Text = $"Достигнутая точность: {Math.Round((currentB_X - currentA_X) / 2, 4)}";
                }

                yes_button.Enabled = false;
                no_button.Enabled = false;
                yes_button_2.Enabled = true;
                no_button_2.Enabled = true;
                new_ab_label.Visible = true;

            }
        }

        private (double[] aValues, double[] bValues, double[] x_1Values, double[] x_2Values) CalculateFunctionOnInterval(double a, double b, double accuracy, double parameter)
        {
            List<double> aValues = new List<double>();
            List<double> bValues = new List<double>();
            List<double> x_1Values = new List<double>();
            List<double> x_2Values = new List<double>();

            while ((b - a) / 2 > accuracy)
            {
                double x1 = (a + b - parameter) / 2;
                double x2 = (a + b + parameter) / 2;
                aValues.Add(a);
                bValues.Add(b);
                x_1Values.Add(x1);
                x_2Values.Add(x2);

                double f1 = CalculateFunctionValue(x1);
                double f2 = CalculateFunctionValue(x2);
                if (f1 <= f2)
                {
                    b = x2;
                }
                else
                {                     
                    a = x1;
                }
            }
            aValues.Add(a);
            bValues.Add(b);
            double minX = (a + b) / 2;
            double minResult = CalculateFunctionValue(minX);

            return (aValues.ToArray(), bValues.ToArray(), x_1Values.ToArray(), x_2Values.ToArray());
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

        private void yes_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = DefaultBackColor;
            if (iterationNumber < aValues.Length - 1)
            {
                double a = aValues[iterationNumber + 1];
                double b = bValues[iterationNumber + 1];
                // Проверяем, верно ли условие  окончания интервала
                bool conditionMet = Math.Abs((b - a) / 2) <= accuracy;

                // Ответ пользователя
                if (conditionMet)
                {
                    // Выводим результаты 
                    yes_button_2.Enabled = false;
                    no_button_2.Enabled = false;
                    Stop_label.Visible = true;
                    Stop_label.Text = $"Минимум найден: x = {Math.Round((a + b) / 2, 4)}; F(x) = {Math.Round(CalculateFunctionValue((a + b) / 2), 4)}";
                }
                else
                {
                    question_2_label.BackColor = Color.Red;
                }
            }
        }

        private void no_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = DefaultBackColor;
            if (iterationNumber < aValues.Length - 1)
            {
                double a = aValues[iterationNumber + 1];
                double b = bValues[iterationNumber + 1];
                // Проверяем, верно ли условие  окончания интервала
                bool conditionMet = Math.Abs((b - a) / 2) <= accuracy;

                // Ответ пользователя
                if (conditionMet)
                {
                    question_2_label.BackColor = Color.Red;
                }
                else
                {
                    // Переходим к следующему шагу
                    next_step_button.Enabled = true;

                    yes_button_2.Enabled = false;
                    no_button_2.Enabled = false;
                }
            }            
        }
    }
}
