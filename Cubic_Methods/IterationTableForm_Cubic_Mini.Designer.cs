namespace Optimization_methods.Cubic_Methods
{
    partial class IterationTableForm_Cubic_Mini
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
            n = new DataGridViewTextBoxColumn();
            x_1 = new DataGridViewTextBoxColumn();
            x_2 = new DataGridViewTextBoxColumn();
            x_0 = new DataGridViewTextBoxColumn();
            f_0 = new DataGridViewTextBoxColumn();
            def_0 = new DataGridViewTextBoxColumn();
            sign = new DataGridViewTextBoxColumn();
            epsilon = new DataGridViewTextBoxColumn();
            info_button = new Button();
            exit_button_cubic = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { n, x_1, x_2, x_0, f_0, def_0, sign, epsilon });
            dataGridView.Location = new Point(41, 80);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(837, 322);
            dataGridView.TabIndex = 39;
            // 
            // n
            // 
            n.HeaderText = "Итерация";
            n.MinimumWidth = 6;
            n.Name = "n";
            n.SortMode = DataGridViewColumnSortMode.NotSortable;
            n.Width = 80;
            // 
            // x_1
            // 
            x_1.HeaderText = "x_1";
            x_1.MinimumWidth = 6;
            x_1.Name = "x_1";
            x_1.Width = 125;
            // 
            // x_2
            // 
            x_2.HeaderText = "x_2";
            x_2.MinimumWidth = 6;
            x_2.Name = "x_2";
            x_2.Width = 125;
            // 
            // x_0
            // 
            x_0.HeaderText = "x_0";
            x_0.MinimumWidth = 6;
            x_0.Name = "x_0";
            x_0.Width = 125;
            // 
            // f_0
            // 
            f_0.HeaderText = "F(x_0)";
            f_0.MinimumWidth = 6;
            f_0.Name = "f_0";
            f_0.Width = 125;
            // 
            // def_0
            // 
            def_0.HeaderText = "F'(x_0)";
            def_0.MinimumWidth = 6;
            def_0.Name = "def_0";
            def_0.Width = 125;
            // 
            // sign
            // 
            sign.HeaderText = "Знак F'(x_0)";
            sign.MinimumWidth = 6;
            sign.Name = "sign";
            sign.Width = 125;
            // 
            // epsilon
            // 
            epsilon.HeaderText = "ε";
            epsilon.MinimumWidth = 6;
            epsilon.Name = "epsilon";
            epsilon.Width = 125;
            // 
            // info_button
            // 
            info_button.Location = new Point(41, 29);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 38;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button_cubic
            // 
            exit_button_cubic.Location = new Point(803, 422);
            exit_button_cubic.Margin = new Padding(3, 4, 3, 4);
            exit_button_cubic.Name = "exit_button_cubic";
            exit_button_cubic.Size = new Size(75, 29);
            exit_button_cubic.TabIndex = 37;
            exit_button_cubic.Text = "Выход";
            exit_button_cubic.UseVisualStyleBackColor = true;
            exit_button_cubic.Click += exit_button_cubic_Click;
            // 
            // IterationTableForm_Cubic_Mini
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 480);
            Controls.Add(dataGridView);
            Controls.Add(info_button);
            Controls.Add(exit_button_cubic);
            Name = "IterationTableForm_Cubic_Mini";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button info_button;
        private Button exit_button_cubic;
        private DataGridViewTextBoxColumn n;
        private DataGridViewTextBoxColumn x_1;
        private DataGridViewTextBoxColumn x_2;
        private DataGridViewTextBoxColumn x_0;
        private DataGridViewTextBoxColumn f_0;
        private DataGridViewTextBoxColumn def_0;
        private DataGridViewTextBoxColumn sign;
        private DataGridViewTextBoxColumn epsilon;
    }
}