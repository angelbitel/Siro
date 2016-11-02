using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Perfil : DevExpress.XtraEditors.XtraForm
    {
        private bool EsPrimera { get; set; }
        public Perfil()
        {
            InitializeComponent();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            ListarMenu();

            /*llenar Nodos Desde Base de Datos*/
            Principal.Bariables.db.Perfil.ToList().ForEach(f => {
                var node = new TreeNode { Name = f.IdPerfil.ToString() };
                node.Text = f.Perfil1;
                node.Tag = f.IdPerfil;
                //f.DetallesPerfil.Where(w=> w.Deshabilitar??false == false).ToList().ForEach(g => {

                //    var equivale = list.SingleOrDefault(s => s.Name == g.MenuName);
                //    var SubNode = new TreeNode { Name = equivale.Name };
                //    SubNode.Text = equivale.Text;
                //    SubNode.Tag = g.IdDetallePerfil;
                //    node.Nodes.Add(SubNode);

                //});
                treeView1.Nodes.Add(node);
            });
        }        
        private void ListarMenu()
        {
            textBox1.Text = string.Empty;
            treeView2.Nodes.Clear();
            /*LLenar segundo treeView con menu principal*/
            var p = new Principal().navBarControl1;
            p.Items.ToList().ForEach(f =>
            {
                var node = new TreeNode { Name = f.Name };
                node.Text = f.Caption;
                treeView2.Nodes.Add(node);

                list.Add(node);
            });
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Id = 0;
            ListarMenu();
        }
        private int Id { get; set; }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void GuardarPerfil()
        {
            if (Id > 0)
            {
                lblMsg.Caption = "No puede agragar perfil!";
                return;
            }
            lblMsg.Caption = string.Empty;
            if (textBox1.Text.Trim() != string.Empty)
            {
                var nodes = LookupChecks(treeView2.Nodes);
                if (nodes.Count > 0)
                {
                    var perfil = new Siro.Perfil() { Perfil1 = textBox1.Text };
                    NuevoPerfil = perfil;
                    Principal.Bariables.db.Perfil.Add(perfil);
                    Principal.Bariables.db.SaveChanges();
                    nodes.ForEach(f =>
                    {
                        Principal.Bariables.db.DetallesPerfil.Add(new Siro.DetallesPerfil
                        {
                            IdPerfil = perfil.IdPerfil,
                            MenuName = f.Name
                        });
                    });
                    Principal.Bariables.db.SaveChanges();
                    lblMsg.Caption = "Perfil Guardado Correctamente!!!";
                }
                else
                {
                    lblMsg.Caption = "Seleccione Algun Nodo";
                }
            }
            else
            {
                lblMsg.Caption = "Escriba Nombre Del Perfil";
            }
            lblMsg.Caption = "Perfil Guardado Correctamente!!!";
        }

        List<TreeNode> list = new List<TreeNode>();

        List<TreeNode> LookupChecks(TreeNodeCollection nodes)
        {
            var list = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    list.Add(node);
            }
            return list;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return;
            ModificarPerfil();
        }

        private void ModificarPerfil()
        {
            var node = treeView1.SelectedNode;
            Id = int.Parse(node.Tag.ToString());
            var node2 = Principal.Bariables.db.DetallesPerfil.Where(w => w.Deshabilitar ?? false == false && w.IdPerfil == Id).ToList();
            textBox1.Text = node.Text;

            for (int i = 0; i < treeView2.Nodes.Count; i++)
            {
                node2.ForEach(g =>
                {
                    if (g.MenuName == treeView2.Nodes[i].Name)
                    {
                        treeView2.Nodes[i].Checked = true;
                        treeView2.Nodes[i].Tag = g.IdDetallePerfil;
                        return;
                    }
                });
            }
        }

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return;
            if(Id>0)
            {
                int id = 0;
                /*Si no existe el registro lo añade*/
                if(e.Node.Tag == null)
                {
                    id=int.Parse(treeView1.SelectedNode.Tag.ToString());
                    Principal.Bariables.db.DetallesPerfil.Add(new Siro.DetallesPerfil
                    {
                        IdPerfil = id,
                        MenuName = e.Node.Name
                    });
                    Principal.Bariables.db.SaveChanges();
                    return;
                }
                bool chk = false;
                /*Si existe el registro lo modifica*/
                id = int.Parse(e.Node.Tag.ToString());
                if (e.Node.Checked)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                }
                Principal.Bariables.db.DetallesPerfil.Single(w => w.IdDetallePerfil == id).Deshabilitar = chk;
                Principal.Bariables.db.SaveChanges();
                lblMsg.Caption = "Perfil Guardado Correctamente!!!";
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuardarPerfil();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModificarPerfil();
            lblMsg.Caption = "Modificara El Perfil De: " + treeView1.SelectedNode.Text;
        }


        public Siro.Perfil NuevoPerfil { get; set; }
    }
}