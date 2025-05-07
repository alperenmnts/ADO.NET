namespace DizinDosya
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCheck = new System.Windows.Forms.Button();
            txtAra = new System.Windows.Forms.TextBox();
            listBox1 = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtDegis = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btnCheck
            // 
            btnCheck.Location = new System.Drawing.Point(497, 87);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new System.Drawing.Size(103, 47);
            btnCheck.TabIndex = 0;
            btnCheck.Text = "Kelimeyi Değiştir";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // txtAra
            // 
            txtAra.Location = new System.Drawing.Point(270, 130);
            txtAra.Name = "txtAra";
            txtAra.Size = new System.Drawing.Size(170, 23);
            txtAra.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(121, 170);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(540, 244);
            listBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(270, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(167, 15);
            label1.TabIndex = 3;
            label1.Text = "Değiştirmek istediğiniz kelime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(270, 103);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(118, 15);
            label2.TabIndex = 3;
            label2.Text = "Değiştirilecek kelime:";
            // 
            // txtDegis
            // 
            txtDegis.Location = new System.Drawing.Point(270, 55);
            txtDegis.Name = "txtDegis";
            txtDegis.Size = new System.Drawing.Size(182, 23);
            txtDegis.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(txtDegis);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(txtAra);
            Controls.Add(btnCheck);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDegis;
    }
}
