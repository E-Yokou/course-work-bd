namespace courseDataBase
{
    partial class Sign_in
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox_SHOWPASSWORD = new System.Windows.Forms.PictureBox();
            this.pictureBox_HIDEPASSWORD = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.AdminRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BUT_Enter = new System.Windows.Forms.Button();
            this.ClientRadio = new System.Windows.Forms.RadioButton();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SHOWPASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HIDEPASSWORD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 426);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(272, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 74);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.pictureBox_SHOWPASSWORD);
            this.panel3.Controls.Add(this.pictureBox_HIDEPASSWORD);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.AdminRadio);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.BUT_Enter);
            this.panel3.Controls.Add(this.ClientRadio);
            this.panel3.Controls.Add(this.textBox_login);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBox_password);
            this.panel3.Location = new System.Drawing.Point(272, 91);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 347);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox_SHOWPASSWORD
            // 
            this.pictureBox_SHOWPASSWORD.Image = global::courseDataBase.Properties.Resources.not_visible_interface_symbol_of_an_eye_with_a_slash_on_it_icon_icons1;
            this.pictureBox_SHOWPASSWORD.Location = new System.Drawing.Point(361, 197);
            this.pictureBox_SHOWPASSWORD.Name = "pictureBox_SHOWPASSWORD";
            this.pictureBox_SHOWPASSWORD.Size = new System.Drawing.Size(38, 27);
            this.pictureBox_SHOWPASSWORD.TabIndex = 12;
            this.pictureBox_SHOWPASSWORD.TabStop = false;
            this.pictureBox_SHOWPASSWORD.Click += new System.EventHandler(this.pictureBox_SHOWPASSWORD_Click);
            // 
            // pictureBox_HIDEPASSWORD
            // 
            this.pictureBox_HIDEPASSWORD.Image = global::courseDataBase.Properties.Resources.eye_visible_outlined_interface_symbol_icon_icons_com_57844;
            this.pictureBox_HIDEPASSWORD.Location = new System.Drawing.Point(361, 197);
            this.pictureBox_HIDEPASSWORD.Name = "pictureBox_HIDEPASSWORD";
            this.pictureBox_HIDEPASSWORD.Size = new System.Drawing.Size(38, 27);
            this.pictureBox_HIDEPASSWORD.TabIndex = 11;
            this.pictureBox_HIDEPASSWORD.TabStop = false;
            this.pictureBox_HIDEPASSWORD.Click += new System.EventHandler(this.pictureBox_HIDEPASSWORD_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(203, 302);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(104, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ещё нет аккаунта?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // AdminRadio
            // 
            this.AdminRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminRadio.AutoSize = true;
            this.AdminRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminRadio.Location = new System.Drawing.Point(287, 135);
            this.AdminRadio.Margin = new System.Windows.Forms.Padding(2);
            this.AdminRadio.Name = "AdminRadio";
            this.AdminRadio.Size = new System.Drawing.Size(104, 17);
            this.AdminRadio.TabIndex = 9;
            this.AdminRadio.TabStop = true;
            this.AdminRadio.Text = "Администратор";
            this.AdminRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(193, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Авторизация";
            // 
            // BUT_Enter
            // 
            this.BUT_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BUT_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.BUT_Enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BUT_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUT_Enter.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold);
            this.BUT_Enter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.BUT_Enter.Location = new System.Drawing.Point(157, 241);
            this.BUT_Enter.Margin = new System.Windows.Forms.Padding(2);
            this.BUT_Enter.MaximumSize = new System.Drawing.Size(199, 40);
            this.BUT_Enter.MinimumSize = new System.Drawing.Size(199, 40);
            this.BUT_Enter.Name = "BUT_Enter";
            this.BUT_Enter.Size = new System.Drawing.Size(199, 40);
            this.BUT_Enter.TabIndex = 8;
            this.BUT_Enter.Text = "Вход";
            this.BUT_Enter.UseVisualStyleBackColor = false;
            this.BUT_Enter.Click += new System.EventHandler(this.BUT_Enter_Click);
            // 
            // ClientRadio
            // 
            this.ClientRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientRadio.AutoSize = true;
            this.ClientRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientRadio.Location = new System.Drawing.Point(160, 135);
            this.ClientRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ClientRadio.Name = "ClientRadio";
            this.ClientRadio.Size = new System.Drawing.Size(78, 17);
            this.ClientRadio.TabIndex = 4;
            this.ClientRadio.TabStop = true;
            this.ClientRadio.Text = "Сотрудник";
            this.ClientRadio.UseVisualStyleBackColor = true;
            // 
            // textBox_login
            // 
            this.textBox_login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_login.Location = new System.Drawing.Point(159, 175);
            this.textBox_login.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(197, 20);
            this.textBox_login.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label3.Location = new System.Drawing.Point(97, 177);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label4.Location = new System.Drawing.Point(97, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.Location = new System.Drawing.Point(157, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тип учетной записи";
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_password.Location = new System.Drawing.Point(159, 204);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(197, 20);
            this.textBox_password.TabIndex = 6;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // Sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Sign_in";
            this.Text = "Sign In";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SHOWPASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HIDEPASSWORD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton AdminRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BUT_Enter;
        private System.Windows.Forms.RadioButton ClientRadio;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox_SHOWPASSWORD;
        private System.Windows.Forms.PictureBox pictureBox_HIDEPASSWORD;
    }
}

