﻿namespace Optimization_methods.Chord_Methods
{
    partial class GraphForm_Chord
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
            groupBox2 = new GroupBox();
            y_label = new Label();
            x_label = new Label();
            groupBox1 = new GroupBox();
            start_button = new Button();
            stop_button = new Button();
            pause_button = new Button();
            info_button = new Button();
            exit_button = new Button();
            panel1 = new Panel();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(y_label);
            groupBox2.Controls.Add(x_label);
            groupBox2.Location = new Point(609, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(191, 87);
            groupBox2.TabIndex = 111;
            groupBox2.TabStop = false;
            // 
            // y_label
            // 
            y_label.AutoSize = true;
            y_label.Location = new Point(15, 53);
            y_label.Name = "y_label";
            y_label.Size = new Size(38, 20);
            y_label.TabIndex = 22;
            y_label.Text = "F(X):";
            // 
            // x_label
            // 
            x_label.AutoSize = true;
            x_label.Location = new Point(15, 23);
            x_label.Name = "x_label";
            x_label.Size = new Size(21, 20);
            x_label.TabIndex = 21;
            x_label.Text = "X:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(start_button);
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(pause_button);
            groupBox1.Location = new Point(679, 226);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(121, 196);
            groupBox1.TabIndex = 110;
            groupBox1.TabStop = false;
            groupBox1.Text = "Визуализация";
            // 
            // start_button
            // 
            start_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            start_button.FlatAppearance.BorderSize = 0;
            start_button.FlatAppearance.MouseOverBackColor = Color.White;
            start_button.FlatStyle = FlatStyle.Flat;
            start_button.Font = new Font("Segoe UI", 13.8F);
            start_button.Location = new Point(36, 85);
            start_button.Margin = new Padding(3, 4, 3, 4);
            start_button.Name = "start_button";
            start_button.Size = new Size(50, 41);
            start_button.TabIndex = 15;
            start_button.Text = "▶";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // stop_button
            // 
            stop_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            stop_button.FlatAppearance.BorderSize = 0;
            stop_button.FlatAppearance.MouseOverBackColor = Color.White;
            stop_button.FlatStyle = FlatStyle.Flat;
            stop_button.Font = new Font("Segoe UI", 13.8F);
            stop_button.Location = new Point(36, 38);
            stop_button.Margin = new Padding(3, 4, 3, 4);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(50, 41);
            stop_button.TabIndex = 17;
            stop_button.Text = "⬛";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            // 
            // pause_button
            // 
            pause_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            pause_button.FlatAppearance.BorderSize = 0;
            pause_button.FlatAppearance.MouseOverBackColor = Color.White;
            pause_button.FlatStyle = FlatStyle.Flat;
            pause_button.Font = new Font("Segoe UI", 13.8F);
            pause_button.Location = new Point(36, 132);
            pause_button.Margin = new Padding(3, 4, 3, 4);
            pause_button.Name = "pause_button";
            pause_button.Size = new Size(50, 41);
            pause_button.TabIndex = 16;
            pause_button.Text = "❚❚";
            pause_button.UseVisualStyleBackColor = true;
            pause_button.Click += pause_button_Click;
            // 
            // info_button
            // 
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(700, 44);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 109;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button
            // 
            exit_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button.FlatStyle = FlatStyle.Flat;
            exit_button.Location = new Point(700, 461);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(100, 35);
            exit_button.TabIndex = 108;
            exit_button.Text = "Выход";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(215, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 58);
            panel1.TabIndex = 112;
            // 
            // GraphForm_Chord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(845, 537);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Name = "GraphForm_Chord";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "График";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label y_label;
        private Label x_label;
        private GroupBox groupBox1;
        private Button start_button;
        private Button stop_button;
        private Button pause_button;
        private Button info_button;
        private Button exit_button;
        private Panel panel1;
    }
}