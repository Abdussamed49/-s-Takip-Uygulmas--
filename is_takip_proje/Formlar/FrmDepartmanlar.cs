﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using is_takip_proje.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace is_takip_proje.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }
        // curd --> create read update delete

        DBIsTakipEntities1 db = new DBIsTakipEntities1();
        void Listele()
        {
            DBIsTakipEntities1 db = new DBIsTakipEntities1();
            var degerler = (from x in db.TblDepartmanlar_
                            select new
                            {
                                x.ID,
                                x.Ad
                            }).ToList();
            gridControl1.DataSource = degerler;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar_ t = new TblDepartmanlar_();
            t.Ad = TxtAd.Text;
            db.TblDepartmanlar_.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı bir şekilde sisteme kaydedildi", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblDepartmanlar_.Find(x);
            db.TblDepartmanlar_.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Departman silme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblDepartmanlar_.Find(x);
            deger.Ad = TxtAd.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Departman güncelleme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
        }
    }
}
