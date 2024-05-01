using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NCalc;


namespace Optimization_methods
{
    public partial class IterationTableForm : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Выполнение метода перебора и заполнение таблицы
            PerformBruteForceMethod();
        }

        private void PerformBruteForceMethod()
        {
            // Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            // Начальное значение минимального результата и соответствующего x
            double minResult = double.MaxValue;
            double minX = 0;

            // Вычисление минимального значения функции на отрезке с использованием перебора
            int iteration = 0;
            for (double x = a; x <= b; x += accuracy)
            {
                // Вычисление значения функции для текущего x
                double result = CalculateFunctionValue(functionExpression, x);

                // Запись данных итерации в таблицу
                dataGridView.Rows.Add(iteration, x, result, minX, minResult, accuracy);

                // Проверка, является ли текущий результат минимальным
                if (result < minResult)
                {
                    minResult = result;
                    minX = x;
                }

                iteration++;
            }
        }

        private double CalculateFunctionValue(string expression, double x)
        {
            try
            {
                Expression e = new Expression(expression);
                e.Parameters["x"] = x;
                object result = e.Evaluate();
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                return double.NaN; // В случае ошибки возвращаем NaN
            }
        }

        private void exit_button_search_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
