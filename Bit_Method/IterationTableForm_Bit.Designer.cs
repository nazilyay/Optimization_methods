namespace Optimization_methods.Bit_Method
{
    partial class IterationTableForm
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
            exit_button_search = new Button();
            dataGridView = new DataGridView();
            iteration = new DataGridViewTextBoxColumn();
            x = new DataGridViewTextBoxColumn();
            result = new DataGridViewTextBoxColumn();
            step = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // info_button
            // 
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(51, 39);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 17;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button_search
            // 
            exit_button_search.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_search.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_search.FlatStyle = FlatStyle.Flat;
            exit_button_search.Location = new Point(492, 471);
            exit_button_search.Margin = new Padding(3, 4, 3, 4);
            exit_button_search.Name = "exit_button_search";
            exit_button_search.Size = new Size(100, 35);
            exit_button_search.TabIndex = 16;
            exit_button_search.Text = "Выход";
            exit_button_search.UseVisualStyleBackColor = true;
            exit_button_search.Click += exit_button_search_Click_1;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { iteration, x, result, step });
            dataGridView.Location = new Point(51, 110);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(541, 322);
            dataGridView.TabIndex = 15;
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
            // step
            // 
            step.HeaderText = "h";
            step.MinimumWidth = 6;
            step.Name = "step";
            step.SortMode = DataGridViewColumnSortMode.NotSortable;
            step.Width = 125;
            // 
            // IterationTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(642, 549);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Controls.Add(dataGridView);
            ForeColor = SystemColors.ControlText;
            Name = "IterationTableForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_search;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn iteration;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn result;
        private DataGridViewTextBoxColumn step;
    }
}