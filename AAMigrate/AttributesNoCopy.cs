using System.Collections.Generic;
using System.Windows.Forms;

namespace AAMigrate
{
    public partial class AttributesNoCopy : Form
    {
        public AttributesNoCopy(List<string> attributes)
        {
            InitializeComponent();
            listBox1.Items.AddRange(attributes.ToArray());
        }
    }
}
