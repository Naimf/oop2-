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



namespace Sign_up
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection ("Data Source=DESKTOP-694JMRN;Initial Catalog=LoginDb;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (first_name.Text!= "" && l_name.Text!="" && gender.Text!="" && email.Text!="" &&
                    password.Text!="" && con_password.Text!= "" )
                {
                    if (password.Text==con_password.Text)
                    {
                        int v = check(email.Text);
                        if (v !=1 )
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("INSERT INTO RegistrationTbl (f_name, l_name, gender, email, password) VALUES (@f_name, @l_name, @gender, @email, @password)", connection);

                            // SqlCommand command = new SqlCommand("INSERT INTO RegistrationTbl (f_name, l_name, gender, email, password) VALUES (@f_name, @l_name, @gender, @email, @password)", connection);
                            command.Parameters.AddWithValue("@f_name", first_name.Text);
                            command.Parameters.AddWithValue("@l_name", l_name.Text);
                            command.Parameters.AddWithValue("@gender", gender.Text);
                            command.Parameters.AddWithValue("@email", email.Text);
                            command.Parameters.AddWithValue("@password", password.Text);
                            command.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Registration Successful !");
                            clear();
                            first_name.Text = "";
                            l_name.Text = "";
                            gender.Text = "";
                            password.Text = "";
                            con_password.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("You are already Registered");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't match .");

                    }
                }
                else
                {
                    MessageBox.Show("Fill the blanks.");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int check (string email)
        {
            connection.Open ();
            string query =  "select count (*) from RegistrationTbl where email = '" + email + "'";
            SqlCommand command = new SqlCommand (query, connection);
            int v= (int)command.ExecuteScalar ();
            connection.Close ();
            return v;
        }

        private void check_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pass.Checked)
            {
                password.UseSystemPasswordChar = false ;
                con_password.UseSystemPasswordChar= false ;
            }
            else
            {
                password.UseSystemPasswordChar = true;
                con_password.UseSystemPasswordChar = true ;

            }
        }

        void clear()
        {
            
            first_name.Clear();
            l_name.Clear();
            email.Clear();
            gender.Text = string.Empty;
            password.Clear();
            con_password.Clear();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void con_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void l_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void first_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
