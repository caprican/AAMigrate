using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;

namespace AAMigrate
{
    public partial class ThisAddIn
    {
        public bool IsArchestraFile { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.WorkbookOpen += Application_WorkbookOpen;
        }

        private void Application_WorkbookOpen(Excel.Workbook Wb)
        {
            string FileName = Wb.FullName;

            if (Wb.FileFormat == Excel.XlFileFormat.xlCSV && !IsArchestraFile)
            {
                if (MessageBox.Show("Le fichier est généré par Archestra ?", "Fichier archestra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Wb.Close();
                    IsArchestraFile = true;
                    Application.Workbooks.Open(FileName, Format: Excel.XlFileFormat.xlCSV, Local: false, Delimiter: ",");
                }
            }
            else if (Wb.FileFormat == Excel.XlFileFormat.xlUnicodeText && !IsArchestraFile)
            {
                if (MessageBox.Show("Le fichier est généré par Archestra ?", "Fichier archestra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Wb.Close();
                    IsArchestraFile = true;
                    Application.Workbooks.OpenText(FileName, Origin: Excel.XlPlatform.xlWindows, Local: true, DataType: Excel.XlTextParsingType.xlDelimited, TextQualifier: Excel.XlTextQualifier.xlTextQualifierDoubleQuote, Comma: true);
                }
            }
            else
            {
                IsArchestraFile = false;
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Application.WorkbookOpen -= Application_WorkbookOpen;
        }

        #region Code généré par VSTO
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        #endregion
    }
}
