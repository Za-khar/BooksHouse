﻿
namespace BooksHouse
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(476, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Будинок мрій";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(606, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 543);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(220, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пошук книг";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(800, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 66);
            this.label3.TabIndex = 3;
            this.label3.Text = "Авторизуватись \r\nяк адмін\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(176, 313);
            this.textBox1.MaximumSize = new System.Drawing.Size(250, 35);
            this.textBox1.MaxLength = 10;
            this.textBox1.MinimumSize = new System.Drawing.Size(250, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(250, 35);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Введіть максимальну ціну";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.WordWrap = false; 
            this.textBox1.Click += new System.EventHandler(this.TextBox1_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(176, 365);
            this.textBox2.MaximumSize = new System.Drawing.Size(250, 35);
            this.textBox2.MaxLength = 10;
            this.textBox2.MinimumSize = new System.Drawing.Size(250, 35);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.Size = new System.Drawing.Size(250, 35);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Введіть мінімальний вік";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.WordWrap = false;
            this.textBox2.Click += new System.EventHandler(this.TextBox2_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox3.Location = new System.Drawing.Point(176, 418);
            this.textBox3.MaximumSize = new System.Drawing.Size(250, 35);
            this.textBox3.MaxLength = 10;
            this.textBox3.MinimumSize = new System.Drawing.Size(250, 35);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox3.Size = new System.Drawing.Size(250, 35);
            this.textBox3.TabIndex = 6;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Введіть максимальний вік";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.WordWrap = false;
            this.textBox3.Click += new System.EventHandler(this.TextBox3_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox4.Location = new System.Drawing.Point(797, 346);
            this.textBox4.MaximumSize = new System.Drawing.Size(250, 35);
            this.textBox4.MaxLength = 10;
            this.textBox4.MinimumSize = new System.Drawing.Size(250, 35);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox4.Size = new System.Drawing.Size(250, 35);
            this.textBox4.TabIndex = 7;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Логін";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.WordWrap = false;
            this.textBox4.Click += new System.EventHandler(this.TextBox4_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox5.Location = new System.Drawing.Point(797, 401);
            this.textBox5.MaximumSize = new System.Drawing.Size(250, 35);
            this.textBox5.MaxLength = 10;
            this.textBox5.MinimumSize = new System.Drawing.Size(250, 35);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox5.Size = new System.Drawing.Size(250, 35);
            this.textBox5.TabIndex = 8;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Пароль";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.WordWrap = false;
            this.textBox5.Click += new System.EventHandler(this.TextBox5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(226, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Пошук";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(850, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Авторизуватись";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Будинок мрій";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

