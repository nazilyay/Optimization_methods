using System;
using System.Drawing;
using System.Windows.Forms;
using NCalc;

namespace Optimization_methods.Bit_Method
{
    public partial class IterationTableForm : Form
    {
        private string functionExpression;
        private double a;
        private double b;
        private double accuracy;

        public IterationTableForm(string functionExpression, double a, double b, double accuracy)
        {
            InitializeComponent();

            this.functionExpression = functionExpression;
            this.a = a;
            this.b = b;
            this.accuracy = accuracy;

            // Отключаем автоматическую генерацию столбцов
            dataGridView.AutoGenerateColumns = false;

            // Добавляем столбцы вручную
            dataGridView.Columns.Add(CreateColumn("Iteration", "Итерация", 100));
            dataGridView.Columns.Add(CreateColumn("X", "x", 120));
            dataGridView.Columns.Add(CreateColumn("FunctionValue", "F(x)", 120));
            dataGridView.Columns.Add(CreateColumn("Step", "h", 120));

            // Выполнение метода перебора и заполнение таблицы
            PerformBitMethod();

            // Добавление обработчика события CellFormatting
            dataGridView.CellFormatting += DataGridView_CellFormatting;
        }

        private DataGridViewColumn CreateColumn(string name, string headerText, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                Width = width,
                DataPropertyName = name,
                ReadOnly = true, // Отключаем редактирование столбцов
                SortMode = DataGridViewColumnSortMode.NotSortable // Отключаем сортировку

            };
        }

        private void PerformBitMethod()
        {
            // Очистка существующих строк в DataGridView
            dataGridView.Rows.Clear();

            // Начальный шаг
            double h = (b - a) / 4.0;
            // Начальное значение x
            double x = a;
            double prevResult = CalculateFunctionValue(x);
            int iteration = -1;
            // Цикл поиска минимума
            while (true)
            {
                iteration++;

                // Запись данных итерации в таблицу
                dataGridView.Rows.Add(iteration, x, prevResult, h);
                // Вычисление значения функции в следующей точке
                double nextX = x + h;
                double nextResult = CalculateFunctionValue(nextX);
                // Сравнение значений функции
                if (prevResult > nextResult)
                {
                    x = nextX;
                    prevResult = nextResult;
                    // Проверка условия a < x < b
                    if (a < x && x < b)
                        continue;
                    else
                    {
                        // Проверка условия окончания поиска
                        if (Math.Abs(h) <= accuracy)
                            break;

                        // Изменение направления и шага поиска
                        h = -h / 4.0;

                        x = nextX;
                        prevResult = nextResult;
                    }
                }
                else
                {
                    // Проверка условия окончания поиска
                    if (Math.Abs(h) <= accuracy)
                        break;

                    // Изменение направления и шага поиска
                    h = -h / 4.0;

                    x = nextX;
                    prevResult = nextResult;
                }
            }
        }

        // Метод, который будет обрабатывать событие CellFormatting
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверка, что это не заголовок столбца
            if (e.RowIndex >= 0)
            {
                // Проверка условия, чтобы выделить клетку с x, если не выполняется условие if (a < x && x < b)
                if (e.ColumnIndex == 1) // проверяем, что это столбец с x
                {
                    double xValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[1].Value);
                    if (!(a < xValue && xValue < b))
                    {
                        e.CellStyle.BackColor = Color.Yellow; // устанавливаем желтый цвет фона для ячейки с x
                    }
                }

                // Проверка условия, чтобы выделить клетку с f(x), если не выполняется условие if (prevResult > nextResult)
                if (e.ColumnIndex == 2 && e.RowIndex < dataGridView.Rows.Count - 1 && e.RowIndex > 0) // проверяем, что это столбец с f(x) и это не последняя строка
                {
                    double prevResultValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex - 1].Cells[2].Value);
                    double nextResultValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[2].Value); // Получаем значение из следующей строки
                    if (!(prevResultValue > nextResultValue))
                    {
                        e.CellStyle.BackColor = Color.Red; // устанавливаем красный цвет фона для ячейки с f(x)
                    }
                }
            }
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

        private void exit_button_search_Click_1(object sender, EventArgs e)
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
