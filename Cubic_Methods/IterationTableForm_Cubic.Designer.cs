namespace Optimization_methods.Cubic_Methods
{
    partial class IterationTableForm_Cubic
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
            y_1 = new DataGridViewTextBoxColumn();
            y_2 = new DataGridViewTextBoxColumn();
            def_1 = new DataGridViewTextBoxColumn();
            def_2 = new DataGridViewTextBoxColumn();
            a_0 = new DataGridViewTextBoxColumn();
            a_1 = new DataGridViewTextBoxColumn();
            a_2 = new DataGridViewTextBoxColumn();
            a_3 = new DataGridViewTextBoxColumn();
            mu = new DataGridViewTextBoxColumn();
            omega = new DataGridViewTextBoxColumn();
            z = new DataGridViewTextBoxColumn();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { n, x_1, x_2, x_0, f_0, y_1, y_2, def_1, def_2, a_0, a_1, a_2, a_3, mu, omega, z, def_0, sign, epsilon });
            dataGridView.Location = new Point(41, 110);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(837, 322);
            dataGridView.TabIndex = 36;
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
            // y_1
            // 
            y_1.HeaderText = "F(x_1)";
            y_1.MinimumWidth = 6;
            y_1.Name = "y_1";
            y_1.Width = 125;
            // 
            // y_2
            // 
            y_2.HeaderText = "F(x_2)";
            y_2.MinimumWidth = 6;
            y_2.Name = "y_2";
            y_2.Width = 125;
            // 
            // def_1
            // 
            def_1.HeaderText = "F'(x_1)";
            def_1.MinimumWidth = 6;
            def_1.Name = "def_1";
            def_1.Width = 125;
            // 
            // def_2
            // 
            def_2.HeaderText = "F'(x_2)";
            def_2.MinimumWidth = 6;
            def_2.Name = "def_2";
            def_2.Width = 125;
            // 
            // a_0
            // 
            a_0.HeaderText = "a_0";
            a_0.MinimumWidth = 6;
            a_0.Name = "a_0";
            a_0.Width = 125;
            // 
            // a_1
            // 
            a_1.HeaderText = "a_1";
            a_1.MinimumWidth = 6;
            a_1.Name = "a_1";
            a_1.Width = 125;
            // 
            // a_2
            // 
            a_2.HeaderText = "a_2";
            a_2.MinimumWidth = 6;
            a_2.Name = "a_2";
            a_2.Width = 125;
            // 
            // a_3
            // 
            a_3.HeaderText = "a_3";
            a_3.MinimumWidth = 6;
            a_3.Name = "a_3";
            a_3.Width = 125;
            // 
            // mu
            // 
            mu.HeaderText = "μ";
            mu.MinimumWidth = 6;
            mu.Name = "mu";
            mu.Width = 125;
            // 
            // omega
            // 
            omega.HeaderText = "ω";
            omega.MinimumWidth = 6;
            omega.Name = "omega";
            omega.Width = 125;
            // 
            // z
            // 
            z.HeaderText = "z";
            z.MinimumWidth = 6;
            z.Name = "z";
            z.Width = 125;
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
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(41, 43);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 35;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button_cubic
            // 
            exit_button_cubic.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_cubic.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_cubic.FlatStyle = FlatStyle.Flat;
            exit_button_cubic.Location = new Point(778, 473);
            exit_button_cubic.Margin = new Padding(3, 4, 3, 4);
            exit_button_cubic.Name = "exit_button_cubic";
            exit_button_cubic.Size = new Size(100, 35);
            exit_button_cubic.TabIndex = 34;
            exit_button_cubic.Text = "Выход";
            exit_button_cubic.UseVisualStyleBackColor = true;
            exit_button_cubic.Click += exit_button_Cubic_Click;
            // 
            // IterationTableForm_Cubic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(931, 547);
            Controls.Add(dataGridView);
            Controls.Add(info_button);
            Controls.Add(exit_button_cubic);
            Name = "IterationTableForm_Cubic";
            ShowIcon = false;
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
        private DataGridViewTextBoxColumn y_1;
        private DataGridViewTextBoxColumn y_2;
        private DataGridViewTextBoxColumn def_1;
        private DataGridViewTextBoxColumn def_2;
        private DataGridViewTextBoxColumn a_0;
        private DataGridViewTextBoxColumn a_1;
        private DataGridViewTextBoxColumn a_2;
        private DataGridViewTextBoxColumn a_3;
        private DataGridViewTextBoxColumn mu;
        private DataGridViewTextBoxColumn omega;
        private DataGridViewTextBoxColumn z;
        private DataGridViewTextBoxColumn def_0;
        private DataGridViewTextBoxColumn sign;
        private DataGridViewTextBoxColumn epsilon;
    }
}