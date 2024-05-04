namespace Optimization_methods
{
    partial class SearchMethodsForm
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
            exit_button = new Button();
            info_button = new Button();
            function_button = new Button();
            function_groupBox = new GroupBox();
            label_1 = new Label();
            function_textBox = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label_2 = new Label();
            b_textBox = new TextBox();
            a_textBox = new TextBox();
            result_label = new Label();
            func_result_label = new Label();
            accuracy_textBox = new TextBox();
            calculate_button = new Button();
            groupBox2 = new GroupBox();
            label2 = new Label();
            groupBox3 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            exit_button_search = new Button();
            data_reset_button = new Button();
            table_search_button = new Button();
            error_label = new Label();
            error_func_search = new Label();
            button_graph_search = new Button();
            Visualization_button = new Button();
            function_groupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // exit_button
            // 
            exit_button.Location = new Point(526, 461);
            exit_button.Margin = new Padding(3, 4, 3, 4);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(173, 29);
            exit_button.TabIndex = 0;
            exit_button.Text = "На главную страницу";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // info_button
            // 
            info_button.Location = new Point(39, 27);
            info_button.Margin = new Padding(3, 4, 3, 4);
            info_button.Name = "info_button";
            info_button.Size = new Size(100, 29);
            info_button.TabIndex = 1;
            info_button.Text = "Справка";
            info_button.UseVisualStyleBackColor = true;
            // 
            // function_button
            // 
            function_button.Location = new Point(301, 27);
            function_button.Margin = new Padding(3, 4, 3, 4);
            function_button.Name = "function_button";
            function_button.Size = new Size(37, 29);
            function_button.TabIndex = 3;
            function_button.Text = "✓";
            function_button.UseVisualStyleBackColor = true;
            function_button.Click += function_button_Click;
            // 
            // function_groupBox
            // 
            function_groupBox.Controls.Add(label_1);
            function_groupBox.Controls.Add(function_textBox);
            function_groupBox.Controls.Add(function_button);
            function_groupBox.Location = new Point(39, 87);
            function_groupBox.Margin = new Padding(3, 4, 3, 4);
            function_groupBox.Name = "function_groupBox";
            function_groupBox.Padding = new Padding(3, 4, 3, 4);
            function_groupBox.Size = new Size(369, 70);
            function_groupBox.TabIndex = 4;
            function_groupBox.TabStop = false;
            function_groupBox.Text = "Введите функцию";
            // 
            // label_1
            // 
            label_1.AutoSize = true;
            label_1.Location = new Point(15, 31);
            label_1.Name = "label_1";
            label_1.Size = new Size(47, 20);
            label_1.TabIndex = 10;
            label_1.Text = "F(x) =";
            // 
            // function_textBox
            // 
            function_textBox.Location = new Point(64, 28);
            function_textBox.Margin = new Padding(3, 4, 3, 4);
            function_textBox.Name = "function_textBox";
            function_textBox.Size = new Size(222, 27);
            function_textBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label_2);
            groupBox1.Controls.Add(b_textBox);
            groupBox1.Controls.Add(a_textBox);
            groupBox1.Location = new Point(39, 211);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(369, 110);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите концы отрезка";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 63);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 12;
            label1.Text = "b =";
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Location = new Point(23, 31);
            label_2.Name = "label_2";
            label_2.Size = new Size(31, 20);
            label_2.TabIndex = 11;
            label_2.Text = "a =";
            // 
            // b_textBox
            // 
            b_textBox.Location = new Point(64, 63);
            b_textBox.Margin = new Padding(3, 4, 3, 4);
            b_textBox.Name = "b_textBox";
            b_textBox.Size = new Size(263, 27);
            b_textBox.TabIndex = 6;
            // 
            // a_textBox
            // 
            a_textBox.Location = new Point(64, 28);
            a_textBox.Margin = new Padding(3, 4, 3, 4);
            a_textBox.Name = "a_textBox";
            a_textBox.Size = new Size(263, 27);
            a_textBox.TabIndex = 5;
            // 
            // result_label
            // 
            result_label.AutoSize = true;
            result_label.Location = new Point(78, 36);
            result_label.Name = "result_label";
            result_label.Size = new Size(47, 20);
            result_label.TabIndex = 6;
            result_label.Text = "x_min";
            // 
            // func_result_label
            // 
            func_result_label.AutoSize = true;
            func_result_label.Location = new Point(99, 65);
            func_result_label.Name = "func_result_label";
            func_result_label.Size = new Size(64, 20);
            func_result_label.TabIndex = 7;
            func_result_label.Text = "F(x_min)";
            // 
            // accuracy_textBox
            // 
            accuracy_textBox.Location = new Point(64, 28);
            accuracy_textBox.Margin = new Padding(3, 4, 3, 4);
            accuracy_textBox.Name = "accuracy_textBox";
            accuracy_textBox.Size = new Size(263, 27);
            accuracy_textBox.TabIndex = 8;
            // 
            // calculate_button
            // 
            calculate_button.Location = new Point(76, 452);
            calculate_button.Margin = new Padding(3, 4, 3, 4);
            calculate_button.Name = "calculate_button";
            calculate_button.Size = new Size(107, 38);
            calculate_button.TabIndex = 5;
            calculate_button.Text = "Вычислить";
            calculate_button.UseVisualStyleBackColor = true;
            calculate_button.Click += calculate_button_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(accuracy_textBox);
            groupBox2.Location = new Point(39, 353);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(369, 77);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Введите точность";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 31);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 13;
            label2.Text = "ε =";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(result_label);
            groupBox3.Controls.Add(func_result_label);
            groupBox3.Location = new Point(448, 87);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(369, 108);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Результат работы метода";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 36);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 11;
            label4.Text = "x_min =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 65);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 10;
            label3.Text = "F(x_min) =";
            // 
            // exit_button_search
            // 
            exit_button_search.Location = new Point(742, 461);
            exit_button_search.Margin = new Padding(3, 4, 3, 4);
            exit_button_search.Name = "exit_button_search";
            exit_button_search.Size = new Size(75, 29);
            exit_button_search.TabIndex = 12;
            exit_button_search.Text = "Выход";
            exit_button_search.UseVisualStyleBackColor = true;
            exit_button_search.Click += exit_button_search_Click;
            // 
            // data_reset_button
            // 
            data_reset_button.Location = new Point(245, 452);
            data_reset_button.Margin = new Padding(3, 4, 3, 4);
            data_reset_button.Name = "data_reset_button";
            data_reset_button.Size = new Size(132, 38);
            data_reset_button.TabIndex = 13;
            data_reset_button.Text = "Сброс данных";
            data_reset_button.UseVisualStyleBackColor = true;
            data_reset_button.Click += data_reset_button_Click;
            // 
            // table_search_button
            // 
            table_search_button.Location = new Point(526, 231);
            table_search_button.Margin = new Padding(3, 4, 3, 4);
            table_search_button.Name = "table_search_button";
            table_search_button.Size = new Size(173, 29);
            table_search_button.TabIndex = 14;
            table_search_button.Text = "Таблица вычислений";
            table_search_button.UseVisualStyleBackColor = true;
            table_search_button.Click += table_search_Click;
            // 
            // error_label
            // 
            error_label.AutoSize = true;
            error_label.Location = new Point(39, 504);
            error_label.Name = "error_label";
            error_label.Size = new Size(41, 20);
            error_label.TabIndex = 12;
            error_label.Text = "Error";
            // 
            // error_func_search
            // 
            error_func_search.AutoSize = true;
            error_func_search.Location = new Point(39, 175);
            error_func_search.Name = "error_func_search";
            error_func_search.Size = new Size(75, 20);
            error_func_search.TabIndex = 15;
            error_func_search.Text = "Error_func";
            // 
            // button_graph_search
            // 
            button_graph_search.Location = new Point(526, 280);
            button_graph_search.Margin = new Padding(3, 4, 3, 4);
            button_graph_search.Name = "button_graph_search";
            button_graph_search.Size = new Size(173, 29);
            button_graph_search.TabIndex = 16;
            button_graph_search.Text = "График";
            button_graph_search.UseVisualStyleBackColor = true;
            button_graph_search.Click += button_graph_search_Click;
            // 
            // Visualization_button
            // 
            Visualization_button.Location = new Point(526, 333);
            Visualization_button.Margin = new Padding(3, 4, 3, 4);
            Visualization_button.Name = "Visualization_button";
            Visualization_button.Size = new Size(173, 34);
            Visualization_button.TabIndex = 17;
            Visualization_button.Text = "Визуализация метода";
            Visualization_button.UseVisualStyleBackColor = true;
            Visualization_button.Click += Visualization_button_Click;
            // 
            // SearchMethodsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 554);
            Controls.Add(Visualization_button);
            Controls.Add(button_graph_search);
            Controls.Add(error_func_search);
            Controls.Add(error_label);
            Controls.Add(table_search_button);
            Controls.Add(data_reset_button);
            Controls.Add(exit_button_search);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(calculate_button);
            Controls.Add(groupBox1);
            Controls.Add(function_groupBox);
            Controls.Add(info_button);
            Controls.Add(exit_button);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SearchMethodsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод перебора";
            function_groupBox.ResumeLayout(false);
            function_groupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button info_button;
        private System.Windows.Forms.Button function_button;
        private System.Windows.Forms.GroupBox function_groupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label result_label;
        private System.Windows.Forms.Label func_result_label;
        private System.Windows.Forms.TextBox function_textBox;
        private System.Windows.Forms.TextBox b_textBox;
        private System.Windows.Forms.TextBox a_textBox;
        private System.Windows.Forms.TextBox accuracy_textBox;
        private System.Windows.Forms.Button calculate_button;
        private Label label_1;
        private Label label1;
        private Label label_2;
        private GroupBox groupBox2;
        private Label label2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label4;
        private Button exit_button_search;
        private Button data_reset_button;
        private Button table_search_button;
        private Label error_label;
        private Label error_func_search;
        private Button button_graph_search;
        private Button Visualization_button;
    }
}