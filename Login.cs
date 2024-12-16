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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;
        private void button1_Click(object sender, EventArgs e)
            {
             
                ClientForm clientForm = new ClientForm();
                clientForm.Show(this); 
            }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeForm EmployeeForm = new EmployeeForm();
            EmployeeForm.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DocsForm DocsForm = new DocsForm();
            DocsForm.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PoiskForm1 PoiskForm1 = new PoiskForm1();
            PoiskForm1.Show(this);
        }

    }
 }
    

