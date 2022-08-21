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
    public partial class DiffOldTagnamesAttributesForm : Form
    {
        public DiffOldTagnamesAttributesForm(List<string> attributeMasks, List<string> oldTagnames)
        {
            InitializeComponent();

            AttributesBox.Items.AddRange(attributeMasks.ToArray());

            OldTagnameBox.Items.AddRange(oldTagnames.ToArray());
        }
    }
}
