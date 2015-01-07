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
using System.Windows.Forms.VisualStyles;

namespace StudentApp
{
    public partial class ViewUI : Form
    {
        public ViewUI()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        private void searchButton_Click(object sender, EventArgs e)
        {
           
            string id = idTextBox.Text;
            string connectingString = 
                @"Data Source = LICT\SQLEXPRESS; Database = StudentDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            string query = "SELECT *FROM sTable";
            
                if (id != "")
                {
                    query = "SELECT *FROM sTable WHERE ID = '" + id + "'";

                }
                
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                listView.Items.Clear();
            students.Clear();
            while (reader.Read())
            {
                Student student = new Student();
                student.id = (int) reader["ID"];
                student.name = reader["Name"].ToString();
                student.email = reader["EmailAddress"].ToString();
                student.address = reader["Address"].ToString();
                student.phoneNumber = reader["PhoneNumber"].ToString();
                students.Add(student);
            }
            foreach (Student student1 in students)
            {
                ListViewItem myView = new ListViewItem();
                myView.Text = student1.id.ToString();
                myView.SubItems.Add(student1.name);
                myView.SubItems.Add(student1.email);
                myView.SubItems.Add(student1.address);
                myView.SubItems.Add(student1.phoneNumber);
                myView.Tag = student1;
                listView.Items.Add(myView);
            }
            connection.Close();


            
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectItem = listView.SelectedItems[0];
            Student selectedStudent = (Student) selectItem.Tag;
            idShowTextBox.Text = selectedStudent.id.ToString();
            nameTextBox.Text = selectedStudent.name;
            emailAddresstextBox.Text = selectedStudent.email;
            addressTextBox.Text = selectedStudent.address;
            phoneNumbertextBox.Text = selectedStudent.phoneNumber;

        }

        private void ViewUI_Load(object sender, EventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailAddresstextBox.Text;
            string address = addressTextBox.Text;
            string phone = phoneNumbertextBox.Text;
            string connectingString =
                @"Data Source = LICT\SQLEXPRESS; Database = StudentDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            string query = "UPDATE sTable SET Name '"+name +" , Email Address '"+email+ "', Address '" + address + "' , Phone Number '" + phone + "' WHERE ID '"+idShowTextBox.Text+"')";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            students.Clear();
            connection.Close();
        }
    }
}
