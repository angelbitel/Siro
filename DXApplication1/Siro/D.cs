using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using System;
using System.Linq;

namespace Siro
{
    internal class T
    {
        internal static ImageComboBoxItem Item(string desc, int value) => new ImageComboBoxItem { Description = desc, Value = value };
        internal static ImageComboBoxItem Item(int value, string desc) => new ImageComboBoxItem { Description = desc, Value = value };
        public static bool IsFormAlreadyOpen(string frmName, Form[] frms)
        {
            bool b = false;
            frms.ToList().ForEach(f => {
                if (f.Name == frmName)
                {
                    b = true;
                    f.BringToFront();
                }
            });
            return b;
        }
        public static void OpenForm(DevExpress.XtraEditors.XtraForm frm)
        {
            if (Principal.This != null)
            {
                if (!IsFormAlreadyOpen(frm.Name, Principal.This.MdiChildren))
                {
                    frm.MdiParent = Principal.This;
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("A OCURRIDO UN ERROR SE CERRARA LA APLICACION");
                try
                {
                    Application.Exit();
                }
                catch (Exception) { }
            }
        }
    }
}