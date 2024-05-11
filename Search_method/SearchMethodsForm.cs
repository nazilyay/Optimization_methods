using System;
using System.Data.Common;
using System.Windows.Forms;
using NCalc;
using Optimization_methods.Search_method;


namespace Optimization_methods
{
    public partial class SearchMethodsForm : Form
    {
        private MenuForms menuForm; // Добавляем поле для хранения ссылки на экземпляр формы MenuForms

        // Добавляем конструктор, который принимает ссылку на экземпляр формы MenuForms
        public SearchMethodsForm(MenuForms menuForm)
        {
            InitializeComponent();

            this.menuForm = menuForm; // Сохраняем ссылку на экземпляр формы MenuForms

            this.FormClosing += GraphForm_Search_FormClosing; // Подключение обработчика к событию FormClosing

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

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;

        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exit_button_search_Click(object sender, EventArgs e)
        {
            menuForm.Close();
        }

        private void GraphForm_Search_FormClosing(object sender, FormClosingEventArgs e)
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
        private void SearchMethodsForm_Load(object sender, EventArgs e)
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

            error_label.Visible = false;
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
                Expression e = new Expression(expression);
                e.Parameters["x"] = 1;
                object result = e.Evaluate();
                error_func_search.Visible = false;
                return true;
            }
            catch (Exception)
            {
                error_func_search.Text = "Некорректный ввод функции.";
                error_func_search.Visible = true;
                return false;
            }
        }

        private (double minResult, double minX) CalculateFunctionOnInterval(string expression, double a, double b, double accuracy)
        {
            double minResult = double.MaxValue;
            double minX = 0;

            double prevResult = double.MaxValue; // Переменная для хранения предыдущего значения функции

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

                // Проверяем, началось ли увеличение значения функции после нахождения минимума
                if (prevResult < minResult && result > minResult)
                {
                    break; // Прекращаем перебор, если значение функции начинает расти после минимума
                }

                prevResult = result; // Сохраняем текущее значение функции для следующей итерации
            }

            return (minResult, minX);
        }


        private void calculate_button_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;
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

            // Проверка правильности ввода значения accuracy
            if (!double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                error_label.Text = "Некорректный ввод значения точности.";
                error_label.Visible = true;
                return;
            }


            if (a >= b)
            {
                error_label.Text = "Некорректный ввод значения a, b.";
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

            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;

            table_search_button.Enabled = true;
            button_graph_search.Enabled = true;
            Visualization_button.Enabled = true;
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
            button_graph_search.Enabled = false;
            Visualization_button.Enabled = false;
            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            accuracy_textBox.Enabled = false;
        }

        private void table_search_Click(object sender, EventArgs e)
        {
            string functionExpression = function_textBox.Text.Trim();
            double a, b, accuracy;

            // Проверка правильности ввода значений a, b и точности
            if (!double.TryParse(a_textBox.Text, out a) ||
                !double.TryParse(b_textBox.Text, out b) ||
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности.";
                error_label.Visible = true;
                return;
            }

            // Создание новой формы для отображения таблицы итерационных вычислений
            IterationTableForm_Search iterationTableForm = new IterationTableForm_Search(functionExpression, a, b, accuracy);
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
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности.";
                error_label.Visible = true;
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
                !double.TryParse(accuracy_textBox.Text, out accuracy) ||
                (a >= b))
            {
                error_label.Text = "Некорректный ввод значений a, b или точности.";
                error_label.Visible = true;
                return;
            }
            // Вычисление минимума функции
            (double minResult, double minX) = CalculateFunctionOnInterval(functionExpression, a, b, accuracy);

            VisualizationForm_Search visualizationForm = new VisualizationForm_Search(functionExpression, a, b, accuracy, minX, minResult);
            visualizationForm.Show();
        }
      
    }

}