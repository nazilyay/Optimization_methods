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
            f_x = new DataGridViewTextBoxColumn();
            def = new DataGridViewTextBoxColumn();
            second_def = new DataGridViewTextBoxColumn();
            epsilon = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // info_button
            // 
            info_button.Location = new Point(35, 29);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 29;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button_middle
            // 
            exit_button_middle.Location = new Point(693, 423);
            exit_button_middle.Margin = new Padding(3, 4, 3, 4);
            exit_button_middle.Name = "exit_button_middle";
            exit_button_middle.Size = new Size(75, 29);
            exit_button_middle.TabIndex = 28;
            exit_button_middle.Text = "Выход";
            exit_button_middle.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { n, x_k, x_next, f_x, def, second_def, epsilon });
            dataGridView.Location = new Point(35, 80);
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
            // 
            // x_next
            // 
            x_next.HeaderText = "x_(k+1)";
            x_next.MinimumWidth = 6;
            x_next.Name = "x_next";
            // 
            // f_x
            // 
            f_x.HeaderText = "F(x_k)";
            f_x.MinimumWidth = 6;
            f_x.Name = "f_x";
            // 
            // def
            // 
            def.HeaderText = "F'(x_k)";
            def.MinimumWidth = 6;
            def.Name = "def";
            // 
            // second_def
            // 
            second_def.HeaderText = "F''(x_k)";
            second_def.MinimumWidth = 6;
            second_def.Name = "second_def";
            // 
            // epsilon
            // 
            epsilon.HeaderText = "ε";
            epsilon.MinimumWidth = 6;
            epsilon.Name = "epsilon";
            // 
            // IterationTableForm_Newton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 480);
            Controls.Add(info_button);
            Controls.Add(exit_button_middle);
            Controls.Add(dataGridView);
            Name = "IterationTableForm_Newton";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_middle;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn n;
        private DataGridViewTextBoxColumn x_k;
        private DataGridViewTextBoxColumn x_next;
        private DataGridViewTextBoxColumn f_x;
        private DataGridViewTextBoxColumn def;
        private DataGridViewTextBoxColumn second_def;
        private DataGridViewTextBoxColumn epsilon;
    }
}