﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Optimization_methods
{
    public partial class Reference_Form : Form
    {
        public Reference_Form()
        {
            InitializeComponent();

            // Создание элемента управления TabControl
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            this.Controls.Add(tabControl);

            // Добавление вкладок
            AddTabPage(tabControl, "Ввод значений");
            AddTabPage(tabControl, "Метод перебора");
            AddTabPage(tabControl, "...");

            // Добавление текста во вторую вкладку
            InsertTextIntoTabPage(tabControl, 0, @"
Данная справка описывает правила для корректного ввода чисел и функций в математической программе.

______________________________________________________________________________________________________________________________
1. **Ввод чисел:**

    - Вводите числа, используя десятичную систему счисления.
    - Разделитель целой и дробной части - запятая (,).
    - Допустимы отрицательные числа, которые обозначаются знаком минус - перед числом.

    Примеры корректного ввода чисел: 
    - 3,14
    - -10,5
    - 0,123

2. **Ввод функций:**

    - Вводимые функции должны быть записаны в соответствии с синтаксисом программы (*).
    - Допустимы функции с одним аргументом 'x'.

    Примеры корректного ввода функций: 
    - 'Sin(x) + 2,4 - x'
______________________________________________________________________________________________________________________________

**Примечание:**
При вводе функций, учитывайте их область определения и область значений.
В случае неправильного ввода чисел или функций, программа может выдать сообщение об ошибке или некорректных данных.
Эта справка предоставляет основные правила для ввода чисел и функций в программе. Пожалуйста, следуйте этим правилам для корректной работы программы.



*Описание математических функций:*

- **Abs:** Возвращает абсолютное значение указанного числа.
    - Пример: `Abs(-5)` вернет `5`.

- **Acos:** Возвращает угол, косинус которого равен указанному числу (в радианах).
    - Пример: `Acos(0.5)` вернет угол, косинус которого равен `0.5`.

- **Asin:** Возвращает угол, синус которого равен указанному числу (в радианах).
    - Пример: `Asin(0.5)` вернет угол, синус которого равен `0.5`.

- **Atan:** Возвращает угол, тангенс которого равен указанному числу (в радианах).
    - Пример: `Atan(1)` вернет угол, тангенс которого равен `1`.

- **Cos:** Возвращает косинус указанного угла (в радианах).
    - Пример: `Cos(0)` вернет `1`.

- **Exp:** Возвращает число e (основание натурального логарифма) в степени указанного числа.
    - Пример: `Exp(2)` вернет значение e^2.

- **Log:** Возвращает натуральный логарифм указанного числа.
    - Пример: `Log(10)` вернет `2.30258509299405`.

- **Log10:** Возвращает десятичный логарифм указанного числа.
    - Пример: `Log10(100)` вернет `2`.

- **Pow:** Возвращает указанное число, возведенное в указанную степень.
    - Пример: `Pow(2, 3)` вернет `8`.

- **Sin:** Возвращает синус указанного угла (в радианах).
    - Пример: `Sin(0)` вернет `0`.

- **Sqrt:** Возвращает квадратный корень указанного числа.
    - Пример: `Sqrt(9)` вернет `3`.

- **Tan:** Возвращает тангенс указанного угла (в радианах).
    - Пример: `Tan(0)` вернет `0`.");

            // Добавление текста в третью вкладку
            InsertTextIntoTabPage(tabControl, 1, @"
Метод перебора (или полного перебора) является простым, но неэффективным методом одномерной оптимизации. Он основывается на вычислении значений целевой функции f(x) для каждой точки на заданном интервале с определенным шагом. 
______________________________________________________________________________________________________________________________

Описание алгоритма метода перебора:

    Шаг 0. 
Задается параметр точности ε>0, отрезок [a;b]. 
Для того, чтобы обеспечить требуемую точность ε определения точки x*, число n отрезков разбиения 
выбирается из условия ε_n≤ε, 
т.е. назначается n=(b-a)/ε

    Шаг 1. 

Отрезок [a;b] разбивается на n равных частей точками деления:
x_i=a+i(b-a)/n

    Шаг 2. 

Происходит сравнение значений функции f(x) во всех точках x_i и находится точка x_k,0≤k≤n, для которой:
f(x_k)=min⁡{f(x_0 ),f(x_1 ),…,f(x_n)}

    Шаг 3. 

Полагается, что 
x*=x_k,f*=f(x_k ). 
Таким образом, получается решение задачи с погрешностью, не превосходящей величины:
ε_n=(b-a)/n.
");
        }

        // Метод для добавления вкладки
        private void AddTabPage(TabControl tabControl, string tabPageName)
        {
            // Создание вкладки
            TabPage tabPage = new TabPage(tabPageName);
            tabControl.TabPages.Add(tabPage);
        }

        // Метод для вставки текста в указанную вкладку
        private void InsertTextIntoTabPage(TabControl tabControl, int index, string text)
        {
            if (index >= 0 && index < tabControl.TabCount)
            {
                // Получаем вкладку по индексу
                TabPage tabPage = tabControl.TabPages[index];

                // Создаем элемент управления TextBox для ввода текста
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                textBox.Multiline = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Dock = DockStyle.Fill;
                textBox.ReadOnly = true;
                textBox.Text = text;
                textBox.BackColor = Color.FromArgb(245, 245, 240); 

                // Добавляем элемент управления TextBox на вкладку
                tabPage.Controls.Add(textBox);
            }
        }
    }
}
