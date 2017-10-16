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


namespace PhoneBook
{
    public partial class PhoneBook : Form
    {
        // holds connection string in con
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Andy\Documents\Visual Studio 2017\Backup Files\PhoneBook\phonebookdatabase.mdf';Integrated Security = True; Connect Timeout = 30;");

        public PhoneBook()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PhoneBook_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1; 
            textBox1.Focus(); //focuses on textbox1 when the application is loaded
            display();
        }

     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // NEW BUTTON clears all textboxes and deselects dropdown menu
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;

            textBox1.Focus(); //focuses back on first textbox if new is clicked
        }

      

        void display() {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Contacts", con); //selects all data from contacts database
            DataTable dt = new DataTable(); //establishes new datatable
            sda.Fill(dt); //fills datatable with data from sda which included everything
            dataGridView1.Rows.Clear(); //clears the rows without clearing the columns in the datagridview
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add(); //adds each value to columns and when done that row proceeds to next row to fill in more columns
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e) //INSERT BUTTON
        {
            con.Open(); //opens connection to database
            SqlCommand cmd = new SqlCommand(@"  
                INSERT INTO contacts
                (FirstName,LastName,Mobile,Email,Category)
                VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", con);
            //inserts what is in the textboxes into the database 

            cmd.ExecuteNonQuery(); //executes sql command upon pressing insert
            con.Close(); //closes connection to database

            MessageBox.Show("Inserted!");
            display();
        }

        private void button4_Click(object sender, EventArgs e) //UPDATE BUTTON
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Contacts
            SET FirstName='" + textBox1.Text + "',LastName='" + textBox2.Text + "',Mobile='" + textBox3.Text + "',Email='" + textBox4.Text + "',Category='" + comboBox1.Text + "'WHERE (Mobile='" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            
            //inserts what is in the textboxes into the database 

            cmd.ExecuteNonQuery(); //executes sql command upon pressing button
            con.Close(); //closes connection to database

            MessageBox.Show("Updated!");
            display();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //populates box 1 with firstname from datagridview
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //populates box 2 with lastname from datagridview
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(); //populates box 3 with mobile # from datagrid view
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(); //populates box 4 with email from datagrid view
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//populates combobox1 with category from datagrid view
        }

        private void button3_Click(object sender, EventArgs e) //DELETE BUTTON
        {
            con.Open(); //opens connection to database
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Contacts WHERE (Mobile = '"+textBox3.Text+"')", con);
            //inserts what is in the textboxes into the database 

            cmd.ExecuteNonQuery(); //executes sql command upon pressing button
            con.Close(); //closes connection to database

            MessageBox.Show("Deleted!");
            display();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) // SEARCH BUTTON
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Contacts Where (Mobile like '%" + textBox5.Text + "%') or (FirstName like '%" + textBox5.Text + "%') or (LastName like '%" + textBox5.Text + "%') or (Email like '%" + textBox5.Text + "%') or (Category like '%" + textBox5.Text + "%')", con);
            DataTable dt = new DataTable(); //establishes new datatable
            sda.Fill(dt); //fills datatable with data from sda which included everything
            dataGridView1.Rows.Clear(); //clears the rows without clearing the columns in the datagridview
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add(); //adds each value to columns and when done that row proceeds to next row to fill in more columns
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }

        }
    }
}
