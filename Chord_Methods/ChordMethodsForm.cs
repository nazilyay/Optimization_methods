using Optimization_methods.Newton_Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using Optimization_methods.Secant_Methods;

namespace Optimization_methods.Chord_Methods
{
    public partial class ChordMethodsForm : Form
    {
        private MenuForms menuForm; // Поле для хранения ссылки на экземпляр формы MenuForms
        public ChordMethodsForm(MenuForms menuForm)
        {
            InitializeComponent();

            this.menuForm = menuForm; // Сохранение ссылки на экземпляр формы MenuForms

            // Добавляем обработчик события загрузки формы
            this.Load += chordMethodsForm_Load;

            this.FormClosing += chordMethodsForm_FormClosing; // Подключение обработчика к событию FormClosing

            // Скрыть сообщение об ошибке
            error_func.Visible = false;
            error_label.Visible = false;
            result_label.Visible = false;
            func_result_label.Visible = false;

            calculate_button.Enabled = false;
            button_chord_graph.Enabled = false;
            table_chord_button.Enabled = false;
            visualization_chord_button.Enabled = false;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
        }

        private void chordMethodsForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void exit_button_chord_Click(object sender, EventArgs e)
        {
            menuForm.Close();

        }

        private void chordMethodsForm_Load(object sender, EventArgs e)
        {
            function_textBox.Text = "Pow(x, 3) - 2 * Pow(x, 2) - 5 * x + 6"; // Пример выражения функции
            a_textBox.Text = "1"; // Пример значения a
            b_textBox.Text = "4"; // Пример значения b
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
            error_label.Visible = false;

            button_chord_graph.Enabled = false;
            table_chord_button.Enabled = false;
            visualization_chord_button.Enabled = false;
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

        private (double minResult, double minX) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double x_prev = a;
            double x_curr = b;
            double epsilon = Math.Abs(x_curr - x_prev);
            double x_new = x_curr;
            while (epsilon > accuracy)
            {
                x_new = x_prev - (CalculateDerivative(expression, x_prev) * (x_curr - x_prev)) / (CalculateDerivative(expression, x_curr) - CalculateDerivative(expression, x_prev));
                epsilon = Math.Abs(x_curr - x_prev);
                x_prev = x_curr;
                x_curr = x_new;
            }
            double minResult = CalculateFunctionValue(expression, x_new);
            return (minResult, x_new);
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

        private double CalculateThirdDerivative(string expression, double x)
        {
            double h = 0.0001; // Шаг для численного дифференцирования
            double xPlusH = x + h;
            double xMinusH = x - h;

            double fPlusH = CalculateSecondDerivative(expression, xPlusH);
            double fMinusH = CalculateSecondDerivative(expression, xMinusH);

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

            // Проверка, что функция определена и трижды дифференцируема на [a, b]
            if (!IsThirdDerivativeDefined(functionExpression, a) || !IsThirdDerivativeDefined(functionExpression, b))
            {
                error_label.Text = "У функции f(x) не существует третьей производной на [a, b].";
                error_label.Visible = true;
                return;
            }

            if (CalculateDerivative(functionExpression, a) * CalculateDerivative(functionExpression, b) > 0)
            {
                error_label.Text = "Рассматриваемая функция не является унимодальной на данном отрезке!";
                error_label.Visible = true;
                return;
            }

            // Проверка корректности второй и третьей производных на отрезке [a, b]
            if (!IsSecondAndThirdDerivativesValid(functionExpression, a, b))
            {
                error_label.Text = "Вторая или третья производная на отрезке [a, b] равна нулю или меняет знак. Метод хорд не сходится.";
                error_label.Visible = true;
                return;
            }

            // Вычисление минимума функции на отрезке 
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

            // Вывод результатов на форму
            func_result_label.Text = minResult.ToString();
            result_label.Text = minX.ToString();
            func_result_label.Visible = true;
            result_label.Visible = true;

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;

            button_chord_graph.Enabled = true;
            table_chord_button.Enabled = true;
            visualization_chord_button.Enabled = true;
        }

        private bool IsSecondAndThirdDerivativesValid(string expression, double a, double b)
        {
            // Вычисляем значения второй и третьей производных на границах интервала [a, b]
            double secondDerivativeA = CalculateSecondDerivative(expression, a);
            double thirdDerivativeA = CalculateThirdDerivative(expression, a);
            double secondDerivativeB = CalculateSecondDerivative(expression, b);
            double thirdDerivativeB = CalculateThirdDerivative(expression, b);

            // Проверяем, что производные сохраняют знак на границах интервала и что вторая производная не равна нулю
            if ((secondDerivativeA > 0 && secondDerivativeB > 0) || (secondDerivativeA < 0 && secondDerivativeB < 0) && secondDerivativeA != 0)
            {
                if ((thirdDerivativeA > 0 && thirdDerivativeB > 0) || (thirdDerivativeA < 0 && thirdDerivativeB < 0))
                {
                    // Успешно прошли проверку для всех значений x в интервале [a, b]
                    return true;
                }
            }
            // Если хотя бы одно условие не выполнено, возвращаем false
            return false;
        }
        private bool IsThirdDerivativeDefined(string expression, double x)
        {
            try
            {
                // Попытка вычислить третью производную в точке x
                CalculateThirdDerivative(expression, x);
                return true;
            }
            catch (Exception)
            {
                return false;
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
            table_chord_button.Enabled = false;

            // Убрать цвет фона у кнопки function_button
            function_button.BackColor = Color.FromArgb(245, 245, 240);

            // Скрыть сообщение 
            error_label.Visible = false;
            error_func.Visible = false;
            func_result_label.Visible = false;
            result_label.Visible = false;
            button_chord_graph.Enabled = false;
            visualization_chord_button.Enabled = false;
            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
        }

        private void table_chord_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности";
                error_label.Visible = true;
                return;
            }

            // Создание новой формы для отображения таблицы итерационных вычислений
            IterationTableForm_Chord iterationTableForm = new IterationTableForm_Chord(functionExpression, a, b, accuracy);
            iterationTableForm.Show(); // Открываем форму модально (блокирует доступ к предыдущей форме)
                                       // Скрываем сообщение об ошибке после закрытия формы
            error_label.Visible = false;
        }

        private void button_chord_graph_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности";
                error_label.Visible = true;
                return;
            }

            // Открытие новой формы с графиком функции и выделенной точкой минимума
            GraphForm_Chord graphForm = new GraphForm_Chord(functionExpression, accuracy, a, b);
            graphForm.Show();
        }

        private void visualization_chord_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;
            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
            !double.TryParse(b_textBox.Text, out b) ||
            !double.TryParse(accuracy_textBox.Text, out accuracy) ||
            (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности";
                error_label.Visible = true;
                return;
            }

            // Создание и отображение новой формы
            visualizationForm_Chord visualizationForm = new visualizationForm_Chord(functionExpression, a, b, accuracy);
            visualizationForm.Show();
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }
    }
}
