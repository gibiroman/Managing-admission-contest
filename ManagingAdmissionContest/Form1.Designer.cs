namespace ManagingAdmissionContest
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.TextBox();
            this.lastname = new System.Windows.Forms.TextBox();
            this.bacGrade = new System.Windows.Forms.TextBox();
            this.csGrade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mathGrade = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.badgeNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.testGrade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firstname";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(375, 77);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(384, 22);
            this.firstname.TabIndex = 1;
            this.firstname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(375, 134);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(384, 22);
            this.lastname.TabIndex = 2;
            // 
            // bacGrade
            // 
            this.bacGrade.Location = new System.Drawing.Point(375, 242);
            this.bacGrade.Name = "bacGrade";
            this.bacGrade.Size = new System.Drawing.Size(384, 22);
            this.bacGrade.TabIndex = 4;
            // 
            // csGrade
            // 
            this.csGrade.Location = new System.Drawing.Point(375, 307);
            this.csGrade.Name = "csGrade";
            this.csGrade.Size = new System.Drawing.Size(384, 22);
            this.csGrade.TabIndex = 5;
            this.csGrade.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lastname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "Badge no.";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "Baccalaureate grade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 27);
            this.label5.TabIndex = 13;
            this.label5.Text = "Computer science grade";
            // 
            // mathGrade
            // 
            this.mathGrade.Location = new System.Drawing.Point(375, 364);
            this.mathGrade.Name = "mathGrade";
            this.mathGrade.Size = new System.Drawing.Size(384, 22);
            this.mathGrade.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(82, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 27);
            this.label6.TabIndex = 15;
            this.label6.Text = "Mathematics grade";
            // 
            // badgeNo
            // 
            this.badgeNo.Location = new System.Drawing.Point(375, 189);
            this.badgeNo.Name = "badgeNo";
            this.badgeNo.Size = new System.Drawing.Size(384, 22);
            this.badgeNo.TabIndex = 3;
            this.badgeNo.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 34);
            this.button1.TabIndex = 16;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testGrade
            // 
            this.testGrade.Location = new System.Drawing.Point(375, 410);
            this.testGrade.Name = "testGrade";
            this.testGrade.Size = new System.Drawing.Size(384, 22);
            this.testGrade.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(82, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 27);
            this.label7.TabIndex = 18;
            this.label7.Text = "Test grade";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 584);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.testGrade);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mathGrade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.csGrade);
            this.Controls.Add(this.bacGrade);
            this.Controls.Add(this.badgeNo);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Formular";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox firstname;
        public System.Windows.Forms.TextBox lastname;
        public System.Windows.Forms.TextBox bacGrade;
        public System.Windows.Forms.TextBox csGrade;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox mathGrade;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox badgeNo;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox testGrade;
        public System.Windows.Forms.Label label7;
    }
}