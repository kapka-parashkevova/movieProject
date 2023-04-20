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
namespace movie
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
             textBox2.PasswordChar = "*";
            // this.BackColor = Color.FromArgb(255, 232, 232); // this should be pink-ish'
            BackColor = Color.AliceBlue;
            conn.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =D:\third\sixth_semester\УСП\movie\movie.mdb;
            Persist Security Info = False; ";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // sign in button
        {
            try
            {
                conn.Open(); // отваряне на връзката 
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Account where name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                OleDbDataReader or = cmd.ExecuteReader(); //Изпраща CommandText към връзката и изгражда OleDbDataReader
                int count = 0;
                while (or.Read()) // чете се резултата от заявката 
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("LOGIN SUCCESSFUL!!!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                   AddMovie add = new AddMovie();
                   add.ShowDialog();
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }
    }
}
