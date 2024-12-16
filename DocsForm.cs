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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class DocsForm : Form
    {
        public DocsForm()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;

        private void button1_Click(object sender, EventArgs e)
        {
            string docnumber = textBox1.Text;
            string idUser = textBox2.Text;
            string idClient = textBox3.Text;
            string date = textBox4.Text;
            string status = textBox5.Text;

            string query = "INSERT INTO Docs (w_docnumber, w_idUser, w_idClient, w_Date, w_Status) VALUES ('" + docnumber + "', '" + idUser + "', '" + idClient + "','" + date + "','" + status + "')";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
        }
    }
}
