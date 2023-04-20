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
    public partial class SignUp : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =D:\third\sixth_semester\УСП\movie\movie.mdb;
            Persist Security Info = False; ");
        Form1 form1;
        public SignUp()
        {
            InitializeComponent();
            BackColor = Color.AliceBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); // отваряне на връзката 
              
              //  OleDbCommand cmd1  = new OleDbCommand("Insert into Account (name, password, email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text +"')", conn);
                OleDbCommand cmd = new OleDbCommand("Insert into Account ([name], [password], [email]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                AddMovie add = new AddMovie();
                add.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
