using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Optimization_methods.Dichotomies_Method
{
    public partial class IterationTableForm_Dichotomies : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;
        private double parameter;

        public IterationTableForm_Dichotomies(string functionExpression, double a, double b, double accuracy, double parameter)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.parameter = parameter;

            // Выполнение метода перебора и заполнение таблицы
            PerformDichotomyMethod();

            // Установка ширины столбцов
            dataGridView.Columns[0].Width = 80;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;
            dataGridView.Columns[7].Width = 100;

        }
        private void PerformDichotomyMethod()
        {
            // Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            int iteration = 0;
            double previousA = a;
            double previousB = b;

            while ((b - a) / 2 > accuracy)
            {
                iteration++;

                // Вычисление пробных точек
                double x1 = (a + b - parameter) / 2;
                double x2 = (a + b + parameter) / 2;

                // Вычисление значений функции в пробных точках
                double f_x1 = CalculateFunctionValue(x1);
                double f_x2 = CalculateFunctionValue(x2);

                double epsilon = (b - a) / 2;
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
                }
                else
                {
                    a = x1;
                }
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
    }
}
