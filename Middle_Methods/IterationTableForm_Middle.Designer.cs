namespace Optimization_methods.Middle_Methods
{
    partial class IterationTableForm_Middle
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
            iteration = new DataGridViewTextBoxColumn();
            step_a = new DataGridViewTextBoxColumn();
            step_b = new DataGridViewTextBoxColumn();
            x = new DataGridViewTextBoxColumn();
            df_x = new DataGridViewTextBoxColumn();
            sign = new DataGridViewTextBoxColumn();
            eps = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // info_button
            // 
            info_button.Location = new Point(42, 29);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 26;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button_middle
            // 
            exit_button_middle.Location = new Point(723, 424);
            exit_button_middle.Margin = new Padding(3, 4, 3, 4);
            exit_button_middle.Name = "exit_button_middle";
            exit_button_middle.Size = new Size(75, 29);
            exit_button_middle.TabIndex = 25;
            exit_button_middle.Text = "Выход";
            exit_button_middle.UseVisualStyleBackColor = true;
            exit_button_middle.Click += exit_button_middle_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { iteration, step_a, step_b, x, df_x, sign, eps });
            dataGridView.Location = new Point(42, 80);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(756, 322);
            dataGridView.TabIndex = 24;
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
            // x
            // 
            x.HeaderText = "x";
            x.MinimumWidth = 6;
            x.Name = "x";
            x.SortMode = DataGridViewColumnSortMode.NotSortable;
            x.Width = 125;
            // 
            // df_x
            // 
            df_x.HeaderText = "F'(x)";
            df_x.MinimumWidth = 6;
            df_x.Name = "df_x";
            df_x.SortMode = DataGridViewColumnSortMode.NotSortable;
            df_x.Width = 125;
            // 
            // sign
            // 
            sign.HeaderText = "Знак F'(x)";
            sign.MinimumWidth = 6;
            sign.Name = "sign";
            sign.SortMode = DataGridViewColumnSortMode.NotSortable;
            sign.Width = 125;
            // 
            // eps
            // 
            eps.HeaderText = "ε";
            eps.MinimumWidth = 6;
            eps.Name = "eps";
            eps.SortMode = DataGridViewColumnSortMode.NotSortable;
            eps.Width = 125;
            // 
            // IterationTableForm_Middle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 479);
            Controls.Add(info_button);
            Controls.Add(exit_button_middle);
            Controls.Add(dataGridView);
            Name = "IterationTableForm_Middle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IterationTableForm_Middle";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_middle;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn iteration;
        private DataGridViewTextBoxColumn step_a;
        private DataGridViewTextBoxColumn step_b;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn df_x;
        private DataGridViewTextBoxColumn sign;
        private DataGridViewTextBoxColumn eps;
    }
}