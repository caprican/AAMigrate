using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

using System.Windows.Forms;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;

namespace AAMigrate
{
    public partial class RibbonMigrate
    {
        private void RibbonMigrate_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void GenerateFileButton_Click(object sender, RibbonControlEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "CSV UTF-8 (délimité par des virgules) (*.csv)|*.csv|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileSave = fileDialog.FileName;

                //System.Globalization.CultureInfo OriginalLanguage = System.Globalization.CultureInfo.CurrentCulture;
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Excel.Worksheet ActiveWorsheet = Globals.ThisAddIn.Application.ActiveSheet;

                foreach (Excel.Worksheet displayWorksheet in Globals.ThisAddIn.Application.Sheets)
                {
                    if (displayWorksheet.Name == "Export")
                    {
                        displayWorksheet.Activate();
                        break;
                    }
                }

                bool ActiveSheetIsExport = (ActiveWorsheet.Name == "Export");
                Globals.ThisAddIn.Application.ActiveSheet.SaveAs(FileSave, FileFormat:62/*Excel.XlFileFormat.xlCSVUTF8*/, Local: false);

                if (ActiveSheetIsExport || (ActiveWorsheet != Globals.ThisAddIn.Application.ActiveSheet))
                    Globals.ThisAddIn.Application.ActiveSheet.Name = "Export";

                ActiveWorsheet.Activate();

                //// Restauration de la langue d'origine
                //System.Threading.Thread.CurrentThread.CurrentCulture = OriginalLanguage;

            }
        }

