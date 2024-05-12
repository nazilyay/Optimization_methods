using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace Optimization_methods.Secant_Methods
{
    public partial class IterationTableForm_Chord : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm_Chord(string functionExpression, double a, double b, double accuracy)
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
            dataGridView.Columns[7].Width = 100;
        }
        private void PerformMiddlePointMethod()
        {// Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            int iteration = 0;
            double x_prev = a;
            double x_curr = b;
            double epsilon = Math.Abs(x_curr - x_prev); // Инициализация epsilon для входа в цикл
            double x_new = x_curr;

            while (epsilon > accuracy)
            {
                x_new = x_prev - CalculateDerivative(x_prev) * (x_curr - x_prev) / (CalculateDerivative(x_curr) - CalculateDerivative(x_prev));// Начальное приближение
                epsilon = Math.Abs(x_curr - x_prev); // Инициализация epsilon для входа в цикл
                dataGridView.Rows.Add(iteration, x_prev, x_curr, x_new, CalculateDerivative(x_prev), CalculateDerivative(x_curr), CalculateFunctionValue(x_new), epsilon);

                x_prev = x_curr;
                x_curr = x_new;
                iteration++;
            }

            // Добавление строки с результатом в таблицу
            double x_min = x_new;
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

        private void exit_button_chord_Click(object sender, EventArgs e)
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
