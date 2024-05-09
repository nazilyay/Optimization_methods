using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;


namespace Optimization_methods.Newton_Methods
{
    public partial class NewtonMethodsForm : Form
    {
        private MenuForms menuForm; // Поле для хранения ссылки на экземпляр формы MenuForms
        public NewtonMethodsForm(MenuForms menuForm)
        {
            InitializeComponent();

            this.menuForm = menuForm; // Сохранение ссылки на экземпляр формы MenuForms

            // Добавляем обработчик события загрузки формы
            this.Load += NewtonMethodsForm_Load;

            this.FormClosing += NewtonMethodsForm_FormClosing; // Подключение обработчика к событию FormClosing

            // Скрыть сообщение об ошибке
            error_func.Visible = false;
            error_label.Visible = false;
            result_label.Visible = false;
            func_result_label.Visible = false;

            calculate_button.Enabled = false;
            button_newton_graph.Enabled = false;
            table_newton_button.Enabled = false;
            visualization_newton_button.Enabled = false;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
            x_0_textBox.Enabled = false;
        }

        private void NewtonMethodsForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void exit_button_newton_Click(object sender, EventArgs e)
        {
            menuForm.Close();

        }

        private void NewtonMethodsForm_Load(object sender, EventArgs e)
        {
            // Установка значений по умолчанию для текстовых полей
            function_textBox.Text = "Pow(Sin(x), 2)+2"; // Пример выражения функции
            a_textBox.Text = "2"; // Пример значения a
            b_textBox.Text = "5"; // Пример значения b
            accuracy_textBox.Text = "0,1"; // Пример точности
            x_0_textBox.Text = "3,6";
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
            x_0_textBox.Enabled = isFunctionValid;
            error_label.Visible = false;
        }

        private bool IsValidFunctionExpression(string expression)
        {
            try
            {
                Expression e = new Expression(expression);
                e.Parameters["x"] = 1;
                object result = e.Evaluate();
                error_func.Visible = false;
                return true;
            }
            catch (Exception)
            {
                error_func.Text = "Некорректный ввод функции.";
                error_func.Visible = true;
                return false;
            }
        }
        private bool IsСonvergence(string expression, double x_0)
        {
            double result = CalculateSecondDerivative(expression, x_0);
            if (Math.Abs(result) < double.Epsilon)
            {
                return true;
            }
            return false;
        }

        private (double minResult, double minX, bool Сonvergence) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy, double x_0)
        {
            bool localСonvergence = true; // локальная переменная для проверки сходимости в каждой итерации

            double x = x_0 - CalculateDerivative(expression, x_0) / CalculateSecondDerivative(expression, x_0);
            double epsilon = Math.Abs(x - x_0);
            double prevx = x_0; // Инициализируем prevx начальным значением x_0
            while (epsilon > accuracy)
            {
                prevx = x;
                if (IsСonvergence(expression, prevx)) { localСonvergence = false; } // устанавливаем localСonvergence в false, если вторая производная равна нулю
                x = prevx - CalculateDerivative(expression, prevx) / CalculateSecondDerivative(expression, prevx);
                epsilon = Math.Abs(x - prevx);
            }
            double minResult = CalculateFunctionValue(expression, x);
            return (minResult, x, localСonvergence); // возвращаем localСonvergence вместе с результатами
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

        private double CalculateSecondDerivative(string expression, double x)
        {
            double h = 0.0001; // Шаг для численного дифференцирования
            double xPlusH = x + h;
            double xMinusH = x - h;

            double fPlusH = CalculateDerivative(expression, xPlusH);
            double fMinusH = CalculateDerivative(expression, xMinusH);

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
            double a, b, accuracy, x_0;
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

            // Проверка правильности ввода значения accuracy
            if (!double.TryParse(x_0_textBox.Text, out x_0))
            {
                error_label.Text = "Некорректный ввод начального приближения.";
                error_label.Visible = true;
                return;
            }

            if (x_0 > b || x_0 < a)
            {
                error_label.Text = "Некорректный ввод начального приближения.";
                error_label.Visible = true;
                return;
            }

            if (IsСonvergence(functionExpression, x_0))
            {
                error_label.Text = "Вторая производная равна нулю. Метод Ньютона не сходится.";
                error_label.Visible = true;
                return;
            }

            if (!(CalculateDerivative(functionExpression, x_0) * CalculateSecondDerivative(functionExpression, x_0) > 0))
            {
                error_label.Text = "Начальное приближение выбрано неправильно!  Метод Ньютона не сходится!";
                error_label.Visible = true;
                return;
            }
            // Вычисление минимума функции на отрезке методом золотого сечения
            (double minResult, double minX, bool localСonvergence) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy, x_0);

            if (!localСonvergence)
            {
                error_label.Text = "Вторая производная равна нулю. Метод Ньютона не сходится.";
                error_label.Visible = true;
                return;
            }

            // Вывод результатов на форму
            func_result_label.Text = minResult.ToString();
            result_label.Text = minX.ToString();
            func_result_label.Visible = true;
            result_label.Visible = true;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
            x_0_textBox.Enabled = false;

            button_newton_graph.Enabled = true;
            table_newton_button.Enabled = true;
            visualization_newton_button.Enabled = true;
        }

        private void data_reset_button_Click(object sender, EventArgs e)
        {
            // Очистка значений всех текстовых полей
            function_textBox.Clear();
            a_textBox.Clear();
            b_textBox.Clear();
            x_0_textBox.Clear();
            accuracy_textBox.Clear();
            calculate_button.Enabled = false;
            table_newton_button.Enabled = false;
            
            // Убрать цвет фона у кнопки function_button
            function_button.BackColor = DefaultBackColor;

            // Скрыть сообщение 
            error_label.Visible = false;
            error_func.Visible = false;
            func_result_label.Visible = false;
            result_label.Visible = false;
            button_newton_graph.Enabled = false;
            visualization_newton_button.Enabled = false;
            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
            x_0_textBox.Enabled = false;
        }

        private void table_newton_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, x_0;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            !double.TryParse(x_0_textBox.Text, out x_0) ||
            (a >= b) || (x_0 < a) || (x_0 > b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности";
                error_label.Visible = true;
                return;
            }

            // Создание новой формы для отображения таблицы итерационных вычислений
            IterationTableForm_Newton iterationTableForm = new IterationTableForm_Newton(functionExpression, a, b, accuracy, x_0);
            iterationTableForm.Show(); // Открываем форму модально (блокирует доступ к предыдущей форме)
            // Скрываем сообщение об ошибке после закрытия формы
            error_label.Visible = false;
        }

        private void button_newton_graph_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, x_0;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            !double.TryParse(x_0_textBox.Text, out x_0) ||
            (a >= b) || (x_0 < a) || (x_0 > b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности";
                error_label.Visible = true;
                return;
            }

            // Открытие новой формы с графиком функции и выделенной точкой минимума
            GraphForm_Newton graphForm = new GraphForm_Newton(functionExpression, accuracy, a, b, x_0);
            graphForm.Show();
        }

        private void visualization_newton_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy, x_0;
            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            !double.TryParse(x_0_textBox.Text, out x_0) ||
            (a >= b) || (x_0 < a) || (x_0 > b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности";
                error_label.Visible = true;
                return;
            }

            // Создание и отображение новой формы
            visualizationForm_Newton visualizationForm = new visualizationForm_Newton(functionExpression, a, b, accuracy, x_0);
            visualizationForm.Show();
        }

    }
}
