using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Golosinas
{
    public partial class VUsuarios : Form
    {
        public VUsuarios()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void VUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            dataGridView1.DataSource = usuarioDA.ListarUsuarios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            user.Codigo = txtCodigo1.Text;
            user.Nombre = txtNombre.Text;
            user.Clave = txtClave.Text;
            user.Rol = cobRol.Text;
            user.EstaActivo = chbEstado.Checked;

            bool insert = usuarioDA.InsertarUsuario(user);

            if (insert)
            {
                MessageBox.Show("Usuario Creado con exito");
                ListarUsuarios(); 
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Usuario no se pudo crear");
            }
        }

        private void LimpiarControles()
        {
            txtCodigo1.Clear();
            txtNombre.Text = "";
            txtClave.Text = "";
            cobRol.Text = String.Empty;
            chbEstado.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtCodigo1.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtClave.Text = dataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
                cobRol.Text = dataGridView1.CurrentRow.Cells["Rol"].Value.ToString();
                chbEstado.Checked = Convert.ToBoolean( dataGridView1.CurrentRow.Cells["EstaActivo"].Value);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                bool elimino = usuarioDA.EliminarUsuario(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                }
                else 
                {
                    MessageBox.Show("El usuario no se pudo eliminar");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
