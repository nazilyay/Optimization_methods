﻿using Optimization_methods.Bit_Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using System.Reflection.Metadata;
using System.Data.Common;

namespace Optimization_methods.Dichotomies_Method
{
    public partial class DichotomiesMethodsForm : Form
    {
        private MenuForms menuForm; // Добавляем поле для хранения ссылки на экземпляр формы MenuForms

        // Добавляем конструктор, который принимает ссылку на экземпляр формы MenuForms
        public DichotomiesMethodsForm(MenuForms menuForm)
        {
            InitializeComponent();

            this.menuForm = menuForm; // Сохраняем ссылку на экземпляр формы MenuForms

            // Добавляем обработчик события загрузки формы
            this.Load += bitMethodsForm_Load;

            this.FormClosing += DichotomiesMethodsForm_FormClosing; // Подключение обработчика к событию FormClosing


            // Скрыть сообщение об ошибке
            error_func_bit.Visible = false;
            error_label.Visible = false;
            result_label.Visible = false;
            func_result_label.Visible = false;

            calculate_button.Enabled = false;
            button_dichotomies_graph.Enabled = false;
            table_dichotomies_button.Enabled = false;
            visualization_button.Enabled = false;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
            parameter_textBox.Enabled = false;
        }
        private void DichotomiesMethodsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Получаем массив всех открытых форм
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            // Закрываем каждую форму, кроме menuForm
            foreach (Form form in forms)
            {
                if (form != menuForm && form != this)
                {
                    form.Close();
                }
            }

            // Отображаем предыдущее скрытое окно
            menuForm.Show();
        }

        private void exit_button_bit_Click(object sender, EventArgs e)
        {
            menuForm.Close();

        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bitMethodsForm_Load(object sender, EventArgs e)
        {
            // Установка значений по умолчанию для текстовых полей
            function_textBox.Text = "Sin(x)+2"; // Пример выражения функции
            a_textBox.Text = "2"; // Пример значения a
            b_textBox.Text = "5"; // Пример значения b
            accuracy_textBox.Text = "0,1"; // Пример точности
            parameter_textBox.Text = "0,1"; // Пример точности
        }


        private void function_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            error_label.Visible = false;

            // Проверка корректности выражения функции
            bool isFunctionValid = IsValidFunctionExpression(functionExpression);

            // Активация/деактивация кнопки calculate_button в зависимости от корректности функции
            calculate_button.Enabled = isFunctionValid;
            a_textBox.Enabled = isFunctionValid;
            b_textBox.Enabled = isFunctionValid;
            accuracy_textBox.Enabled = isFunctionValid;
            parameter_textBox.Enabled = isFunctionValid;
        }


