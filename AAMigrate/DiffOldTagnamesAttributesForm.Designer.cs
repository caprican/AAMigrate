namespace AAMigrate
{
    partial class DiffOldTagnamesAttributesForm
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
            this.AttributesBox = new System.Windows.Forms.ListBox();
            this.OldTagnameBox = new System.Windows.Forms.ListBox();
            this.bClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AttributesBox
            // 
            this.AttributesBox.FormattingEnabled = true;
            this.AttributesBox.ItemHeight = 25;
            this.AttributesBox.Location = new System.Drawing.Point(12, 77);
            this.AttributesBox.Name = "AttributesBox";
            this.AttributesBox.Size = new System.Drawing.Size(556, 679);
            this.AttributesBox.TabIndex = 0;
            // 
            // OldTagnameBox
            // 
            this.OldTagnameBox.FormattingEnabled = true;
            this.OldTagnameBox.ItemHeight = 25;
            this.OldTagnameBox.Location = new System.Drawing.Point(574, 77);
            this.OldTagnameBox.Name = "OldTagnameBox";
            this.OldTagnameBox.Size = new System.Drawing.Size(566, 679);
            this.OldTagnameBox.TabIndex = 1;
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(12, 766);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(195, 67);
            this.bClose.TabIndex = 2;
            this.bClose.Text = "Fermer et annuler";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Instances recherchées";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(569, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Instances trouvées";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(753, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Il n\'y a pas le même nombre d\'anciennes instances que de nouveaux attributs";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.button1.Location = new System.Drawing.Point(945, 766);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 67);
            this.button1.TabIndex = 6;
            this.button1.Text = "Migrer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DiffOldTagnamesAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 845);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.OldTagnameBox);
            this.Controls.Add(this.AttributesBox);
            this.Name = "DiffOldTagnamesAttributesForm";
            this.Text = "DiffOldTagnamesAttributesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AttributesBox;
        private System.Windows.Forms.ListBox OldTagnameBox;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}