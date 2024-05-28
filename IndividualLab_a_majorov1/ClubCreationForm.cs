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

namespace IndividualLab_a_majorov1
{
    public partial class ClubCreationForm : Form
    {
        private string connectionString;

        private DataTable availableStudentsTable;
        public string SelectedStudentId { get; private set; } = "";
        public string EnteredClubTitle { get; private set; } = "";
        public ClubCreationForm()
        {
            InitializeComponent();
        }
        public ClubCreationForm(string connectionString)
        {
            this.connectionString = connectionString;

            InitializeComponent();
        }

        private void ClubCreationForm_Load(object sender, EventArgs e)
        {
            // Заполнение DataGrid
            string sqlCommandDataGrid = "SELECT * FROM STUDENT";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandDataGrid, connection);
                availableStudentsTable = new DataTable();
                availableStudentsGridView.DataSource = availableStudentsTable;
                adapter.Fill(availableStudentsTable);

                availableStudentsGridView.Columns[0].Visible = false;

                availableStudentsGridView.Columns[1].Width = 150;
                availableStudentsGridView.Columns[1].HeaderText = "Имя";
                availableStudentsGridView.Columns[1].ReadOnly = true;

                availableStudentsGridView.Columns[2].Width = 150;
                availableStudentsGridView.Columns[2].HeaderText = "Фамилия";
                availableStudentsGridView.Columns[2].ReadOnly = true;
            }
            thisClubExistsLabel.Text = "";
        }

        private void chooseHeadButton_Click(object sender, EventArgs e)
        {
            if (availableStudentsGridView.CurrentRow != null)
            {
                // Сохраняем Id выбранного ученика в открытом свойстве
                string selectedStudentId = availableStudentsGridView.CurrentRow.Cells[0].Value.ToString();
                this.SelectedStudentId = selectedStudentId;
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                MessageBox.Show("Выберите ученика, чтобы назначить его руководителем.", "Руководитель не выбран!");
                return;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            queryTextBox.Text = "";
        }

        private void queryTextBox_TextChanged(object sender, EventArgs e)
        {
            // Заполнение DataGrid
            string queryString = queryTextBox.Text;
            string sqlCommandDataGrid = "SELECT * FROM STUDENT WHERE Second_name LIKE '%" + queryString + "%'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandDataGrid, connection);
                availableStudentsTable.Clear();
                adapter.Fill(availableStudentsTable);
            }
        }

        private void createClubButton_Click(object sender, EventArgs e)
        {
            string clubTitle = clubTitleTextBox.Text;
            if (availableStudentsGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите ученика, чтобы назначить его руководителем.", "Руководитель не выбран!");
                return;
            }
            // Если название клуба не введено, то выводим соответствующее сообщение
            else if (clubTitle.Length == 0)
            {
                thisClubExistsLabel.Text = "Введите название кружка!";
            }
            else
            {
                string sqlFetchClubCommand = "SELECT Title FROM CLUB WHERE Title = '" + clubTitle + "'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataReader reader = (new SqlCommand(sqlFetchClubCommand, connection)).ExecuteReader();
                    reader.Read();
                    // Если нашлась строка (кружок в базе с таким же названием) - выводим соответствующее сообщение
                    if (reader.HasRows)
                    {
                        reader.Close();
                        thisClubExistsLabel.Text = "Клуб с таким названием уже существует!";
                    }
                    // Иначе сохраняем Id выбранного ученика и название кружка в открытых свойствах
                    else
                    {
                        reader.Close();
                        string selectedStudentId = availableStudentsGridView.CurrentRow.Cells[0].Value.ToString();
                        this.SelectedStudentId = selectedStudentId;
                        this.EnteredClubTitle = clubTitle;
                        this.DialogResult = DialogResult.Yes;
                    }
                }
            }
            
        }
    }
}
