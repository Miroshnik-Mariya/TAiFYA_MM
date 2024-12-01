namespace Analyzator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_analizator = new System.Windows.Forms.Label();
            this.TextBox_InputOperator = new System.Windows.Forms.TextBox();
            this.button_analyze = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox_massiv = new System.Windows.Forms.ListBox();
            this.enter_analyz = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_analizator
            // 
            this.label_analizator.AutoSize = true;
            this.label_analizator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_analizator.Location = new System.Drawing.Point(13, 9);
            this.label_analizator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_analizator.Name = "label_analizator";
            this.label_analizator.Size = new System.Drawing.Size(501, 25);
            this.label_analizator.TabIndex = 0;
            this.label_analizator.Text = "Лабораторная работа. Вариант 17. Мирошник Мария";
            // 
            // TextBox_InputOperator
            // 
            this.TextBox_InputOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox_InputOperator.Location = new System.Drawing.Point(12, 246);
            this.TextBox_InputOperator.Margin = new System.Windows.Forms.Padding(9);
            this.TextBox_InputOperator.Name = "TextBox_InputOperator";
            this.TextBox_InputOperator.Size = new System.Drawing.Size(1031, 30);
            this.TextBox_InputOperator.TabIndex = 1;
            this.TextBox_InputOperator.TextChanged += new System.EventHandler(this.text_analyze_TextChanged);
            // 
            // button_analyze
            // 
            this.button_analyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_analyze.Location = new System.Drawing.Point(532, 80);
            this.button_analyze.Name = "button_analyze";
            this.button_analyze.Size = new System.Drawing.Size(511, 100);
            this.button_analyze.TabIndex = 0;
            this.button_analyze.Text = "Анализ";
            this.button_analyze.UseVisualStyleBackColor = true;
            this.button_analyze.Click += new System.EventHandler(this.button_analyze_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(514, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Формат строки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(511, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Семантика";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox_massiv
            // 
            this.listBox_massiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_massiv.FormattingEnabled = true;
            this.listBox_massiv.ItemHeight = 25;
            this.listBox_massiv.Location = new System.Drawing.Point(12, 330);
            this.listBox_massiv.Name = "listBox_massiv";
            this.listBox_massiv.Size = new System.Drawing.Size(1031, 204);
            this.listBox_massiv.TabIndex = 0;
            this.listBox_massiv.SelectedIndexChanged += new System.EventHandler(this.listBox_ident_SelectedIndexChanged);
            // 
            // enter_analyz
            // 
            this.enter_analyz.Location = new System.Drawing.Point(12, 80);
            this.enter_analyz.Name = "enter_analyz";
            this.enter_analyz.Size = new System.Drawing.Size(514, 100);
            this.enter_analyz.TabIndex = 4;
            this.enter_analyz.Text = "Ввод анализатора";
            this.enter_analyz.UseVisualStyleBackColor = true;
            this.enter_analyz.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "Результат";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Результат";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(28, 401);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(62, 20);
            this.result.TabIndex = 6;
            this.result.Text = "Ответ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1067, 547);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enter_analyz);
            this.Controls.Add(this.button_analyze);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox_massiv);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBox_InputOperator);
            this.Controls.Add(this.label_analizator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Анализатор автоматного языка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_analizator;
        private System.Windows.Forms.TextBox TextBox_InputOperator;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_analyze;
        private System.Windows.Forms.ListBox listBox_massiv;
        private System.Windows.Forms.Button enter_analyz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label result;
    }
}

