using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;
using System.Data.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmGorevDetay : Form
    {
        public FrmGorevDetay()
        {
            InitializeComponent();
        }

        DBIsTakipEntities1 db = new DBIsTakipEntities1();
        private void FrmGorevDetay_Load(object sender, EventArgs e)
        {
            db.TblGorevDetaylar.Load();
            bindingSource1.DataSource = db.TblGorevDetaylar.Local;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void görevDetaySilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
