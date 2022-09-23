﻿namespace AAMigrate
{
    partial class SettingsForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.cBSheetNameNewTemplate = new System.Windows.Forms.ComboBox();
            this.tbSheetNameNewTemplate = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSheetNameOldConcatTemplate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSheetNameOldTemplate = new System.Windows.Forms.TextBox();
            this.cBSheetNameOldTemplate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSheetBrute = new System.Windows.Forms.TextBox();
            this.cBSheetBrute = new System.Windows.Forms.ComboBox();
            this.Defaultbutton = new System.Windows.Forms.Button();
            this.cBSheetNameOldConcatTemplate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSheetExport = new System.Windows.Forms.TextBox();
            this.cBSheetExport = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(228, 157);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 25);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Enregistrer";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cBSheetNameNewTemplate
            // 
            this.cBSheetNameNewTemplate.FormattingEnabled = true;
            this.cBSheetNameNewTemplate.Items.AddRange(new object[] {
            "",
            "Contenant",
            "Ne contenant pas",
            "Commençant par",
            "Se terminant par"});
            this.cBSheetNameNewTemplate.Location = new System.Drawing.Point(238, 92);
            this.cBSheetNameNewTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cBSheetNameNewTemplate.Name = "cBSheetNameNewTemplate";
            this.cBSheetNameNewTemplate.Size = new System.Drawing.Size(62, 21);
            this.cBSheetNameNewTemplate.TabIndex = 2;
            // 
            // tbSheetNameNewTemplate
            // 
            this.tbSheetNameNewTemplate.Location = new System.Drawing.Point(122, 92);
            this.tbSheetNameNewTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSheetNameNewTemplate.Name = "tbSheetNameNewTemplate";
            this.tbSheetNameNewTemplate.Size = new System.Drawing.Size(112, 20);
            this.tbSheetNameNewTemplate.TabIndex = 3;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(144, 157);
            this.bCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(80, 25);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Fermer";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Feuille nouveau model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Concat ancien models";
            // 
            // tbSheetNameOldConcatTemplate
            // 
            this.tbSheetNameOldConcatTemplate.Location = new System.Drawing.Point(122, 68);
            this.tbSheetNameOldConcatTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSheetNameOldConcatTemplate.Name = "tbSheetNameOldConcatTemplate";
            this.tbSheetNameOldConcatTemplate.Size = new System.Drawing.Size(112, 20);
            this.tbSheetNameOldConcatTemplate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Feuille ancien model";
            // 
            // tbSheetNameOldTemplate
            // 
            this.tbSheetNameOldTemplate.Location = new System.Drawing.Point(122, 44);
            this.tbSheetNameOldTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSheetNameOldTemplate.Name = "tbSheetNameOldTemplate";
            this.tbSheetNameOldTemplate.Size = new System.Drawing.Size(112, 20);
            this.tbSheetNameOldTemplate.TabIndex = 10;
            // 
            // cBSheetNameOldTemplate
            // 
            this.cBSheetNameOldTemplate.FormattingEnabled = true;
            this.cBSheetNameOldTemplate.Items.AddRange(new object[] {
            "",
            "Contenant",
            "Ne contenant pas",
            "Commençant par",
            "Se terminant par"});
            this.cBSheetNameOldTemplate.Location = new System.Drawing.Point(238, 44);
            this.cBSheetNameOldTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cBSheetNameOldTemplate.Name = "cBSheetNameOldTemplate";
            this.cBSheetNameOldTemplate.Size = new System.Drawing.Size(62, 21);
            this.cBSheetNameOldTemplate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Feuilles données brute";
            // 
            // tbSheetBrute
            // 
            this.tbSheetBrute.Location = new System.Drawing.Point(122, 20);
            this.tbSheetBrute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSheetBrute.Name = "tbSheetBrute";
            this.tbSheetBrute.Size = new System.Drawing.Size(112, 20);
            this.tbSheetBrute.TabIndex = 13;
            // 
            // cBSheetBrute
            // 
            this.cBSheetBrute.FormattingEnabled = true;
            this.cBSheetBrute.Items.AddRange(new object[] {
            "",
            "Contenant",
            "Ne contenant pas",
            "Commençant par",
            "Se terminant par"});
            this.cBSheetBrute.Location = new System.Drawing.Point(238, 19);
            this.cBSheetBrute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cBSheetBrute.Name = "cBSheetBrute";
            this.cBSheetBrute.Size = new System.Drawing.Size(62, 21);
            this.cBSheetBrute.TabIndex = 12;
            // 
            // Defaultbutton
            // 
            this.Defaultbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Defaultbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Defaultbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Defaultbutton.Location = new System.Drawing.Point(11, 155);
            this.Defaultbutton.Margin = new System.Windows.Forms.Padding(2);
            this.Defaultbutton.Name = "Defaultbutton";
            this.Defaultbutton.Size = new System.Drawing.Size(65, 25);
            this.Defaultbutton.TabIndex = 15;
            this.Defaultbutton.Text = "Défaut";
            this.Defaultbutton.UseVisualStyleBackColor = true;
            this.Defaultbutton.Click += new System.EventHandler(this.Defaultbutton_Click);
            // 
            // cBSheetNameOldConcatTemplate
            // 
            this.cBSheetNameOldConcatTemplate.FormattingEnabled = true;
            this.cBSheetNameOldConcatTemplate.Items.AddRange(new object[] {
            "",
            "Contenant",
            "Ne contenant pas",
            "Commençant par",
            "Se terminant par"});
            this.cBSheetNameOldConcatTemplate.Location = new System.Drawing.Point(238, 67);
            this.cBSheetNameOldConcatTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.cBSheetNameOldConcatTemplate.Name = "cBSheetNameOldConcatTemplate";
            this.cBSheetNameOldConcatTemplate.Size = new System.Drawing.Size(62, 21);
            this.cBSheetNameOldConcatTemplate.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Feuille d\'export";
            // 
            // tbSheetExport
            // 
            this.tbSheetExport.Location = new System.Drawing.Point(122, 117);
            this.tbSheetExport.Margin = new System.Windows.Forms.Padding(2);
            this.tbSheetExport.Name = "tbSheetExport";
            this.tbSheetExport.Size = new System.Drawing.Size(112, 20);
            this.tbSheetExport.TabIndex = 18;
            // 
            // cBSheetExport
            // 
            this.cBSheetExport.FormattingEnabled = true;
            this.cBSheetExport.Items.AddRange(new object[] {
            "",
            "Contenant",
            "Ne contenant pas",
            "Commençant par",
            "Se terminant par"});
            this.cBSheetExport.Location = new System.Drawing.Point(238, 117);
            this.cBSheetExport.Margin = new System.Windows.Forms.Padding(2);
            this.cBSheetExport.Name = "cBSheetExport";
            this.cBSheetExport.Size = new System.Drawing.Size(62, 21);
            this.cBSheetExport.TabIndex = 17;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 193);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSheetExport);
            this.Controls.Add(this.cBSheetExport);
            this.Controls.Add(this.cBSheetNameOldConcatTemplate);
            this.Controls.Add(this.Defaultbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSheetBrute);
            this.Controls.Add(this.cBSheetBrute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSheetNameOldTemplate);
            this.Controls.Add(this.cBSheetNameOldTemplate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSheetNameOldConcatTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tbSheetNameNewTemplate);
            this.Controls.Add(this.cBSheetNameNewTemplate);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingsForm";
            this.Text = "aa migrate settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox cBSheetNameNewTemplate;
        private System.Windows.Forms.TextBox tbSheetNameNewTemplate;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSheetNameOldConcatTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSheetNameOldTemplate;
        private System.Windows.Forms.ComboBox cBSheetNameOldTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBSheetBrute;
        private System.Windows.Forms.Button Defaultbutton;
        private System.Windows.Forms.ComboBox cBSheetNameOldConcatTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSheetExport;
        private System.Windows.Forms.ComboBox cBSheetExport;
        private System.Windows.Forms.TextBox tbSheetBrute;
    }
}