using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sign_up
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-694JMRN;Initial Catalog=LoginDb;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void insert_button_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-694JMRN;Initial Catalog=LoginDb;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO RegistrationTbl ( f_name, l_name, gender, email, password) VALUES ( @f_name, @l_name, @gender, @email, @password)", connection);
                    command.Parameters.AddWithValue("@Id", Convert.ToInt32(ID_box.Text)); // Assuming Id is of type int
                    command.Parameters.AddWithValue("@f_name", first_name.Text);
                    command.Parameters.AddWithValue("@l_name", l_name.Text);
                    command.Parameters.AddWithValue("@gender", gender.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@password", password.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully inserted");
                    BindData();
                    clear();
                    // Assuming this method is defined elsewhere and binds data to dataGridView1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        void BindData()
        {

            try
            {
                using (SqlCommand command = new SqlCommand("select * from RegistrationTbl", connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dtbable = new DataTable();
                        sda.Fill(dtbable);
                        dataGridView1.DataSource = dtbable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (ID_box.Text != "")
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Delete RegistrationTbl where Id = '" + int.Parse(ID_box.Text) + " ' ", connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("successfully Deleted");
                BindData();
                clear();
            }
            else
            {
                MessageBox.Show(" ID please");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-694JMRN;Initial Catalog=LoginDb;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE RegistrationTbl  set  f_name = @f_name, l_name = @l_name, gender = @gender, email = @email, password = @password  WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@f_name", first_name.Text);
                   // command.Parameters.AddWithValue("@id", ID_box.Text);
                    command.Parameters.AddWithValue("@l_name", l_name.Text);
                    command.Parameters.AddWithValue("@gender", gender.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@password", password.Text);
                    command.Parameters.AddWithValue("@Id", int.Parse(ID_box.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated");
                    BindData();
                   // clear();
                    // Assuming this method is defined elsewhere and binds data to dataGridView1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand("Delete RegistrationTbl where Id = '" + int.Parse(ID_box.Text) + " ' ", connection);
                //  using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-694JMRN;Initial Catalog=LoginDb;Integrated Security=True"))
                SqlCommand command = new SqlCommand("select * from RegistrationTbl where Id = '" + int.Parse(ID_box.Text) + "'", connection);
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dtbable = new DataTable();
                        sda.Fill(dtbable);
                        dataGridView1.DataSource = dtbable;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                clear();
            }


        }
        void clear ()
        {
            ID_box.Clear();
            first_name.Clear();
            l_name.Clear();
            email.Clear();
            gender.Text = string.Empty;
            password.Clear();
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
          clear();
            BindData();
        }
    }
}
