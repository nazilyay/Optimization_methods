using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace Optimization_methods.Newton_Methods
{
    public partial class IterationTableForm_Newton : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;
        private double x_0;

        public IterationTableForm_Newton(string functionExpression, double a, double b, double accuracy, double x_0)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;
            this.x_0 = x_0;

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
        {// Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            int iteration = 0;
            double x_k = x_0 - CalculateDerivative(x_0) / CalculateSecondDerivative(x_0);// Начальное приближение
            double epsilon = Math.Abs(x_k - x_0); // Инициализация epsilon для входа в цикл

            dataGridView.Rows.Add(iteration, x_0, x_k, CalculateDerivative(x_0), CalculateSecondDerivative(x_0), CalculateFunctionValue(x_k), epsilon);

            while (epsilon > accuracy)
            {
                iteration++;
                // Вычисление значения производной f'(x_k)
                double f_prime_x_k = CalculateDerivative(x_k);

                // Вычисление значения второй производной f''(x_k)
                double f_double_prime_x_k = CalculateSecondDerivative(x_k);

                // Проверка деления на ноль
                if (Math.Abs(f_double_prime_x_k) < double.Epsilon)
                {
                    MessageBox.Show("Вторая производная равна нулю. Метод Ньютона не сходится.");
                    return;
                }

                double x_k_plus_1 = x_k - f_prime_x_k / f_double_prime_x_k; // Новая точка x_{k+1}

                double f = CalculateFunctionValue(x_k_plus_1);

                // Вычисление epsilon для остановки алгоритма
                epsilon = Math.Abs(x_k_plus_1 - x_k);

                // Добавление данных итерации в таблицу
                dataGridView.Rows.Add(iteration, x_k, x_k_plus_1, f_prime_x_k, f_double_prime_x_k, f, epsilon);

                x_k = x_k_plus_1; // Обновление текущей точки
            }

            // Добавление строки с результатом в таблицу
            double x_min = x_k;
            double f_x_min = CalculateFunctionValue(x_min);

            dataGridView.Rows.Add("Результат:", "x_min = ", x_min, "f (x_min) = ", f_x_min, "", "");

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


        private void exit_button_middle_Click(object sender, EventArgs e)
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
