using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace Sign_up
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //  SqlConnection connection = new SqlConnection("Data Source = DESKTOP - 694JMRN; Initial Catalog = LoginDb; Integrated Security = True");

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-694JMRN;Initial Catalog=LoginDb;Integrated Security=True");

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.UseSystemPasswordChar = false;

            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          string email, user_password;
            email = u_name.Text;
            user_password = password.Text;
            try
            {
                string querry = "SELECT * FROM RegistrationTbl WHERE email = '" + u_name.Text + "'AND password = '" + password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry ,connection  );
                DataTable dtbable = new DataTable();
                sda.Fill( dtbable );
                if (dtbable.Rows.Count > 0)
                {
                    email = u_name.Text;
                    user_password = password.Text;
                    menu mf = new menu();
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid login details", "error ", MessageBoxButtons.OK , MessageBoxIcon.Error);
                    u_name.Clear();
                    password.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Error!");

            }
            finally
            {
               connection.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
    

}
