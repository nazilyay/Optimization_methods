namespace Optimization_methods.Search_method
{
    partial class VisualizationForm_Search
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
            groupBox1 = new GroupBox();
            previous_step_button = new Button();
            stop_button = new Button();
            next_step_button = new Button();
            info_button = new Button();
            exit_button_search = new Button();
            panel_graph = new Panel();
            x_out_label = new Label();
            f_out_label = new Label();
            label_accuracy = new Label();
            number_label = new Label();
            number_textBox = new TextBox();
            number_button = new Button();
            step_label = new Label();
            step_out_label = new Label();
            x_label = new Label();
            f_label = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label1 = new Label();
            x_min_out_label = new Label();
            f_min_out_label = new Label();
            x_min_label = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            yes_button = new Button();
            no_button = new Button();
            error_label = new Label();
            Error_number_label = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(previous_step_button);
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(next_step_button);
            groupBox1.Location = new Point(38, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 95);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Панель управления";
            // 
            // previous_step_button
            // 
            previous_step_button.Location = new Point(12, 39);
            previous_step_button.Margin = new Padding(3, 4, 3, 4);
            previous_step_button.Name = "previous_step_button";
            previous_step_button.Size = new Size(49, 39);
            previous_step_button.TabIndex = 15;
            previous_step_button.Text = "◀";
            previous_step_button.UseVisualStyleBackColor = true;
            previous_step_button.Click += Previous_step_button_Click;
            // 
            // stop_button
            // 
            stop_button.Location = new Point(70, 39);
            stop_button.Margin = new Padding(3, 4, 3, 4);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(94, 39);
            stop_button.TabIndex = 17;
            stop_button.Text = "⬛";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            // 
            // next_step_button
            // 
            next_step_button.Location = new Point(170, 39);
            next_step_button.Margin = new Padding(3, 4, 3, 4);
            next_step_button.Name = "next_step_button";
            next_step_button.Size = new Size(49, 39);
            next_step_button.TabIndex = 16;
            next_step_button.Text = "▶";
            next_step_button.UseVisualStyleBackColor = true;
            next_step_button.Click += Next_step_button_Click;
            // 
            // info_button
            // 
            info_button.Location = new Point(38, 22);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 20;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button_search
            // 
            exit_button_search.Location = new Point(765, 429);
            exit_button_search.Margin = new Padding(3, 4, 3, 4);
            exit_button_search.Name = "exit_button_search";
            exit_button_search.Size = new Size(75, 29);
            exit_button_search.TabIndex = 19;
            exit_button_search.Text = "Выход";
            exit_button_search.UseVisualStyleBackColor = true;
            exit_button_search.Click += exit_button_search_Click;
            // 
            // panel_graph
            // 
            panel_graph.Location = new Point(38, 191);
            panel_graph.Name = "panel_graph";
            panel_graph.Size = new Size(358, 248);
            panel_graph.TabIndex = 22;
            // 
            // x_out_label
            // 
            x_out_label.AutoSize = true;
            x_out_label.Location = new Point(36, 72);
            x_out_label.Name = "x_out_label";
            x_out_label.Size = new Size(16, 20);
            x_out_label.TabIndex = 23;
            x_out_label.Text = "x";
            // 
            // f_out_label
            // 
            f_out_label.AutoSize = true;
            f_out_label.Location = new Point(51, 106);
            f_out_label.Name = "f_out_label";
            f_out_label.Size = new Size(31, 20);
            f_out_label.TabIndex = 24;
            f_out_label.Text = "f(x)";
            // 
            // label_accuracy
            // 
            label_accuracy.AutoSize = true;
            label_accuracy.Location = new Point(70, 88);
            label_accuracy.Name = "label_accuracy";
            label_accuracy.Size = new Size(0, 20);
            label_accuracy.TabIndex = 25;
            // 
            // number_label
            // 
            number_label.AutoSize = true;
            number_label.Location = new Point(448, 35);
            number_label.Name = "number_label";
            number_label.Size = new Size(287, 20);
            number_label.TabIndex = 27;
            number_label.Text = "Вычислите число отрезков по формуле:";
            // 
            // number_textBox
            // 
            number_textBox.Location = new Point(482, 69);
            number_textBox.Margin = new Padding(3, 4, 3, 4);
            number_textBox.Name = "number_textBox";
            number_textBox.Size = new Size(137, 27);
            number_textBox.TabIndex = 28;
            // 
            // number_button
            // 
            number_button.Location = new Point(634, 69);
            number_button.Margin = new Padding(3, 4, 3, 4);
            number_button.Name = "number_button";
            number_button.Size = new Size(37, 29);
            number_button.TabIndex = 29;
            number_button.Text = "✓";
            number_button.UseVisualStyleBackColor = true;
            number_button.Click += number_button_Click;
            // 
            // step_label
            // 
            step_label.AutoSize = true;
            step_label.Location = new Point(11, 34);
            step_label.Name = "step_label";
            step_label.Size = new Size(40, 20);
            step_label.TabIndex = 30;
            step_label.Text = "Шаг:";
            // 
            // step_out_label
            // 
            step_out_label.AutoSize = true;
            step_out_label.Location = new Point(57, 34);
            step_out_label.Name = "step_out_label";
            step_out_label.Size = new Size(17, 20);
            step_out_label.TabIndex = 31;
            step_out_label.Text = "n";
            // 
            // x_label
            // 
            x_label.AutoSize = true;
            x_label.Location = new Point(11, 72);
            x_label.Name = "x_label";
            x_label.Size = new Size(19, 20);
            x_label.TabIndex = 32;
            x_label.Text = "x:";
            // 
            // f_label
            // 
            f_label.AutoSize = true;
            f_label.Location = new Point(11, 106);
            f_label.Name = "f_label";
            f_label.Size = new Size(36, 20);
            f_label.TabIndex = 33;
            f_label.Text = "F(x):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(f_label);
            groupBox2.Controls.Add(x_out_label);
            groupBox2.Controls.Add(f_out_label);
            groupBox2.Controls.Add(x_label);
            groupBox2.Controls.Add(label_accuracy);
            groupBox2.Controls.Add(step_out_label);
            groupBox2.Controls.Add(step_label);
            groupBox2.Location = new Point(446, 103);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(236, 134);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Результаты итерации:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(x_min_out_label);
            groupBox3.Controls.Add(f_min_out_label);
            groupBox3.Controls.Add(x_min_label);
            groupBox3.Location = new Point(446, 256);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(236, 96);
            groupBox3.TabIndex = 35;
            groupBox3.TabStop = false;
            groupBox3.Text = "Значение минимума на шаге:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 64);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 37;
            label1.Text = "F(x_min):";
            // 
            // x_min_out_label
            // 
            x_min_out_label.AutoSize = true;
            x_min_out_label.Location = new Point(67, 32);
            x_min_out_label.Name = "x_min_out_label";
            x_min_out_label.Size = new Size(47, 20);
            x_min_out_label.TabIndex = 34;
            x_min_out_label.Text = "x_min";
            // 
            // f_min_out_label
            // 
            f_min_out_label.AutoSize = true;
            f_min_out_label.Location = new Point(82, 64);
            f_min_out_label.Name = "f_min_out_label";
            f_min_out_label.Size = new Size(62, 20);
            f_min_out_label.TabIndex = 35;
            f_min_out_label.Text = "f(x_min)";
            // 
            // x_min_label
            // 
            x_min_label.AutoSize = true;
            x_min_label.Location = new Point(11, 32);
            x_min_label.Name = "x_min_label";
            x_min_label.Size = new Size(50, 20);
            x_min_label.TabIndex = 36;
            x_min_label.Text = "x_min:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(448, 72);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 36;
            label2.Text = "n =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(446, 299);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(446, 108);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(446, 371);
            label5.Name = "label5";
            label5.Size = new Size(285, 20);
            label5.TabIndex = 39;
            label5.Text = "Необходимо продолжить вычисления?";
            // 
            // yes_button
            // 
            yes_button.Location = new Point(743, 367);
            yes_button.Margin = new Padding(3, 4, 3, 4);
            yes_button.Name = "yes_button";
            yes_button.Size = new Size(37, 29);
            yes_button.TabIndex = 40;
            yes_button.Text = "✔";
            yes_button.UseVisualStyleBackColor = true;
            yes_button.Click += yes_button_Click;
            // 
            // no_button
            // 
            no_button.Location = new Point(803, 367);
            no_button.Margin = new Padding(3, 4, 3, 4);
            no_button.Name = "no_button";
            no_button.Size = new Size(37, 29);
            no_button.TabIndex = 41;
            no_button.Text = "✖";
            no_button.UseVisualStyleBackColor = true;
            no_button.Click += no_button_Click;
            // 
            // error_label
            // 
            error_label.AutoSize = true;
            error_label.Location = new Point(446, 419);
            error_label.Name = "error_label";
            error_label.Size = new Size(41, 20);
            error_label.TabIndex = 42;
            error_label.Text = "Error";
            // 
            // Error_number_label
            // 
            Error_number_label.AutoSize = true;
            Error_number_label.Location = new Point(677, 73);
            Error_number_label.Name = "Error_number_label";
            Error_number_label.Size = new Size(41, 20);
            Error_number_label.TabIndex = 43;
            Error_number_label.Text = "Error";
            // 
            // VisualizationForm_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 484);
            Controls.Add(Error_number_label);
            Controls.Add(error_label);
            Controls.Add(no_button);
            Controls.Add(yes_button);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(number_button);
            Controls.Add(number_textBox);
            Controls.Add(number_label);
            Controls.Add(panel_graph);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Name = "VisualizationForm_Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VisualizationForm_Search";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button previous_step_button;
        private Button stop_button;
        private Button next_step_button;
        private Button info_button;
        private Button exit_button_search;
        private Panel panel_graph;
        private Label x_out_label;
        private Label f_out_label;
        private Label label_accuracy;
        private Label number_label;
        private TextBox number_textBox;
        private Button number_button;
        private Label step_label;
        private Label step_out_label;
        private Label x_label;
        private Label f_label;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label x_min_out_label;
        private Label f_min_out_label;
        private Label x_min_label;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button yes_button;
        private Button no_button;
        private Label error_label;
        private Label Error_number_label;
    }
}