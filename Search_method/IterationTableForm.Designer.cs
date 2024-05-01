namespace Optimization_methods
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
            dataGridView = new DataGridView();
            iteration = new DataGridViewTextBoxColumn();
            x = new DataGridViewTextBoxColumn();
            result = new DataGridViewTextBoxColumn();
            minX = new DataGridViewTextBoxColumn();
            minResult = new DataGridViewTextBoxColumn();
            accurac = new DataGridViewTextBoxColumn();
            exit_button_search = new Button();
            info_button = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { iteration, x, result, minX, minResult, accurac });
            dataGridView.Location = new Point(42, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(723, 322);
            dataGridView.TabIndex = 0;
            // 
            // iteration
            // 
            iteration.HeaderText = "Итерация";
            iteration.MinimumWidth = 6;
            iteration.Name = "iteration";
            iteration.Width = 125;
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
            // minX
            // 
            minX.HeaderText = "x_min";
            minX.MinimumWidth = 6;
            minX.Name = "minX";
            minX.Width = 125;
            // 
            // minResult
            // 
            minResult.HeaderText = "F(x_min)";
            minResult.MinimumWidth = 6;
            minResult.Name = "minResult";
            minResult.Width = 125;
            // 
            // accurac
            // 
            accurac.HeaderText = "ε";
            accurac.MinimumWidth = 6;
            accurac.Name = "accurac";
            accurac.Width = 125;
            // 
            // exit_button_search
            // 
            exit_button_search.Location = new Point(690, 408);
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
            info_button.Location = new Point(42, 13);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 14;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // IterationTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(info_button);
            Controls.Add(exit_button_search);
            Controls.Add(dataGridView);
            Name = "IterationTableForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IterationTableForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button exit_button_search;
        private DataGridViewTextBoxColumn iteration;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn result;
        private DataGridViewTextBoxColumn minX;
        private DataGridViewTextBoxColumn minResult;
        private DataGridViewTextBoxColumn accurac;
        private Button info_button;
    }
}