namespace Optimization_methods
{
    partial class GraphForm_Bit
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
            exit_button_search = new Button();
            info_button = new Button();
            start_button = new Button();
            pause_button = new Button();
            stop_button = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            x_coordinateLabel = new Label();
            y_coordinateLabel = new Label();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // exit_button_search
            // 
            exit_button_search.Location = new Point(676, 375);
            exit_button_search.Margin = new Padding(3, 4, 3, 4);
            exit_button_search.Name = "exit_button_search";
            exit_button_search.Size = new Size(75, 29);
            exit_button_search.TabIndex = 13;
            exit_button_search.Text = "Выход";
            exit_button_search.UseVisualStyleBackColor = true;
            exit_button_search.Click += exit_button_search_Click;
            // 
            // info_button
            // 
            info_button.Location = new Point(651, 46);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 14;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // start_button
            // 
            start_button.Location = new Point(36, 85);
            start_button.Margin = new Padding(3, 4, 3, 4);
            start_button.Name = "start_button";
            start_button.Size = new Size(49, 39);
            start_button.TabIndex = 15;
            start_button.Text = "▶";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // pause_button
            // 
            pause_button.Location = new Point(36, 132);
            pause_button.Margin = new Padding(3, 4, 3, 4);
            pause_button.Name = "pause_button";
            pause_button.Size = new Size(49, 39);
            pause_button.TabIndex = 16;
            pause_button.Text = "❚❚";
            pause_button.UseVisualStyleBackColor = true;
            pause_button.Click += pause_button_Click;
            // 
            // stop_button
            // 
            stop_button.Location = new Point(36, 38);
            stop_button.Margin = new Padding(3, 4, 3, 4);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(49, 39);
            stop_button.TabIndex = 17;
            stop_button.Text = "⬛";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(start_button);
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(pause_button);
            groupBox1.Location = new Point(630, 172);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(121, 196);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Визуализация";
            // 
            // x_coordinateLabel
            // 
            x_coordinateLabel.AutoSize = true;
            x_coordinateLabel.Location = new Point(6, 23);
            x_coordinateLabel.Name = "x_coordinateLabel";
            x_coordinateLabel.Size = new Size(21, 20);
            x_coordinateLabel.TabIndex = 19;
            x_coordinateLabel.Text = "X:";
            // 
            // y_coordinateLabel
            // 
            y_coordinateLabel.AutoSize = true;
            y_coordinateLabel.Location = new Point(6, 45);
            y_coordinateLabel.Name = "y_coordinateLabel";
            y_coordinateLabel.Size = new Size(20, 20);
            y_coordinateLabel.TabIndex = 20;
            y_coordinateLabel.Text = "Y:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(x_coordinateLabel);
            groupBox2.Controls.Add(y_coordinateLabel);
            groupBox2.Location = new Point(597, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(191, 73);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Координаты точки:";
            // 
            // GraphForm_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Name = "GraphForm_Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "График";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button exit_button_search;
        private Button info_button;
        private Button start_button;
        private Button pause_button;
        private Button stop_button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private Label x_coordinateLabel;
        private Label y_coordinateLabel;
        private GroupBox groupBox2;
    }
}