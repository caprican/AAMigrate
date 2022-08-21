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
    public partial class SelectBook : Form
    {
        public string BookSelected { get; set; }

        public SelectBook(List<string> booksNames)
        {
            InitializeComponent();
            listBox1.Items.AddRange(booksNames.ToArray());

            bValid.Enabled = booksNames.Count > 0;

            listBox1.SelectedValueChanged += (sender, e) =>
            {
                BookSelected = listBox1.SelectedItem?.ToString();
                bValid.Enabled = true;
            };

            listBox1.DoubleClick += (_, e) =>
            {
                if (!string.IsNullOrEmpty(BookSelected))
                {
                    this.DialogResult = DialogResult.OK;
                }
            };
        }
    }
}
