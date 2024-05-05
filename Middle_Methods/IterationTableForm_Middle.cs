using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace Optimization_methods.Middle_Methods
{
    public partial class IterationTableForm_Middle : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm_Middle(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Выполнение метода средней точки и заполнение таблицы
            PerformMiddlePointMethod();

            // Установка ширины столбцов
            dataGridView.Columns[0].Width = 80;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;

        }

        private void PerformMiddlePointMethod()
        {
            // Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            int iteration = 0;
            double epsilon = (b - a) / 2;

            while (epsilon > accuracy)
            {
                // Вычисление середины интервала
                double x_k = (a + b) / 2;

                // Вычисление значения производной f'(x_k)
                double f_prime_x_k = CalculateDerivativeValue(x_k);

                // Выбор нового интервала в зависимости от знака производной
                if (f_prime_x_k > 0)
                {
                    // Добавление данных итерации в таблицу
                    dataGridView.Rows.Add(iteration + 1, a, b, x_k, f_prime_x_k, "+", epsilon);
                    b = x_k;
                }
                else
                {
                    // Добавление данных итерации в таблицу
                    dataGridView.Rows.Add(iteration + 1, a, b, x_k, f_prime_x_k, "-", epsilon);
                    a = x_k;
                }

                // Окрашиваем предыдущую строку (если она существует)
                if (iteration > 0)
                {
                    if ((double)dataGridView.Rows[iteration - 1].Cells[1].Value != a)
                        dataGridView.Rows[iteration].Cells[1].Style.BackColor = Color.Yellow;
                    else
                        dataGridView.Rows[iteration].Cells[2].Style.BackColor = Color.Yellow;
                }

                epsilon = (b - a) / 2;
                iteration++;
            }

           

            // Добавляем последнюю итерацию
            double x = (a + b) / 2;
            double f = CalculateDerivativeValue(x);
            if (f > 0)
            {
                dataGridView.Rows.Add(iteration + 1, a, b, x, f, "+", epsilon);
            }
            else
            {
                dataGridView.Rows.Add(iteration + 1 , a, b, x, f, "-", epsilon);
            }

 // Окрашиваем последнюю добавленную строку
            if (iteration > 0)
            {
                if ((double)dataGridView.Rows[iteration - 1].Cells[1].Value != a)
                    dataGridView.Rows[iteration - 1].Cells[1].Style.BackColor = Color.Yellow;
                else dataGridView.Rows[iteration].Cells[2].Style.BackColor = Color.Yellow;
            }
            // Добавление строки с результатом в таблицу
            double x_min = (a + b) / 2;
            double f_x_min = CalculateFunctionValue(x_min);

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

        private double CalculateDerivativeValue(double x)
        {
            double h = 0.0001; // шаг для аппроксимации производной
            double xPlusH = x + h;
            double xMinusH = x - h;

            // Аппроксимация производной по формуле конечных разностей
            double derivative = (CalculateFunctionValue(xPlusH) - CalculateFunctionValue(xMinusH)) / (2 * h);

            return derivative;
        }


        private void exit_button_middle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
