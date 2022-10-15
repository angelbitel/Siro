using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Siro.Controller
{
    internal class AutoSugestTextBox
    {
        internal AutoSugestTextBox(ref TextEdit textBox, List<string> lstValores)
        {
            AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
            var tx = textBox.MaskBox;
            tx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tx.AutoCompleteCustomSource = customSource;
            customSource.AddRange(lstValores.ToArray());
        }
        internal AutoSugestTextBox(ref TextEdit textBox, string val)
        {
            textBox.BackColor = System.Drawing.Color.OrangeRed;
            textBox.ForeColor = System.Drawing.Color.White;
            textBox.Text = val;
        }
        internal AutoSugestTextBox(ref TextEdit textBox, string val, System.Drawing.Color color)
        {
            textBox.BackColor = color;
            textBox.ForeColor = System.Drawing.Color.White;
            textBox.Text = val;
        }
    }
}
