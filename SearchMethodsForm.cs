using System;
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
            function_button.Click += function_button_Click;
            calculate_button.Click += calculate_button_Click;
            calculate_button.Enabled = false; // Изначально отключаем кнопку calculate_button
        }

    
  
        private void function_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();

            // Проверка корректности выражения функции
            bool isFunctionValid = IsValidFunctionExpression(functionExpression);

            // Активация/деактивация кнопки calculate_button в зависимости от корректности функции
            calculate_button.Enabled = isFunctionValid;
        }

        private bool IsValidFunctionExpression(string expression)
        {
            try
            {
                // Создаем объект Expression
                Expression exp = new Expression(expression);

                // Устанавливаем параметры для переменной x
                exp.Parameters["x"] = 0; // Устанавливаем начальное значение переменной x для проверки синтаксиса

                // Попытка вычислить выражение для проверки синтаксиса
                exp.Evaluate();
                MessageBox.Show("GOOD");

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("NOT");

                return false;
            }
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a = Convert.ToDouble(a_textBox.Text);
            double b = Convert.ToDouble(b_textBox.Text);
            double accuracy = Convert.ToDouble(accuracy_textBox.Text);

            // Вычисление значения функции на отрезке методом перебора
            CalculateFunctionOnInterval(functionExpression, a, b, accuracy);
        }

        private void CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double minResult = double.MaxValue;
            double minX = 0;

            for (double x = a; x <= b; x += accuracy)
            {
                // Заменяем значение переменной x в выражении
                string exprWithX = expression.Replace("x", x.ToString());

                Expression exp = new Expression(exprWithX);

                // Добавляем пользовательские функции sin, cos, tan с поддержкой аргументов
                exp.EvaluateFunction += (name, args) =>
                {
                    if (name == "sin" && args.Parameters.Length == 1)
                        args.Result = Math.Sin(Convert.ToDouble(args.Parameters[0].Evaluate()));
                    else if (name == "cos" && args.Parameters.Length == 1)
                        args.Result = Math.Cos(Convert.ToDouble(args.Parameters[0].Evaluate()));
                    else if (name == "tan" && args.Parameters.Length == 1)
                        args.Result = Math.Tan(Convert.ToDouble(args.Parameters[0].Evaluate()));
                    else
                        throw new EvaluationException($"Функция '{name}' не поддерживает указанное количество аргументов.");
                };

                // Вычисляем значение выражения для текущего значения x
                double result = Convert.ToDouble(exp.Evaluate());

                // Находим минимальное значение функции
                if (result < minResult)
                {
                    minResult = result;
                    minX = x;
                }
            }

            // Вывод результатов на форму
            func_result_label.Text = $"min f(x) = {minResult} при x = {minX}";
            result_label.Text = $"f(x) = {minResult}";
        }
    }
}