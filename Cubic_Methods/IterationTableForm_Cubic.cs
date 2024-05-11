﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;    
namespace Optimization_methods.Cubic_Methods
{
    public partial class IterationTableForm_Cubic : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm_Cubic(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Выполнение метода средней точки и заполнение таблицы
            PerformMiddlePointMethod();

            // Установка ширины столбцов
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = 100; // Устанавливаем ширину столбца
            }
            dataGridView.Columns[0].Width = 80;
        }
        private void PerformMiddlePointMethod()
        {// Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            int iteration = 0;
            double x1 = a;
            double x2 = b;

            double epsilon = Math.Abs(x2 - x1);
            double x0 = 0;
            while (epsilon > accuracy)
            {
                double y1 = CalculateFunctionValue(x1);
                double y2 = CalculateFunctionValue(x2);
                double y11 = CalculateDerivative(x1);
                double y12 = CalculateDerivative(x2);

                double z = y11 + y12 - 3 * (y2 - y1) / (x2 - x1);
                double omega = Math.Sqrt(Math.Pow(z, 2) - y11 * y12);
                double mu = (omega + z - y11) / (2 * omega - y11 + y12);

                double a0 = y1;
                double a1 = (y2 - y1) / (x2 - x1);
                double a2 = Math.Pow((y2 - y1) / (x2 - x1), 2) - y11 / (x2 - x1);
                double a3 = (y12 - y11) / Math.Pow((x2 - x1), 2) - 2 * (y2 - y1) / Math.Pow((x2 - x1), 3);

                x0 = x1 + mu * (x2 - x1);


                double y0_derivative = CalculateDerivative(x0);
                if (y0_derivative * y11 < 0)
                {
                    if (CalculateDerivative(x0) > 0)
                        dataGridView.Rows.Add(iteration, x1, x2, x0, CalculateFunctionValue(x0), CalculateFunctionValue(x1), CalculateFunctionValue(x2), CalculateDerivative(x1), CalculateDerivative(x2), a0, a1, a2, a3, mu, omega, z, CalculateDerivative(x0), "+", Math.Abs(x2 - x0));
                    else if (CalculateDerivative(x0) < 0)
                        dataGridView.Rows.Add(iteration, x1, x2, x0, CalculateFunctionValue(x0), CalculateFunctionValue(x1), CalculateFunctionValue(x2), CalculateDerivative(x1), CalculateDerivative(x2), a0, a1, a2, a3, mu, omega, z, CalculateDerivative(x0), "-", Math.Abs(x2 - x0));
                    if (iteration > 0)
                    {
                        if ((double)dataGridView.Rows[iteration - 1].Cells[1].Value != x1)
                            dataGridView.Rows[iteration].Cells[1].Style.BackColor = Color.Yellow;
                        else
                            dataGridView.Rows[iteration].Cells[2].Style.BackColor = Color.Yellow;
                    }
                    x1 = x0; 
                }
                else if (y0_derivative * y12 < 0)
                {
                    if (CalculateDerivative(x0) > 0)
                        dataGridView.Rows.Add(iteration, x1, x2, x0, CalculateFunctionValue(x0), CalculateFunctionValue(x1), CalculateFunctionValue(x2), CalculateDerivative(x1), CalculateDerivative(x2), a0, a1, a2, a3, mu, omega, z, CalculateDerivative(x0), "+", Math.Abs(x0 - x1));
                    else if (CalculateDerivative(x0) < 0)
                        dataGridView.Rows.Add(iteration, x1, x2, x0, CalculateFunctionValue(x0), CalculateFunctionValue(x1), CalculateFunctionValue(x2), CalculateDerivative(x1), CalculateDerivative(x2), a0, a1, a2, a3, mu, omega, z, CalculateDerivative(x0), "-", Math.Abs(x0 - x1));
                    if (iteration > 0)
                    {
                        if ((double)dataGridView.Rows[iteration - 1].Cells[1].Value != x1)
                            dataGridView.Rows[iteration].Cells[1].Style.BackColor = Color.Yellow;
                        else
                            dataGridView.Rows[iteration].Cells[2].Style.BackColor = Color.Yellow;
                    }
                    x2 = x0; 
                }
                // Окрашиваем предыдущую строку (если она существует)
               
                epsilon = Math.Abs(x2 - x1);
                iteration++;

            }
            // Добавление строки с результатом в таблицу
            double x_min = x0;
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

        private void exit_button_Cubic_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
