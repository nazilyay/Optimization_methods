namespace Optimization_methods
{
        partial class MenuForms
        {
            /// <summary>
            /// Обязательная переменная конструктора.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Освободить все используемые ресурсы.
            /// </summary>
            /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            start_button = new Button();
            exit_button = new Button();
            methods_combobox = new ComboBox();
            group_of_methods_listBox = new ListBox();
            error_label1 = new Label();
            error_label2 = new Label();
            methods_groupBox = new GroupBox();
            info_button = new Button();
            methods_groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // start_button
            // 
            start_button.Location = new Point(25, 246);
            start_button.Margin = new Padding(3, 4, 3, 4);
            start_button.Name = "start_button";
            start_button.Size = new Size(75, 29);
            start_button.TabIndex = 0;
            start_button.Text = "Пуск";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // exit_button
            // 
            exit_button.Location = new Point(661, 500);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(75, 29);
            exit_button.TabIndex = 1;
            exit_button.Text = "Выход";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // methods_combobox
            // 
            methods_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            methods_combobox.FormattingEnabled = true;
            methods_combobox.Location = new Point(390, 48);
            methods_combobox.Margin = new Padding(3, 4, 3, 4);
            methods_combobox.Name = "methods_combobox";
            methods_combobox.Size = new Size(244, 28);
            methods_combobox.TabIndex = 2;
            // 
            // group_of_methods_listBox
            // 
            group_of_methods_listBox.FormattingEnabled = true;
            group_of_methods_listBox.Location = new Point(25, 48);
            group_of_methods_listBox.Margin = new Padding(3, 4, 3, 4);
            group_of_methods_listBox.Name = "group_of_methods_listBox";
            group_of_methods_listBox.Size = new Size(289, 104);
            group_of_methods_listBox.TabIndex = 3;
            // 
            // error_label1
            // 
            error_label1.AutoSize = true;
            error_label1.Location = new Point(25, 175);
            error_label1.Name = "error_label1";
            error_label1.Size = new Size(65, 20);
            error_label1.TabIndex = 4;
            error_label1.Text = "Ошибка";
            // 
            // error_label2
            // 
            error_label2.AutoSize = true;
            error_label2.Location = new Point(390, 175);
            error_label2.Name = "error_label2";
            error_label2.Size = new Size(65, 20);
            error_label2.TabIndex = 5;
            error_label2.Text = "Ошибка";
            // 
            // methods_groupBox
            // 
            methods_groupBox.Controls.Add(error_label2);
            methods_groupBox.Controls.Add(start_button);
            methods_groupBox.Controls.Add(group_of_methods_listBox);
            methods_groupBox.Controls.Add(methods_combobox);
            methods_groupBox.Controls.Add(error_label1);
            methods_groupBox.Location = new Point(63, 123);
            methods_groupBox.Margin = new Padding(3, 4, 3, 4);
            methods_groupBox.Name = "methods_groupBox";
            methods_groupBox.Padding = new Padding(3, 4, 3, 4);
            methods_groupBox.Size = new Size(673, 340);
            methods_groupBox.TabIndex = 6;
            methods_groupBox.TabStop = false;
            methods_groupBox.Text = "Выберите метод";
            // 
            // info_button
            // 
            info_button.Location = new Point(63, 47);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 7;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // MenuForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Controls.Add(methods_groupBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuForms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Численные методы оптимизации";
            methods_groupBox.ResumeLayout(false);
            methods_groupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button start_button;
            private System.Windows.Forms.Button exit_button;
            private System.Windows.Forms.ComboBox methods_combobox;
            private System.Windows.Forms.ListBox group_of_methods_listBox;
            private System.Windows.Forms.Label error_label1;
            private System.Windows.Forms.Label error_label2;
        private GroupBox methods_groupBox;
        private Button info_button;
    }


}