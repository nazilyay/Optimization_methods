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
            begin_button = new Button();
            end_button = new Button();
            previous_step_button = new Button();
            stop_button = new Button();
            next_step_button = new Button();
            info_button = new Button();
            exit_button_search = new Button();
            panel_graph = new Panel();
            number_label = new Label();
            number_textBox = new TextBox();
            number_button = new Button();
            label2 = new Label();
            label3 = new Label();
            Error_number_label = new Label();
            label5 = new Label();
            dataGridView = new DataGridView();
            number = new DataGridViewTextBoxColumn();
            x = new DataGridViewTextBoxColumn();
            result = new DataGridViewTextBoxColumn();
            min_x = new DataGridViewTextBoxColumn();
            result_min = new DataGridViewTextBoxColumn();
            min_button = new Button();
            label1 = new Label();
            label4 = new Label();
            Result_label = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(begin_button);
            groupBox1.Controls.Add(end_button);
            groupBox1.Controls.Add(previous_step_button);
            groupBox1.Controls.Add(stop_button);
            groupBox1.Controls.Add(next_step_button);
            groupBox1.Location = new Point(44, 97);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(358, 95);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Панель управления";
            // 
            // begin_button
            // 
            begin_button.FlatAppearance.BorderSize = 0;
            begin_button.FlatAppearance.MouseOverBackColor = Color.White;
            begin_button.FlatStyle = FlatStyle.Flat;
            begin_button.Font = new Font("Microsoft Sans Serif", 13.8F);
            begin_button.Location = new Point(23, 36);
            begin_button.Margin = new Padding(3, 4, 3, 4);
            begin_button.Name = "begin_button";
            begin_button.Size = new Size(49, 39);
            begin_button.TabIndex = 19;
            begin_button.Text = "↩";
            begin_button.UseVisualStyleBackColor = true;
            begin_button.Click += begin_button_Click;
            // 
            // end_button
            // 
            end_button.FlatAppearance.BorderSize = 0;
            end_button.FlatAppearance.MouseOverBackColor = Color.White;
            end_button.FlatStyle = FlatStyle.Flat;
            end_button.Font = new Font("Microsoft Sans Serif", 13.8F);
            end_button.Location = new Point(291, 36);
            end_button.Margin = new Padding(3, 4, 3, 4);
            end_button.Name = "end_button";
            end_button.Size = new Size(49, 39);
            end_button.TabIndex = 18;
            end_button.Text = "↪";
            end_button.UseVisualStyleBackColor = true;
            end_button.Click += end_button_Click;
            // 
            // previous_step_button
            // 
            previous_step_button.FlatAppearance.BorderSize = 0;
            previous_step_button.FlatAppearance.MouseOverBackColor = Color.White;
            previous_step_button.FlatStyle = FlatStyle.Flat;
            previous_step_button.Font = new Font("Microsoft Sans Serif", 13.8F);
            previous_step_button.Location = new Point(78, 36);
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
            stop_button.FlatAppearance.BorderSize = 0;
            stop_button.FlatAppearance.MouseOverBackColor = Color.White;
            stop_button.FlatStyle = FlatStyle.Flat;
            stop_button.Font = new Font("Microsoft Sans Serif", 13.8F);
            stop_button.Location = new Point(136, 36);
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
            next_step_button.FlatAppearance.BorderSize = 0;
            next_step_button.FlatAppearance.MouseOverBackColor = Color.White;
            next_step_button.FlatStyle = FlatStyle.Flat;
            next_step_button.Font = new Font("Microsoft Sans Serif", 13.8F);
            next_step_button.Location = new Point(236, 36);
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
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(44, 39);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 20;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button_search
            // 
            exit_button_search.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_search.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_search.FlatStyle = FlatStyle.Flat;
            exit_button_search.Location = new Point(882, 476);
            exit_button_search.Margin = new Padding(3, 4, 3, 4);
            exit_button_search.Name = "exit_button_search";
            exit_button_search.Size = new Size(100, 35);
            exit_button_search.TabIndex = 19;
            exit_button_search.Text = "Выход";
            exit_button_search.UseVisualStyleBackColor = true;
            exit_button_search.Click += exit_button_search_Click;
            // 
            // panel_graph
            // 
            panel_graph.Location = new Point(44, 216);
            panel_graph.Name = "panel_graph";
            panel_graph.Size = new Size(358, 248);
            panel_graph.TabIndex = 22;
            // 
            // number_label
            // 
            number_label.AutoSize = true;
            number_label.Location = new Point(454, 54);
            number_label.Name = "number_label";
            number_label.Size = new Size(268, 20);
            number_label.TabIndex = 27;
            number_label.Text = "Введите число отрезков по формуле:";
            // 
            // number_textBox
            // 
            number_textBox.Location = new Point(492, 88);
            number_textBox.Margin = new Padding(3, 4, 3, 4);
            number_textBox.Name = "number_textBox";
            number_textBox.Size = new Size(137, 27);
            number_textBox.TabIndex = 28;
            // 
            // number_button
            // 
            number_button.FlatAppearance.BorderSize = 0;
            number_button.FlatAppearance.MouseOverBackColor = Color.White;
            number_button.FlatStyle = FlatStyle.Flat;
            number_button.Location = new Point(644, 88);
            number_button.Margin = new Padding(3, 4, 3, 4);
            number_button.Name = "number_button";
            number_button.Size = new Size(37, 29);
            number_button.TabIndex = 29;
            number_button.Text = "✓";
            number_button.UseVisualStyleBackColor = true;
            number_button.Click += number_button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(458, 91);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 36;
            label2.Text = "n =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(452, 324);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 37;
            // 
            // Error_number_label
            // 
            Error_number_label.AutoSize = true;
            Error_number_label.Location = new Point(687, 92);
            Error_number_label.Name = "Error_number_label";
            Error_number_label.Size = new Size(41, 20);
            Error_number_label.TabIndex = 43;
            Error_number_label.Text = "Error";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(452, 396);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 39;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { number, x, result, min_x, result_min });
            dataGridView.Location = new Point(458, 143);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(524, 273);
            dataGridView.TabIndex = 44;
            // 
            // number
            // 
            number.HeaderText = "Шаг";
            number.MinimumWidth = 6;
            number.Name = "number";
            number.Width = 50;
            // 
            // x
            // 
            x.HeaderText = "x";
            x.MinimumWidth = 6;
            x.Name = "x";
            x.Width = 125;
            // 
            // result
            // 
            result.HeaderText = "F(x)";
            result.MinimumWidth = 6;
            result.Name = "result";
            result.Width = 125;
            // 
            // min_x
            // 
            min_x.HeaderText = "x_min";
            min_x.MinimumWidth = 6;
            min_x.Name = "min_x";
            min_x.Width = 125;
            // 
            // result_min
            // 
            result_min.HeaderText = "F(x_min)";
            result_min.MinimumWidth = 6;
            result_min.Name = "result_min";
            result_min.Width = 125;
            // 
            // min_button
            // 
            min_button.FlatAppearance.BorderSize = 0;
            min_button.FlatAppearance.MouseOverBackColor = Color.White;
            min_button.FlatStyle = FlatStyle.Flat;
            min_button.Location = new Point(458, 479);
            min_button.Margin = new Padding(3, 4, 3, 4);
            min_button.Name = "min_button";
            min_button.Size = new Size(75, 29);
            min_button.TabIndex = 45;
            min_button.Text = "✓";
            min_button.UseVisualStyleBackColor = true;
            min_button.Click += min_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(454, 442);
            label1.Name = "label1";
            label1.Size = new Size(393, 20);
            label1.TabIndex = 46;
            label1.Text = "Выделите строку с минимальным значением функции!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(548, 483);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 47;
            // 
            // Result_label
            // 
            Result_label.AutoSize = true;
            Result_label.Location = new Point(554, 483);
            Result_label.Name = "Result_label";
            Result_label.Size = new Size(49, 20);
            Result_label.TabIndex = 48;
            Result_label.Text = "Result";
            // 
            // VisualizationForm_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 240);
            ClientSize = new Size(1032, 557);
            Controls.Add(Result_label);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(min_button);
            Controls.Add(dataGridView);
            Controls.Add(Error_number_label);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(number_button);
            Controls.Add(number_textBox);
            Controls.Add(number_label);
            Controls.Add(panel_graph);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Name = "VisualizationForm_Search";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод перебора";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
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
        private Label number_label;
        private TextBox number_textBox;
        private Button number_button;
        private Label label2;
        private Label label3;
        private Label Error_number_label;
        private Label label5;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn number;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn result;
        private DataGridViewTextBoxColumn min_x;
        private DataGridViewTextBoxColumn result_min;
        private Button begin_button;
        private Button end_button;
        private Button min_button;
        private Label label1;
        private Label label4;
        private Label Result_label;
    }
}