using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void kiemTraKichHoatForm(Form form)
        {
            Form[] DSFormCon = this.MdiChildren;
            var kiemTraTonTai = DSFormCon.Where(s => s.Name == form.Name).FirstOrDefault();

            if (kiemTraTonTai != null)
            {
                kiemTraTonTai.Activate();
            }
            else
            {
                form.MdiParent = this;
                form.Show();
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLySach f = new frmQuanLySach();
            kiemTraKichHoatForm(f);
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia f = new frmDocGia();
            kiemTraKichHoatForm(f);
        }

        private void mượnTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuonTra f = new frmMuonTra();
            kiemTraKichHoatForm(f);
        }

        private void quánLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe f=new frmBaoCaoThongKe();
            kiemTraKichHoatForm(f);
        }
    }
}
