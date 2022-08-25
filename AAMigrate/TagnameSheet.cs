using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMigrate
{
    public class TagnameSheet
    {
        public string Name { get; }
        public string StartingName { get; }

        public int ColumnStart { get; }
        public int ColumnEnd { get; set; }

        public TagnameSheet(string name, int column)
        {
            if(name.StartsWith("$"))
                name = name.Substring(1);

            //Name = name.EndsWith("_") || name.Contains("*") ? name : name + "_";
            Name = name.ToUpper();
            StartingName = name.Contains("*") ? name.Remove(name.IndexOf('*')) : String.Empty;
            
            ColumnStart = column;
        }
    }
}
