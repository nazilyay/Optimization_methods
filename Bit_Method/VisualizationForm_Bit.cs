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

namespace Optimization_methods.Bit_Method
{
    public partial class VisualizationForm_Bit : Form
    {
        private Chart chart;
        private double a, b, accuracy;
        private string functionExpression;
        private double[] xValues, fxValues;
        private double currentX, currentY, prevY, prevX, step;
        private int iterationNumber;
        private int mistake;
        private bool end;
        public VisualizationForm_Bit(string functionExpression, double a, double b, double accuracy)
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
            this.FormClosing += VisualizationForm_Closing;
            // Заблокировать кнопки
            Stop_label.Visible = false;
            yes_button.Enabled = false;
            no_button.Enabled = false;
            yes_button_2.Enabled = false;
            no_button_2.Enabled = false;
            yes_button_3.Enabled = false;
            no_button_3.Enabled = false;
        }
        private void VisualizationForm_Closing(object sender, FormClosingEventArgs e)
        {
            End_Form endMethods = new End_Form(mistake, "Метода поразрядного перебора", end, xValues[xValues.Length - 2], CalculateFunctionValue(xValues[xValues.Length - 2]));
            endMethods.Show();
        }

        private void InitializeArrays()
        {
            // Вычисляем массив значений x и f(x) на интервале [a, b]
            (xValues, fxValues) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);
            mistake = 0;
            end = false;
            // Инициализируем текущие значения как начальные значения из массива
            currentX = a;
            currentY = CalculateFunctionValue(a);
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
            double minY = fxValues[0];
            double maxY = fxValues[0];
            foreach (var y in fxValues)
            {
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

            // Создание серии данных для точки
            Series pointSeries = new Series();
            pointSeries.ChartType = SeriesChartType.Point;
            pointSeries.MarkerStyle = MarkerStyle.Circle;
            pointSeries.MarkerSize = 10;
            pointSeries.Color = System.Drawing.Color.Red;

            // Добавление начальной точки на график
            pointSeries.Points.AddXY(currentX, currentY);
            chart.Series.Add(pointSeries);
        }

        private void UpdateLabels()
        {
            x_0_out_label.Text = prevX.ToString();
            f_0_out_label.Text = prevY.ToString();
            step_out_label.Text = iterationNumber.ToString();
            x_1_out_label.Text = currentX.ToString();
            f_x_1_out_label.Text = currentY.ToString();
            h_out_label.Text = (currentX - prevX).ToString();
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            question_3_label.BackColor = Color.FromArgb(245, 245, 240); ;
            question_1_label.BackColor = Color.FromArgb(245, 245, 240); ;
            question_2_label.BackColor = Color.FromArgb(245, 245, 240); ;
            // Переинициализация массивов значений и переменных
            InitializeArrays();

            // Обновляем координаты точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            // Обновление меток
            UpdateLabels();

            // Активация кнопок next_step_button и previous_step_button
            next_step_button.Enabled = true;
            // Заблокировать кнопки
            Stop_label.Visible = false;
            yes_button.Enabled = false;
            no_button.Enabled = false;
            yes_button_2.Enabled = false;
            no_button_2.Enabled = false;
            yes_button_3.Enabled = false;
            no_button_3.Enabled = false;
        }

