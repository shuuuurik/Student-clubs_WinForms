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
    public partial class EnrollmentForm : Form
    {
        private string connectionString;
        private int studentId;

        private DataTable availableClubsTable;
        public EnrollmentForm()
        {
            InitializeComponent();
        }
        public EnrollmentForm(string connectionString, int studentId)
        {
            this.connectionString = connectionString;
            this.studentId = studentId;

            InitializeComponent();
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            // Заполнение DataGrid
            string sqlCommandDataGrid = "EXEC [FetchAvailableClubs] " + studentId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandDataGrid, connection);
                availableClubsTable = new DataTable();
                availableClubsGridView.DataSource = availableClubsTable;
                adapter.Fill(availableClubsTable);

                availableClubsGridView.Columns[0].Visible = false;

                availableClubsGridView.Columns[1].Width = 250;
                availableClubsGridView.Columns[1].HeaderText = "Название кружка";
                availableClubsGridView.Columns[1].ReadOnly = true;
            }
            //queryTextBox.Focus();
        }

        private void enrollmentButton_Click(object sender, EventArgs e)
        {
            // Получаем выбранные строки с кружками
            DataGridViewSelectedRowCollection selectedClubs = availableClubsGridView.SelectedRows;
            if (selectedClubs.Count == 0)
            {
                MessageBox.Show("Выберите строки кружков, чтобы записаться на них.", "Кружки не выбраны!");
                return;
            }
            //if (MessageBox.Show("Вы уверены, что хотите записаться на выбранные кружки? ", "",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            // Получаем id всех выбранных кружков для записи
            List<String> selectedClubIds = new List<String>();
            foreach (DataGridViewRow selectedClub in selectedClubs)
            {
                selectedClubIds.Add(selectedClub.Cells[0].Value.ToString());
            }
            // Добавляем студенту с studentId все кружки, id которых содержатся в selectedClubIds
            foreach (string selectedClubId in selectedClubIds)
            {
                string sqlCommand = "INSERT INTO STUDENT_CLUB VALUES (" + studentId + "," + selectedClubId + ");";
                // Выполнение SQL-запроса
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    (new SqlCommand(sqlCommand, connection)).ExecuteNonQuery();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            //}
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            queryTextBox.Text = "";
        }

        private void queryTextBox_TextChanged(object sender, EventArgs e)
        {
            // Заполнение DataGrid
            string queryString = queryTextBox.Text;
            string sqlCommandDataGrid;
            if (queryString == "")
            {
                sqlCommandDataGrid = "EXEC [FetchAvailableClubs] " + studentId;
            }
            else
            {
                sqlCommandDataGrid = "EXEC [FetchAvailableClubs] " + studentId + "," + queryString;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandDataGrid, connection);
                availableClubsTable.Clear();
                adapter.Fill(availableClubsTable);
            }
        }
    }
}