        private void OrderColumnButton_Click(object sender, RibbonControlEventArgs e)
        {
            List<string> workSheetName = new List<string>();
            foreach (Excel.Worksheet displayWorksheet in Globals.ThisAddIn.Application.Sheets)
                workSheetName.Add(displayWorksheet.Name);

            if (Globals.ThisAddIn.Application.Sheets.Count < 3 || !workSheetName.Any(a => a == "Brute") || !workSheetName.Any(a => a.StartsWith("$")) || !workSheetName.Any(a => a.StartsWith("$ST_")))
            {
                MessageBox.Show("La structure des feuilles ne correspond pas au modèle", "Incohérence modèle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> workBookNames = new List<string>();
            foreach(Excel.Workbook workbook in Globals.ThisAddIn.Application.Workbooks)
            {
                workBookNames.Add(workbook.Name);
            }

            workBookNames.Remove(Globals.ThisAddIn.Application.ActiveWorkbook.Name);

            Excel.Workbook OriginalBook = null;

            if(workBookNames.Count >= 1)
            {
                SelectBook selectBook = new SelectBook(workBookNames);
                if (selectBook.ShowDialog() == DialogResult.OK && selectBook.BookSelected != null)
                {
                    OriginalBook = Globals.ThisAddIn.Application.Workbooks[selectBook.BookSelected];
                }
            }
            else if(workBookNames.Count == 1)
            {
                OriginalBook = Globals.ThisAddIn.Application.Workbooks[workBookNames.First()];
            }
            else
            {
                OriginalBook = null;
            }

            Excel.Worksheet bruteWorksheet = null, templateWorksheet = null;
            foreach (Excel.Worksheet displayWorksheet in Globals.ThisAddIn.Application.Sheets)
            {
                if (displayWorksheet.Name == "Brute")
                {
                    displayWorksheet.Activate();
                    bruteWorksheet = displayWorksheet;
                }
                else if (displayWorksheet.Name == "$templates")
                {
                    templateWorksheet = displayWorksheet;
                }
                else if (displayWorksheet.Name == $"{workSheetName.First(f => f.StartsWith("$") && !f.StartsWith("$ST_"))}")
                {
                    templateWorksheet = displayWorksheet;
                }
            }

            if (!workSheetName.Any(a => a == "$templates"))
                CopyColumnFromTemplate(OriginalBook, bruteWorksheet, templateWorksheet, workSheetName.Find(f => f.StartsWith("$") && !f.StartsWith("$ST_")));
            else
                MergeTemplate(OriginalBook, bruteWorksheet, templateWorksheet);
        }

        private string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }

        private static bool LineIsFree(Excel.Range range) => (int)range.Interior.Color == FreeColor;
        private static readonly int FreeColor = Color.Transparent.ToArgb();

        private void LineAlreadyMigred(Excel.Worksheet bruteWorksheet)
        {
            for (int iBruteRow = 1; iBruteRow < bruteWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row + 1; iBruteRow++)
            {
                if (!LineIsFree(bruteWorksheet.Range[$"{iBruteRow}:{iBruteRow}"]))
                {
                    bruteWorksheet.Range[$"{iBruteRow}:{iBruteRow}"].Interior.Color = System.Drawing.Color.DarkBlue;
                }
            }
        }

        private void DuplicateBruteSheet(Excel.Workbook dataBook, Excel.Worksheet bruteWorksheet)
        {
            if (!(dataBook is null))
            {
                ((Excel.Worksheet)dataBook.ActiveSheet).UsedRange.Copy();
                bruteWorksheet.Range["A1"].Activate();
                bruteWorksheet.Paste();
            }
        }

        private int GetLastRowOldTemplate(Excel.Worksheet bruteWorksheet, int startTemplate)
        {
            int endTemplate = startTemplate;
            for (int i = startTemplate; i <= bruteWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row; i++)
            {
                endTemplate = i;
                if (string.IsNullOrEmpty(bruteWorksheet.Range[$"A{i}"].Value))
                    break;
            }
            if (endTemplate < bruteWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row)
                endTemplate--;

            return endTemplate;
        }

        private void CopyColumnFromTemplate(Excel.Workbook dataBook, Excel.Worksheet bruteWorksheet, Excel.Worksheet templateWorksheet, string workSheetName)
        {
            DuplicateBruteSheet(dataBook, bruteWorksheet);              // copie les données brute dans la feuille "Brute"

            // Recherche de la position du modèle dans la feuille
            int startTemplate = bruteWorksheet.Range["A:A"].Find($":TEMPLATE={workSheetName}").Row;
            startTemplate += 2;                      // Correction de la ligne

            int endTemplate = GetLastRowOldTemplate(bruteWorksheet, startTemplate);

            LineAlreadyMigred(bruteWorksheet);                          // Marque les lignes déjà traité par un autre modèle

            // Parcour des colonnes
            int indColumn = 1;
            List<string> NoCopyAttributes = new List<string>();
            while (!string.IsNullOrEmpty(templateWorksheet.Cells[2, indColumn].Value))
            {
                Excel.Range findAttribute = bruteWorksheet.Range[$"{startTemplate - 1}:{startTemplate - 1}"].Find(templateWorksheet.Cells[2, indColumn].Value,
                                                                                                                  Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext);

                if (findAttribute != null)
                {
                    string colOrig = GetExcelColumnName(findAttribute.Column);
                    string colDest = GetExcelColumnName(indColumn);

                    int rowDest = 3;

                    for (int i = startTemplate; i <= endTemplate; i++)
                    {
                        if (LineIsFree(bruteWorksheet.Range[$"{colOrig}{i}"]))
                        {
                            templateWorksheet.Range[$"{colDest}{rowDest}"].Value = $"={bruteWorksheet.Name}!{colOrig}{i}";
                            bruteWorksheet.Range[$"{colOrig}{i}"].Font.Bold = true;
                            bruteWorksheet.Range[$"{colOrig}{i}"].Font.Color = System.Drawing.Color.DarkOrange;
                            rowDest++;

                            if (!(dataBook is null))
                            {
                                dataBook.ActiveSheet.Range[$"{colOrig}{i}"].Font.Bold = true;
                                dataBook.ActiveSheet.Range[$"{colOrig}{i}"].Font.Color = System.Drawing.Color.DarkOrange;
                            }
                        }
                    }
                }
                else
                {
                    NoCopyAttributes.Add(templateWorksheet.Cells[2, indColumn].Value);
                }

                indColumn++;
            }

            #region coloration des ligne
            for (int i = startTemplate; i <= endTemplate; i++)
            {
                if (LineIsFree(bruteWorksheet.Range[$"A{i}"]))
                {
                    bruteWorksheet.Range[$"{i}:{i}"].Interior.Color = System.Drawing.Color.FromArgb(169, 208, 142);

                    if (!(dataBook is null))
                    {
                        dataBook.ActiveSheet.Range[$"{i}:{i}"].Interior.Color = System.Drawing.Color.FromArgb(169, 208, 142);
                    }
                }
            }
            #endregion

            if (NoCopyAttributes.Count > 0)
            {
                AttributesNoCopy attributesNoCopy = new AttributesNoCopy(NoCopyAttributes);
                attributesNoCopy.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tous les attributs ont été copiés", "Copie attributs", MessageBoxButtons.OK);
            }
        }

        private List<TagnameSheet> GetMaskTagname(Excel.Worksheet templateWorksheet)
        {
            List<TagnameSheet> tagnameSheets = new List<TagnameSheet>();
            List<string> commentString = new List<string>() { "//", "/*", "(*", "'" };
            for (int i = 1; i < templateWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column; i++)
            {
                if (templateWorksheet.Range[$"{GetExcelColumnName(i)}1"].Value is string attributeName && !string.IsNullOrEmpty(attributeName) &&
                    !commentString.Any(comment => attributeName.StartsWith(comment)))
                {
                    tagnameSheets.Add(new TagnameSheet(attributeName, i));
                }
            }

            if (tagnameSheets.Count == 0)
            {
                return null;
            }

            tagnameSheets[tagnameSheets.Count - 1].ColumnEnd = templateWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
            for (int i = 0; i < tagnameSheets.Count - 1; i++)
            {
                tagnameSheets[i].ColumnEnd = tagnameSheets[i + 1].ColumnStart - 1;

                List<string> attributName = new List<string>();
                for (int j = tagnameSheets[i].ColumnStart; j < tagnameSheets[i].ColumnEnd; j++)
                {
                    string attribut = templateWorksheet.Range[$"{GetExcelColumnName(j)}2"].Value as string;

                    attributName.Add(attribut.Contains(".") ? attribut.Split('.').Skip(1).Aggregate((concat, str) => $"{concat}.{str}") : attribut);
                }

                if(attributName.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key).FirstOrDefault() is string duplicationAttribut)
                {
                    tagnameSheets[i].ColumnEnd = templateWorksheet.Range[$"{GetExcelColumnName(tagnameSheets[i].ColumnStart)}2:{GetExcelColumnName(tagnameSheets[i].ColumnEnd)}2"].Find(duplicationAttribut).FindNext().Column - 1;
                }
            }

            return tagnameSheets;
        }

