using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeCRUD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           

            // TODO: This line of code loads data into the 'sekolahDataSet.siswa' table. You can move, or remove it, as needed.
            this.siswaTableAdapter.Fill(this.sekolahDataSet.siswa);

            this.siswaTableAdapter.Fill(this.sekolahDataSet.siswa);
            txtNIS.Enabled = false;
            txtNama.Enabled = false;
            txtJurusan.Enabled = false;
            txtJeniskelamin.Enabled = false;
            btnSave.Enabled = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            btnSave.Enabled = true;
            txtNIS.Enabled = true;
            txtNama.Enabled = true;
            txtJurusan.Enabled = true;
            txtJeniskelamin.Enabled = true;
            txtNIS.Text = "";
            txtNama.Text = "";
            txtJurusan.Text = "";
            txtJeniskelamin.Text = "";
            int ctr, len;
            string codeval;

            dt = sekolahDataSet.Tables["siswa"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            Code = dr["NIS"].ToString();
            codeval = Code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtNIS.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                txtNIS.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtNIS.Text = "C" + ctr;
            }
            btnAdd.Enabled = false;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;

            dt = sekolahDataSet.Tables["siswa"];
            dr = dt.NewRow();
            dr[0] = txtNIS.Text;
            dr[1] = txtNama.Text;
            dr[2] = txtJurusan.Text;
            dr[3] = txtJeniskelamin.Text;
            dt.Rows.Add(dr);
            siswaTableAdapter.Update(sekolahDataSet);
            txtNIS.Text = System.Convert.ToString(dr[0]);
            txtNIS.Enabled = false;
            txtNama.Enabled = false;
            txtJurusan.Enabled = false;
            txtJeniskelamin.Enabled = false;
            
            this.siswaTableAdapter.Fill(this.sekolahDataSet.siswa);
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow dr;
            string Code;

            Code = txtNIS.Text;
            dr = sekolahDataSet.Tables["siswa"].Rows.Find(Code);
            dr.Delete();
            siswaTableAdapter.Update(sekolahDataSet);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
