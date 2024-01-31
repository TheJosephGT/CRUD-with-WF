using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_with_WF.model;

namespace CRUD_with_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentacion.FrmTabla oFrmTabla = new Presentacion.FrmTabla();

            oFrmTabla.ShowDialog();

            CargarDatos();
        }

        private void CargarDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var data = from d in db.Table_datos
                           select d;
                dataGridView1.DataSource = data.ToList();
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if(id != null)
            {
                Presentacion.FrmTabla oFrmTable = new Presentacion.FrmTabla(id);
                oFrmTable.ShowDialog();

                CargarDatos();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                using (CrudEntities db = new CrudEntities())
                {
                    Table_datos oTabla = db.Table_datos.Find(id);
                    db.Table_datos.Remove(oTabla);

                    db.SaveChanges();
                }
                CargarDatos();
            }
        }
    }
}
