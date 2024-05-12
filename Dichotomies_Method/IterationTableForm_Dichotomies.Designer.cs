namespace Optimization_methods.Dichotomies_Method
{
    partial class IterationTableForm_Dichotomies
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
            exit_button_dichotomies = new Button();
            dataGridView = new DataGridView();
            iteration = new DataGridViewTextBoxColumn();
            step_a = new DataGridViewTextBoxColumn();
            step_b = new DataGridViewTextBoxColumn();
            epsilon = new DataGridViewTextBoxColumn();
            x_1 = new DataGridViewTextBoxColumn();
            f_x_1 = new DataGridViewTextBoxColumn();
            x_2 = new DataGridViewTextBoxColumn();
            f_x_2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // info_button
            // 
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(45, 43);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 20;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button_dichotomies
            // 
            exit_button_dichotomies.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_dichotomies.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_dichotomies.FlatStyle = FlatStyle.Flat;
            exit_button_dichotomies.Location = new Point(800, 467);
            exit_button_dichotomies.Margin = new Padding(3, 4, 3, 4);
            exit_button_dichotomies.Name = "exit_button_dichotomies";
            exit_button_dichotomies.Size = new Size(100, 35);
            exit_button_dichotomies.TabIndex = 19;
            exit_button_dichotomies.Text = "Выход";
            exit_button_dichotomies.UseVisualStyleBackColor = true;
            exit_button_dichotomies.Click += exit_button_dichotomies_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { iteration, step_a, step_b, epsilon, x_1, f_x_1, x_2, f_x_2 });
            dataGridView.Location = new Point(45, 112);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(855, 322);
            dataGridView.TabIndex = 18;
            // 
            // iteration
            // 
            iteration.Frozen = true;
            iteration.HeaderText = "Итерация";
            iteration.MinimumWidth = 6;
            iteration.Name = "iteration";
            iteration.SortMode = DataGridViewColumnSortMode.NotSortable;
            iteration.Width = 80;
            // 
            // step_a
            // 
            step_a.HeaderText = "a";
            step_a.MinimumWidth = 6;
            step_a.Name = "step_a";
            step_a.SortMode = DataGridViewColumnSortMode.NotSortable;
            step_a.Width = 125;
            // 
            // step_b
            // 
            step_b.HeaderText = "b";
            step_b.MinimumWidth = 6;
            step_b.Name = "step_b";
            step_b.SortMode = DataGridViewColumnSortMode.NotSortable;
            step_b.Width = 125;
            // 
            // epsilon
            // 
            epsilon.HeaderText = "ε_n";
            epsilon.MinimumWidth = 6;
            epsilon.Name = "epsilon";
            epsilon.SortMode = DataGridViewColumnSortMode.NotSortable;
            epsilon.Width = 125;
            // 
            // x_1
            // 
            x_1.HeaderText = "x_1";
            x_1.MinimumWidth = 6;
            x_1.Name = "x_1";
            x_1.SortMode = DataGridViewColumnSortMode.NotSortable;
            x_1.Width = 125;
            // 
            // f_x_1
            // 
            f_x_1.HeaderText = "F(x_1)";
            f_x_1.MinimumWidth = 6;
            f_x_1.Name = "f_x_1";
            f_x_1.SortMode = DataGridViewColumnSortMode.NotSortable;
            f_x_1.Width = 125;
            // 
            // x_2
            // 
            x_2.HeaderText = "x_2";
            x_2.MinimumWidth = 6;
            x_2.Name = "x_2";
            x_2.SortMode = DataGridViewColumnSortMode.NotSortable;
            x_2.Width = 125;
            // 
            // f_x_2
            // 
            f_x_2.HeaderText = "F(x_2)";
            f_x_2.MinimumWidth = 6;
            f_x_2.Name = "f_x_2";
            f_x_2.SortMode = DataGridViewColumnSortMode.NotSortable;
            f_x_2.Width = 125;
            // 
            // IterationTableForm_Dichotomies
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(947, 534);
            Controls.Add(info_button);
            Controls.Add(exit_button_dichotomies);
            Controls.Add(dataGridView);
            Name = "IterationTableForm_Dichotomies";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_dichotomies;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn iteration;
        private DataGridViewTextBoxColumn step_a;
        private DataGridViewTextBoxColumn step_b;
        private DataGridViewTextBoxColumn epsilon;
        private DataGridViewTextBoxColumn x_1;
        private DataGridViewTextBoxColumn f_x_1;
        private DataGridViewTextBoxColumn x_2;
        private DataGridViewTextBoxColumn f_x_2;
    }
}