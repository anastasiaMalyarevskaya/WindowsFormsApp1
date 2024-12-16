using System;
using System.Collections;
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

    public partial class PoiskForm1 : Form
    {
        public PoiskForm1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
            if (myConnection.State != ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string userInput1 = textBox1.Text.Trim();
            string userInput2 = textBox2.Text.Trim();
            string userInput3 = textBox3.Text.Trim();

            // Проверяем, что хотя бы одно текстовое поле заполнено
            if (string.IsNullOrEmpty(userInput1) && string.IsNullOrEmpty(userInput2) && string.IsNullOrEmpty(userInput3))
            {
                MessageBox.Show("Пожалуйста, введите хотя бы одно значение для поиска.");
                return;
            }

            // Создаем строку запроса
            string query = "SELECT * FROM Users WHERE 1=1";
            List<string> parameters = new List<string>();

            // Добавляем условия поиска в запрос в зависимости от заполненных текстовых полей
            if (!string.IsNullOrEmpty(userInput1))
            {
                query += " AND w_name = ?";
                parameters.Add(userInput1);
            }
            if (!string.IsNullOrEmpty(userInput2))
            {
                query += " AND w_idUser = ?";
                parameters.Add(userInput2);
            }
            if (!string.IsNullOrEmpty(userInput3))
            {
                query += " AND w_department = ?";
                parameters.Add(userInput3);
            }

            // Выполняем запрос для таблицы Users
            ExecuteQuery(query, parameters, "Users");

            // Выполняем аналогичный запрос для таблицы Clients
            query = "SELECT * FROM Clients WHERE 1=1";
            parameters.Clear();
            if (!string.IsNullOrEmpty(userInput1))
            {
                query += " AND w_name = ?";
                parameters.Add(userInput1);
            }
            if (!string.IsNullOrEmpty(userInput2))
            {
                query += " AND w_idClients = ?";
                parameters.Add(userInput2);
            }
            if (!string.IsNullOrEmpty(userInput3))
            {
                query += " AND w_work = ?";
                parameters.Add(userInput3);
            }
            ExecuteQuery(query, parameters, "Clients");

            // Выполняем аналогичный запрос для таблицы Docs
            query = "SELECT * FROM Docs WHERE 1=1";
            parameters.Clear();
            if (!string.IsNullOrEmpty(userInput1))
            {
                query += " AND w_Status = ?";
                parameters.Add(userInput1);
            }
            if (!string.IsNullOrEmpty(userInput2))
            {
                query += " AND w_docnumber = ?";
                parameters.Add(userInput2);
            }
            if (!string.IsNullOrEmpty(userInput3))
            {
                query += " AND w_id = ?";
                parameters.Add(userInput3);
            }
            ExecuteQuery(query, parameters, "Docs");
        }

        private void ExecuteQuery(string query, List<string> parameters, string tableName)
        {
            using (OleDbCommand command = new OleDbCommand(query, myConnection))
            {
                // Добавляем параметры в команду
                for (int i = 0; i < parameters.Count; i++)
                {
                    command.Parameters.AddWithValue("?", parameters[i]);
                }

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // Очищаем listBox перед выводом новых данных
                    listBox1.Items.Clear();
                    listBox1.Items.Add($"Результаты из таблицы {tableName}:");

                    while (reader.Read())
                    {
                        string result = reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString();
                        Console.WriteLine(result); // Отладочное сообщение
                        listBox1.Items.Add(result);
                    }
                }
            }
        }

        private void PoiskForm1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "workersDataSet4.Users". При необходимости она может быть перемещена или удалена.
            // this.usersTableAdapter3.Fill(this.workersDataSet4.Users);

        }
    }
 }
 