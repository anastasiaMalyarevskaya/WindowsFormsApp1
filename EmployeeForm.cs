using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class EmployeeForm : Form
    {
        private PoiskForm1 PoiskForm1;

        public EmployeeForm()
        {
            InitializeComponent();
            PoiskForm1 = new PoiskForm1();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;
            string department = textBox5.Text;
            string query = "INSERT INTO Users (w_name, w_surname,w_phonenumber, w_email, w_department) VALUES ('" + name + "', '" + surname + "', '" + phone + "','" + email + "','" + department + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
    }
}
