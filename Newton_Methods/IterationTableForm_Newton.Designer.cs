namespace Optimization_methods.Newton_Methods
{
    partial class IterationTableForm_Newton
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
            info_button = new Button();
            exit_button_middle = new Button();
            dataGridView = new DataGridView();
            n = new DataGridViewTextBoxColumn();
            x_k = new DataGridViewTextBoxColumn();
            x_next = new DataGridViewTextBoxColumn();
            def = new DataGridViewTextBoxColumn();
            second_def = new DataGridViewTextBoxColumn();
            f_x = new DataGridViewTextBoxColumn();
            epsilon = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // info_button
            // 
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(35, 40);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 29;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button_middle
            // 
            exit_button_middle.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_middle.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_middle.FlatStyle = FlatStyle.Flat;
            exit_button_middle.Location = new Point(668, 465);
            exit_button_middle.Margin = new Padding(3, 4, 3, 4);
            exit_button_middle.Name = "exit_button_middle";
            exit_button_middle.Size = new Size(100, 35);
            exit_button_middle.TabIndex = 28;
            exit_button_middle.Text = "Выход";
            exit_button_middle.UseVisualStyleBackColor = true;
            exit_button_middle.Click += exit_button_middle_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { n, x_k, x_next, def, second_def, f_x, epsilon });
            dataGridView.Location = new Point(35, 107);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(733, 322);
            dataGridView.TabIndex = 27;
            // 
            // n
            // 
            n.HeaderText = "Итерация";
            n.MinimumWidth = 6;
            n.Name = "n";
            n.SortMode = DataGridViewColumnSortMode.NotSortable;
            n.Width = 80;
            // 
            // x_k
            // 
            x_k.HeaderText = "x_k";
            x_k.MinimumWidth = 6;
            x_k.Name = "x_k";
            x_k.Width = 125;
            // 
            // x_next
            // 
            x_next.HeaderText = "x_(k+1)";
            x_next.MinimumWidth = 6;
            x_next.Name = "x_next";
            x_next.Width = 125;
            // 
            // def
            // 
            def.HeaderText = "F'(x_k)";
            def.MinimumWidth = 6;
            def.Name = "def";
            def.Width = 125;
            // 
            // second_def
            // 
            second_def.HeaderText = "F''(x_k)";
            second_def.MinimumWidth = 6;
            second_def.Name = "second_def";
            second_def.Width = 125;
            // 
            // f_x
            // 
            f_x.HeaderText = "F(x_(k+1))";
            f_x.MinimumWidth = 6;
            f_x.Name = "f_x";
            f_x.Width = 125;
            // 
            // epsilon
            // 
            epsilon.HeaderText = "ε";
            epsilon.MinimumWidth = 6;
            epsilon.Name = "epsilon";
            epsilon.Width = 125;
            // 
            // IterationTableForm_Newton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(817, 531);
            Controls.Add(info_button);
            Controls.Add(exit_button_middle);
            Controls.Add(dataGridView);
            Name = "IterationTableForm_Newton";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_middle;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn n;
        private DataGridViewTextBoxColumn x_prev;
        private DataGridViewTextBoxColumn x_k;
        private DataGridViewTextBoxColumn x_next;
        private DataGridViewTextBoxColumn f_x;
        private DataGridViewTextBoxColumn def;
        private DataGridViewTextBoxColumn second_def;
        private DataGridViewTextBoxColumn epsilon;
    }
}