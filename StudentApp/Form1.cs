using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class studentForm : Form
    {
        public studentForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailAddresstextBox.Text;
            string address = addressTextBox.Text;
            string phone = phoneNumbertextBox.Text;
            string connectingString =
                @"Data Source = LICT\SQLEXPRESS; Database = StudentDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            string query = "INSERT INTO sTable VALUES ('"+ name +"', '"+email +"','" + address + "' , '" + phone + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void studentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
