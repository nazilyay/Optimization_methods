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
        public MenuForms()
        {
            InitializeComponent();

            // Добавляем элементы в первый ListBox
            group_of_methods_listBox.Items.Add("Поисковые методы");
            group_of_methods_listBox.Items.Add("Методы исключения отрезков");
            group_of_methods_listBox.Items.Add("Методы, использующие производные");
            group_of_methods_listBox.Items.Add("Метод ломаных");

            // Привязываем обработчик события SelectedIndexChanged к ListBox
            group_of_methods_listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            error_label1.Visible = false; // Скрыть сообщение об ошибке
            error_label2.Visible = false; // Скрыть сообщение об ошибке
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
                    methods_combobox.Items.AddRange(new string[] { "Дихотомия", "Золотое сечение" });
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
            this.Refresh();
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
                                    SearchMethodsForm searchMethods = new SearchMethodsForm();
                                    searchMethods.Show();
                                    this.Hide();
                                    break;
                                case 1: // Если выбран "Метод поразрядного поиска"
                                    BitMethodsForm bitMethods = new BitMethodsForm();
                                    bitMethods.Show();
                                    this.Hide();
                                    break;
                            }
                        }
                        else
                        {
                            error_label2.Text = "Пожалуйста, выберите значение из списка.";
                            error_label2.Visible = true;
                            this.Refresh();
                        }
                        break;
                    case 1: // Если выбраны "Методы исключения отрезков"
                        if (methods_combobox.SelectedItem != null)
                        {

                            switch (methods_combobox.SelectedIndex)
                            {
                                case 0:  // Если выбрана "Дихотомия"
                                    DichotomiesMethodsForm dichotomiesMethods = new DichotomiesMethodsForm();
                                    dichotomiesMethods.Show();
                                    this.Hide();
                                    break;
                                case 1: // Если выбрано "Золотое сечение"
                                    GoldenMethodsForm goldenMethods = new GoldenMethodsForm();
                                    goldenMethods.Show();
                                    this.Hide();
                                    break;
                            }
                        }
                        else
                        {
                            error_label2.Text = "Пожалуйста, выберите значение из списка.";
                            error_label2.Visible = true;
                            this.Refresh();
                        }
                        break;
                    case 2: // Если выбраны "Методы, использующие производные"
                        if (methods_combobox.SelectedItem != null)
                        {

                            switch (methods_combobox.SelectedIndex)
                            {
                                case 0:  // Если выбран "Метод средней точки"
                                    MiddleMethodsForm middleMethods = new MiddleMethodsForm();
                                    middleMethods.Show();
                                    this.Hide();
                                    break;
                                case 1: // Если выбран "Метод Ньютона"
                                    NewtonMethodsForm newtonMethods = new NewtonMethodsForm();
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
                            error_label2.Text = "Пожалуйста, выберите значение из списка.";
                            error_label2.Visible = true;
                            this.Refresh();
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
                error_label1.Text = "Пожалуйста, выберите значение из списка.";
                error_label1.Visible = true; // Показать сообщение об ошибке
                this.Refresh();
            }
        }
    }


    public partial class BitMethodsForm : Form
    {
        public BitMethodsForm()
        {
            /*InitializeComponent();*/
        }
    }

    public partial class DichotomiesMethodsForm : Form
    {
        public DichotomiesMethodsForm()
        {
            /*InitializeComponent();*/
        }
    }

    public partial class GoldenMethodsForm : Form
    {
        public GoldenMethodsForm()
        {
            /*InitializeComponent();*/
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

    public partial class NewtonMethodsForm : Form
    {
        public NewtonMethodsForm()
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

    public partial class MiddleMethodsForm : Form
    {
        public MiddleMethodsForm()
        {
            /*InitializeComponent();*/
        }
    }
}
