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

namespace WindowsFormsApp1
{


    public partial class ClientForm : Form
    {
        private PoiskForm1 PoiskForm1;

        public ClientForm()
        {
            InitializeComponent();
            PoiskForm1 = new PoiskForm1();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string name  = textBox1.Text;
            string surname = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;
            string work = textBox5.Text;
            string query = "INSERT INTO Clients (w_name, w_surname, w_phonenumber,  w_email, w_work) VALUES ('" + name + "', '" + surname + "', '" + phone + "','" + email + "','" + work + "')";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
        }
    }
}
