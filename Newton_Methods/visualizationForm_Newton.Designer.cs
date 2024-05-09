namespace Optimization_methods.Newton_Methods
{
    partial class visualizationForm_Newton
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
            groupBox6 = new GroupBox();
            label6 = new Label();
            no_button_1 = new Button();
            question_1_label = new Label();
            yes_button_1 = new Button();
            groupBox3 = new GroupBox();
            label2 = new Label();
            no_2_button = new Button();
            question_2_label = new Label();
            yes_2_button = new Button();
            Stop_label = new Label();
            groupBox1 = new GroupBox();
            stop_button = new Button();
            next_step_button = new Button();
            label3 = new Label();
            groupBox2 = new GroupBox();
            x_next = new Label();
            epsilon_label = new Label();
            second_def_label = new Label();
            def_out_label = new Label();
            f_out_label = new Label();
            step_out_label = new Label();
            x_out_label = new Label();
            panel_graph = new Panel();
            info_button = new Button();
            exit_button = new Button();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(no_button_1);
            groupBox6.Controls.Add(question_1_label);
            groupBox6.Controls.Add(yes_button_1);
            groupBox6.Location = new Point(441, 31);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(358, 121);
            groupBox6.TabIndex = 114;
            groupBox6.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 88);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 25;
            // 
            // no_button_1
            // 
            no_button_1.Location = new Point(212, 79);
            no_button_1.Margin = new Padding(3, 4, 3, 4);
            no_button_1.Name = "no_button_1";
            no_button_1.Size = new Size(75, 29);
            no_button_1.TabIndex = 63;
            no_button_1.Text = "Нет";
            no_button_1.UseVisualStyleBackColor = true;
            no_button_1.Click += no_button_1_Click;
            // 
            // question_1_label
            // 
            question_1_label.AutoSize = true;
            question_1_label.Location = new Point(70, 23);
            question_1_label.Name = "question_1_label";
            question_1_label.Size = new Size(211, 20);
            question_1_label.TabIndex = 61;
            question_1_label.Text = "Начальное приближение 3.6";
            question_1_label.TextAlign = ContentAlignment.TopCenter;
            // 
            // yes_button_1
            // 
            yes_button_1.Location = new Point(70, 79);
            yes_button_1.Margin = new Padding(3, 4, 3, 4);
            yes_button_1.Name = "yes_button_1";
            yes_button_1.Size = new Size(75, 29);
            yes_button_1.TabIndex = 62;
            yes_button_1.Text = "Да";
            yes_button_1.UseVisualStyleBackColor = true;
            yes_button_1.Click += yes_button_1_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(no_2_button);
            groupBox3.Controls.Add(question_2_label);
            groupBox3.Controls.Add(yes_2_button);
            groupBox3.Location = new Point(441, 415);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(352, 103);
            groupBox3.TabIndex = 113;
            groupBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 88);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 25;
            // 
            // no_2_button
            // 
            no_2_button.Location = new Point(212, 59);
            no_2_button.Margin = new Padding(3, 4, 3, 4);
            no_2_button.Name = "no_2_button";
            no_2_button.Size = new Size(75, 29);
            no_2_button.TabIndex = 63;
            no_2_button.Text = "Нет";
            no_2_button.UseVisualStyleBackColor = true;
            no_2_button.Click += no_button_2_Click;
            // 
            // question_2_label
            // 
            question_2_label.AutoSize = true;
            question_2_label.Location = new Point(59, 23);
            question_2_label.Name = "question_2_label";
            question_2_label.Size = new Size(248, 20);
            question_2_label.TabIndex = 61;
            question_2_label.Text = "Выполнилось условие остановки?";
            // 
            // yes_2_button
            // 
            yes_2_button.Location = new Point(70, 59);
            yes_2_button.Margin = new Padding(3, 4, 3, 4);
            yes_2_button.Name = "yes_2_button";
            yes_2_button.Size = new Size(75, 29);
            yes_2_button.TabIndex = 62;
            yes_2_button.Text = "Да";
            yes_2_button.UseVisualStyleBackColor = true;
            yes_2_button.Click += yes_button_2_Click;
            // 
            // Stop_label
            // 
            Stop_label.AutoSize = true;
            Stop_label.Location = new Point(342, 541);
            Stop_label.Name = "Stop_label";
            Stop_label.Size = new Size(137, 20);
            Stop_label.TabIndex = 111;
            Stop_label.Text = "Минимум найден!";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(next_step_button);
            groupBox1.Location = new Point(39, 415);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(358, 103);
            groupBox1.TabIndex = 112;
            groupBox1.TabStop = false;
            groupBox1.Text = "Панель управления";
            // 
            // stop_button
            // 
            stop_button.Location = new Point(212, 45);
            stop_button.Margin = new Padding(3, 4, 3, 4);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(75, 39);
            stop_button.TabIndex = 17;
            stop_button.Text = "⬛";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            // 
            // next_step_button
            // 
            next_step_button.Location = new Point(70, 45);
            next_step_button.Margin = new Padding(3, 4, 3, 4);
            next_step_button.Name = "next_step_button";
            next_step_button.Size = new Size(75, 39);
            next_step_button.TabIndex = 16;
            next_step_button.Text = "▶";
            next_step_button.UseVisualStyleBackColor = true;
            next_step_button.Click += Next_step_button_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(447, 308);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 109;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(x_next);
            groupBox2.Controls.Add(epsilon_label);
            groupBox2.Controls.Add(second_def_label);
            groupBox2.Controls.Add(def_out_label);
            groupBox2.Controls.Add(f_out_label);
            groupBox2.Controls.Add(step_out_label);
            groupBox2.Controls.Add(x_out_label);
            groupBox2.Location = new Point(441, 158);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 236);
            groupBox2.TabIndex = 107;
            groupBox2.TabStop = false;
            // 
            // x_next
            // 
            x_next.AutoSize = true;
            x_next.Location = new Point(21, 170);
            x_next.Name = "x_next";
            x_next.Size = new Size(57, 20);
            x_next.TabIndex = 83;
            x_next.Text = "x_(k+1)";
            // 
            // epsilon_label
            // 
            epsilon_label.AutoSize = true;
            epsilon_label.Location = new Point(21, 199);
            epsilon_label.Name = "epsilon_label";
            epsilon_label.Size = new Size(16, 20);
            epsilon_label.TabIndex = 82;
            epsilon_label.Text = "ε";
            // 
            // second_def_label
            // 
            second_def_label.AutoSize = true;
            second_def_label.Location = new Point(21, 141);
            second_def_label.Name = "second_def_label";
            second_def_label.Size = new Size(52, 20);
            second_def_label.TabIndex = 82;
            second_def_label.Text = "F''(x_k)";
            // 
            // def_out_label
            // 
            def_out_label.AutoSize = true;
            def_out_label.Location = new Point(21, 110);
            def_out_label.Name = "def_out_label";
            def_out_label.Size = new Size(49, 20);
            def_out_label.TabIndex = 81;
            def_out_label.Text = "F'(x_k)";
            // 
            // f_out_label
            // 
            f_out_label.AutoSize = true;
            f_out_label.Location = new Point(21, 80);
            f_out_label.Name = "f_out_label";
            f_out_label.Size = new Size(46, 20);
            f_out_label.TabIndex = 80;
            f_out_label.Text = "F(x_k)";
            // 
            // step_out_label
            // 
            step_out_label.AutoSize = true;
            step_out_label.Location = new Point(21, 21);
            step_out_label.Name = "step_out_label";
            step_out_label.Size = new Size(17, 20);
            step_out_label.TabIndex = 31;
            step_out_label.Text = "n";
            // 
            // x_out_label
            // 
            x_out_label.AutoSize = true;
            x_out_label.Location = new Point(21, 51);
            x_out_label.Name = "x_out_label";
            x_out_label.Size = new Size(29, 20);
            x_out_label.TabIndex = 37;
            x_out_label.Text = "x_k";
            // 
            // panel_graph
            // 
            panel_graph.Location = new Point(39, 80);
            panel_graph.Name = "panel_graph";
            panel_graph.Size = new Size(358, 314);
            panel_graph.TabIndex = 108;
            // 
            // info_button
            // 
            info_button.Location = new Point(39, 31);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 106;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button
            // 
            exit_button.Location = new Point(718, 537);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(75, 29);
            exit_button.TabIndex = 105;
            exit_button.Text = "Выход";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // visualizationForm_Newton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 596);
            Controls.Add(groupBox6);
            Controls.Add(groupBox3);
            Controls.Add(Stop_label);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(panel_graph);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Name = "visualizationForm_Newton";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод Ньютона";
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox6;
        private Label label6;
        private Button no_button_1;
        private Label question_1_label;
        private Button yes_button_1;
        private GroupBox groupBox3;
        private Label label2;
        private Button no_2_button;
        private Label question_2_label;
        private Button yes_2_button;
        private Label Stop_label;
        private GroupBox groupBox1;
        private Button stop_button;
        private Button next_step_button;
        private Label label3;
        private GroupBox groupBox2;
        private Label def_out_label;
        private Label f_out_label;
        private Label step_out_label;
        private Label x_out_label;
        private Panel panel_graph;
        private Button info_button;
        private Button exit_button;
        private Label epsilon_label;
        private Label second_def_label;
        private Label x_next;
    }
}