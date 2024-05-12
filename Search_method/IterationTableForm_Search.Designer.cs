namespace Optimization_methods
{
    partial class IterationTableForm_Search
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
            dataGridView = new DataGridView();
            iteration = new DataGridViewTextBoxColumn();
            x = new DataGridViewTextBoxColumn();
            result = new DataGridViewTextBoxColumn();
            minX = new DataGridViewTextBoxColumn();
            minResult = new DataGridViewTextBoxColumn();
            exit_button_search = new Button();
            info_button = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { iteration, x, result, minX, minResult });
            dataGridView.Location = new Point(46, 104);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(654, 322);
            dataGridView.TabIndex = 0;
            // 
            // iteration
            // 
            iteration.Frozen = true;
            iteration.HeaderText = "Итерация";
            iteration.MinimumWidth = 6;
            iteration.Name = "iteration";
            iteration.SortMode = DataGridViewColumnSortMode.NotSortable;
            iteration.Width = 125;
            // 
            // x
            // 
            x.HeaderText = "x";
            x.MinimumWidth = 6;
            x.Name = "x";
            x.SortMode = DataGridViewColumnSortMode.NotSortable;
            x.Width = 125;
            // 
            // result
            // 
            result.HeaderText = "F(x)";
            result.MinimumWidth = 6;
            result.Name = "result";
            result.SortMode = DataGridViewColumnSortMode.NotSortable;
            result.Width = 125;
            // 
            // minX
            // 
            minX.HeaderText = "x_min";
            minX.MinimumWidth = 6;
            minX.Name = "minX";
            minX.SortMode = DataGridViewColumnSortMode.NotSortable;
            minX.Width = 125;
            // 
            // minResult
            // 
            minResult.HeaderText = "F(x_min)";
            minResult.MinimumWidth = 6;
            minResult.Name = "minResult";
            minResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            minResult.Width = 125;
            // 
            // exit_button_search
            // 
            exit_button_search.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_search.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_search.FlatStyle = FlatStyle.Flat;
            exit_button_search.Location = new Point(600, 455);
            exit_button_search.Margin = new Padding(3, 4, 3, 4);
            exit_button_search.Name = "exit_button_search";
            exit_button_search.Size = new Size(100, 35);
            exit_button_search.TabIndex = 13;
            exit_button_search.Text = "Выход";
            exit_button_search.UseVisualStyleBackColor = true;
            exit_button_search.Click += exit_button_search_Click;
            // 
            // info_button
            // 
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(46, 43);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 14;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // IterationTableForm_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(745, 521);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Controls.Add(dataGridView);
            Name = "IterationTableForm_Search";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button exit_button_search;
        private Button info_button;
        private DataGridViewTextBoxColumn iteration;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn result;
        private DataGridViewTextBoxColumn minX;
        private DataGridViewTextBoxColumn minResult;
    }
}