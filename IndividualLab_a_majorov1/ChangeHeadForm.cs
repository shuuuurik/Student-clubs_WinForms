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
    public partial class ChangeHeadForm : Form
    {
        private string connectionString;
        private int clubId;
        private int headId;
        public string SelectedStudentId { get; private set; } = "";

        private DataTable availableStudentsTable;
        public ChangeHeadForm()
        {
            InitializeComponent();
        }
        public ChangeHeadForm(string connectionString, int clubId, int headId)
        {
            this.connectionString = connectionString;
            this.clubId = clubId;
            this.headId = headId;

            InitializeComponent();
        }

        private void ChangeHeadForm_Load(object sender, EventArgs e)
        {
            // Заполнение DataGrid
            string sqlCommandDataGrid = "EXEC [ListStudentsInClub] " + clubId;
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
        }

        private void chooseHeadButton_Click(object sender, EventArgs e)
        {
            if (availableStudentsGridView.CurrentRow != null)
            {
                string selectedStudentId = availableStudentsGridView.CurrentRow.Cells[0].Value.ToString();
                // Меняем Id руководителя у кружка
                string sqlUpdateCommand = "UPDATE CLUB SET SDT_Id = " + selectedStudentId +
                    " WHERE Id = " + clubId;
                // Новый руководитель исключается из числа участников кружка
                string sqlDeleteCommand = "DELETE FROM STUDENT_CLUB WHERE SDT_ID = " + selectedStudentId + " AND " +
                    "CLB_Id = " + clubId;

                // Сохраняем Id выбранного ученика в открытом свойстве
                this.SelectedStudentId = selectedStudentId;

                // Старый руководитель становится участником кружка
                string sqlInsertCommand = "INSERT INTO STUDENT_CLUB VALUES (" + headId + ", " + clubId + ")";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    (new SqlCommand(sqlUpdateCommand, connection)).ExecuteNonQuery();
                    (new SqlCommand(sqlDeleteCommand, connection)).ExecuteNonQuery();
                    (new SqlCommand(sqlInsertCommand, connection)).ExecuteNonQuery();
                    this.DialogResult = DialogResult.Yes;
                }
            }
            else
            {
                MessageBox.Show("Выберите ученика, чтобы назначить его новым руководителем.", "Руководитель не выбран!");
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
            string sqlCommandDataGrid = "EXEC [ListStudentsInClub] " + clubId + ", '" + queryString + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandDataGrid, connection);
                availableStudentsTable.Clear();
                adapter.Fill(availableStudentsTable);
            }
        }
    }
}
