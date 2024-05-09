using Optimization_methods.Dichotomies_Method;
using Optimization_methods.Golden_Methods;
using Optimization_methods.Middle_Methods;
using Optimization_methods.Newton_Methods;
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
    public partial class MenuForms : Form
    {
        private MenuForms menuForm;

        public MenuForms()
        {
            InitializeComponent();

            // Сохраняем ссылку на экземпляр формы MenuForms
            this.menuForm = menuForm;


            // Привязываем обработчик события SelectedIndexChanged к ListBox
            group_of_methods_listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            // Привязываем обработчики событий для нажатия клавиш
            group_of_methods_listBox.KeyDown += GroupListBox_KeyDown;
            methods_combobox.KeyDown += MethodsComboBox_KeyDown;

            // Добавляем элементы в первый ListBox
            group_of_methods_listBox.Items.Add("Поисковые методы");
            group_of_methods_listBox.Items.Add("Методы исключения отрезков");
            group_of_methods_listBox.Items.Add("Методы, использующие производные");
            group_of_methods_listBox.Items.Add("Метод ломаных");


            error_label1.Visible = false; // Скрыть сообщение об ошибке
            error_label2.Visible = false; // Скрыть сообщение об ошибке
        }
        private void GroupListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (group_of_methods_listBox.SelectedIndex != 3) {                 
                    // Переходим к выбору в methods_combobox
                methods_combobox.Focus();
                methods_combobox.DroppedDown = true; // Раскрываем список
                e.Handled = true;}

            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                // Перемещаем выбор в списке вверх или вниз
                if (group_of_methods_listBox.Items.Count > 0)
                {
                    int currentIndex = group_of_methods_listBox.SelectedIndex;
                    if (e.KeyCode == Keys.Up && currentIndex > 0)
                    {
                        group_of_methods_listBox.SelectedIndex = currentIndex - 1;
                    }
                    else if (e.KeyCode == Keys.Down && currentIndex < group_of_methods_listBox.Items.Count - 1)
                    {
                        group_of_methods_listBox.SelectedIndex = currentIndex + 1;
                    }
                }
                e.Handled = true;
            }
        }

        private void MethodsComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Нажатие Enter для нажатия кнопки start_button
                start_button.PerformClick();
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Переходим к выбору в group_of_methods_listBox
                group_of_methods_listBox.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                // Перемещаем выбор в списке вверх или вниз
                if (methods_combobox.Items.Count > 0)
                {
                    int currentIndex = methods_combobox.SelectedIndex;
                    if (e.KeyCode == Keys.Up && currentIndex > 0)
                    {
                        methods_combobox.SelectedIndex = currentIndex - 1;
                    }
                    else if (e.KeyCode == Keys.Down && currentIndex < methods_combobox.Items.Count - 1)
                    {
                        methods_combobox.SelectedIndex = currentIndex + 1;
                    }
                }
                e.Handled = true;
            }
        }
            private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (group_of_methods_listBox.SelectedIndex)
            {
                case 0: // Если выбраны "Поисковые методы"
                    methods_combobox.Items.Clear();
                    methods_combobox.Items.AddRange(new string[] { "Метод перебора", "Метод поразрядного поиска"  });
                    methods_combobox.Enabled = true;
                    break;
                case 1: // Если выбраны "Методы исключения отрезков"
                    methods_combobox.Items.Clear();
                    methods_combobox.Items.AddRange(new string[] { "Метод дихотомии", "Метод золотого сечения" });
                    methods_combobox.Enabled = true;
                    break;
                case 2: // Если выбраны "Методы, использующие производные"
                    methods_combobox.Items.Clear();
                    methods_combobox.Items.AddRange(new string[] { "Метод средней точки", "Метод Ньютона", "Метод хорд", "Метод кубической аппроксимации" });
                    methods_combobox.Enabled = true;
                    break;
                default: // Если выбран другой элемент, очищаем ComboBox и отключаем его
                    methods_combobox.Items.Clear();
                    methods_combobox.Enabled = false;
                    break;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            error_label1.Visible = false; // Скрыть сообщение об ошибке
            error_label2.Visible = false; // Скрыть сообщение об ошибке
            if (group_of_methods_listBox.SelectedItem != null)
            {
                switch (group_of_methods_listBox.SelectedIndex)
                {
                    case 0: // Если выбраны "Поисковые методы"
                        if (methods_combobox.SelectedItem != null)
                        {

                            switch (methods_combobox.SelectedIndex)
                            {
                                case 0:  // Если выбран "Метод перебора"
                                    SearchMethodsForm searchMethods = new SearchMethodsForm(this);
                                    searchMethods.Show();
                                    this.Hide();
                                    break;
                                case 1: // Если выбран "Метод поразрядного поиска"
                                    BitMethodsForm bitMethods = new BitMethodsForm(this);
                                    bitMethods.Show();
                                    this.Hide();
                                    break;
                            }
                        }
                        else
                        {
                            error_label2.Text = "Выберите значение из списка.";
                            error_label2.Visible = true;
                        }
                        break;
                    case 1: // Если выбраны "Методы исключения отрезков"
                        if (methods_combobox.SelectedItem != null)
                        {

                            switch (methods_combobox.SelectedIndex)
                            {
                                case 0:  // Если выбрана "Дихотомия"
                                    DichotomiesMethodsForm dichotomiesMethods = new DichotomiesMethodsForm(this);
                                    dichotomiesMethods.Show();
                                    this.Hide();
                                    break;
                                case 1: // Если выбрано "Метод золотого сечения"
                                    GoldenMethodsForm goldenMethods = new GoldenMethodsForm(this);
                                    goldenMethods.Show();
                                    this.Hide();
                                    break;
                            }
                        }
                        else
                        {
                            error_label2.Text = "Выберите значение из списка.";
                            error_label2.Visible = true;
                        }
                        break;
                    case 2: // Если выбраны "Методы, использующие производные"
                        if (methods_combobox.SelectedItem != null)
                        {

                            switch (methods_combobox.SelectedIndex)
                            {
                                case 0:  // Если выбран "Метод средней точки"
                                    MiddleMethodsForm middleMethods = new MiddleMethodsForm(this);
                                    middleMethods.Show();
                                    this.Hide();
                                    break;
                                case 1: // Если выбран "Метод Ньютона"
                                    NewtonMethodsForm newtonMethods = new NewtonMethodsForm(this);
                                    newtonMethods.Show();
                                    this.Hide();
                                    break;
                                case 2:  // Если выбран "Метод хорд"
                                    ChordMethodsForm chordMethods = new ChordMethodsForm();
                                    chordMethods.Show();
                                    this.Hide();
                                    break;
                                case 3: // Если выбран "Метод кубической аппроксимации"
                                    CubicMethodsForm cubicMethods = new CubicMethodsForm();
                                    cubicMethods.Show();
                                    this.Hide();
                                    break;
                            }
                        }
                        else
                        {
                            error_label2.Text = "Выберите значение из списка.";
                            error_label2.Visible = true;
                        }
                        break;
                    case 3: // Если выбран "Метод ломаных"
                        PolylinesMethodsForm polylinesMethods = new PolylinesMethodsForm();
                        polylinesMethods.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                error_label1.Text = "Выберите значение из списка.";
                error_label1.Visible = true; // Показать сообщение об ошибке
            }
        }
    }

    public partial class PolylinesMethodsForm : Form
    {
        public PolylinesMethodsForm()
        {
            /*InitializeComponent();*/
        }
    }

    public partial class ChordMethodsForm : Form
    {
        public ChordMethodsForm()
        {
            /*InitializeComponent();*/
        }
    }


    public partial class CubicMethodsForm : Form
    {
        public CubicMethodsForm()
        {
            /*InitializeComponent();*/
        }
    }
}
