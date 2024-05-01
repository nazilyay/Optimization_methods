﻿using System;
using System.Data.Common;
using System.Windows.Forms;
using NCalc;


namespace Optimization_methods
{
    public partial class SearchMethodsForm : Form
    {
        public SearchMethodsForm()
        {
            InitializeComponent();

            // Добавляем обработчик события загрузки формы
            this.Load += SearchMethodsForm_Load;

            // Скрыть сообщение об ошибке
            error_func_search.Visible = false;
            error_label.Visible = false;
            result_label.Visible = false;
            func_result_label.Visible = false;

            calculate_button.Enabled = false;
            button_graph_search.Enabled = false;
            table_search_button.Enabled = false;
            Visualization_button.Enabled = false;

        }

        private void SearchMethodsForm_Load(object sender, EventArgs e)
        {
            // Установка значений по умолчанию для текстовых полей
            function_textBox.Text = "Sin(x)+2"; // Пример выражения функции
            a_textBox.Text = "0"; // Пример значения a
            b_textBox.Text = "5"; // Пример значения b
            accuracy_textBox.Text = "0,1"; // Пример точности
        }


        private void function_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();

            // Проверка корректности выражения функции
            bool isFunctionValid = IsValidFunctionExpression(functionExpression);

            // Если функция корректна, устанавливаем зеленый цвет фона кнопки, иначе - красный
            function_button.BackColor = isFunctionValid ? Color.Green : Color.Red;

            // Активация/деактивация кнопки calculate_button в зависимости от корректности функции
            calculate_button.Enabled = isFunctionValid;
        }


        private bool IsValidFunctionExpression(string expression)
        {
            try
            {
                Expression e = new Expression(expression);
                e.Parameters["x"] = 1;
                object result = e.Evaluate();
                return true;
            }
            catch (Exception)
            {
                error_func_search.Text = "Ошибка: Неправильный ввод функции.";
                error_func_search.Visible = true;
                return false;
            }
        }

        private (double minResult, double minX) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
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

            return (minResult, minX);
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значения a
            if (!double.TryParse(a_textBox.Text, out a))
            {
                error_label.Text = "Ошибка: Неправильный ввод значения a.";
                error_label.Visible = true;
                return;
            }

            // Проверка правильности ввода значения b
            if (!double.TryParse(b_textBox.Text, out b))
            {
                error_label.Text = "Ошибка: Неправильный ввод значения b.";
                error_label.Visible = true;
                return;
            }

            // Проверка правильности ввода значения accuracy
            if (!double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                error_label.Text = "Ошибка: Неправильный ввод значения точности.";
                error_label.Visible = true;
                return;
            }

            // Вычисление минимума функции на отрезке методом перебора
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

            // Вывод результатов на форму
            func_result_label.Text = minResult.ToString();
            result_label.Text = minX.ToString();
            func_result_label.Visible = true;
            result_label.Visible = true;

            table_search_button.Enabled = true;
            button_graph_search.Enabled = true;
            Visualization_button.Enabled = true;
        }
        private void exit_button_search_Click(object sender, EventArgs e)
        {
            // Получаем массив всех открытых форм
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            // Закрываем каждую форму
            foreach (Form form in forms)
            {
                form.Close();
            }
        }

        private void data_reset_button_Click(object sender, EventArgs e)
        {
            // Очистка значений всех текстовых полей
            function_textBox.Clear();
            a_textBox.Clear();
            b_textBox.Clear();
            accuracy_textBox.Clear();
            calculate_button.Enabled = false;
            table_search_button.Enabled = false;
            // Убираем цвет фона у кнопки function_button
            function_button.BackColor = DefaultBackColor;

            // Скрываем сообщение об ошибке
            error_label.Visible = false;
            error_func_search.Visible = false;
            func_result_label.Visible = false;
            result_label.Visible = false;
        }

        private void table_search_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                error_label.Text = "Ошибка: Неправильный ввод значений a, b или точности.";
                error_label.Visible = true;
                return;
            }

            // Создание новой формы для отображения таблицы итерационных вычислений
            IterationTableForm iterationTableForm = new IterationTableForm(functionExpression, a, b, accuracy);
            iterationTableForm.Show(); // Открываем форму модально (блокирует доступ к предыдущей форме)

            // Скрываем сообщение об ошибке после закрытия формы
            error_label.Visible = false;

        }

        private void button_graph_search_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Получение значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                MessageBox.Show("Ошибка: Неправильный ввод значений a, b или точности.");
                return;
            }

            // Вычисление минимума функции
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

            // Открытие новой формы с графиком функции и выделенной точкой минимума
            GraphForm_Search graphForm = new GraphForm_Search(functionExpression, accuracy, a, b, minX, minResult);
            graphForm.Show();
        }

        private void Visualization_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Получение значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                MessageBox.Show("Ошибка: Неправильный ввод значений a, b или точности.");
                return;
            }

            // Открытие новой формы с графиком функции
            /*VisualizationForm_Search VisualizationForm = new VisualizationForm_Search(functionExpression, accuracy, a, b);
            VisualizationForm.Show();*/

        }
    }


}