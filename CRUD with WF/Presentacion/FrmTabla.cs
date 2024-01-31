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

namespace CRUD_with_WF.Presentacion
{
    public partial class FrmTabla : Form
    {
        public int? id;
        Table_datos otabla = null;
        public FrmTabla(int? id=null)
        {
            InitializeComponent();

            this.id = id;
            if(id != null)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                otabla = db.Table_datos.Find(id);
                txtNombre.Text = otabla.nombre;
                txtCorreo.Text = otabla.correo;
                txtFechaNacimiento.Text = otabla.fecha_nacimiento;


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {
                if(id == null)
                {
                    otabla = new Table_datos();
                }

                otabla.nombre = txtNombre.Text;
                otabla.correo = txtCorreo.Text;
                otabla.fecha_nacimiento = txtFechaNacimiento.Text;

                if(id == null)
                {
                    db.Table_datos.Add(otabla);
                }
                else
                {
                    db.Entry(otabla).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                this.Close();

            }
        }

        private void FrmTabla_Load(object sender, EventArgs e)
        {

        }
    }
}
