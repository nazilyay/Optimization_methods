using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NCalc;


namespace Optimization_methods
{
    public partial class IterationTableForm_Search : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm_Search(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Выполнение метода перебора и заполнение таблицы
            PerformBruteForceMethod();

            // Установка ширины столбцов и необходимых свойств
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = 120; // Устанавливаем ширину столбца
                column.ReadOnly = true; // Отключаем редактирование столбцов
                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Отключаем сортировку
            }
            dataGridView.Columns[0].Width = 100;
            // Добавление обработчика события CellFormatting
            dataGridView.CellFormatting += DataGridView_CellFormatting;

        }


        private void PerformBruteForceMethod()
        {
            // Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            // Начальное значение минимального результата и соответствующего x
            double minResult = CalculateFunctionValue(functionExpression, a);
            double minX = a;

            // Вычисление минимального значения функции на отрезке с использованием перебора
            int iteration = 0;
            for (double x = a; x <= b; x += accuracy)
            {
                // Вычисление значения функции для текущего x
                double result = CalculateFunctionValue(functionExpression, x);

                // Проверка, является ли текущий результат минимальным
                if (result < minResult)
                {
                    minResult = result;
                    minX = x;
                }

                // Запись данных итерации в таблицу
                dataGridView.Rows.Add(iteration, x, result, minX, minResult);

                iteration++;
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверка условия, чтобы выделить клетку с f(x), если не выполняется условие if (prevResult > nextResult)
            if ((e.ColumnIndex == 2 || e.ColumnIndex == 4) && e.RowIndex < dataGridView.Rows.Count - 1 && e.RowIndex >= 1) // проверяем, что это столбец с f(x) и это не последняя строка
            {
                double prevResultValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex - 1].Cells[2].Value);
                double nextResultValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[2].Value); // Получаем значение из следующей строки
                if (!(prevResultValue > nextResultValue))
                {
                    e.CellStyle.BackColor = Color.Red; // устанавливаем красный цвет фона для ячейки с f(x)
                }
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

        private void info_button_Click(object sender, EventArgs e)
        {
            Reference_Form Reference = new Reference_Form();
            Reference.Show();
        }
    }
}
