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
            this.exit_button = new System.Windows.Forms.Button();
            this.info_button = new System.Windows.Forms.Button();
            this.function_button = new System.Windows.Forms.Button();
            this.function_groupBox = new System.Windows.Forms.GroupBox();
            this.function_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_textBox = new System.Windows.Forms.TextBox();
            this.a_textBox = new System.Windows.Forms.TextBox();
            this.result_label = new System.Windows.Forms.Label();
            this.func_result_label = new System.Windows.Forms.Label();
            this.accuracy_textBox = new System.Windows.Forms.TextBox();
            this.calculate_button = new System.Windows.Forms.Button();
            this.function_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(599, 403);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(173, 23);
            this.exit_button.TabIndex = 0;
            this.exit_button.Text = "На главную страницу";
            this.exit_button.UseVisualStyleBackColor = true;
            // 
            // info_button
            // 
            this.info_button.Location = new System.Drawing.Point(12, 12);
            this.info_button.Name = "info_button";
            this.info_button.Size = new System.Drawing.Size(100, 23);
            this.info_button.TabIndex = 1;
            this.info_button.Text = "Справка";
            this.info_button.UseVisualStyleBackColor = true;
            // 
            // function_button
            // 
            this.function_button.Location = new System.Drawing.Point(164, 41);
            this.function_button.Name = "function_button";
            this.function_button.Size = new System.Drawing.Size(37, 23);
            this.function_button.TabIndex = 3;
            this.function_button.Text = "✓";
            this.function_button.UseVisualStyleBackColor = true;
            this.function_button.Click += new System.EventHandler(this.function_button_Click);
            // 
            // function_groupBox
            // 
            this.function_groupBox.Controls.Add(this.function_textBox);
            this.function_groupBox.Controls.Add(this.function_button);
            this.function_groupBox.Location = new System.Drawing.Point(39, 81);
            this.function_groupBox.Name = "function_groupBox";
            this.function_groupBox.Size = new System.Drawing.Size(256, 100);
            this.function_groupBox.TabIndex = 4;
            this.function_groupBox.TabStop = false;
            this.function_groupBox.Text = "Введите функцию";
            // 
            // function_textBox
            // 
            this.function_textBox.Location = new System.Drawing.Point(23, 41);
            this.function_textBox.Name = "function_textBox";
            this.function_textBox.Size = new System.Drawing.Size(100, 22);
            this.function_textBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_textBox);
            this.groupBox1.Controls.Add(this.a_textBox);
            this.groupBox1.Location = new System.Drawing.Point(39, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введите начальные данные";
            // 
            // b_textBox
            // 
            this.b_textBox.Location = new System.Drawing.Point(23, 66);
            this.b_textBox.Name = "b_textBox";
            this.b_textBox.Size = new System.Drawing.Size(100, 22);
            this.b_textBox.TabIndex = 6;
            // 
            // a_textBox
            // 
            this.a_textBox.Location = new System.Drawing.Point(23, 35);
            this.a_textBox.Name = "a_textBox";
            this.a_textBox.Size = new System.Drawing.Size(100, 22);
            this.a_textBox.TabIndex = 5;
            // 
            // result_label
            // 
            this.result_label.AutoSize = true;
            this.result_label.Location = new System.Drawing.Point(382, 217);
            this.result_label.Name = "result_label";
            this.result_label.Size = new System.Drawing.Size(31, 16);
            this.result_label.TabIndex = 6;
            this.result_label.Text = "ввв";
            // 
            // func_result_label
            // 
            this.func_result_label.AutoSize = true;
            this.func_result_label.Location = new System.Drawing.Point(382, 269);
            this.func_result_label.Name = "func_result_label";
            this.func_result_label.Size = new System.Drawing.Size(31, 16);
            this.func_result_label.TabIndex = 7;
            this.func_result_label.Text = "ввв";
            // 
            // accuracy_textBox
            // 
            this.accuracy_textBox.Location = new System.Drawing.Point(62, 333);
            this.accuracy_textBox.Name = "accuracy_textBox";
            this.accuracy_textBox.Size = new System.Drawing.Size(100, 22);
            this.accuracy_textBox.TabIndex = 8;
            // 
            // calculate_button
            // 
            this.calculate_button.Location = new System.Drawing.Point(258, 333);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(107, 30);
            this.calculate_button.TabIndex = 5;
            this.calculate_button.Text = "Вычислить";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            // 
            // SearchMethodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.accuracy_textBox);
            this.Controls.Add(this.func_result_label);
            this.Controls.Add(this.result_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.function_groupBox);
            this.Controls.Add(this.info_button);
            this.Controls.Add(this.exit_button);
            this.Name = "SearchMethodsForm";
            this.Text = "Метод перебора";
            this.function_groupBox.ResumeLayout(false);
            this.function_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
}
}