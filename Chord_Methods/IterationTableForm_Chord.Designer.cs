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
            info_button.Location = new Point(35, 29);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 32;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // exit_button_chord
            // 
            exit_button_chord.Location = new Point(797, 422);
            exit_button_chord.Margin = new Padding(3, 4, 3, 4);
            exit_button_chord.Name = "exit_button_chord";
            exit_button_chord.Size = new Size(75, 29);
            exit_button_chord.TabIndex = 31;
            exit_button_chord.Text = "Выход";
            exit_button_chord.UseVisualStyleBackColor = true;
            exit_button_chord.Click += exit_button_chord_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { n, x_prev, x_k, x_next, f_x, def, second_def, epsilon });
            dataGridView.Location = new Point(35, 80);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(837, 322);
            dataGridView.TabIndex = 33;
            // 
            // n
            // 
            n.HeaderText = "Итерация";
            n.MinimumWidth = 6;
            n.Name = "n";
            n.SortMode = DataGridViewColumnSortMode.NotSortable;
            n.Width = 80;
            // 
            // x_prev
            // 
            x_prev.HeaderText = "x_(k-1)";
            x_prev.MinimumWidth = 6;
            x_prev.Name = "x_prev";
            x_prev.Width = 125;
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
            // f_x
            // 
            f_x.HeaderText = "F'(x_(k-1))";
            f_x.MinimumWidth = 6;
            f_x.Name = "f_x";
            f_x.Width = 125;
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
            second_def.HeaderText = "F(x_(k+1))";
            second_def.MinimumWidth = 6;
            second_def.Name = "second_def";
            second_def.Width = 125;
            // 
            // epsilon
            // 
            epsilon.HeaderText = "ε";
            epsilon.MinimumWidth = 6;
            epsilon.Name = "epsilon";
            epsilon.Width = 125;
            // 
            // IterationTableForm_Chord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 480);
            Controls.Add(dataGridView);
            Controls.Add(info_button);
            Controls.Add(exit_button_chord);
            Name = "IterationTableForm_Chord";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button info_button;
        private Button exit_button_chord;
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