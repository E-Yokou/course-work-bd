﻿namespace courseDataBase
{
    partial class Add_Data_Driver
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BUT_load_image = new System.Windows.Forms.Button();
            this.pb_show = new System.Windows.Forms.PictureBox();
            this.textBox_FIO = new System.Windows.Forms.TextBox();
            this.textBox_PHONE = new System.Windows.Forms.TextBox();
            this.textBox_SALARY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_IDBUS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BUT_Save = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_show)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 62);
            this.panel1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(18, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(276, 37);
            this.label8.TabIndex = 15;
            this.label8.Text = "Создание Записи:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.BUT_load_image);
            this.panel3.Controls.Add(this.pb_show);
            this.panel3.Controls.Add(this.textBox_FIO);
            this.panel3.Controls.Add(this.textBox_PHONE);
            this.panel3.Controls.Add(this.textBox_SALARY);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox_IDBUS);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.BUT_Save);
            this.panel3.Location = new System.Drawing.Point(12, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(732, 321);
            this.panel3.TabIndex = 7;
            // 
            // BUT_load_image
            // 
            this.BUT_load_image.Location = new System.Drawing.Point(136, 207);
            this.BUT_load_image.Name = "BUT_load_image";
            this.BUT_load_image.Size = new System.Drawing.Size(158, 46);
            this.BUT_load_image.TabIndex = 28;
            this.BUT_load_image.Text = "Загрузить фото";
            this.BUT_load_image.UseVisualStyleBackColor = true;
            this.BUT_load_image.Click += new System.EventHandler(this.BUT_load_image_Click);
            // 
            // pb_show
            // 
            this.pb_show.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pb_show.Location = new System.Drawing.Point(509, 48);
            this.pb_show.Name = "pb_show";
            this.pb_show.Size = new System.Drawing.Size(198, 134);
            this.pb_show.TabIndex = 27;
            this.pb_show.TabStop = false;
            // 
            // textBox_FIO
            // 
            this.textBox_FIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_FIO.Location = new System.Drawing.Point(136, 48);
            this.textBox_FIO.Multiline = true;
            this.textBox_FIO.Name = "textBox_FIO";
            this.textBox_FIO.Size = new System.Drawing.Size(338, 29);
            this.textBox_FIO.TabIndex = 17;
            this.textBox_FIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_FIO_KeyPress);
            // 
            // textBox_PHONE
            // 
            this.textBox_PHONE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_PHONE.Location = new System.Drawing.Point(136, 83);
            this.textBox_PHONE.Multiline = true;
            this.textBox_PHONE.Name = "textBox_PHONE";
            this.textBox_PHONE.Size = new System.Drawing.Size(338, 29);
            this.textBox_PHONE.TabIndex = 18;
            // 
            // textBox_SALARY
            // 
            this.textBox_SALARY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_SALARY.Location = new System.Drawing.Point(136, 118);
            this.textBox_SALARY.Multiline = true;
            this.textBox_SALARY.Name = "textBox_SALARY";
            this.textBox_SALARY.Size = new System.Drawing.Size(338, 29);
            this.textBox_SALARY.TabIndex = 19;
            this.textBox_SALARY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SALARY_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(44, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 29);
            this.label5.TabIndex = 26;
            this.label5.Text = "id bus:";
            // 
            // textBox_IDBUS
            // 
            this.textBox_IDBUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_IDBUS.Location = new System.Drawing.Point(136, 153);
            this.textBox_IDBUS.Multiline = true;
            this.textBox_IDBUS.Name = "textBox_IDBUS";
            this.textBox_IDBUS.Size = new System.Drawing.Size(338, 29);
            this.textBox_IDBUS.TabIndex = 20;
            this.textBox_IDBUS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IDBUS_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(46, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 29);
            this.label4.TabIndex = 25;
            this.label4.Text = "salary:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(41, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "phone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(69, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "FIO:";
            // 
            // BUT_Save
            // 
            this.BUT_Save.Location = new System.Drawing.Point(316, 207);
            this.BUT_Save.Name = "BUT_Save";
            this.BUT_Save.Size = new System.Drawing.Size(158, 46);
            this.BUT_Save.TabIndex = 16;
            this.BUT_Save.Text = "Сохранить";
            this.BUT_Save.UseVisualStyleBackColor = true;
            this.BUT_Save.Click += new System.EventHandler(this.BUT_Save_Click);
            // 
            // Add_Data_Driver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MinimumSize = new System.Drawing.Size(654, 451);
            this.Name = "Add_Data_Driver";
            this.Text = "Add_Data_Driver";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_FIO;
        private System.Windows.Forms.TextBox textBox_PHONE;
        private System.Windows.Forms.TextBox textBox_SALARY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_IDBUS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BUT_Save;
        private System.Windows.Forms.PictureBox pb_show;
        private System.Windows.Forms.Button BUT_load_image;
    }
}