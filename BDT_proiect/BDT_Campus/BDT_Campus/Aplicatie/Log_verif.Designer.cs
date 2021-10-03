
namespace BDT_Campus
{
    partial class Log_verif
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
            this.buttonRefuz = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConfirmare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRefuz
            // 
            this.buttonRefuz.Location = new System.Drawing.Point(165, 313);
            this.buttonRefuz.Name = "buttonRefuz";
            this.buttonRefuz.Size = new System.Drawing.Size(125, 40);
            this.buttonRefuz.TabIndex = 16;
            this.buttonRefuz.Text = "Nu sunt eu";
            this.buttonRefuz.UseVisualStyleBackColor = true;
            this.buttonRefuz.Click += new System.EventHandler(this.buttonRefuz_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Sunteți conectat ca";
            // 
            // buttonConfirmare
            // 
            this.buttonConfirmare.Location = new System.Drawing.Point(165, 267);
            this.buttonConfirmare.Name = "buttonConfirmare";
            this.buttonConfirmare.Size = new System.Drawing.Size(125, 40);
            this.buttonConfirmare.TabIndex = 13;
            this.buttonConfirmare.Text = "Confirmare";
            this.buttonConfirmare.UseVisualStyleBackColor = true;
            this.buttonConfirmare.Click += new System.EventHandler(this.buttonConfirmare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pentru a finaliza înregistrarea vă rugăm selectați funcția dumneavoastră";
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(58, 228);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(330, 21);
            this.comboBoxRol.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirmarea Identității";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelUser.Location = new System.Drawing.Point(171, 168);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(119, 17);
            this.labelUser.TabIndex = 19;
            this.labelUser.Text = "Nume Utilizator";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonHelp.Location = new System.Drawing.Point(99, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(84, 25);
            this.buttonHelp.TabIndex = 21;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonExit.Location = new System.Drawing.Point(12, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(81, 25);
            this.buttonExit.TabIndex = 20;
            this.buttonExit.Text = "Ieșire";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Log_verif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonRefuz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConfirmare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.label2);
            this.Name = "Log_verif";
            this.Text = "Log_verif";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefuz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConfirmare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonExit;
    }
}