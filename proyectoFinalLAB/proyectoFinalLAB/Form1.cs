using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace proyectoFinalLAB
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

           /* Producto producto1 = new Producto();
            producto1.Nombre = "leche";
            producto1.Precio = 69;
            producto1.Stock = 19;
            producto1.Tipo = "lacteo";
            productos.Add(producto1);

            Producto producto2 = new Producto();
            producto2.Nombre = "yogurt";
            producto2.Precio = 40;
            producto2.Stock = 20;
            producto2.Tipo = "lacteo";
            productos.Add(producto2);

            Producto producto3 = new Producto();
            producto3.Nombre = "arroz";
            producto3.Precio = 50;
            producto3.Stock = 9;
            producto3.Tipo = "alimentos";
            productos.Add(producto3);

            Producto producto4 = new Producto();
            producto4.Nombre = "galletas oreo";
            producto4.Precio = 55;
            producto4.Stock = 26;
            producto4.Tipo = "golosinas";
            productos.Add(producto4);

            Producto producto5 = new Producto();
            producto5.Nombre = "lavandina";
            producto5.Precio = 90;
            producto5.Stock = 6;
            producto5.Tipo = "productos limpieza";
            productos.Add(producto5);

            Producto producto6 = new Producto();
            producto6.Nombre = "heladera";
            producto6.Precio = 60000;
            producto6.Stock = 5;
            producto6.Tipo = "electrodomesticos";
            productos.Add(producto6);

            Producto producto7 = new Producto();
            producto7.Nombre = "costillas de cerdo";
            producto7.Precio = 500;
            producto7.Stock = 10;
            producto7.Tipo = "carniceria";
            productos.Add(producto7);

            Producto producto8 = new Producto();
            producto8.Nombre = "aceite de girasol";
            producto8.Precio = 90;
            producto8.Stock = 10;
            producto8.Tipo = "alimentos";
            productos.Add(producto8);*/

            XmlSerializer serializador = new XmlSerializer(typeof(List<Producto>));
            FileStream lector = File.OpenRead("Productos.xml");
            Producto.productos = (List<Producto>)serializador.Deserialize(lector);
            lector.Close();

            lista.DataSource = Producto.productos;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtNombreA.Text == "")
            {
                errorProvider1.SetError(txtNombreA, "debe ingresar un nombre");
                txtNombreA.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreA, "");
            if (txtPrecioA.Text == "")
            {
                errorProvider1.SetError(txtPrecioA, "debe ingresar el precio");
                txtPrecioA.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreA, "");
            if (existe(txtNombreA.Text))
            {
                errorProvider1.SetError(txtNombreA, "El producto existe");
                txtNombreA.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreA, "");

            decimal Precio;
            if(!Decimal.TryParse(txtPrecioA.Text,out Precio))
            {

                errorProvider1.SetError(txtPrecioA, "Debe ingresar numeros");
                txtPrecioA.Focus();
                return;
            }
            if (Precio < 0)
            {

                errorProvider1.SetError(txtPrecioA, "Debe ingresar un valor positivo");
                txtPrecioA.Focus();
                return;
            }
            errorProvider1.SetError(txtPrecioA, "");

            decimal Stock;
            if (!Decimal.TryParse(txtCantidadA.Text, out Stock))
            {

                errorProvider1.SetError(txtCantidadA, "Debe ingresar numeros");
                txtCantidadA.Focus();
                return;
            }
            if (Precio < 0)
            {

                errorProvider1.SetError(txtCantidadA, "Debe ingresar un valor positivo");
                txtCantidadA.Focus();
                return;
            }
            errorProvider1.SetError(txtCantidadA, "");


            Producto miproducto = new Producto();
            miproducto.Nombre = txtNombreA.Text;
            miproducto.Precio = Convert.ToInt32(txtPrecioA.Text);
            miproducto.Stock = Convert.ToInt32(txtCantidadA.Text);
            miproducto.Tipo = txtTipoA.Text;
            Producto.productos.Add(miproducto);


            lista.DataSource = null;
            lista.DataSource = Producto.productos;


            txtNombreA.Clear();
            txtPrecioA.Clear();
            txtCantidadA.Clear();
            txtTipoA.Clear();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private bool existe(string Nombre)
        {
            foreach (Producto Producto in Producto.productos)
            {
                if (Producto.Nombre == Nombre) return true;
            }
            return false;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Producto miproducto = Producto.getproducto(txtNombreV.Text);
            if (miproducto == null)
            {
                errorProvider1.SetError(txtNombreV, "el producto no existe");
                txtNombreV.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreV, "");
            txtNombreV.Text = miproducto.Nombre;
            lblP.Text = miproducto.Precio.ToString();
            lblC.Text = miproducto.Stock.ToString();
            lblT.Text = miproducto.Tipo;
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtNombreC.Text == "")
            {
                errorProvider1.SetError(txtNombreC, "debe ingresar un nombre");
                txtNombreC.Focus();
                return;
            }
              errorProvider1.SetError(txtNombreC, "");
            if (!existe(txtNombreC.Text))
            {
                errorProvider1.SetError(txtNombreC, "El producto no existe");
                txtPrecioC.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreC, "");
            if (txtPrecioC.Text == "")
            {
                errorProvider1.SetError(txtPrecioC, "debe ingresar el precio, si no desea cambiarlo ingrese el mismo");
                txtPrecioC.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreC, "");
           

            decimal Precio;
            if (!Decimal.TryParse(txtPrecioC.Text, out Precio))
            {

                errorProvider1.SetError(txtPrecioC, "Debe ingresar numeros, si no desea cambiarlo ingrese el mismo");
                txtPrecioC.Focus();
                return;
            }
            if (Precio < 0)
            {

                errorProvider1.SetError(txtPrecioC, "Debe ingresar un valor positivo");
                txtPrecioC.Focus();
                return;
            }
            errorProvider1.SetError(txtPrecioC, "");

            decimal Stock;
            if (!Decimal.TryParse(txtCantidadC.Text, out Stock))
            {

                errorProvider1.SetError(txtCantidadC, "Debe ingresar numeros");
                txtCantidadC.Focus();
                return;
            }
            if (Precio < 0)
            {

                errorProvider1.SetError(txtCantidadC, "Debe ingresar un valor positivo");
                txtCantidadC.Focus();
                return;
            }
            errorProvider1.SetError(txtCantidadC, "");



            foreach (Producto miproducto in Producto.productos)
            {
                if (miproducto.Nombre == txtNombreC.Text)
                {
                    miproducto.Precio = Convert.ToDecimal( txtPrecioC.Text);
                    miproducto.Stock = Convert.ToDecimal(txtCantidadC.Text); 
                    miproducto.Tipo = txtTipoC.Text;
                    break;
                }
            }

            lista.DataSource = null;
            lista.DataSource = Producto.productos;

            txtNombreC.Clear();
            txtPrecioC.Clear();
            txtCantidadC.Clear();
            txtTipoC.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNombreB.Text == "")
            {
                errorProvider1.SetError(txtNombreB, "debe ingresar un nombre");
                txtNombreB.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreB, "");

            if (!existe(txtNombreB.Text))
            {
                errorProvider1.SetError(txtNombreB, "El producto no existe");
                txtPrecioC.Focus();
                return;
            }
            errorProvider1.SetError(txtNombreB, "");


            DialogResult rta = MessageBox.Show("esta seguro que desea eliminar producto?",
                "confirmacion", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.No) return;

            

            foreach(Producto miproducto in Producto.productos)
            {
                if(miproducto.Nombre == txtNombreB.Text)
                {
                    Producto.productos.Remove( miproducto);
                    break;
                }   
            }
            lista.DataSource = null;
            lista.DataSource = Producto.productos;

            txtNombreB.Clear();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Producto>));
            TextWriter escritor = new StreamWriter("Productos.xml");
            serializador.Serialize(escritor, Producto.productos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formulario = new Form2();
            formulario.Show();
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
