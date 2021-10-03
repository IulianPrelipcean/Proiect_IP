
namespace BDT_Campus
{
    partial class Cont_info
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
            this.labelUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelChange = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(24, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numele de utilizator:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.labelUser.Location = new System.Drawing.Point(218, 149);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(158, 25);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Nume Utilizator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(24, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parola actuală:";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.labelPass.Location = new System.Drawing.Point(218, 188);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(74, 25);
            this.labelPass.TabIndex = 3;
            this.labelPass.Text = "Parola";
            // 
            // buttonShow
            // 
            this.buttonShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonShow.Location = new System.Drawing.Point(393, 192);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(87, 29);
            this.buttonShow.TabIndex = 4;
            this.buttonShow.Text = "Afișare parolă";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(142, 90);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(145, 29);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Contul meu";
            // 
            // labelChange
            // 
            this.labelChange.AutoSize = true;
            this.labelChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelChange.Location = new System.Drawing.Point(24, 240);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(144, 25);
            this.labelChange.TabIndex = 6;
            this.labelChange.Text = "Modifică parola";
            // 
            // buttonChange
            // 
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonChange.Location = new System.Drawing.Point(393, 255);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(87, 28);
            this.buttonChange.TabIndex = 7;
            this.buttonChange.Text = "Modifică";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(89, 23);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Înapoi";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(107, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(89, 23);
            this.buttonHelp.TabIndex = 9;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // Cont_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 450);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.labelChange);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label1);
            this.Name = "Cont_info";
            this.Text = "Cont_info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonHelp;
    }
}