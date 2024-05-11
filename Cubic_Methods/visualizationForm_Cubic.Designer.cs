namespace Optimization_methods.Cubic_Methods
{
    partial class visualizationForm_Cubic
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
            groupBox4 = new GroupBox();
            cubic_label = new Label();
            label1 = new Label();
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
            def_2_label = new Label();
            def_1_label = new Label();
            f_2_label = new Label();
            f_1_label = new Label();
            step_out_label = new Label();
            x_2_label = new Label();
            x_1_label = new Label();
            panel_graph = new Panel();
            info_button = new Button();
            exit_button = new Button();
            new_eps_label = new Label();
            groupBox5 = new GroupBox();
            def_0_label = new Label();
            f_0_label = new Label();
            x_0_label = new Label();
            z_label = new Label();
            omega_label = new Label();
            mu_label = new Label();
            groupBox7 = new GroupBox();
            panel1 = new Panel();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.BackgroundImageLayout = ImageLayout.None;
            groupBox4.Controls.Add(cubic_label);
            groupBox4.Controls.Add(label1);
            groupBox4.Location = new Point(454, 428);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(352, 129);
            groupBox4.TabIndex = 115;
            groupBox4.TabStop = false;
            groupBox4.Text = "Кубический интерполяционный многочлен Эрмита";
            // 
            // cubic_label
            // 
            cubic_label.AutoSize = true;
            cubic_label.Location = new Point(21, 51);
            cubic_label.Name = "cubic_label";
            cubic_label.Size = new Size(48, 20);
            cubic_label.TabIndex = 33;
            cubic_label.Text = "P_3(x)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 88);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 25;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(no_button_1);
            groupBox6.Controls.Add(question_1_label);
            groupBox6.Controls.Add(yes_button_1);
            groupBox6.Location = new Point(46, 505);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(358, 103);
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
            no_button_1.Location = new Point(212, 55);
            no_button_1.Margin = new Padding(3, 4, 3, 4);
            no_button_1.Name = "no_button_1";
            no_button_1.Size = new Size(86, 29);
            no_button_1.TabIndex = 63;
            no_button_1.Text = "(x_0; x_2)";
            no_button_1.UseVisualStyleBackColor = true;
            no_button_1.Click += no_button_1_Click;
            // 
            // question_1_label
            // 
            question_1_label.AutoSize = true;
            question_1_label.Location = new Point(41, 23);
            question_1_label.Name = "question_1_label";
            question_1_label.Size = new Size(274, 20);
            question_1_label.TabIndex = 61;
            question_1_label.Text = "К какому новому отрезку переходим?";
            // 
            // yes_button_1
            // 
            yes_button_1.Location = new Point(59, 55);
            yes_button_1.Margin = new Padding(3, 4, 3, 4);
            yes_button_1.Name = "yes_button_1";
            yes_button_1.Size = new Size(86, 29);
            yes_button_1.TabIndex = 62;
            yes_button_1.Text = "(x_1; x_0)";
            yes_button_1.UseVisualStyleBackColor = true;
            yes_button_1.Click += yes_button_1_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(no_2_button);
            groupBox3.Controls.Add(question_2_label);
            groupBox3.Controls.Add(yes_2_button);
            groupBox3.Location = new Point(46, 709);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(358, 103);
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
            Stop_label.Location = new Point(148, 840);
            Stop_label.Name = "Stop_label";
            Stop_label.Size = new Size(137, 20);
            Stop_label.TabIndex = 111;
            Stop_label.Text = "Минимум найден!";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(next_step_button);
            groupBox1.Location = new Point(46, 396);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(454, 120);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 110;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 311);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 109;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(def_2_label);
            groupBox2.Controls.Add(def_1_label);
            groupBox2.Controls.Add(f_2_label);
            groupBox2.Controls.Add(f_1_label);
            groupBox2.Controls.Add(step_out_label);
            groupBox2.Controls.Add(x_2_label);
            groupBox2.Controls.Add(x_1_label);
            groupBox2.Location = new Point(454, 158);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 252);
            groupBox2.TabIndex = 107;
            groupBox2.TabStop = false;
            // 
            // def_2_label
            // 
            def_2_label.AutoSize = true;
            def_2_label.Location = new Point(21, 204);
            def_2_label.Name = "def_2_label";
            def_2_label.Size = new Size(50, 20);
            def_2_label.TabIndex = 83;
            def_2_label.Text = "F'(x_2)";
            // 
            // def_1_label
            // 
            def_1_label.AutoSize = true;
            def_1_label.Location = new Point(21, 174);
            def_1_label.Name = "def_1_label";
            def_1_label.Size = new Size(50, 20);
            def_1_label.TabIndex = 82;
            def_1_label.Text = "F'(x_1)";
            // 
            // f_2_label
            // 
            f_2_label.AutoSize = true;
            f_2_label.Location = new Point(21, 143);
            f_2_label.Name = "f_2_label";
            f_2_label.Size = new Size(47, 20);
            f_2_label.TabIndex = 81;
            f_2_label.Text = "F(x_2)";
            // 
            // f_1_label
            // 
            f_1_label.AutoSize = true;
            f_1_label.Location = new Point(21, 112);
            f_1_label.Name = "f_1_label";
            f_1_label.Size = new Size(47, 20);
            f_1_label.TabIndex = 80;
            f_1_label.Text = "F(x_1)";
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
            // x_2_label
            // 
            x_2_label.AutoSize = true;
            x_2_label.Location = new Point(21, 82);
            x_2_label.Name = "x_2_label";
            x_2_label.Size = new Size(30, 20);
            x_2_label.TabIndex = 37;
            x_2_label.Text = "x_2";
            // 
            // x_1_label
            // 
            x_1_label.AutoSize = true;
            x_1_label.Location = new Point(21, 52);
            x_1_label.Name = "x_1_label";
            x_1_label.Size = new Size(30, 20);
            x_1_label.TabIndex = 23;
            x_1_label.Text = "x_1";
            // 
            // panel_graph
            // 
            panel_graph.Location = new Point(46, 83);
            panel_graph.Name = "panel_graph";
            panel_graph.Size = new Size(358, 294);
            panel_graph.TabIndex = 108;
            // 
            // info_button
            // 
            info_button.Location = new Point(46, 34);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 106;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button
            // 
            exit_button.Location = new Point(731, 836);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(75, 29);
            exit_button.TabIndex = 105;
            exit_button.Text = "Выход";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // new_eps_label
            // 
            new_eps_label.AutoSize = true;
            new_eps_label.Location = new Point(16, 31);
            new_eps_label.Name = "new_eps_label";
            new_eps_label.Size = new Size(16, 20);
            new_eps_label.TabIndex = 69;
            new_eps_label.Text = "ε";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(def_0_label);
            groupBox5.Controls.Add(f_0_label);
            groupBox5.Controls.Add(x_0_label);
            groupBox5.Controls.Add(z_label);
            groupBox5.Controls.Add(omega_label);
            groupBox5.Controls.Add(mu_label);
            groupBox5.Location = new Point(454, 576);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(352, 236);
            groupBox5.TabIndex = 117;
            groupBox5.TabStop = false;
            groupBox5.Text = "Определение новой точки:";
            // 
            // def_0_label
            // 
            def_0_label.AutoSize = true;
            def_0_label.Location = new Point(21, 196);
            def_0_label.Name = "def_0_label";
            def_0_label.Size = new Size(50, 20);
            def_0_label.TabIndex = 37;
            def_0_label.Text = "F'(x_0)";
            // 
            // f_0_label
            // 
            f_0_label.AutoSize = true;
            f_0_label.Location = new Point(21, 165);
            f_0_label.Name = "f_0_label";
            f_0_label.Size = new Size(47, 20);
            f_0_label.TabIndex = 36;
            f_0_label.Text = "F(x_0)";
            // 
            // x_0_label
            // 
            x_0_label.AutoSize = true;
            x_0_label.Location = new Point(21, 133);
            x_0_label.Name = "x_0_label";
            x_0_label.Size = new Size(30, 20);
            x_0_label.TabIndex = 35;
            x_0_label.Text = "x_0";
            // 
            // z_label
            // 
            z_label.AutoSize = true;
            z_label.Location = new Point(21, 102);
            z_label.Name = "z_label";
            z_label.Size = new Size(16, 20);
            z_label.TabIndex = 34;
            z_label.Text = "z";
            // 
            // omega_label
            // 
            omega_label.AutoSize = true;
            omega_label.Location = new Point(21, 72);
            omega_label.Name = "omega_label";
            omega_label.Size = new Size(21, 20);
            omega_label.TabIndex = 33;
            omega_label.Text = "ω";
            // 
            // mu_label
            // 
            mu_label.AutoSize = true;
            mu_label.Location = new Point(21, 41);
            mu_label.Name = "mu_label";
            mu_label.Size = new Size(18, 20);
            mu_label.TabIndex = 32;
            mu_label.Text = "μ";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(new_eps_label);
            groupBox7.Location = new Point(46, 617);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(358, 77);
            groupBox7.TabIndex = 118;
            groupBox7.TabStop = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(454, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 69);
            panel1.TabIndex = 116;
            // 
            // visualizationForm_Cubic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 902);
            Controls.Add(groupBox7);
            Controls.Add(groupBox5);
            Controls.Add(panel1);
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
            Name = "visualizationForm_Cubic";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод кубической аппроксимации";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox4;
        private Label label1;
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
        private Label f_2_label;
        private Label f_1_label;
        private Label step_out_label;
        private Label x_2_label;
        private Label x_1_label;
        private Panel panel_graph;
        private Button info_button;
        private Button exit_button;
        private Label def_2_label;
        private Label def_1_label;
        private Label new_eps_label;
        private GroupBox groupBox5;
        private Label x_0_label;
        private Label z_label;
        private Label omega_label;
        private Label mu_label;
        private GroupBox groupBox7;
        private Label def_0_label;
        private Label f_0_label;
        private Label cubic_label;
        private Panel panel1;
    }
}