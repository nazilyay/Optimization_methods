using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimization_methods
{
    public partial class End_Form : Form
    {
        public End_Form(int mistake, string text, bool end, double x_min, double f_min)
        {
            InitializeComponent();

            // Создаем и настраиваем Label
            Label label = new Label();
            label.TextAlign = ContentAlignment.MiddleCenter; // Выравниваем текст по центру
            label.Font = new Font("Segoe UI", 14); // Устанавливаем шрифт и размер текста
            label.AutoSize = true; // Включаем автоматическое изменение размера
            label.Padding = new Padding(20, 20, 20, 20); // Устанавливаем отступы: слева, сверху, справа, снизу

            string mistakeText = GetMistakeText(mistake); // Получаем строку с правильным склонением слова "ошибка"

            // В зависимости от значения end выбираем соответствующий текст
            string endText = end ? $"При выполнении пошагово \n" +
                $"'{text}' студент совершил \n" +
                $"{mistake} {mistakeText} \n" +
                $"и получил следующие результаты для функции:\n" +
                $"x_min = {x_min},\nf(x_min) = {f_min}." :
                                   $"Студент не завершил метод до конца!";

            label.Text = endText;

            // Устанавливаем AutoSize для формы
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Добавляем Label на форму
            this.Controls.Add(label);

            // Центрируем форму на экране
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private string GetMistakeText(int mistake)
        {
            // Определяем правильное склонение в зависимости от числа ошибок
            if (mistake == 1)
                return "ошибку";
            else if (mistake > 1 && mistake < 5)
                return "ошибки";
            else
                return "ошибок";
        }
    }
}
