using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System;
using System.Globalization;

namespace movie
{
    public partial class AddMovie : Form
    {
        Form1 form1;
        OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =D:\third\sixth_semester\УСП\movie\movie.mdb;
            Persist Security Info = False; ");

        public AddMovie()
        {

            InitializeComponent();
            BackColor = Color.AliceBlue;
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void AddMovie_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd1 = new OleDbCommand("Insert into Movies (Title, ReleaseDate, Genre, Duration) values ('" +
                  textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
                // cmd.CommandText = "Update Rooms set capacity=capacity-1 where IDroom='" + textBox3.Text + "'";
                cmd1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("The movie is added successfully!");
                // Form2_Load(sender, e);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
               
                conn.Open();
               
                OleDbCommand cmd1 = new OleDbCommand("Select Title from Movies where Genre = '" + textBox5.Text + "'", conn);
                OleDbDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {

                    listBox1.Items.Add(reader["Title"].ToString());

                }
               
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            try
            {
                conn.Open();
                OleDbCommand cmd1 = new OleDbCommand("Select Title from Movies where ReleaseDate = '" + textBox6.Text + "'", conn);
                OleDbDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {

                    listBox2.Items.Add(reader["Title"].ToString());

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
