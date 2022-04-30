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
    public partial class VProducto : Form
    {
        public VProducto()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;

        ProductoDA productoDA = new ProductoDA();
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoP.Text))
                {
                    errorProvider1.SetError(txtCodigoP, "Ingrese el codigo");
                    txtCodigoP.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtDescrip.Text))
                {
                    errorProvider1.SetError(txtDescrip, "Ingrese una descripcion");
                    txtDescrip.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    errorProvider1.SetError(txtPrecio, "Ingese un precio");
                    txtPrecio.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtExistencia.Text))
                {
                    errorProvider1.SetError(txtExistencia, "Ingrese una existencia");
                    txtExistencia.Focus();
                    return;
                }

                Producto producto = new Producto();
                producto.Codigo = txtCodigoP.Text;
                producto.Descripcion = txtDescrip.Text;
                producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                producto.Existencia = Convert.ToInt32(txtExistencia.Text);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                producto.Imagen = ms.GetBuffer();

                bool inserta = productoDA.InsertaProductp(producto);
                if (inserta)
                {
                    ListarProductos();
                    MessageBox.Show("Producto insertado");
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void VProducto_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void ListarProductos()
        {
            dvgProductos.DataSource = productoDA.ListaProductos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dvgProductos.SelectedRows.Count > 0)
            {
                txtCodigoP.Text = dvgProductos.CurrentRow.Cells["Codigo"].Value.ToString();
                txtDescrip.Text = dvgProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dvgProductos.CurrentRow.Cells["Precio"].Value.ToString();
                txtExistencia.Text = dvgProductos.CurrentRow.Cells["Existencia"].Value.ToString();

                var temporal = productoDA.SeleccionarImagen(dvgProductos.CurrentRow.Cells["Codigo"].Value.ToString());

                if (temporal.Length > 0)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    pictureBox1.Image = null; 
                }
                txtCodigoP.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dvgProductos.SelectedRows.Count > 0)
            {
                bool elimino = productoDA.EliminarProducto(dvgProductos.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino == true)
                {
                    ListarProductos();
                    MessageBox.Show("Producto Eliminado");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto");
                }
            }
        }
    }
}
