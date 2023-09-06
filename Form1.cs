using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TA3
{
    public partial class Form1 : Form
    {

        List<Datos> miDatos = new List<Datos>();
        

        public Form1()
        {
            InitializeComponent();
        }
   

    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text=="" || textBox5.Text =="")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

           
            string Nombre=textBox1.Text.Trim();
            string Id = textBox2.Text.Trim();
            string Dni = textBox4.Text.Trim();
            int Edad = int.Parse(textBox5.Text);
            
            Datos objeto = new Datos();
            objeto.Nombre = Nombre;
            objeto.Id = Id;
            objeto.Dni = Dni;
            objeto.Edad = Edad;


            ListViewItem item = new ListViewItem(objeto.Nombre);
            item.SubItems.Add(objeto.Id.ToString());
            item.SubItems.Add(objeto.Edad.ToString());
            item.SubItems.Add(objeto.Edad.ToString());
            listView1.Items.Add(item);

            miDatos.Add(objeto);
      
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregar columnas al ListView
            listView1.View = View.Details;
            listView1.Columns.Add("Columna 1");
            listView1.Columns.Add("Columna 2");
            listView1.Columns.Add("Columna 3");
            listView1.Columns.Add("Columna 4");
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            miDatos.RemoveAll(_ => true);
            MessageBox.Show("Todos los datos se van a borrado.");
            listView1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = miDatos.Count;
            MessageBox.Show("Cantidad de datos: " + count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ageToRemove = int.Parse(textBox5.Text);
            miDatos.RemoveAll(dato => dato.Edad == ageToRemove);
            listView1.Items.Clear();
            foreach (Datos dato in miDatos)
            {
                ListViewItem item = new ListViewItem(dato.Nombre);
                item.SubItems.Add(dato.Id.ToString());
                item.SubItems.Add(dato.Edad.ToString());
                item.SubItems.Add(dato.Dni);
                listView1.Items.Add(item);
            }

            MessageBox.Show("Se han eliminado los datos con la edad especificada.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //busca si el nombre que quieres agregar a datos existen o no existen
            string nombreBuscar = textBox1.Text.Trim();
            bool existe = miDatos.Exists(dato => dato.Nombre == nombreBuscar);
            if (existe)
            {
                MessageBox.Show("El nombre existe en los datos.");
            }
            else
            {
                MessageBox.Show("El nombre no existe en los datos.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //solo va a filtrar datos que tiene la misma edad y los que no tiene lo borra
            int edadFiltrar = int.Parse(textBox5.Text);
            List<Datos> datosFiltrados = miDatos.FindAll(dato => dato.Edad == edadFiltrar);
            listView1.Items.Clear();
            foreach (Datos dato in datosFiltrados)
            {
                ListViewItem item = new ListViewItem(dato.Nombre);
                item.SubItems.Add(dato.Id.ToString());
                item.SubItems.Add(dato.Edad.ToString());
                item.SubItems.Add(dato.Dni);
                listView1.Items.Add(item);
            }

            MessageBox.Show("Se han filtrado los datos por la edad especificada.");



        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Ordenar la lista por nombre y eliminar duplicados
            var datosOrdenados = miDatos.OrderBy(dato => dato.Nombre).Distinct().ToList();

            listView1.Items.Clear();
            foreach (Datos dato in datosOrdenados)
            {
                ListViewItem item = new ListViewItem(dato.Nombre);
                item.SubItems.Add(dato.Id.ToString());
                item.SubItems.Add(dato.Edad.ToString());
                item.SubItems.Add(dato.Dni);
                listView1.Items.Add(item);
            }

            MessageBox.Show("Se han ordenado los datos sin duplicandose.");

        }
    }


}






