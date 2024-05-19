using System;
using System.Drawing;
using System.Windows.Forms;
using NCalc;

namespace Optimization_methods.Golden_Methods
{
    public partial class IterationTableForm_Golden : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm_Golden(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Выполнение метода золотого сечения и заполнение таблицы
            PerformGoldenSectionMethod();


            // Установка ширины столбцов и необходимых свойств
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = 100; // Устанавливаем ширину столбца
                column.ReadOnly = true; // Отключаем редактирование столбцов
                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Отключаем сортировку
            }
            dataGridView.Columns[0].Width = 80;

        }

        private void PerformGoldenSectionMethod()
        {
            // Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            int iteration = 0;
            double previousA = a;
            double previousB = b;
            double epsilon = (b - a) / 2;
            double tau = (Math.Sqrt(5) - 1) / 2; // Параметр алгоритма

            // Вычисление пробных точек
            double x1 = a + (3 - Math.Sqrt(5)) / 2 * (b - a);
            double x2 = a + (Math.Sqrt(5) - 1) / 2 * (b - a);

            // Вычисление значений функции в пробных точках
            double f_x1 = CalculateFunctionValue(x1);
            double f_x2 = CalculateFunctionValue(x2);

            while (epsilon > accuracy)
            {
                iteration++;

                // Добавление данных итерации в таблицу
                dataGridView.Rows.Add(iteration, a, b, epsilon, x1, f_x1, x2, f_x2);

                // Проверка изменения значений a и b и выделение соответствующих ячеек
                if (previousA != a)
                {
                    dataGridView.Rows[iteration - 1].Cells[1].Style.BackColor = Color.Yellow; // выделение ячейки с измененным a
                    previousA = a;
                }
                if (previousB != b)
                {
                    dataGridView.Rows[iteration - 1].Cells[2].Style.BackColor = Color.Yellow; // выделение ячейки с измененным b
                    previousB = b;
                }

                // Сравнение значений функции для определения нового отрезка
                if (f_x1 <= f_x2)
                {
                    b = x2;
                    x2 = x1;
                    f_x2 = f_x1;
                    x1 = b + a - x2;
                    f_x1 = CalculateFunctionValue(x1);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    f_x1 = f_x2;
                    x2 = b + a - x1;
                    f_x2 = CalculateFunctionValue(x2);
                }
                epsilon = tau * epsilon;
            }

            // Добавление последней итерации с результатами в таблицу
            double x_min = (a + b) / 2;
            double f_x_min = CalculateFunctionValue(x_min);

            dataGridView.Rows.Add(iteration + 1, a, b, (b - a) / 2, "", "", "", "");
            // Проверка изменения значений a и b в последней строке и выделение соответствующих ячеек
            if (previousA != a)
            {
                dataGridView.Rows[iteration].Cells[1].Style.BackColor = Color.Yellow; // выделение ячейки с измененным a
            }
            else if (previousB != b)
            {
                dataGridView.Rows[iteration].Cells[2].Style.BackColor = Color.Yellow; // выделение ячейки с измененным b
            }

            dataGridView.Rows.Add("Результат", "", "x_min = ", x_min, "f (x_min) = ", f_x_min, "", "");
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

        private void exit_button_dichotomies_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }
    }
}
