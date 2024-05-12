using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            label.Dock = DockStyle.Fill; // Занимаем всю доступную область формы
            label.Font = new Font("Segoe UI", 12); // Устанавливаем шрифт и размер текста
            label.AutoEllipsis = true; // Включаем перенос текста

            string mistakeText = GetMistakeText(mistake); // Получаем строку с правильным склонением слова "ошибка"

            // В зависимости от значения end выбираем соответствующий текст
            string endText = end ? $"При выполнении пошагово \n" +
                $"'{text}' студент совершил \n" +
                $"{mistake} {mistakeText} \n" +
                $"и получил следующие результаты для функции:\n" +
                $"x_min = {x_min},\nf(x_min) = {f_min}." :
                                   $"Студент не завершил метод до конца!";

            label.Text = endText;
            this.Controls.Add(label);
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
