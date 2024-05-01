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
            SuspendLayout();
            // 
            // start_button
            // 
            start_button.Location = new Point(341, 305);
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
            exit_button.Location = new Point(713, 519);
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
            methods_combobox.FormattingEnabled = true;
            methods_combobox.Location = new Point(403, 101);
            methods_combobox.Margin = new Padding(3, 4, 3, 4);
            methods_combobox.Name = "methods_combobox";
            methods_combobox.Size = new Size(230, 28);
            methods_combobox.TabIndex = 2;
            // 
            // group_of_methods_listBox
            // 
            group_of_methods_listBox.FormattingEnabled = true;
            group_of_methods_listBox.Location = new Point(127, 101);
            group_of_methods_listBox.Margin = new Padding(3, 4, 3, 4);
            group_of_methods_listBox.Name = "group_of_methods_listBox";
            group_of_methods_listBox.Size = new Size(216, 104);
            group_of_methods_listBox.TabIndex = 3;
            // 
            // error_label1
            // 
            error_label1.AutoSize = true;
            error_label1.Location = new Point(127, 222);
            error_label1.Name = "error_label1";
            error_label1.Size = new Size(65, 20);
            error_label1.TabIndex = 4;
            error_label1.Text = "Ошибка";
            // 
            // error_label2
            // 
            error_label2.AutoSize = true;
            error_label2.Location = new Point(403, 222);
            error_label2.Name = "error_label2";
            error_label2.Size = new Size(65, 20);
            error_label2.TabIndex = 5;
            error_label2.Text = "Ошибка";
            // 
            // MenuForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(error_label2);
            Controls.Add(error_label1);
            Controls.Add(group_of_methods_listBox);
            Controls.Add(methods_combobox);
            Controls.Add(exit_button);
            Controls.Add(start_button);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuForms";
            Text = "Численные методы оптимизации";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button start_button;
            private System.Windows.Forms.Button exit_button;
            private System.Windows.Forms.ComboBox methods_combobox;
            private System.Windows.Forms.ListBox group_of_methods_listBox;
            private System.Windows.Forms.Label error_label1;
            private System.Windows.Forms.Label error_label2;
        }


}