        private bool IsValidFunctionExpression(string expression)
        {
            try
            {
                Expression e = new Expression(expression);
                e.Parameters["x"] = 1;
                object result = e.Evaluate();
                error_func_bit.Visible = false;
                return true;
            }
            catch (Exception)
            {
                error_func_bit.Text = "Некорректный ввод функции.";
                error_func_bit.Visible = true;
                return false;
            }
        }
        private (double minResult, double minX) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy, double parameter)
        {

            while ((b - a) / 2 > accuracy)
            {
                double x1 = (a + b - parameter) / 2;
                double x2 = (a + b + parameter) / 2;

                double f1 = CalculateFunctionValue(expression, x1);
                double f2 = CalculateFunctionValue(expression, x2);

                if (f1 <= f2)
                    b = x2;
                else
                    a = x1;
            }

            double minX = (a + b) / 2;
            double minResult = CalculateFunctionValue(expression, minX);

            return (minResult, minX);
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

        private double CalculateDerivative(string expression, double x)
        {
            double h = 0.0001; // Шаг для численного дифференцирования
            double xPlusH = x + h;
            double xMinusH = x - h;

            double fPlusH = CalculateFunctionValue(expression, xPlusH);
            double fMinusH = CalculateFunctionValue(expression, xMinusH);

            return (fPlusH - fMinusH) / (2 * h);
        }
        private void calculate_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, parameter;
            error_label.Visible = false;

            // Проверка правильности ввода значения a
            if (!double.TryParse(a_textBox.Text, out a))
            {
                error_label.Text = "Некорректный ввод значения a.";
                error_label.Visible = true;
                return;
            }

            // Проверка правильности ввода значения b
            if (!double.TryParse(b_textBox.Text, out b))
            {
                error_label.Text = "Некорректный ввод значения b.";
                error_label.Visible = true;
                return;
            }

            if (a >= b)
            {
                error_label.Text = "Некорректный ввод значения a, b.";
                error_label.Visible = true;
                return;
            }

            // Проверка правильности ввода значения accuracy
            if (!double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                error_label.Text = "Некорректный ввод значения точности.";
                error_label.Visible = true;
                return;
            }

            // Проверка правильности ввода значения parameter
            if (!double.TryParse(parameter_textBox.Text, out parameter))
            {
                error_label.Text = "Некорректный ввод значения параметра алгоритма.";
                error_label.Visible = true;
                return;
            }


            if (CalculateDerivative(functionExpression, a) * CalculateDerivative(functionExpression, b) > 0)
            {
                error_label.Text = "Рассматриваемая функция не является унимодальной на данном отрезке!";
                error_label.Visible = true;
                return;
            }

            if (!(parameter > 0 && parameter < 2 * accuracy))
            {
                error_label.Text = "Некорректный ввод значения параметра алгоритма.";
                error_label.Visible = true;
                return;
            }

            // Вычисление минимума функции на отрезке методом перебора
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy, parameter);

            // Вывод результатов на форму
            func_result_label.Text = minResult.ToString();
            result_label.Text = minX.ToString();
            func_result_label.Visible = true;
            result_label.Visible = true;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
            parameter_textBox.Enabled = false;

            button_dichotomies_graph.Enabled = true;
            table_dichotomies_button.Enabled = true;
            visualization_button.Enabled = true;
        }

        private void data_reset_button_Click(object sender, EventArgs e)
        {
            // Очистка значений всех текстовых полей
            function_textBox.Clear();
            a_textBox.Clear();
            b_textBox.Clear();
            accuracy_textBox.Clear();
            parameter_textBox.Clear();
            calculate_button.Enabled = false;
            table_dichotomies_button.Enabled = false;
            // Убираем цвет фона у кнопки function_button
            function_button.BackColor = Color.FromArgb(245, 245, 240);

            // Скрываем сообщение об ошибке
            error_label.Visible = false;
            error_func_bit.Visible = false;

            func_result_label.Visible = false;
            result_label.Visible = false;
            button_dichotomies_graph.Enabled = false;
            visualization_button.Enabled = false;
            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
            parameter_textBox.Enabled = false;
        }

        private void table_dichotomies_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, parameter;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                !double.TryParse(parameter_textBox.Text, out parameter) ||
                (a >= b) || (!(parameter > 0 && parameter < 2 * accuracy)))
            {
                error_label.Text = "Некорректный ввод значений a, b, точности или параметра алгоритма";
                error_label.Visible = true;
                return;
            }

            // Создание новой формы для отображения таблицы итерационных вычислений
            IterationTableForm_Dichotomies iterationTableForm = new IterationTableForm_Dichotomies(functionExpression, a, b, accuracy, parameter);
            iterationTableForm.Show(); // Открываем форму модально (блокирует доступ к предыдущей форме)

            // Скрываем сообщение об ошибке после закрытия формы
            error_label.Visible = false;

        }

        private void button_dichotomies_graph_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, parameter;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                !double.TryParse(parameter_textBox.Text, out parameter) ||
                (a >= b) || (!(parameter > 0 && parameter < 2 * accuracy)))
            {
                error_label.Text = "Некорректный ввод значений a, b, точности или параметра алгоритма";
                error_label.Visible = true;
                return;
            }

            // Вычисление минимума функции
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy, parameter);

            // Открытие новой формы с графиком функции и выделенной точкой минимума
            GraphForm_Dichotomies graphForm = new GraphForm_Dichotomies(functionExpression, accuracy, a, b, parameter);
            graphForm.Show();
        }

        private void visualization_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, parameter;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                !double.TryParse(parameter_textBox.Text, out parameter) ||
                (a >= b) || (!(parameter > 0 && parameter < 2 * accuracy)))
            {
                error_label.Text = "Некорректный ввод значений a, b, точности или параметра алгоритма";
                error_label.Visible = true;
                return;
            }

            // Создание и отображение новой формы
            VisualizationForm visualizationForm = new VisualizationForm(functionExpression, a, b, accuracy, parameter);
            visualizationForm.Show();
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }
    }
}
