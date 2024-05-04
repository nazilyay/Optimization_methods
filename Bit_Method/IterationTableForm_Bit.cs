using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
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

            // Выполнение метода перебора и заполнение таблицы
            PerformBitMethod();

            // Установка ширины столбцов
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 120;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 120;

            // Добавление обработчика события CellFormatting
            dataGridView.CellFormatting += DataGridView_CellFormatting;


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
            int itteration = -1;
            // Цикл поиска минимума
            while (true)
            {
                itteration++;

                // Запись данных итерации в таблицу
                dataGridView.Rows.Add(itteration, x, prevResult, h);
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
                    {  // Проверка условия окончания поиска
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
            // Проверка условия, чтобы выделить клетку с x, если не выполняется условие if (a < x && x < b)
            if (e.ColumnIndex == 1 && e.RowIndex >= 1 && e.RowIndex < dataGridView.Rows.Count - 1)  // проверяем, что это столбец с x и это не заголовок столбца
            {
                double xValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[1].Value);
                if (!(a < xValue && xValue < b))
                {
                    e.CellStyle.BackColor = Color.Yellow; // устанавливаем желтый цвет фона для ячейки с x
                }
            }

            // Проверка условия, чтобы выделить клетку с f(x), если не выполняется условие if (prevResult > nextResult)
            if (e.ColumnIndex == 2 && e.RowIndex < dataGridView.Rows.Count - 1 && e.RowIndex >= 1) // проверяем, что это столбец с f(x) и это не последняя строка
            {
                double prevResultValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex - 1].Cells[2].Value);
                double nextResultValue = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[2].Value); // Получаем значение из следующей строки
                if (!(prevResultValue > nextResultValue))
                {
                    e.CellStyle.BackColor = Color.Red; // устанавливаем красный цвет фона для ячейки с f(x)
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
    }
}