        private Dictionary<string, OldTagnameSheet> GetOldTagname(Excel.Worksheet bruteWorksheet, List<TagnameSheet> maskTagnames, string firstTagnameRow)
        {
            Dictionary<string, OldTagnameSheet> oldTagnameRow = new Dictionary<string, OldTagnameSheet>();
            foreach (TagnameSheet maskTagname in maskTagnames)
            {
                string tagname = string.Empty;
                if (!maskTagname.Name.Contains('*'))
                {
                    tagname = maskTagname.Name + firstTagnameRow.Substring(maskTagname.Name.Length);
                }
                else
                {
                    char[] masterTagname = firstTagnameRow.ToArray();
                    char[] tagnameChars = maskTagname.Name.ToArray();
                    for (int c = 0; c < tagnameChars.Length; c++)
                    {
                        tagname += (tagnameChars[c] == '*') ? masterTagname[c] : tagnameChars[c];
                    }
                }
                
                if (bruteWorksheet.Range["A:A"].Find(tagname, LookAt: XlLookAt.xlWhole) is Excel.Range tagnameCell && tagnameCell != null && LineIsFree(tagnameCell))
                {
                    if(!oldTagnameRow.ContainsKey(maskTagname.Name))
                    {
                        oldTagnameRow.Add(maskTagname.Name, new OldTagnameSheet { Tagname = tagname, Row = tagnameCell.Row });
                    }
                    else
                    {
                        MessageBox.Show($"Le filtre {maskTagname.Name} est en double", "Erreur de filtrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return oldTagnameRow;
        }

        private int GetRowOldAttribut(Excel.Worksheet bruteWorksheet, int oldAttributRow)
        {
            int oldTagnameRow = oldAttributRow;
            while (oldTagnameRow > 1)
            {
                if (bruteWorksheet.Range[$"A{oldTagnameRow}"].Value == ":Tagname")
                {
                    break;
                }
                else
                {
                    oldTagnameRow--;
                }
            }
            return oldTagnameRow;
        }

        private void UpperCell(Excel.Worksheet worksheet, int column, int row)
        {
            worksheet.Range[$"{GetExcelColumnName(column)}{row}"].Font.Bold = true;
            worksheet.Range[$"{GetExcelColumnName(column)}{row}"].Font.Color = System.Drawing.Color.DarkOrange;
        }

        private void MergeTemplate(Excel.Workbook dataBook, Excel.Worksheet bruteWorksheet, Excel.Worksheet templateWorksheet)
        {
            DuplicateBruteSheet(dataBook, bruteWorksheet);              // copie les données brute dans la feuille "Brute"

            List<TagnameSheet> attributNameMasks = GetMaskTagname(templateWorksheet);        // Obtient la liste des tag constituant la nouvelle instance

            if (attributNameMasks is null)
            {
                MessageBox.Show("Aucun jeu d'attribut trouvé");
                return;
            }

            var duplicateKeys = attributNameMasks.GroupBy(x => x.Name).Where(group => group.Count() > 1).Select(group => group.Key);
            if(duplicateKeys.Any())
            {
                MessageBox.Show($"Filtre en double : {duplicateKeys.Aggregate((concat, str) => concat + ", " + str)}", "Filtre en double", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            LineAlreadyMigred(bruteWorksheet);                          // Marque les lignes déjà traité par un autre modèle

            int rowTemplate = 3;
            int endRowBruteSheet = bruteWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            for(int iBruteRow = 1; iBruteRow < endRowBruteSheet; iBruteRow++)
            {
                if (LineIsFree(bruteWorksheet.Range[$"A{iBruteRow}"]) && bruteWorksheet.Range[$"A{iBruteRow}"].Value is string firstTagname &&
                    (firstTagname.ToUpper().StartsWith(attributNameMasks[0].Name) || (!string.IsNullOrEmpty(attributNameMasks[0].StartingName) && firstTagname.ToUpper().StartsWith(attributNameMasks[0].StartingName))))
                {
                    Dictionary<string, OldTagnameSheet> oldTagnames = GetOldTagname(bruteWorksheet, attributNameMasks, firstTagname);

                    if (attributNameMasks.Count != oldTagnames.Count)
                    {
                        var windows = new DiffOldTagnamesAttributesForm(attributNameMasks.Select(attribute => attribute.Name).ToList(), oldTagnames.Select(tag => tag.Value.Tagname).ToList());
                        if(windows.ShowDialog() != DialogResult.Ignore)
                            return;
                    }

                    foreach (TagnameSheet attributNameMask in attributNameMasks)
                    {
                        for (int iColumn = attributNameMask.ColumnStart; iColumn <= attributNameMask.ColumnEnd; iColumn++)
                        {
                            if(oldTagnames.ContainsKey(attributNameMask.Name))
                            {
                                int oldTagnameRow = GetRowOldAttribut(bruteWorksheet, oldTagnames[attributNameMask.Name].Row - 1);

                                if (oldTagnameRow < 0)
                                {
                                    MessageBox.Show("Problème");
                                    return;
                                }

                                string attributeName = templateWorksheet.Range[$"{GetExcelColumnName(iColumn)}2"].Value;
                                if (bruteWorksheet.Range[$"{oldTagnameRow}:{oldTagnameRow}"].Find(attributeName) is Excel.Range BruteAttribute && BruteAttribute != null &&
                                    LineIsFree(bruteWorksheet.Range[$"{oldTagnames[attributNameMask.Name].Row}:{oldTagnames[attributNameMask.Name].Row}"]))
                                {
                                    int iBruteColumn = BruteAttribute.Column;

                                    if (!(bruteWorksheet.Range[$"{GetExcelColumnName(iBruteColumn)}{oldTagnames[attributNameMask.Name].Row}"].Value is null))
                                    {
                                        templateWorksheet.Range[$"{GetExcelColumnName(iColumn)}{rowTemplate}"].Value = $"={bruteWorksheet.Name}!{GetExcelColumnName(iBruteColumn)}{oldTagnames[attributNameMask.Name].Row}";
                                    }
                                    else
                                    {
                                        templateWorksheet.Range[$"{GetExcelColumnName(iColumn)}{rowTemplate}"].ClearComments();
                                        templateWorksheet.Range[$"{GetExcelColumnName(iColumn)}{rowTemplate}"].AddComment($"Source : {bruteWorksheet.Name}!{GetExcelColumnName(iBruteColumn)}{oldTagnames[attributNameMask.Name].Row}");
                                    }

                                    UpperCell(bruteWorksheet, iBruteColumn, oldTagnames[attributNameMask.Name].Row);

                                    if (!(dataBook is null))
                                    {
                                        UpperCell(dataBook.ActiveSheet, iBruteColumn, oldTagnames[attributNameMask.Name].Row);
                                    }
                                }
                            }
                        }
                        if(oldTagnames.ContainsKey(attributNameMask.Name))
                        {
                            if (LineIsFree(bruteWorksheet.Range[$"{oldTagnames[attributNameMask.Name].Row}:{oldTagnames[attributNameMask.Name].Row}"]))
                            {
                                bruteWorksheet.Range[$"{oldTagnames[attributNameMask.Name].Row}:{oldTagnames[attributNameMask.Name].Row}"].Interior.Color = System.Drawing.Color.FromArgb(169, 208, 142);

                                if(!(dataBook is null))
                                {
                                    dataBook.ActiveSheet.Range[$"{oldTagnames[attributNameMask.Name].Row}:{oldTagnames[attributNameMask.Name].Row}"].Interior.Color = System.Drawing.Color.FromArgb(169, 208, 142);
                                }
                            }
                        }
                    }
                    rowTemplate++;
                }
            }

            int lastRowTemplate = templateWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            foreach (Excel.Worksheet sheet in Globals.ThisAddIn.Application.Sheets)
            {
                if(sheet.Name.StartsWith("$ST_") && lastRowTemplate > 3)
                {
                    sheet.Range["3:3"].AutoFill(sheet.Range[$"3:{lastRowTemplate}"]);
                }
            }

            MessageBox.Show("Transfert des colonnes en fonction des template terminé", "Transfert terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearStyleSheetButton_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet displayWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            int lastRow = displayWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row + 1;

            for(int iRow = 1; iRow < lastRow; iRow++)
            {
                displayWorksheet.Range[$"{iRow}:{iRow}"].Style = "Normal";
            }
        }

        private void ExportsButton_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet exportSheet = null;
            List<Excel.Worksheet> templateSheets = new List<Excel.Worksheet>();
            foreach (Excel.Worksheet displayWorksheet in Globals.ThisAddIn.Application.Sheets)
            {
                if (displayWorksheet.Name == "Export")
                {
                    exportSheet = displayWorksheet;
                }
                else if(displayWorksheet.Name.StartsWith("$ST_"))
                {
                    templateSheets.Add(displayWorksheet);
                }
            }


            if (exportSheet is null || templateSheets.Count == 0)
            {
                return;
            }

            int row = 1;
            foreach(Excel.Worksheet templateSheet in templateSheets)
            {
                templateSheet.UsedRange.Copy();
                exportSheet.Range[$"A{row}"].PasteSpecial(XlPasteType.xlPasteValues);

                int lastColumn = exportSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                exportSheet.Range[$"B{row}:{GetExcelColumnName(lastColumn)}{row}"].Value = string.Empty;

                row = exportSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row + 2;
            }

        }
    }
}
