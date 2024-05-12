using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Optimization_methods.Search_method
{
    public partial class VisualizationForm_Search : Form
    {
        private Chart chart;
        private double a, b, accuracy;
        private string functionExpression;
        private double currentX, currentY, x_min, f_x_min, step, min;
        private int iterationNumber;
        private bool isMinimumFound;
        private int mistake;
        private bool end;
        public VisualizationForm_Search(string functionExpression, double a, double b, double accuracy, double min, double f_x_min)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.min = min;
            this.f_x_min = f_x_min;

            mistake = 0;
            end = false;
            // Инициализация переменных
            currentX = a;
            currentY = CalculateFunctionValue(currentX);
            x_min = a;
            f_x_min = currentY;
            step = accuracy;
            iterationNumber = 0;
            isMinimumFound = false;

            // Установка ширины столбцов
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;

            this.FormClosing += VisualizationForm_Closing;

            // Отображение функции на графике
            DisplayFunctionGraph();

            previous_step_button.Enabled = false;
            next_step_button.Enabled = false;
            end_button.Enabled = false;
            begin_button.Enabled = false;
            Error_number_label.Visible = false;
            Result_label.Visible = false;
            label1.Visible = false;
            min_button.Visible = false;
        }
        private void VisualizationForm_Closing(object sender, FormClosingEventArgs e)
        {
            End_Form endMethods = new End_Form(mistake, "Метода перебора", end, min, CalculateFunctionValue(min));
            endMethods.Show();
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
                double y = CalculateFunctionValue(x);
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
            pointSeries.Color = Color.Red;

            // Добавление начальной точки на график
            pointSeries.Points.AddXY(currentX, currentY);
            chart.Series.Add(pointSeries);
        }

        private double CalculateFunctionValue(double x)
        {
            Expression exp = new Expression(functionExpression);
            exp.Parameters["x"] = x;
            return Convert.ToDouble(exp.Evaluate());
        }

        private void AddRowToDataGridView(double step, double x, double fx, double xmin, double fxmin)
        {
            dataGridView.Rows.Add(step, x, fx, xmin, fxmin);
        }

        private void RemoveRowFromDataGridView(int rowIndex)
        {
            if (rowIndex > 0 && rowIndex < dataGridView.Rows.Count)
            {
                dataGridView.Rows.RemoveAt(rowIndex - 1);
            }
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            // Сброс переменных к исходным значениям
            currentX = a;
            currentY = CalculateFunctionValue(currentX);
            x_min = a;
            f_x_min = currentY;
            iterationNumber = 0;
            isMinimumFound = false;
            number_textBox.Enabled = true;
            number_button.Enabled = true;
            previous_step_button.Enabled = false;
            next_step_button.Enabled = false;
            end_button.Enabled = false;
            begin_button.Enabled = false;
            label1.Visible = false;
            min_button.Visible = false;
            min_button.BackColor = Color.FromArgb(245, 245, 240);
            Result_label.Visible = false;

            // Обновляем координаты точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            // Очищаем DataGridView
            dataGridView.Rows.Clear();
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
            double Y = CalculateFunctionValue(currentX);
            double nextY = CalculateFunctionValue(currentX + accuracy);

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

                // Показать label1 и min_button
                label1.Visible = true;
                min_button.Visible = true;
            }

            previous_step_button.Enabled = true;

            // Добавляем данные в DataGridView
            AddRowToDataGridView(iterationNumber, currentX, currentY, x_min, f_x_min);
        }


        private void Previous_step_button_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            min_button.Visible = false;
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
            currentY = CalculateFunctionValue(currentX);

            // Обновляем координаты точки на графике
            chart.Series[1].Points[0].XValue = currentX;
            chart.Series[1].Points[0].YValues[0] = currentY;

            next_step_button.Enabled = true;

            // Удаляем последнюю строку из DataGridView
            RemoveRowFromDataGridView(dataGridView.Rows.Count - 1);
        }

        private double CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double minResult = double.MaxValue;
            double minX = 0;

            for (double x = a; x <= b; x += accuracy)
            {
                double result = CalculateFunctionValue(x);

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
            end_button.Enabled = false;
            begin_button.Enabled = false;
            Error_number_label.Visible = false;
            Result_label.Visible = false;
            label1.Visible = false;
            min_button.Visible = false;
            min_button.BackColor = Color.FromArgb(245, 245, 240);

            // Сброс переменных к исходным значениям
            currentX = a;
            currentY = CalculateFunctionValue(currentX);
            x_min = a;
            f_x_min = currentY;
            iterationNumber = 0;
            isMinimumFound = false;

            // Считываем значение из number_textBox
            double value;
            if (double.TryParse(number_textBox.Text, out value))
            {
                double n = (b - a) / accuracy;
                if (Math.Abs(n - Math.Round(value)) < double.Epsilon)
                {
                    number_textBox.Enabled = false;
                    number_button.Enabled = false;
                    previous_step_button.Enabled = true;
                    stop_button.Enabled = true;
                    next_step_button.Enabled = true;
                    end_button.Enabled = true;
                    begin_button.Enabled = true;
                }
                else
                {
                    mistake++;
                    Error_number_label.Text = "Ошибка!";
                    Error_number_label.Visible = true;
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


        private void end_button_Click(object sender, EventArgs e)
        {
            // Переходим на последний шаг
            while (currentX + accuracy <= b)
            {
                Next_step_button_Click(sender, e);
            }
        }

        private void begin_button_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            min_button.Visible = false;
            // Переходим на первый шаг
            while (currentX - accuracy >= a)
            {
                Previous_step_button_Click(sender, e);
            }
        }

        private void min_button_Click(object sender, EventArgs e)
        {
            double minFx = f_x_min;

            // Проверяем, есть ли выбранная строка с минимальным значением f(x)
            bool selectedMinimum = false;
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                double fx = Convert.ToDouble(row.Cells[2].Value);
                if (Math.Abs(fx - minFx) < double.Epsilon)
                {
                    selectedMinimum = true;
                    break;
                }
            }

            // Если строка с минимальным значением f(x) выбрана, загораем кнопку зеленым
            if (selectedMinimum)
            {
                end = true;
                min_button.BackColor = Color.LightGreen;
                Result_label.Text = "Верно!";
                Result_label.Visible = true;
                Result_label.BackColor = Color.LightGreen;
                // Сброс переменных к исходным значениям
                currentX = a;
                currentY = CalculateFunctionValue(currentX);
                x_min = a;
                f_x_min = currentY;
                iterationNumber = 0;
                isMinimumFound = false;
                number_textBox.Enabled = true;
                number_button.Enabled = true;
                previous_step_button.Enabled = false;
                next_step_button.Enabled = false;
                end_button.Enabled = false;
                begin_button.Enabled = false;

                // Обновляем координаты точки на графике
                chart.Series[1].Points[0].XValue = currentX;
                chart.Series[1].Points[0].YValues[0] = currentY;

                // Очищаем DataGridView
                dataGridView.Rows.Clear();
            }
            else
            {
                mistake++;
                min_button.BackColor = Color.Red;
                Result_label.Text = "Не верно!";
                Result_label.Visible = true;
                Result_label.BackColor = Color.Red;
            }
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }
    }
}

