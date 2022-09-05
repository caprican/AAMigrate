﻿namespace AAMigrate
{
    partial class RibbonMigrate : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonMigrate()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.aaGroup = this.Factory.CreateRibbonGroup();
            this.OrderColumnButton = this.Factory.CreateRibbonButton();
            this.ExportsButton = this.Factory.CreateRibbonButton();
            this.GenerateFileButton = this.Factory.CreateRibbonButton();
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.DoNotMigrateButton = this.Factory.CreateRibbonButton();
            this.UnmarkRowButton = this.Factory.CreateRibbonButton();
            this.ClearStyleSheetButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.aaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.aaGroup);
            this.tab1.Label = "Everdyn";
            this.tab1.Name = "tab1";
            // 
            // aaGroup
            // 
            this.aaGroup.Items.Add(this.OrderColumnButton);
            this.aaGroup.Items.Add(this.ExportsButton);
            this.aaGroup.Items.Add(this.GenerateFileButton);
            this.aaGroup.Items.Add(this.menu1);
            this.aaGroup.Label = "ArchestrA";
            this.aaGroup.Name = "aaGroup";
            // 
            // OrderColumnButton
            // 
            this.OrderColumnButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.OrderColumnButton.Label = "Transfert attributs";
            this.OrderColumnButton.Name = "OrderColumnButton";
            this.OrderColumnButton.OfficeImageId = "PasteTranspose";
            this.OrderColumnButton.ShowImage = true;
            this.OrderColumnButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OrderColumnButton_Click);
            // 
            // ExportsButton
            // 
            this.ExportsButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExportsButton.Label = "Vers exports";
            this.ExportsButton.Name = "ExportsButton";
            this.ExportsButton.OfficeImageId = "TableExportMenu";
            this.ExportsButton.ShowImage = true;
            this.ExportsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExportsButton_Click);
            // 
            // GenerateFileButton
            // 
            this.GenerateFileButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.GenerateFileButton.Label = "Génération";
            this.GenerateFileButton.Name = "GenerateFileButton";
            this.GenerateFileButton.OfficeImageId = "GetPowerQueryDataFromCsv";
            this.GenerateFileButton.ShowImage = true;
            this.GenerateFileButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GenerateFileButton_Click);
            // 
            // menu1
            // 
            this.menu1.Items.Add(this.DoNotMigrateButton);
            this.menu1.Items.Add(this.UnmarkRowButton);
            this.menu1.Items.Add(this.ClearStyleSheetButton);
            this.menu1.Label = "Marquage ligne";
            this.menu1.Name = "menu1";
            // 
            // DoNotMigrateButton
            // 
            this.DoNotMigrateButton.Label = "Marquer la ligne";
            this.DoNotMigrateButton.Name = "DoNotMigrateButton";
            this.DoNotMigrateButton.OfficeImageId = "SparkLineNegativePointColorPicker";
            this.DoNotMigrateButton.ShowImage = true;
            this.DoNotMigrateButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DoNotMigrateButton_Click);
            // 
            // UnmarkRowButton
            // 
            this.UnmarkRowButton.Label = "Démarquer la ligne";
            this.UnmarkRowButton.Name = "UnmarkRowButton";
            this.UnmarkRowButton.OfficeImageId = "ClearFormats";
            this.UnmarkRowButton.ShowImage = true;
            this.UnmarkRowButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.UnmarkRowButton_Click);
            // 
            // ClearStyleSheetButton
            // 
            this.ClearStyleSheetButton.Label = "Tout démarque";
            this.ClearStyleSheetButton.Name = "ClearStyleSheetButton";
            this.ClearStyleSheetButton.OfficeImageId = "ClearFormats";
            this.ClearStyleSheetButton.ShowImage = true;
            this.ClearStyleSheetButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ClearStyleSheetButton_Click);
            // 
            // RibbonMigrate
            // 
            this.Name = "RibbonMigrate";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonMigrate_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.aaGroup.ResumeLayout(false);
            this.aaGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup aaGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GenerateFileButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton OrderColumnButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton UnmarkRowButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ExportsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DoNotMigrateButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ClearStyleSheetButton;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMigrate RibbonMigrate
        {
            get { return this.GetRibbon<RibbonMigrate>(); }
        }
    }
}
