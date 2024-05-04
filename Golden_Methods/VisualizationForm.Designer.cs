namespace Optimization_methods.Golden_Methods
{
    partial class VisualizationForm
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
            label4 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            epsilon_label = new Label();
            f_2_out_label = new Label();
            f_1_out_label = new Label();
            step_out_label = new Label();
            x_1_out_label = new Label();
            ab_out_label = new Label();
            x_2_out_label = new Label();
            panel_graph = new Panel();
            info_button = new Button();
            exit_button = new Button();
            groupBox4 = new GroupBox();
            new_epsilon_label = new Label();
            new_f_2_label = new Label();
            new_f_1_label = new Label();
            new_x_1_label = new Label();
            new_ab_label = new Label();
            new_x_2_label = new Label();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(no_button_1);
            groupBox6.Controls.Add(question_1_label);
            groupBox6.Controls.Add(yes_button_1);
            groupBox6.Location = new Point(46, 496);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(358, 103);
            groupBox6.TabIndex = 90;
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
            no_button_1.Location = new Point(212, 55);
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
            question_1_label.Location = new Point(59, 22);
            question_1_label.Name = "question_1_label";
            question_1_label.Size = new Size(248, 20);
            question_1_label.TabIndex = 61;
            question_1_label.Text = "Выполнилось условие остановки?";
            // 
            // yes_button_1
            // 
            yes_button_1.Location = new Point(70, 55);
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
            groupBox3.Location = new Point(46, 618);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(358, 103);
            groupBox3.TabIndex = 88;
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
            question_2_label.Location = new Point(134, 22);
            question_2_label.Name = "question_2_label";
            question_2_label.Size = new Size(120, 20);
            question_2_label.TabIndex = 61;
            question_2_label.Text = "F(x_1) <= F(x_2)?";
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
            Stop_label.Location = new Point(454, 661);
            Stop_label.Name = "Stop_label";
            Stop_label.Size = new Size(137, 20);
            Stop_label.TabIndex = 86;
            Stop_label.Text = "Минимум найден!";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(next_step_button);
            groupBox1.Location = new Point(46, 387);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(358, 103);
            groupBox1.TabIndex = 87;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(454, 114);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 85;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 305);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 84;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(epsilon_label);
            groupBox2.Controls.Add(f_2_out_label);
            groupBox2.Controls.Add(f_1_out_label);
            groupBox2.Controls.Add(step_out_label);
            groupBox2.Controls.Add(x_1_out_label);
            groupBox2.Controls.Add(ab_out_label);
            groupBox2.Controls.Add(x_2_out_label);
            groupBox2.Location = new Point(454, 68);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 248);
            groupBox2.TabIndex = 82;
            groupBox2.TabStop = false;
            // 
            // epsilon_label
            // 
            epsilon_label.AutoSize = true;
            epsilon_label.Location = new Point(21, 207);
            epsilon_label.Name = "epsilon_label";
            epsilon_label.Size = new Size(16, 20);
            epsilon_label.TabIndex = 82;
            epsilon_label.Text = "ε";
            // 
            // f_2_out_label
            // 
            f_2_out_label.AutoSize = true;
            f_2_out_label.Location = new Point(21, 176);
            f_2_out_label.Name = "f_2_out_label";
            f_2_out_label.Size = new Size(47, 20);
            f_2_out_label.TabIndex = 81;
            f_2_out_label.Text = "F(x_2)";
            // 
            // f_1_out_label
            // 
            f_1_out_label.AutoSize = true;
            f_1_out_label.Location = new Point(21, 112);
            f_1_out_label.Name = "f_1_out_label";
            f_1_out_label.Size = new Size(47, 20);
            f_1_out_label.TabIndex = 80;
            f_1_out_label.Text = "F(x_1)";
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
            // x_1_out_label
            // 
            x_1_out_label.AutoSize = true;
            x_1_out_label.Location = new Point(21, 82);
            x_1_out_label.Name = "x_1_out_label";
            x_1_out_label.Size = new Size(30, 20);
            x_1_out_label.TabIndex = 37;
            x_1_out_label.Text = "x_1";
            // 
            // ab_out_label
            // 
            ab_out_label.AutoSize = true;
            ab_out_label.Location = new Point(21, 52);
            ab_out_label.Name = "ab_out_label";
            ab_out_label.Size = new Size(43, 20);
            ab_out_label.TabIndex = 23;
            ab_out_label.Text = "(a; b)";
            // 
            // x_2_out_label
            // 
            x_2_out_label.AutoSize = true;
            x_2_out_label.Location = new Point(21, 144);
            x_2_out_label.Name = "x_2_out_label";
            x_2_out_label.Size = new Size(30, 20);
            x_2_out_label.TabIndex = 39;
            x_2_out_label.Text = "x_2";
            // 
            // panel_graph
            // 
            panel_graph.Location = new Point(46, 77);
            panel_graph.Name = "panel_graph";
            panel_graph.Size = new Size(358, 294);
            panel_graph.TabIndex = 83;
            // 
            // info_button
            // 
            info_button.Location = new Point(46, 28);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 81;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button
            // 
            exit_button.Location = new Point(731, 692);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(75, 29);
            exit_button.TabIndex = 80;
            exit_button.Text = "Выход";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(new_epsilon_label);
            groupBox4.Controls.Add(new_f_2_label);
            groupBox4.Controls.Add(new_f_1_label);
            groupBox4.Controls.Add(new_x_1_label);
            groupBox4.Controls.Add(new_ab_label);
            groupBox4.Controls.Add(new_x_2_label);
            groupBox4.Location = new Point(454, 351);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(352, 221);
            groupBox4.TabIndex = 91;
            groupBox4.TabStop = false;
            // 
            // new_epsilon_label
            // 
            new_epsilon_label.AutoSize = true;
            new_epsilon_label.Location = new Point(21, 185);
            new_epsilon_label.Name = "new_epsilon_label";
            new_epsilon_label.Size = new Size(16, 20);
            new_epsilon_label.TabIndex = 82;
            new_epsilon_label.Text = "ε";
            // 
            // new_f_2_label
            // 
            new_f_2_label.AutoSize = true;
            new_f_2_label.Location = new Point(21, 154);
            new_f_2_label.Name = "new_f_2_label";
            new_f_2_label.Size = new Size(47, 20);
            new_f_2_label.TabIndex = 81;
            new_f_2_label.Text = "F(x_2)";
            // 
            // new_f_1_label
            // 
            new_f_1_label.AutoSize = true;
            new_f_1_label.Location = new Point(21, 90);
            new_f_1_label.Name = "new_f_1_label";
            new_f_1_label.Size = new Size(47, 20);
            new_f_1_label.TabIndex = 80;
            new_f_1_label.Text = "F(x_1)";
            // 
            // new_x_1_label
            // 
            new_x_1_label.AutoSize = true;
            new_x_1_label.Location = new Point(21, 60);
            new_x_1_label.Name = "new_x_1_label";
            new_x_1_label.Size = new Size(30, 20);
            new_x_1_label.TabIndex = 37;
            new_x_1_label.Text = "x_1";
            // 
            // new_ab_label
            // 
            new_ab_label.AutoSize = true;
            new_ab_label.Location = new Point(21, 30);
            new_ab_label.Name = "new_ab_label";
            new_ab_label.Size = new Size(43, 20);
            new_ab_label.TabIndex = 23;
            new_ab_label.Text = "(a; b)";
            // 
            // new_x_2_label
            // 
            new_x_2_label.AutoSize = true;
            new_x_2_label.Location = new Point(21, 122);
            new_x_2_label.Name = "new_x_2_label";
            new_x_2_label.Size = new Size(30, 20);
            new_x_2_label.TabIndex = 39;
            new_x_2_label.Text = "x_2";
            // 
            // VisualizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 754);
            Controls.Add(groupBox4);
            Controls.Add(groupBox6);
            Controls.Add(groupBox3);
            Controls.Add(Stop_label);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(panel_graph);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Name = "VisualizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VisualizationForm";
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Label label4;
        private Label label3;
        private GroupBox groupBox2;
        private Label f_2_out_label;
        private Label f_1_out_label;
        private Label step_out_label;
        private Label x_1_out_label;
        private Label ab_out_label;
        private Label x_2_out_label;
        private Panel panel_graph;
        private Button info_button;
        private Button exit_button;
        private Label epsilon_label;
        private GroupBox groupBox4;
        private Label new_epsilon_label;
        private Label new_f_2_label;
        private Label new_f_1_label;
        private Label new_x_1_label;
        private Label new_ab_label;
        private Label new_x_2_label;
    }
}