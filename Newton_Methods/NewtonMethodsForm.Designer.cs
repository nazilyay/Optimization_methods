namespace Optimization_methods.Newton_Methods
{
    partial class NewtonMethodsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            visualization_newton_button = new Button();
            button_newton_graph = new Button();
            error_func = new Label();
            error_label = new Label();
            table_newton_button = new Button();
            data_reset_button = new Button();
            exit_button_newton = new Button();
            groupBox3 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            result_label = new Label();
            func_result_label = new Label();
            groupBox2 = new GroupBox();
            label2 = new Label();
            accuracy_textBox = new TextBox();
            calculate_button = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label_2 = new Label();
            b_textBox = new TextBox();
            a_textBox = new TextBox();
            function_groupBox = new GroupBox();
            label_1 = new Label();
            function_textBox = new TextBox();
            function_button = new Button();
            info_button = new Button();
            exit_button = new Button();
            groupBox4 = new GroupBox();
            x_0_label = new Label();
            x_0_textBox = new TextBox();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            function_groupBox.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // visualization_newton_button
            // 
            visualization_newton_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            visualization_newton_button.FlatAppearance.MouseOverBackColor = Color.White;
            visualization_newton_button.FlatStyle = FlatStyle.Flat;
            visualization_newton_button.Location = new Point(548, 414);
            visualization_newton_button.Margin = new Padding(3, 4, 3, 4);
            visualization_newton_button.Name = "visualization_newton_button";
            visualization_newton_button.Size = new Size(175, 35);
            visualization_newton_button.TabIndex = 88;
            visualization_newton_button.Text = "Визуализация метода";
            visualization_newton_button.UseVisualStyleBackColor = true;
            visualization_newton_button.Click += visualization_newton_button_Click;
            // 
            // button_newton_graph
            // 
            button_newton_graph.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            button_newton_graph.FlatAppearance.MouseOverBackColor = Color.White;
            button_newton_graph.FlatStyle = FlatStyle.Flat;
            button_newton_graph.Location = new Point(548, 342);
            button_newton_graph.Margin = new Padding(3, 4, 3, 4);
            button_newton_graph.Name = "button_newton_graph";
            button_newton_graph.Size = new Size(175, 35);
            button_newton_graph.TabIndex = 87;
            button_newton_graph.Text = "График";
            button_newton_graph.UseVisualStyleBackColor = true;
            button_newton_graph.Click += button_newton_graph_Click;
            // 
            // error_func
            // 
            error_func.AutoSize = true;
            error_func.Location = new Point(39, 179);
            error_func.Name = "error_func";
            error_func.Size = new Size(75, 20);
            error_func.TabIndex = 86;
            error_func.Text = "Error_func";
            // 
            // error_label
            // 
            error_label.AutoSize = true;
            error_label.Location = new Point(39, 586);
            error_label.Name = "error_label";
            error_label.Size = new Size(41, 20);
            error_label.TabIndex = 82;
            error_label.Text = "Error";
            // 
            // table_newton_button
            // 
            table_newton_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            table_newton_button.FlatAppearance.MouseOverBackColor = Color.White;
            table_newton_button.FlatStyle = FlatStyle.Flat;
            table_newton_button.Location = new Point(548, 269);
            table_newton_button.Margin = new Padding(3, 4, 3, 4);
            table_newton_button.Name = "table_newton_button";
            table_newton_button.Size = new Size(175, 35);
            table_newton_button.TabIndex = 85;
            table_newton_button.Text = "Таблица вычислений";
            table_newton_button.UseVisualStyleBackColor = true;
            table_newton_button.Click += table_newton_button_Click;
            // 
            // data_reset_button
            // 
            data_reset_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            data_reset_button.FlatAppearance.MouseOverBackColor = Color.White;
            data_reset_button.FlatStyle = FlatStyle.Flat;
            data_reset_button.Location = new Point(259, 539);
            data_reset_button.Margin = new Padding(3, 4, 3, 4);
            data_reset_button.Name = "data_reset_button";
            data_reset_button.Size = new Size(100, 35);
            data_reset_button.TabIndex = 84;
            data_reset_button.Text = "Сброс данных";
            data_reset_button.UseVisualStyleBackColor = true;
            data_reset_button.Click += data_reset_button_Click;
            // 
            // exit_button_newton
            // 
            exit_button_newton.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_newton.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_newton.FlatStyle = FlatStyle.Flat;
            exit_button_newton.Location = new Point(718, 539);
            exit_button_newton.Margin = new Padding(3, 4, 3, 4);
            exit_button_newton.Name = "exit_button_newton";
            exit_button_newton.Size = new Size(100, 35);
            exit_button_newton.TabIndex = 83;
            exit_button_newton.Text = "Выход";
            exit_button_newton.UseVisualStyleBackColor = true;
            exit_button_newton.Click += exit_button_newton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(result_label);
            groupBox3.Controls.Add(func_result_label);
            groupBox3.Location = new Point(449, 91);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(369, 108);
            groupBox3.TabIndex = 81;
            groupBox3.TabStop = false;
            groupBox3.Text = "Результат работы метода";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 41);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 11;
            label4.Text = "x_min =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 70);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 10;
            label3.Text = "F(x_min) =";
            // 
            // result_label
            // 
            result_label.AutoSize = true;
            result_label.Location = new Point(78, 41);
            result_label.Name = "result_label";
            result_label.Size = new Size(47, 20);
            result_label.TabIndex = 6;
            result_label.Text = "x_min";
            // 
            // func_result_label
            // 
            func_result_label.AutoSize = true;
            func_result_label.Location = new Point(99, 70);
            func_result_label.Name = "func_result_label";
            func_result_label.Size = new Size(64, 20);
            func_result_label.TabIndex = 7;
            func_result_label.Text = "F(x_min)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(accuracy_textBox);
            groupBox2.Location = new Point(39, 344);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(369, 77);
            groupBox2.TabIndex = 80;
            groupBox2.TabStop = false;
            groupBox2.Text = "Введите точность";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 36);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 13;
            label2.Text = "ε =";
            // 
            // accuracy_textBox
            // 
            accuracy_textBox.Location = new Point(64, 33);
            accuracy_textBox.Margin = new Padding(3, 4, 3, 4);
            accuracy_textBox.Name = "accuracy_textBox";
            accuracy_textBox.Size = new Size(256, 27);
            accuracy_textBox.TabIndex = 8;
            // 
            // calculate_button
            // 
            calculate_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            calculate_button.FlatAppearance.MouseOverBackColor = Color.White;
            calculate_button.FlatStyle = FlatStyle.Flat;
            calculate_button.Location = new Point(103, 539);
            calculate_button.Margin = new Padding(3, 4, 3, 4);
            calculate_button.Name = "calculate_button";
            calculate_button.Size = new Size(100, 35);
            calculate_button.TabIndex = 78;
            calculate_button.Text = "Вычислить";
            calculate_button.UseVisualStyleBackColor = true;
            calculate_button.Click += calculate_button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label_2);
            groupBox1.Controls.Add(b_textBox);
            groupBox1.Controls.Add(a_textBox);
            groupBox1.Location = new Point(39, 215);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(369, 110);
            groupBox1.TabIndex = 79;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите концы отрезка";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 68);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 12;
            label1.Text = "b =";
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Location = new Point(27, 33);
            label_2.Name = "label_2";
            label_2.Size = new Size(31, 20);
            label_2.TabIndex = 11;
            label_2.Text = "a =";
            // 
            // b_textBox
            // 
            b_textBox.Location = new Point(64, 65);
            b_textBox.Margin = new Padding(3, 4, 3, 4);
            b_textBox.Name = "b_textBox";
            b_textBox.Size = new Size(256, 27);
            b_textBox.TabIndex = 6;
            // 
            // a_textBox
            // 
            a_textBox.Location = new Point(64, 30);
            a_textBox.Margin = new Padding(3, 4, 3, 4);
            a_textBox.Name = "a_textBox";
            a_textBox.Size = new Size(256, 27);
            a_textBox.TabIndex = 5;
            // 
            // function_groupBox
            // 
            function_groupBox.Controls.Add(label_1);
            function_groupBox.Controls.Add(function_textBox);
            function_groupBox.Controls.Add(function_button);
            function_groupBox.Location = new Point(39, 91);
            function_groupBox.Margin = new Padding(3, 4, 3, 4);
            function_groupBox.Name = "function_groupBox";
            function_groupBox.Padding = new Padding(3, 4, 3, 4);
            function_groupBox.Size = new Size(369, 70);
            function_groupBox.TabIndex = 77;
            function_groupBox.TabStop = false;
            function_groupBox.Text = "Введите функцию";
            // 
            // label_1
            // 
            label_1.AutoSize = true;
            label_1.Location = new Point(11, 30);
            label_1.Name = "label_1";
            label_1.Size = new Size(47, 20);
            label_1.TabIndex = 10;
            label_1.Text = "F(x) =";
            // 
            // function_textBox
            // 
            function_textBox.Location = new Point(64, 28);
            function_textBox.Margin = new Padding(3, 4, 3, 4);
            function_textBox.Name = "function_textBox";
            function_textBox.Size = new Size(256, 27);
            function_textBox.TabIndex = 4;
            // 
            // function_button
            // 
            function_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            function_button.FlatAppearance.BorderSize = 0;
            function_button.FlatAppearance.MouseOverBackColor = Color.White;
            function_button.FlatStyle = FlatStyle.Flat;
            function_button.Location = new Point(326, 26);
            function_button.Margin = new Padding(3, 4, 3, 4);
            function_button.Name = "function_button";
            function_button.Size = new Size(37, 29);
            function_button.TabIndex = 3;
            function_button.Text = "✓";
            function_button.UseVisualStyleBackColor = true;
            function_button.Click += function_button_Click;
            // 
            // info_button
            // 
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(39, 37);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 76;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button
            // 
            exit_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button.FlatStyle = FlatStyle.Flat;
            exit_button.Location = new Point(449, 539);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(175, 35);
            exit_button.TabIndex = 75;
            exit_button.Text = "На главную страницу";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(x_0_label);
            groupBox4.Controls.Add(x_0_textBox);
            groupBox4.Location = new Point(39, 443);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(369, 77);
            groupBox4.TabIndex = 89;
            groupBox4.TabStop = false;
            groupBox4.Text = "Введите начальное приближение";
            // 
            // x_0_label
            // 
            x_0_label.AutoSize = true;
            x_0_label.Location = new Point(14, 37);
            x_0_label.Name = "x_0_label";
            x_0_label.Size = new Size(44, 20);
            x_0_label.TabIndex = 13;
            x_0_label.Text = "x_0 =";
            // 
            // x_0_textBox
            // 
            x_0_textBox.Location = new Point(64, 34);
            x_0_textBox.Margin = new Padding(3, 4, 3, 4);
            x_0_textBox.Name = "x_0_textBox";
            x_0_textBox.Size = new Size(256, 27);
            x_0_textBox.TabIndex = 8;
            // 
            // NewtonMethodsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 240);
            ClientSize = new Size(864, 626);
            Controls.Add(groupBox4);
            Controls.Add(visualization_newton_button);
            Controls.Add(button_newton_graph);
            Controls.Add(error_func);
            Controls.Add(error_label);
            Controls.Add(table_newton_button);
            Controls.Add(data_reset_button);
            Controls.Add(exit_button_newton);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(calculate_button);
            Controls.Add(groupBox1);
            Controls.Add(function_groupBox);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Name = "NewtonMethodsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод Ньютона";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            function_groupBox.ResumeLayout(false);
            function_groupBox.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button visualization_newton_button;
        private Button button_newton_graph;
        private Label error_func;
        private Label error_label;
        private Button table_newton_button;
        private Button data_reset_button;
        private Button exit_button_newton;
        private GroupBox groupBox3;
        private Label label4;
        private Label label3;
        private Label result_label;
        private Label func_result_label;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox accuracy_textBox;
        private Button calculate_button;
        private GroupBox groupBox1;
        private Label label1;
        private Label label_2;
        private TextBox b_textBox;
        private TextBox a_textBox;
        private GroupBox function_groupBox;
        private Label label_1;
        private TextBox function_textBox;
        private Button function_button;
        private Button info_button;
        private Button exit_button;
        private GroupBox groupBox4;
        private Label x_0_label;
        private TextBox x_0_textBox;
    }
}