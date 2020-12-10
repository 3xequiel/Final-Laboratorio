using System;
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
    public partial class Form2 : Form
    {
        List<Producto> productos = new List<Producto>();
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Producto>));
            FileStream lector = File.OpenRead("Productos.xml");
            productos = (List<Producto>)serializador.Deserialize(lector);
            lector.Close();
            lista2.DataSource = productos;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Producto>));
            TextWriter escritor = new StreamWriter("Productos.xml");
            serializador.Serialize(escritor, productos);
            escritor.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal Compra = 0;
            if (!Producto.existe(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El producto no existe");
                txtNombre.Focus();
                return;
            }
            errorProvider1.SetError(txtNombre, "");
           
            foreach (Producto miproducto in productos)
            {
               

                if (miproducto.Nombre == txtNombre.Text)
                {
                    if (miproducto.Stock - Convert.ToInt32(txtCantidad.Text) < 0)
                    {
                        errorProvider1.SetError(txtCantidad, "Stock insuficiente");
                        txtCantidad.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtCantidad, "");
                }
                        Compra = miproducto.Precio * Convert.ToInt32(txtCantidad.Text);
                    miproducto.Stock= miproducto.Stock - Convert.ToInt32(txtCantidad.Text);


                    break;
                    MessageBox.Show("su compra es de: $" + Compra, "Compra realizada");
                    lista2.DataSource = null;
                    lista2.DataSource = productos;
                }
                
            }
           
        }

       
    }

