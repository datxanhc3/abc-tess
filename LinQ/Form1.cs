using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            linqDataContext db = new linqDataContext();
            // cach 1 :
            // lấy bảng sản phẩm ra , điều kiện colums donhangnhap phải bé hơn 5(compraTo) , và sắp xếp donhangnhap (oderby
            //    dataGridView1.DataSource = db.TBL_SANPAHMs.Where(p=>p.donhangnhap.CompareTo("5")==-1).OrderBy(p=>p.donhangnhap);
            // cach 2 :
            //dataGridView1.DataSource = from u in db.TBL_SANPAHMs
            //                           from c in db.TBL_NCCs                                     
            //                           where u.mancc == c.mancc
            //                           orderby u.donhangnhap
            //                           select new
            //                           {
            //                               ID = c.mancc,
            //                               TENNCC = c.tenncc,
            //                               TEN_HANG = u.tenhang,
            //                               SOLUONG = u.soluong,                                     
            //                           };
            dataGridView1.DataSource = from k in db.TBL_SANPAHMs
                                       from g in db.TBL_NCCs    
                                   //where k.mancc == g.mancc
                                    select k;
            
        }

        public void xoancc()
        {
            linqDataContext xoa = new linqDataContext();

            string i = dataGridView1.SelectedCells[0].OwningRow.Cells["mancc"].Value.ToString();
            TBL_NCC dele = xoa.TBL_NCCs.Where(p => p.mancc.Equals(i)).FirstOrDefault();
            xoa.TBL_NCCs.DeleteOnSubmit(dele);
            xoa.SubmitChanges();


            
        }
        public void xoasp()
        {
            linqDataContext xoa = new linqDataContext();

            string i = dataGridView1.SelectedCells[0].OwningRow.Cells["mahang"].Value.ToString();
            TBL_SANPAHM dele = xoa.TBL_SANPAHMs.Where(p => p.mancc.Equals(i)).FirstOrDefault();
            xoa.TBL_SANPAHMs.DeleteOnSubmit(dele);
            xoa.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //xoancc();
            xoasp();


            button5_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            linqDataContext db = new linqDataContext();
            dataGridView1.DataSource = db.TBL_NCCs.Where(p => p.mancc.Equals(textBox1.Text));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            linqDataContext xoa = new linqDataContext();

            string i = dataGridView1.SelectedCells[0].OwningRow.Cells["mahang"].Value.ToString();
        }
    }
}
