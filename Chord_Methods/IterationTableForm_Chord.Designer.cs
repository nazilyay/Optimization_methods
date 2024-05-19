namespace Optimization_methods.Secant_Methods
{
    partial class IterationTableForm_Chord
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
            exit_button_chord = new Button();
            dataGridView = new DataGridView();
            button1 = new Button();
            n = new DataGridViewTextBoxColumn();
            x_prev = new DataGridViewTextBoxColumn();
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
            info_button.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            info_button.FlatAppearance.MouseOverBackColor = Color.White;
            info_button.FlatStyle = FlatStyle.Flat;
            info_button.Location = new Point(35, 40);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 35);
            info_button.TabIndex = 32;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            info_button.Click += info_button_Click;
            // 
            // exit_button_chord
            // 
            exit_button_chord.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            exit_button_chord.FlatAppearance.MouseOverBackColor = Color.White;
            exit_button_chord.FlatStyle = FlatStyle.Flat;
            exit_button_chord.Location = new Point(772, 468);
            exit_button_chord.Margin = new Padding(3, 4, 3, 4);
            exit_button_chord.Name = "exit_button_chord";
            exit_button_chord.Size = new Size(100, 35);
            exit_button_chord.TabIndex = 31;
            exit_button_chord.Text = "Выход";
            exit_button_chord.UseVisualStyleBackColor = true;
            exit_button_chord.Click += exit_button_chord_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { n, x_prev, x_k, x_next, f_x, def, second_def, epsilon });
            dataGridView.Location = new Point(35, 109);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(837, 322);
            dataGridView.TabIndex = 33;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.FromArgb(78, 59, 45);
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(167, 29);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 110;
            button1.Text = "Справка";
            button1.UseVisualStyleBackColor = true;
            // 
            // n
            // 
            n.HeaderText = "Итерация";
            n.MinimumWidth = 6;
            n.Name = "n";
            n.ReadOnly = true;
            n.SortMode = DataGridViewColumnSortMode.NotSortable;
            n.Width = 80;
            // 
            // x_prev
            // 
            x_prev.HeaderText = "x_(k-1)";
            x_prev.MinimumWidth = 6;
            x_prev.Name = "x_prev";
            x_prev.ReadOnly = true;
            x_prev.SortMode = DataGridViewColumnSortMode.NotSortable;
            x_prev.Width = 125;
            // 
            // x_k
            // 
            x_k.HeaderText = "x_k";
            x_k.MinimumWidth = 6;
            x_k.Name = "x_k";
            x_k.ReadOnly = true;
            x_k.SortMode = DataGridViewColumnSortMode.NotSortable;
            x_k.Width = 125;
            // 
            // x_next
            // 
            x_next.HeaderText = "x_(k+1)";
            x_next.MinimumWidth = 6;
            x_next.Name = "x_next";
            x_next.ReadOnly = true;
            x_next.SortMode = DataGridViewColumnSortMode.NotSortable;
            x_next.Width = 125;
            // 
            // f_x
            // 
            f_x.HeaderText = "F'(x_(k-1))";
            f_x.MinimumWidth = 6;
            f_x.Name = "f_x";
            f_x.ReadOnly = true;
            f_x.SortMode = DataGridViewColumnSortMode.NotSortable;
            f_x.Width = 125;
            // 
            // def
            // 
            def.HeaderText = "F'(x_k)";
            def.MinimumWidth = 6;
            def.Name = "def";
            def.ReadOnly = true;
            def.SortMode = DataGridViewColumnSortMode.NotSortable;
            def.Width = 125;
            // 
            // second_def
            // 
            second_def.HeaderText = "F(x_(k+1))";
            second_def.MinimumWidth = 6;
            second_def.Name = "second_def";
            second_def.ReadOnly = true;
            second_def.SortMode = DataGridViewColumnSortMode.NotSortable;
            second_def.Width = 125;
            // 
            // epsilon
            // 
            epsilon.HeaderText = "ε";
            epsilon.MinimumWidth = 6;
            epsilon.Name = "epsilon";
            epsilon.ReadOnly = true;
            epsilon.SortMode = DataGridViewColumnSortMode.NotSortable;
            epsilon.Width = 125;
            // 
            // IterationTableForm_Chord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 230, 238);
            ClientSize = new Size(919, 537);
            Controls.Add(button1);
            Controls.Add(dataGridView);
            Controls.Add(info_button);
            Controls.Add(exit_button_chord);
            Name = "IterationTableForm_Chord";
            ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_chord;
        private DataGridView dataGridView;
        private Button button1;
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