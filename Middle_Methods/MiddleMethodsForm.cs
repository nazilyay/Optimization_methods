using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace Optimization_methods.Middle_Methods
{
    public partial class MiddleMethodsForm : Form
    {
        private MenuForms menuForm; // Поле для хранения ссылки на экземпляр формы MenuForms

        public MiddleMethodsForm(MenuForms menuForm)
        {
            InitializeComponent();

            this.menuForm = menuForm; // Сохранение ссылки на экземпляр формы MenuForms

            // Добавляем обработчик события загрузки формы
            this.Load += MiddleMethodsForm_Load;

            this.FormClosing += MiddleMethodsForm_FormClosing; // Подключение обработчика к событию FormClosing

            // Скрыть сообщение об ошибке
            error_func_bit.Visible = false;
            error_label.Visible = false;
            result_label.Visible = false;
            func_result_label.Visible = false;

            calculate_button.Enabled = false;
            button_middle_graph.Enabled = false;
            table_middle_button.Enabled = false;
            visualization_middle_button.Enabled = false;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
        }

        private void MiddleMethodsForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exit_button_middle_Click(object sender, EventArgs e)
        {
            menuForm.Close();

        }

        private void MiddleMethodsForm_Load(object sender, EventArgs e)
        {
            // Установка значений по умолчанию для текстовых полей
            function_textBox.Text = "Sin(x)+2"; // Пример выражения функции
            a_textBox.Text = "2"; // Пример значения a
            b_textBox.Text = "5"; // Пример значения b
            accuracy_textBox.Text = "0,1"; // Пример точности
        }

        private void function_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();

            // Проверка корректности выражения функции
            bool isFunctionValid = IsValidFunctionExpression(functionExpression);

            // Активация/деактивация кнопки calculate_button в зависимости от корректности функции
            calculate_button.Enabled = isFunctionValid;
            a_textBox.Enabled = isFunctionValid;
            b_textBox.Enabled = isFunctionValid;
            accuracy_textBox.Enabled = isFunctionValid;
        }

        private bool IsValidFunctionExpression(string expression)
        {
            try
            {
                object result = CalculateFunctionValue(expression, 1);
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
        private (double minResult, double minX) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double x = (a + b) / 2; // Начальное значение средней точки
            double epsilon = (b - a) / 2; // Начальная половина длины интервала

            while (Math.Abs(epsilon) > accuracy)
            {
                double derivative = CalculateDerivative(expression, x);

                if (derivative > 0)
                {
                    b = x;
                }
                else
                {
                    a = x;
                }

                x = (a + b) / 2; // Новое значение средней точки
                epsilon = (b - a) / 2; // Новая половина длины интервала
            }

            double minResult = CalculateFunctionValue(expression, x);

            return (minResult, x);
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
        private void calculate_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;


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

            // Вычисление минимума функции на отрезке методом золотого сечения
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

            // Вывод результатов на форму
            func_result_label.Text = minResult.ToString();
            result_label.Text = minX.ToString();
            func_result_label.Visible = true;
            result_label.Visible = true;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;

            button_middle_graph.Enabled = true;
            table_middle_button.Enabled = true;
            visualization_middle_button.Enabled = true;
        }

        private void data_reset_button_Click(object sender, EventArgs e)
        {
            // Очистка значений всех текстовых полей
            function_textBox.Clear();
            a_textBox.Clear();
            b_textBox.Clear();
            accuracy_textBox.Clear();
            calculate_button.Enabled = false;
            table_middle_button.Enabled = false;

            // Убрать цвет фона у кнопки function_button
            function_button.BackColor = DefaultBackColor;

            // Скрыть сообщение об ошибке
            error_label.Visible = false;
            error_func_bit.Visible = false;
            func_result_label.Visible = false;
            result_label.Visible = false;
            button_middle_graph.Enabled = false;
            visualization_middle_button.Enabled = false;
            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
        }

        private void table_middle_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b, точности или параметра алгоритма";
                error_label.Visible = true;
                return;
            }

            // Создание новой формы для отображения таблицы итерационных вычислений
            IterationTableForm_Middle iterationTableForm = new IterationTableForm_Middle(functionExpression, a, b, accuracy);
            iterationTableForm.Show(); // Открываем форму модально (блокирует доступ к предыдущей форме)
            // Скрываем сообщение об ошибке после закрытия формы
            error_label.Visible = false;
        }

        private void button_middle_graph_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b, точности или параметра алгоритма";
                error_label.Visible = true;
                return;
            }

            // Вычисление минимума функции
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

            // Открытие новой формы с графиком функции и выделенной точкой минимума
             GraphForm_Middle graphForm = new GraphForm_Middle(functionExpression, accuracy, a, b);
             graphForm.Show();
        }

        private void visualization_middle_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b, точности или параметра алгоритма";
                error_label.Visible = true;
                return;
            }

            // Создание и отображение новой формы
            visualizationForm_Middle visualizationForm = new visualizationForm_Middle(functionExpression, a, b, accuracy);
              visualizationForm.Show();
        }
    }
}
