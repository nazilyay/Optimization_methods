﻿namespace Optimization_methods.Dichotomies_Method
{
    partial class DichotomiesMethodsForm
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
            visualization_button = new Button();
            button_dichotomies_graph = new Button();
            error_func_bit = new Label();
            error_label = new Label();
            table_dichotomies_button = new Button();
            data_reset_button = new Button();
            exit_button_dichotomies = new Button();
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
            parameter_label = new Label();
            parameter_textBox = new TextBox();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            function_groupBox.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // visualization_button
            // 
            visualization_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            visualization_button.FlatAppearance.MouseOverBackColor = Color.White;
            visualization_button.FlatStyle = FlatStyle.Flat;
            visualization_button.Location = new Point(547, 401);
            visualization_button.Margin = new Padding(3, 4, 3, 4);
            visualization_button.Name = "visualization_button";
            visualization_button.Size = new Size(173, 35);
            visualization_button.TabIndex = 45;
            visualization_button.Text = "Визуализация метода";
            visualization_button.UseVisualStyleBackColor = true;
            visualization_button.Click += visualization_button_Click;
            // 
            // button_dichotomies_graph
            // 
            button_dichotomies_graph.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            button_dichotomies_graph.FlatAppearance.MouseOverBackColor = Color.White;
            button_dichotomies_graph.FlatStyle = FlatStyle.Flat;
            button_dichotomies_graph.Location = new Point(547, 335);
            button_dichotomies_graph.Margin = new Padding(3, 4, 3, 4);
            button_dichotomies_graph.Name = "button_dichotomies_graph";
            button_dichotomies_graph.Size = new Size(173, 35);
            button_dichotomies_graph.TabIndex = 44;
            button_dichotomies_graph.Text = "График";
            button_dichotomies_graph.UseVisualStyleBackColor = true;
            button_dichotomies_graph.Click += button_dichotomies_graph_Click;
            // 
            // error_func_bit
            // 
            error_func_bit.AutoSize = true;
            error_func_bit.Location = new Point(39, 177);
            error_func_bit.Name = "error_func_bit";
            error_func_bit.Size = new Size(75, 20);
            error_func_bit.TabIndex = 43;
            error_func_bit.Text = "Error_func";
            // 
            // error_label
            // 
            error_label.AutoSize = true;
            error_label.Location = new Point(39, 602);
            error_label.Name = "error_label";
            error_label.Size = new Size(41, 20);
            error_label.TabIndex = 39;
            error_label.Text = "Error";
            // 
            // table_dichotomies_button
            // 
            table_dichotomies_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            table_dichotomies_button.FlatAppearance.MouseOverBackColor = Color.White;
            table_dichotomies_button.FlatStyle = FlatStyle.Flat;
            table_dichotomies_button.Location = new Point(547, 262);
            table_dichotomies_button.Margin = new Padding(3, 4, 3, 4);
            table_dichotomies_button.Name = "table_dichotomies_button";
            table_dichotomies_button.Size = new Size(173, 35);
            table_dichotomies_button.TabIndex = 42;
            table_dichotomies_button.Text = "Таблица вычислений";
            table_dichotomies_button.UseVisualStyleBackColor = true;
            table_dichotomies_button.Click += table_dichotomies_button_Click;
            // 
            // data_reset_button
            // 
            data_reset_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            data_reset_button.FlatAppearance.MouseOverBackColor = Color.White;
            data_reset_button.FlatStyle = FlatStyle.Flat;
            data_reset_button.Location = new Point(227, 555);
            data_reset_button.Margin = new Padding(3, 4, 3, 4);
            data_reset_button.Name = "data_reset_button";
            data_reset_button.Size = new Size(132, 35);
            data_reset_button.TabIndex = 41;
            data_reset_button.Text = "Сброс данных";
            data_reset_button.UseVisualStyleBackColor = true;
            data_reset_button.Click += data_reset_button_Click;
            // 
            // exit_button_dichotomies
            // 
            exit_button_dichotomies.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_dichotomies.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_dichotomies.FlatStyle = FlatStyle.Flat;
            exit_button_dichotomies.Location = new Point(717, 555);
            exit_button_dichotomies.Margin = new Padding(3, 4, 3, 4);
            exit_button_dichotomies.Name = "exit_button_dichotomies";
            exit_button_dichotomies.Size = new Size(100, 35);
            exit_button_dichotomies.TabIndex = 40;
            exit_button_dichotomies.Text = "Выход";
            exit_button_dichotomies.UseVisualStyleBackColor = true;
            exit_button_dichotomies.Click += exit_button_bit_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(result_label);
            groupBox3.Controls.Add(func_result_label);
            groupBox3.Location = new Point(448, 89);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(369, 108);
            groupBox3.TabIndex = 38;
            groupBox3.TabStop = false;
            groupBox3.Text = "Результат работы метода";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 38);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 11;
            label4.Text = "x_min =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 67);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 10;
            label3.Text = "F(x_min) =";
            // 
            // result_label
            // 
            result_label.AutoSize = true;
            result_label.Location = new Point(78, 38);
            result_label.Name = "result_label";
            result_label.Size = new Size(47, 20);
            result_label.TabIndex = 6;
            result_label.Text = "x_min";
            // 
            // func_result_label
            // 
            func_result_label.AutoSize = true;
            func_result_label.Location = new Point(99, 67);
            func_result_label.Name = "func_result_label";
            func_result_label.Size = new Size(64, 20);
            func_result_label.TabIndex = 7;
            func_result_label.Text = "F(x_min)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(accuracy_textBox);
            groupBox2.Location = new Point(39, 345);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(369, 77);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Введите точность";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 31);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 13;
            label2.Text = "ε =";
            // 
            // accuracy_textBox
            // 
            accuracy_textBox.Location = new Point(57, 28);
            accuracy_textBox.Margin = new Padding(3, 4, 3, 4);
            accuracy_textBox.Name = "accuracy_textBox";
            accuracy_textBox.Size = new Size(263, 27);
            accuracy_textBox.TabIndex = 8;
            // 
            // calculate_button
            // 
            calculate_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            calculate_button.FlatAppearance.MouseOverBackColor = Color.White;
            calculate_button.FlatStyle = FlatStyle.Flat;
            calculate_button.Location = new Point(64, 555);
            calculate_button.Margin = new Padding(3, 4, 3, 4);
            calculate_button.Name = "calculate_button";
            calculate_button.Size = new Size(107, 35);
            calculate_button.TabIndex = 35;
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
            groupBox1.Location = new Point(39, 213);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(369, 110);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите концы отрезка";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 73);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 12;
            label1.Text = "b =";
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Location = new Point(24, 37);
            label_2.Name = "label_2";
            label_2.Size = new Size(31, 20);
            label_2.TabIndex = 11;
            label_2.Text = "a =";
            // 
            // b_textBox
            // 
            b_textBox.Location = new Point(57, 70);
            b_textBox.Margin = new Padding(3, 4, 3, 4);
            b_textBox.Name = "b_textBox";
            b_textBox.Size = new Size(263, 27);
            b_textBox.TabIndex = 6;
            // 
            // a_textBox
            // 
            a_textBox.Location = new Point(57, 34);
            a_textBox.Margin = new Padding(3, 4, 3, 4);
            a_textBox.Name = "a_textBox";
            a_textBox.Size = new Size(263, 27);
            a_textBox.TabIndex = 5;
            // 
            // function_groupBox
            // 
            function_groupBox.Controls.Add(label_1);
            function_groupBox.Controls.Add(function_textBox);
            function_groupBox.Controls.Add(function_button);
            function_groupBox.Location = new Point(39, 89);
            function_groupBox.Margin = new Padding(3, 4, 3, 4);
            function_groupBox.Name = "function_groupBox";
            function_groupBox.Padding = new Padding(3, 4, 3, 4);
            function_groupBox.Size = new Size(369, 70);
            function_groupBox.TabIndex = 34;
            function_groupBox.TabStop = false;
            function_groupBox.Text = "Введите функцию";
            // 
            // label_1
            // 
            label_1.AutoSize = true;
            label_1.Location = new Point(8, 31);
            label_1.Name = "label_1";
            label_1.Size = new Size(47, 20);
            label_1.TabIndex = 10;
            label_1.Text = "F(x) =";
            // 
            // function_textBox
            // 
            function_textBox.Location = new Point(61, 28);
            function_textBox.Margin = new Padding(3, 4, 3, 4);
            function_textBox.Name = "function_textBox";
            function_textBox.Size = new Size(259, 27);
            function_textBox.TabIndex = 4;
            // 
            // function_button
            // 
            function_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            function_button.FlatAppearance.BorderSize = 0;
            function_button.FlatAppearance.MouseOverBackColor = Color.White;
            function_button.FlatStyle = FlatStyle.Flat;
            function_button.Location = new Point(326, 27);
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
            info_button.Location = new Point(39, 29);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 33;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button
            // 
            exit_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button.FlatStyle = FlatStyle.Flat;
            exit_button.Location = new Point(448, 555);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(173, 35);
            exit_button.TabIndex = 32;
            exit_button.Text = "На главную страницу";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(parameter_label);
            groupBox4.Controls.Add(parameter_textBox);
            groupBox4.Location = new Point(39, 447);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(369, 77);
            groupBox4.TabIndex = 46;
            groupBox4.TabStop = false;
            groupBox4.Text = "Введите параметр алгоритма";
            // 
            // parameter_label
            // 
            parameter_label.AutoSize = true;
            parameter_label.Location = new Point(23, 35);
            parameter_label.Name = "parameter_label";
            parameter_label.Size = new Size(32, 20);
            parameter_label.TabIndex = 13;
            parameter_label.Text = "δ =";
            // 
            // parameter_textBox
            // 
            parameter_textBox.Location = new Point(57, 32);
            parameter_textBox.Margin = new Padding(3, 4, 3, 4);
            parameter_textBox.Name = "parameter_textBox";
            parameter_textBox.Size = new Size(263, 27);
            parameter_textBox.TabIndex = 8;
            // 
            // DichotomiesMethodsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 240);
            ClientSize = new Size(857, 640);
            Controls.Add(groupBox4);
            Controls.Add(visualization_button);
            Controls.Add(button_dichotomies_graph);
            Controls.Add(error_func_bit);
            Controls.Add(error_label);
            Controls.Add(table_dichotomies_button);
            Controls.Add(data_reset_button);
            Controls.Add(exit_button_dichotomies);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(calculate_button);
            Controls.Add(groupBox1);
            Controls.Add(function_groupBox);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Name = "DichotomiesMethodsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод дихотомии";
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

        private Button visualization_button;
        private Button button_dichotomies_graph;
        private Label error_func_bit;
        private Label error_label;
        private Button table_dichotomies_button;
        private Button data_reset_button;
        private Button exit_button_dichotomies;
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
        private Label parameter_label;
        private TextBox parameter_textBox;
    }
}