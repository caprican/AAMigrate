using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAMigrate
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            tbSheetNameNewTemplate.Text = Properties.Settings.Default.NewTemplateMark;
            cBSheetNameNewTemplate.SelectedIndex = Properties.Settings.Default.NewTemplateMarkPosition;

            tbSheetNameOldTemplate.Text = Properties.Settings.Default.OldTemplateMark;
            cBSheetNameOldTemplate.SelectedIndex = Properties.Settings.Default.OldTemplateMarkPosition;

            tbSheetNameOldConcatTemplate.Text = Properties.Settings.Default.OldTemplateConcatMark;
            cBSheetNameOldConcatTemplate.SelectedIndex = Properties.Settings.Default.OldTemplateConcatMarkPosition;

            tbSheetBrute.Text = Properties.Settings.Default.SheetDataBruteMark;
            cBSheetBrute.SelectedIndex = Properties.Settings.Default.SheetDataBruteMarkPosition;

            tbSheetExport.Text = Properties.Settings.Default.SheetExportMark;
            cBSheetBrute.SelectedIndex = Properties.Settings.Default.SheetExportMarkPosition;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NewTemplateMark = tbSheetNameNewTemplate.Text;
            Properties.Settings.Default.NewTemplateMarkPosition = (byte)cBSheetNameNewTemplate.SelectedIndex;

            Properties.Settings.Default.OldTemplateMark = tbSheetNameOldTemplate.Text;
            Properties.Settings.Default.OldTemplateMarkPosition = (byte)cBSheetNameOldTemplate.SelectedIndex;

            Properties.Settings.Default.OldTemplateConcatMark = tbSheetNameOldConcatTemplate.Text;
            Properties.Settings.Default.OldTemplateConcatMarkPosition = (byte)cBSheetNameOldConcatTemplate.SelectedIndex;

            Properties.Settings.Default.SheetDataBruteMark = tbSheetBrute.Text;
            Properties.Settings.Default.SheetDataBruteMarkPosition = (byte)cBSheetBrute.SelectedIndex;

            Properties.Settings.Default.SheetExportMark = tbSheetExport.Text;
            Properties.Settings.Default.SheetExportMarkPosition = (byte)cBSheetBrute.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void Defaultbutton_Click(object sender, EventArgs e)
        {
            tbSheetNameNewTemplate.Text ="_NEW";
            cBSheetNameNewTemplate.SelectedIndex = 4;

            tbSheetNameOldTemplate.Text = "_OLD";
            cBSheetNameOldTemplate.SelectedIndex = 4;

            tbSheetNameOldConcatTemplate.Text = "$templates";
            cBSheetNameOldConcatTemplate.SelectedIndex = 0;

            tbSheetBrute.Text = "Brute";
            cBSheetBrute.SelectedIndex = 0;

            tbSheetExport.Text = "Export";
            cBSheetBrute.SelectedIndex = 0;
        }
    }
}
