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
            methods_groupBox = new GroupBox();
            error_label2 = new Label();
            group_of_methods_listBox = new ListBox();
            methods_combobox = new ComboBox();
            error_label1 = new Label();
            label1 = new Label();
            start_button = new Button();
            info_button = new Button();
            exit_button = new Button();
            methods_groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // methods_groupBox
            // 
            methods_groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            methods_groupBox.BackColor = Color.FromArgb(218, 230, 238);
            methods_groupBox.Controls.Add(error_label2);
            methods_groupBox.Controls.Add(start_button);
            methods_groupBox.Controls.Add(group_of_methods_listBox);
            methods_groupBox.Controls.Add(methods_combobox);
            methods_groupBox.Controls.Add(error_label1);
            methods_groupBox.FlatStyle = FlatStyle.Flat;
            methods_groupBox.Location = new Point(44, 162);
            methods_groupBox.Name = "methods_groupBox";
            methods_groupBox.Size = new Size(675, 257);
            methods_groupBox.TabIndex = 6;
            methods_groupBox.TabStop = false;
            methods_groupBox.Text = "Выберите метод";
            // 
            // error_label2
            // 
            error_label2.AutoSize = true;
            error_label2.ForeColor = Color.FromArgb(78, 59, 45);
            error_label2.Location = new Point(388, 133);
            error_label2.Name = "error_label2";
            error_label2.Size = new Size(65, 20);
            error_label2.TabIndex = 5;
            error_label2.Text = "Ошибка";
            // 
            // group_of_methods_listBox
            // 
            group_of_methods_listBox.BackColor = Color.FromArgb(245, 245, 240);
            group_of_methods_listBox.FormattingEnabled = true;
            group_of_methods_listBox.Location = new Point(25, 48);
            group_of_methods_listBox.Name = "group_of_methods_listBox";
            group_of_methods_listBox.Size = new Size(289, 64);
            group_of_methods_listBox.TabIndex = 3;
            // 
            // methods_combobox
            // 
            methods_combobox.BackColor = Color.FromArgb(245, 245, 240);
            methods_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            methods_combobox.FormattingEnabled = true;
            methods_combobox.Location = new Point(388, 48);
            methods_combobox.Name = "methods_combobox";
            methods_combobox.Size = new Size(244, 28);
            methods_combobox.TabIndex = 2;
            // 
            // error_label1
            // 
            error_label1.AutoSize = true;
            error_label1.ForeColor = Color.FromArgb(78, 59, 45);
            error_label1.Location = new Point(25, 133);
            error_label1.Name = "error_label1";
            error_label1.Size = new Size(65, 20);
            error_label1.TabIndex = 4;
            error_label1.Text = "Ошибка";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(172, 82);
            label1.Name = "label1";
            label1.Size = new Size(437, 46);
            label1.TabIndex = 8;
            label1.Text = "Одномерная оптимизация";
            // 
            // start_button
            // 
            start_button.BackColor = Color.FromArgb(218, 230, 238);
            start_button.BackgroundImageLayout = ImageLayout.Zoom;
            start_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            start_button.FlatAppearance.MouseOverBackColor = Color.White;
            start_button.FlatStyle = FlatStyle.Flat;
            start_button.Location = new Point(25, 194);
            start_button.Name = "start_button";
            start_button.Size = new Size(86, 35);
            start_button.TabIndex = 0;
            start_button.Text = "Пуск";
            start_button.UseVisualStyleBackColor = false;
            start_button.Click += start_button_Click;
            // 
            // info_button
            // 
            info_button.BackColor = Color.FromArgb(218, 230, 238);
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(44, 40);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 7;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = false;
            info_button.Click += info_button_Click;
            // 
            // exit_button
            // 
            exit_button.BackColor = Color.FromArgb(218, 230, 238);
            exit_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button.FlatStyle = FlatStyle.Flat;
            exit_button.Location = new Point(619, 453);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(100, 35);
            exit_button.TabIndex = 1;
            exit_button.Text = "Выход";
            exit_button.UseVisualStyleBackColor = false;
            exit_button.Click += exit_button_Click;
            // 
            // MenuForms
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(775, 524);
            Controls.Add(label1);
            Controls.Add(methods_groupBox);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MenuForms";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Численные методы оптимизации";
            methods_groupBox.ResumeLayout(false);
            methods_groupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox methods_groupBox;
        private Label error_label2;
        private ListBox group_of_methods_listBox;
        private ComboBox methods_combobox;
        private Label error_label1;
        private Label label1;
        private Button start_button;
        private Button info_button;
        private Button exit_button;
    }


}