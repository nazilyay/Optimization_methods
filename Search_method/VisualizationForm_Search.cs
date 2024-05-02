using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Optimization_methods.Search_method
{
    public partial class VisualizationForm_Search : Form
    {
        private Chart chart;
        private double a, b, accuracy;
        private string functionExpression;
        private double currentX, currentY, x_min, f_x_min;
        private double step;
        private int iterationNumber;
        private bool isMinimumFound;

        public VisualizationForm_Search(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = a;
            double y = Convert.ToDouble(exp.Evaluate());

            // Инициализация переменных
            currentX = a;
            currentY = y; // Установим высокое значение, чтобы точка была видна на графике
            x_min = a;

            f_x_min = y; // Инициализируем f(x_min) большим значением для корректного поиска минимума
            step = accuracy; // Шаг метода перебора
            iterationNumber = 0;
            isMinimumFound = false;

            // Отображение функции на графике
            DisplayFunctionGraph();

            // Обновление меток
            UpdateLabels();

            // Заблокировать кнопки
            yes_button.Enabled = false;
            no_button.Enabled = false;
            Error_number_label.Visible = false;
            error_label.Visible = false;
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
            double minY = double.MaxValue;
            double maxY = double.MinValue;
            for (double x = a; x <= b; x += accuracy)
            {
                Expression exp = new Expression(functionExpression);
                exp.Parameters["x"] = x;
                double y = Convert.ToDouble(exp.Evaluate());
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
            }
            chartArea.AxisY.Minimum = Math.Round(minY - 5);
            chartArea.AxisY.Maximum = Math.Round(maxY + 5); ;

            // Добавление области на график
            chart.ChartAreas.Add(chartArea);

            // Создание серии данных для графика функции
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;

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
            x_out_label.Text = currentX.ToString();
            f_out_label.Text = currentY.ToString();
            x_min_out_label.Text = x_min.ToString();
            f_min_out_label.Text = f_x_min.ToString();
            step_out_label.Text = iterationNumber.ToString();
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            // Сброс переменных к исходным значениям
            currentX = a;
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = currentX;
            currentY = Convert.ToDouble(exp.Evaluate());
            x_min = a;
            f_x_min = currentY;
            iterationNumber = 0;
            isMinimumFound = false;
            number_button.BackColor = DefaultBackColor;

            // Обновляем координаты точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            // Обновление меток
            UpdateLabels();

            // Активация кнопок next_step_button и previous_step_button
            next_step_button.Enabled = true;
            previous_step_button.Enabled = true;
            number_button.Enabled = true;
            number_textBox.Enabled = true;

            // Делаем кнопки yes_button и no_button недоступными
            yes_button.Enabled = false;
            no_button.Enabled = false;
        }
        private void Next_step_button_Click(object sender, EventArgs e)
        {
            // Переходим к следующей итерации
            currentX += step;
            iterationNumber++;

            // Проверяем, выйдем ли мы за границы интервала после шага
            if (currentX + accuracy > b)
            {
                next_step_button.Enabled = false;
            }

            // Вычисляем значение функции для текущего X
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = currentX;
            double Y = Convert.ToDouble(exp.Evaluate());
            exp.Parameters["x"] = currentX + accuracy;
            double nextY = Convert.ToDouble(exp.Evaluate());

            // Проверяем, началось ли увеличение значения функции после нахождения минимума
            if (Y > currentY && isMinimumFound)
            {
                next_step_button.Enabled = false; // Останавливаем дальнейший перебор
                return;
            }

            // Проверяем, началось ли увеличение значения функции после нахождения минимума
            if (nextY > Y)
            {
                next_step_button.Enabled = false; // Останавливаем дальнейший перебор
            }
            currentY = Y; // Обновляем значение текущего Y

            // Если найден новый минимум, обновляем значения x_min и f_x_min
            if (currentY < f_x_min)
            {
                x_min = currentX;
                f_x_min = currentY;
            }

            // Обновляем положение точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            // Если значение функции равно минимуму на интервале, то считаем, что минимум найден
            if (currentY == CalculateFunctionOnInterval(functionExpression, a, b, accuracy))
            {
                isMinimumFound = true;
            }

            // Обновляем метки
            UpdateLabels();

            previous_step_button.Enabled = true;

        }

        private void Previous_step_button_Click(object sender, EventArgs e)
        {
            // Переходим к предыдущей итерации
            currentX -= step;
            iterationNumber--;

            // Проверяем, выйдем ли мы за границы интервала после шага
            if (currentX - accuracy < a)
            {
                previous_step_button.Enabled = false;
            }

            // Если найден новый минимум, обновляем значения x_min и f_x_min
            if (currentY < f_x_min)
            {
                x_min = currentX;
                f_x_min = currentY;
            }

            // Вычисляем значение функции для текущего X
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = currentX;
            currentY = Convert.ToDouble(exp.Evaluate());

            // Обновляем координаты точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            // Обновляем метки
            UpdateLabels();

            next_step_button.Enabled = true;
        }


        private void yes_button_Click(object sender, EventArgs e)
        {
            number_button.BackColor = DefaultBackColor;
            error_label.Visible = false;

            // Если пользователь нажал, значит минимум еще не найден
            if (isMinimumFound)
            {
                error_label.Text = "Ошибка! Минимум уже найден.";
                error_label.Visible = true;
                yes_button.Enabled = false;
                return;
            }

            // Переходим к следующей итерации
            currentX += step;
            iterationNumber++;

            if (currentX > b)
            {
                return;
            }

            // Вычисляем значение функции для текущего X
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = currentX;
            currentY = Convert.ToDouble(exp.Evaluate());

            // Если найден новый минимум, обновляем значения x_min и f_x_min
            if (currentY < f_x_min)
            {
                x_min = currentX;
                f_x_min = currentY;
            }
            // Обновляем положение точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            if (currentY == CalculateFunctionOnInterval(functionExpression, a, b, accuracy))
            {
                isMinimumFound = true;
            }
            // Обновляем метки
            UpdateLabels();
        }

        private void no_button_Click(object sender, EventArgs e)
        {
            error_label.Visible = false;
            // Если пользователь нажал, значит минимум найден
            if (!isMinimumFound)
            {
                error_label.Text = "Ошибка! Минимум не найден.";
                error_label.Visible = true;
                return;
            }
            number_button.Enabled = true;
            yes_button.Enabled = false;
            no_button.Enabled = false;
            error_label.Text = "Верно! Вычисления окончены!";
            error_label.Visible = true;
        }

        private double CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double minResult = double.MaxValue;
            double minX = 0;

            for (double x = a; x <= b; x += accuracy)
            {
                Expression exp = new Expression(expression);
                exp.Parameters["x"] = x;
                double result = Convert.ToDouble(exp.Evaluate());

                // Находим минимальное значение функции
                if (result < minResult)
                {
                    minResult = result;
                    minX = x;
                }
            }

            return minResult;
        }

        private void number_button_Click(object sender, EventArgs e)
        {
            // Заблокировать кнопки
            previous_step_button.Enabled = false;
            next_step_button.Enabled = false;
            yes_button.Enabled = false;
            no_button.Enabled = false;
            Error_number_label.Visible = false;

            // Сброс переменных к исходным значениям
            currentX = a;
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = currentX;
            currentY = Convert.ToDouble(exp.Evaluate());
            x_min = a;
            f_x_min = currentY;
            iterationNumber = 0;
            isMinimumFound = false;

            // Обновление меток
            UpdateLabels();

            // Считываем значение из number_textBox
            double value;
            if (double.TryParse(number_textBox.Text, out value))
            {
                double n = (b - a) / accuracy;
                if (Math.Abs(n - Math.Round(value)) < double.Epsilon)
                {
                    number_textBox.Enabled = false;

                    yes_button.Enabled = true;
                    no_button.Enabled = true;

                    number_button.Enabled = false;

                    number_button.BackColor = Color.Green;

                }
                else
                {
                    Error_number_label.Text = "Ошибка!";
                    Error_number_label.Visible = true;
                    number_button.BackColor = Color.Red;

                }
            }
            else
            {
                Error_number_label.Text = "Введите корректное число.";
                Error_number_label.Visible = true;
            }
        }

        private void exit_button_search_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