        private void Next_step_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240); ;

            // Сохраняем значения текущего шага в качестве значений предыдущего шага
            prevX = currentX;
            prevY = currentY;

            // Переходим к следующему шагу
            iterationNumber++;

            // Проверяем, выходим ли за границы массива значений
            if (iterationNumber >= xValues.Length)
            {
                next_step_button.Enabled = false;
                end = true;
                return;
            }

            // Обновляем текущие значения
            currentX = xValues[iterationNumber];
            currentY = fxValues[iterationNumber];


            // Обновляем координаты точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            // Обновляем значения на форме
            UpdateLabels();

            if (iterationNumber >= 1)
            {
                // Выводим вопрос f(x_0) > f(x_1)
                question_1_label.Visible = true;
                next_step_button.Enabled = false;
                yes_button.Enabled = true;
                no_button.Enabled = true;
            }

        }

        private void yes_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240); ;
            // Проверяем, верно ли условие f(x_0) > f(x_1)
            bool conditionMet = prevY > currentY;

            // Ответ пользователя
            if (conditionMet)
            {
                // Выводим результаты 
                x_new_label.Text = $"x_min = {currentX}";
                f_new_label.Text = $"F(x_min) = {currentY}";

                // Переходим к следующему шагу
                yes_button.Enabled = false;
                no_button.Enabled = false;
                yes_button_2.Enabled = true;
                no_button_2.Enabled = true;
            }
            else
            {
                mistake++;
                question_1_label.BackColor = Color.Red;
            }

        }

        private void no_button_Click(object sender, EventArgs e)
        {
            question_1_label.BackColor = Color.FromArgb(245, 245, 240); ;
            // Проверяем, верно ли условие f(x_0) > f(x_1)
            bool conditionMet = prevY > currentY;

            // Ответ пользователя
            if (conditionMet)
            {
                mistake++;
                question_1_label.BackColor = Color.Red;
            }
            else
            {
                yes_button.Enabled = false;
                no_button.Enabled = false;
                yes_button_3.Enabled = true;
                no_button_3.Enabled = true;
            }
        }

        private (double[], double[]) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double h = (b - a) / 4.0;
            double x = a;
            double prevResult = CalculateFunctionValue(x);

            List<double> xValues = new List<double>();
            List<double> fxValues = new List<double>();
            xValues.Add(x);
            fxValues.Add(prevResult);

            while (true)
            {
                double nextX = x + h;
                double nextResult = CalculateFunctionValue(nextX);
                xValues.Add(nextX);
                fxValues.Add(nextResult);

                if (prevResult > nextResult)
                {
                    x = nextX;
                    prevResult = nextResult;

                    if (a < x && x < b)
                        continue;
                    else
                    {
                        if (Math.Abs(h) <= accuracy)
                            break;

                        h = -h / 4.0;
                        x = nextX;
                        prevResult = nextResult;
                    }
                }
                else
                {
                    if (Math.Abs(h) <= accuracy)
                        break;

                    h = -h / 4.0;
                    x = nextX;
                    prevResult = nextResult;
                }
            }

            return (xValues.ToArray(), fxValues.ToArray());
        }

        private double CalculateFunctionValue(double x)
        {
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = x;
            return Convert.ToDouble(exp.Evaluate());
        }

        private void exit_button_search_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void yes_button_2_Click(object sender, EventArgs e)
        {
            question_2_label.BackColor = Color.FromArgb(245, 245, 240); ;

            // Проверяем, верно ли условие x принадлежит интервалу?
            bool conditionMet = (currentX < b) && (currentX > a);

            // Ответ пользователя
            if (conditionMet)
            {
                // Переходим к следующему шагу
                next_step_button.Enabled = true;

                yes_button_2.Enabled = false;
                no_button_2.Enabled = false;
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
            // Проверяем, верно ли условие f(x_0) > f(x_1)
            bool conditionMet = (currentX < b) && (currentX > a);

            // Ответ пользователя
            if (conditionMet)
            {
                mistake++;
                question_2_label.BackColor = Color.Red;
            }
            else
            {
                yes_button_2.Enabled = false;
                no_button_2.Enabled = false;

                yes_button_3.Enabled = true;
                no_button_3.Enabled = true;
            }
        }

        private void yes_button_3_Click(object sender, EventArgs e)
        {
            question_3_label.BackColor = Color.FromArgb(245, 245, 240); ;

            // Проверяем, верно ли условие  окончания интервала
            bool conditionMet = Math.Abs(prevX - currentX) <= accuracy;

            // Ответ пользователя
            if (conditionMet)
            {
                yes_button_3.Enabled = false;
                no_button_3.Enabled = false;
                Stop_label.Visible = true;
                end = true;
            }
            else
            {
                mistake++;
                question_3_label.BackColor = Color.Red;
            }

        }

        private void no_button_3_Click(object sender, EventArgs e)
        {
            question_3_label.BackColor = Color.FromArgb(245, 245, 240); ;

            // Проверяем, верно ли условие  окончания интервала
            bool conditionMet = Math.Abs(prevX - currentX) <= accuracy;

            // Ответ пользователя
            if (conditionMet)
            {
                mistake++;
                question_3_label.BackColor = Color.Red;
            }
            else
            {
                // Выводим результаты 
                x_new_label.Text = $"x_min = {currentX}";
                f_new_label.Text = $"F(x_min) = {currentY}";
                new_step_label.Text = $"h = {-(currentX - prevX) / 4}";

                // Переходим к следующему шагу
                next_step_button.Enabled = true;

                yes_button_3.Enabled = false;
                no_button_3.Enabled = false;
            }
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }

    }
}
