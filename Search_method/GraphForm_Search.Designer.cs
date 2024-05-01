namespace Optimization_methods
{
    partial class GraphForm_Search
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
            SuspendLayout();
            // 
            // exit_button_search
            // 
            exit_button_search.Location = new Point(713, 408);
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
            info_button.Location = new Point(12, 408);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 14;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // start_button
            // 
            start_button.Location = new Point(186, 408);
            start_button.Margin = new Padding(3, 4, 3, 4);
            start_button.Name = "start_button";
            start_button.Size = new Size(100, 29);
            start_button.TabIndex = 15;
            start_button.Text = "Старт";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // pause_button
            // 
            pause_button.Location = new Point(313, 408);
            pause_button.Margin = new Padding(3, 4, 3, 4);
            pause_button.Name = "pause_button";
            pause_button.Size = new Size(100, 29);
            pause_button.TabIndex = 16;
            pause_button.Text = "Пауза";
            pause_button.UseVisualStyleBackColor = true;
            pause_button.Click += pause_button_Click;
            // 
            // stop_button
            // 
            stop_button.Location = new Point(438, 408);
            stop_button.Margin = new Padding(3, 4, 3, 4);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(100, 29);
            stop_button.TabIndex = 17;
            stop_button.Text = "stop_button";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            // 
            // GraphForm_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(stop_button);
            Controls.Add(pause_button);
            Controls.Add(start_button);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Name = "GraphForm_Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GraphForm_Search";
            ResumeLayout(false);
        }

        #endregion

        private Button exit_button_search;
        private Button info_button;
        private Button start_button;
        private Button pause_button;
        private Button stop_button;
    }
}