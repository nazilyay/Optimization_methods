﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private Series currentXSeries, lineSeries, series, horizontalLineSeries; // Серия для текущей позиции
        private double[] xValues, EpsValue;
        private double currentX;
        private double currentY, currentEps;
        private int iterationNumber;
        private TableLayoutPanel tableLayoutPanel;


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

            question_1_label.Text = $"Отрезок [{a}; {b}] \nвыбрано корректно?";

            FunctionGraph();
        }
        private void SetupUI()
        {
            yes_button_1.Enabled = no_button_1.Enabled = true;
            next_step_button.Enabled = yes_2_button.Enabled = no_2_button.Enabled = false;
            Stop_label.Visible = step_out_label.Visible = x_out_label.Visible = x_next.Visible = f_out_label.Visible = epsilon_label.Visible = prev_x_label.Visible = prev_def_label.Visible = def_label.Visible = false;
        }

        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (xValues, EpsValue) = CalculateFunctionOnInterval(a, b, accuracy);

            iterationNumber = 1;
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
                Font = new Font("Times New Roman", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None
            };
            panel.Controls.Add(label, columnIndex * 2, 0); // Добавляем текст в нечетные столбцы
        }

        private void FunctionGraph()
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 4; // Добавляем 4 столбца
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Каждый столбец занимает 25% ширины
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tableLayoutPanel);

            // Добавляем текст и линии в соответствующие столбцы
            AddLineAndLabel(Color.Red, "y = f(x)", 4, 15, 10, tableLayoutPanel, 0);
            AddLineAndLabel(Color.Violet, "y = f'(x)", 2, 15, 10, tableLayoutPanel, 1);
            AddLineAndLabel(Color.Green, "y = f''(x)", 2, 15, 10, tableLayoutPanel, 2);
            AddLineAndLabel(Color.Aqua, "y = f'''(x)", 2, 15, 10, tableLayoutPanel, 3);

            // Создание графика
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            panel_graph.Controls.Add(chart);

            // Создание области для графика
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Minimum = a;
            chartArea.AxisX.Maximum = b;

            // Вычисление максимального и минимального значения Y
            double minY = double.MaxValue;
            double maxY = double.MinValue;
            for (double x = a; x <= b; x += accuracy)
            {
                double y = CalculateFunctionValue(x);
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
            }
            chartArea.AxisY.Minimum = Math.Round(minY - 5);
            chartArea.AxisY.Maximum = Math.Round(maxY + 5);
            chart.ChartAreas.Add(chartArea);

            // Подписываем оси
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "Y";

            // Создаем серии данных для функций и их производных
            Color[] colors = { Color.Red, Color.Violet, Color.Green, Color.Aqua };
            Func<double, double>[] derivativeFunctions = { CalculateFunctionValue, CalculateDerivative, CalculateSecondDerivative, CalculateThirdDerivative };
            int[] lineWidths = { 4, 2, 2, 2 }; // Разные ширины линий

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
                }

                // Добавление серии данных на график
                chart.Series.Add(series);
            }

            // Создание серии данных для горизонтальной линии y=0
            horizontalLineSeries = new Series();
            horizontalLineSeries.ChartType = SeriesChartType.Line;
            horizontalLineSeries.BorderWidth = 1;
            horizontalLineSeries.Color = Color.Black;
            for (double x = chartArea.AxisX.Minimum; x <= chartArea.AxisX.Maximum; x += accuracy)
            {
                double y = 0;
                horizontalLineSeries.Points.AddXY(x, y);
            }
            chart.Series.Add(horizontalLineSeries);
        }
        private void ClearGraph()
        {
            // Очистка панели с таблицей
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.Dispose();

            // Очистка графика и его области
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Dispose();

            currentXSeries?.Dispose();
            lineSeries?.Dispose();

            // Очистка панели, содержащей график
            panel_graph.Controls.Clear();
        }
        private void DisplayFunctionGraph()
        {
            // Создание графика
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            panel_graph.Controls.Add(chart);

            // Создание области для графика
            chartArea = new ChartArea();
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
            chartArea.AxisY.Minimum = Math.Round(minY - 2);
            chartArea.AxisY.Maximum = Math.Round(maxY + 2);

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

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            step_out_label.Text = $"Шаг: {iterationNumber}";
            prev_x_label.Text = $"x_(k-1) = {Math.Round(xValues[iterationNumber - 1], 6)}";
            x_out_label.Text = $"x_k = {Math.Round(xValues[iterationNumber], 6)}";
            prev_def_label.Text = $"F'(x_(k-1)) = {Math.Round(CalculateDerivative(xValues[iterationNumber - 1]), 6)}";
            def_label.Text = $"F'(x_k) = {Math.Round(CalculateDerivative(xValues[iterationNumber]), 6)}";
            x_next.Text = $"x_(k+1) = {Math.Round(xValues[iterationNumber + 1], 6)}";
            f_out_label.Text = $"F(x_(k+1)) = {Math.Round(CalculateFunctionValue(xValues[iterationNumber + 1]), 6)}";
            epsilon_label.Text = $"Точность = {Math.Round(EpsValue[iterationNumber], 6)}";
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
            question_1_label.BackColor = DefaultBackColor;
            // Переходим к следующему шагу
            iterationNumber++;

            // Проверяем, выходим ли за границы массива значений
            if (iterationNumber >= xValues.Length)
            {
                next_step_button.Enabled = false;
                return;
            }

            currentX = xValues[iterationNumber];
            currentEps = EpsValue[iterationNumber];
            currentY = CalculateFunctionValue(currentX);

            // Определение новых границ осей
            double minX = currentX;
            double minY = currentY;

            // Установка новых границ осей
            chartArea.AxisX.Minimum = Math.Round(minX) - 1; // Примерное новое минимальное значение по X
            chartArea.AxisX.Maximum = Math.Round(minX) + 1; // Примерное новое максимальное значение по X
            chartArea.AxisY.Minimum = Math.Round(minY) - 1; // Примерное новое минимальное значение по Y
            chartArea.AxisY.Maximum = Math.Round(minY) + 1; // Примерное новое максимальное значение по Y

            // Обновляем координаты точки текущей позиции
            currentXSeries.Points.Clear();
            currentXSeries.Points.AddXY(currentX, currentY);



            lineSeries.Points.Clear();

            double derivative = CalculateDerivative(currentX);
            double x1 = currentX - 10; // Левая граница от точки x
            double y1 = currentY - derivative * 10; // Определяем y на основе производной и расстояния
            double x2 = currentX + 10; // Правая граница от точки x
            double y2 = currentY + derivative * 10; // Определяем y на основе производной и расстояния

            // Добавляем точки для продолжения прямой
            lineSeries.Points.AddXY(x1, y1);
            lineSeries.Points.AddXY(x2, y2);

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
            question_1_label.BackColor = DefaultBackColor;

            yes_button_1.Enabled = false;
            no_button_1.Enabled = false;

            yes_2_button.Enabled = no_2_button.Enabled = true;
            step_out_label.Visible = x_out_label.Visible = x_next.Visible = f_out_label.Visible = epsilon_label.Visible = prev_x_label.Visible = prev_def_label.Visible = def_label.Visible = true;
            ClearGraph();
            DisplayFunctionGraph();
            UpdateLabels();
        }

        private void no_button_1_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.Red;
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
            EpsValue.Add(epsilon);

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

    }
}
