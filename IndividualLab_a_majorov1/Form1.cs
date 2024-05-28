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
using System.Globalization;

namespace IndividualLab_a_majorov1
{
    public partial class Form1 : Form
    {
        private DataTable studentClubsTable = new DataTable();
        private DataTable clubParticipantsTable = new DataTable();
        private DataTable managedClubsTable = new DataTable();
        private DataTable managedStudentsTable = new DataTable();

        public Form1()
        {
            //studentClubsTable.Columns[1].ColumnName = "Название кружка";
            //clubParticipantsTable.Columns[1].ColumnName = "Имя";
            //clubParticipantsTable.Columns[2].ColumnName = "Фамилия";
            //managedClubsTable.Columns[0].ColumnName = "Название кружка";
            //managedStudentsTable.Columns[0].ColumnName = "Имя";
            //managedStudentsTable.Columns[1].ColumnName = "Фамилия";

            InitializeComponent();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.sTUDENTBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.mAYOROV_LABDataSet);
                studentChangesNotSavedLabel.Text = "";
                openEnrollmentFormButton.Enabled = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Вы не можете удалить студента, который руководит кружком",
                    ex.GetType().ToString());
            }
            repairDataGridViewHeaders();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (studentGridView.CurrentCell != null)
            {
                studentGridView.CurrentCell.Selected = true;
            }
            bindingNavigatorAddNewItem.Enabled = true;
            studentBindingNavigatorSaveItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mAYOROV_LABDataSet.CLUB' table. You can move, or remove it, as needed.
            this.cLUBTableAdapter.Fill(this.mAYOROV_LABDataSet.CLUB);
            // TODO: This line of code loads data into the 'mAYOROV_LABDataSet.STUDENT' table. You can move, or remove it, as needed.
            this.sTUDENTTableAdapter.Fill(this.mAYOROV_LABDataSet.STUDENT);

            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            studentGridView.Columns[0].Visible = false;
            clubGridView.Columns[0].Visible = false;
            clubGridView.Columns[2].Visible = false;
            headGridView.Columns[0].Visible = false;

            studentClubsGridView.DataSource = studentClubsTable;

            clubParticipantsGridView.DataSource = clubParticipantsTable;

            headLabel.Text = "";
            studentChangesNotSavedLabel.Text = "";
            clubChangesNotSavedLabel.Text = "";

            managedClubsGridView.DataSource = managedClubsTable;
            managedStudentsGridView.DataSource = managedStudentsTable;

            repairDataGridViewHeaders();
        }

        private void studentGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Посмотреть список кружков выбранного студента
            // Формируем SQL-запрос
            if (studentGridView.CurrentRow != null && (int)studentGridView.CurrentRow.Cells[0].Value > 0)
            {
                string sid = studentGridView.CurrentRow.Cells[0].Value.ToString();
                string sqlCommand = "SELECT [CLUB].Id, [CLUB].Title FROM STUDENT_CLUB scb " +
                    "INNER JOIN CLUB ON CLB_Id = [CLUB].Id " +
                    "WHERE [scb].SDT_Id = " + sid;
                string connectionString = sTUDENTTableAdapter.Connection.ConnectionString;
                // Выполнение SQL-запроса
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                    studentClubsTable.Clear();
                    adapter.Fill(studentClubsTable);
                }
                if (studentClubsTable.Rows.Count == 0)
                {
                    leaveButton.Enabled = false;
                }
                else
                {
                    leaveButton.Enabled = true;
                }
                openEnrollmentFormButton.Enabled = true;
                studentChangesNotSavedLabel.Text = "";
            }
            else
            {
                studentClubsTable.Clear();
                openEnrollmentFormButton.Enabled = false;
                leaveButton.Enabled = false;
                studentChangesNotSavedLabel.Text = "Сохраните изменения!";
            }
            repairDataGridViewHeaders();
        }
        // Если в строке есть null-значения, то заблокировать доступ к кнопкам перемещения, сохранения и добавления
        private void studentGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = studentGridView.Rows[e.RowIndex];   // текущая строка
            for (int i = 1; i <= 2; ++i)
            {
                if (row.Cells[i].Value == null)
                {
                    studentBindingNavigatorSaveItem.Enabled = false;
                    bindingNavigatorAddNewItem.Enabled = false;
                    bindingNavigatorMovePreviousItem.Enabled = false;
                    bindingNavigatorMoveFirstItem.Enabled = false;
                    bindingNavigatorMoveNextItem.Enabled = false;
                    bindingNavigatorMoveLastItem.Enabled = false;
                    return;
                }
            }
        }

        // При добавлении новой строки также блокируем доступ к кнопкам перемещения, сохранения и добавления
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            studentGridView.Focus();
            studentBindingNavigatorSaveItem.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
        }


        private void studentGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Проверяем, существует ли строка
            string str_count = bindingNavigatorCountItem.Text;
            string str_number = str_count.Substring(str_count.IndexOf(' '));
            if (e.RowIndex >= int.Parse(str_number))
            {
                e.Cancel = false;
                studentBindingNavigatorSaveItem.Enabled = true;
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;
                return;
            }

            DataGridViewRow row = studentGridView.Rows[e.RowIndex];  // текущая строка
            // ячейка First_name в текущей строке
            DataGridViewCell nameCell = row.Cells[1];
            // ячейка Second_name в текущей строке
            DataGridViewCell surnameCell = row.Cells[2];

            studentBindingNavigatorSaveItem.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;

            // значение в ячейке First_name пусто
            if (nameCell.Value == null || nameCell.Value.ToString().Length == 0) 
            {
                nameCell.ErrorText = "Заполните имя";  // метка в ячейке First_name
                row.ErrorText = "Заполните имя";  // метка в ошибочной строке
                e.Cancel = true;  // запрет ухода из строки
            }
            // значение в ячейке Second_name пусто
            else if (surnameCell.Value == null || surnameCell.Value.ToString().Length == 0) 
            {
                surnameCell.ErrorText = "Заполните фамилию";  // метка в ячейке Second_name
                row.ErrorText = "Заполните фамилию";  // метка в ошибочной строке
                e.Cancel = true;  // запрет ухода из строки
            }
            else
            {
                nameCell.ErrorText = "";  // метка в ячейке First_name
                surnameCell.ErrorText = "";  // метка в ячейке Second_name
                row.ErrorText = "";  // метка в ошибочной строке
                studentBindingNavigatorSaveItem.Enabled = true;
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;

                e.Cancel = false;
            }
            repairDataGridViewHeaders();
        }
        private void leaveButton_Click(object sender, EventArgs e)
        {
            // Получаем id выбранного студента
            string selectedStudentId;
            if (studentGridView.CurrentRow != null)
            {
                selectedStudentId = studentGridView.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                return;
            }
            // Получаем выбранные строки с кружками
            DataGridViewSelectedRowCollection selectedClubs = studentClubsGridView.SelectedRows;
            if (selectedClubs.Count == 0)
            {
                MessageBox.Show("Выберите строки кружков, чтобы покинуть их.", "Кружки не выбраны!");
                return;
            }
            if (MessageBox.Show("Вы уверены, что хотите покинуть выбранные кружки? ", "Уход из кружков",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Получаем id всех выбранных кружков для удаления
                List<String> selectedClubIds = new List<String>();
                foreach (DataGridViewRow selectedClub in selectedClubs)
                {
                    selectedClubIds.Add(selectedClub.Cells[0].Value.ToString());
                }
                // Удаляем у студента с selectedStudentId все кружки, id которых содержатся в selectedClubIds
                foreach (string selectedClubId in selectedClubIds)
                {
                    string sqlCommand = "DELETE FROM STUDENT_CLUB WHERE SDT_Id = " + selectedStudentId +
                        " AND CLB_Id = " + selectedClubId;
                    // Выполнение SQL-запроса
                    string connectionString = sTUDENTTableAdapter.Connection.ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        (new SqlCommand(sqlCommand, connection)).ExecuteNonQuery();
                        // Имитируем нажатие на выбранную ячейку в studentGridView, чтобы обновилась studentClubsGridView
                        studentGridView.CurrentCell.Selected = true;
                    }
                }
            }
        }

        private void openEnrollmentFormButton_Click(object sender, EventArgs e)
        {
            // Открываем форму записи на кружки для текущего студента
            string connectionString = sTUDENTTableAdapter.Connection.ConnectionString;
            int studentId = (int)studentGridView.CurrentRow.Cells[0].Value;
            Form enrollmentForm = new EnrollmentForm(connectionString, studentId);
            enrollmentForm.ShowDialog();
            // Имитируем нажатие на выбранную ячейку в studentGridView, чтобы обновилась studentClubsGridView
            studentGridView.CurrentCell.Selected = true;

            repairDataGridViewHeaders();
        }
        private void clubBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.cLUBBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.mAYOROV_LABDataSet);
                clubChangesNotSavedLabel.Text = "";
                // Имитируем нажатие на выбранную ячейку в clubGridView, чтобы обновилась headLabel
                if (clubGridView.CurrentCell != null)
                {
                    clubGridView.CurrentCell.Selected = true;
                }
            }
            // Данное исключение выбрасывается, когда мы удаляем и создаем кружок с одним названием, после
            // чего нажимаем на кнопку "Сохранить"
            catch (SqlException)
            {
                // Выполняем сохранение в ручном режиме
                DataGridViewRowCollection clubRows = clubGridView.Rows;
                foreach (DataGridViewRow row in clubRows)
                {
                    // Проверяем, есть ли в базе кружки, которые содержатся в несохранненных строках clubGridView
                    if ((int)row.Cells[0].Value < 0)
                    {
                        string rowTitle = row.Cells[1].Value.ToString();
                        string rowHeadId = row.Cells[2].Value.ToString();
                        string connectionString = cLUBTableAdapter.Connection.ConnectionString;
                        string sqlFetchClubCommand = "SELECT Title FROM Club WHERE Title = '" + rowTitle + "'";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlDataReader reader = (new SqlCommand(sqlFetchClubCommand, connection)).ExecuteReader();
                            reader.Read();
                            // Если нашлась строка (кружок в базе с таким же названием) - изменяем Id руководителя
                            if (reader.HasRows)
                            {
                                reader.Close();
                                string sqlUpdateCommand = "UPDATE Club SET SDT_Id = " + rowHeadId + " " +
                                    "WHERE Title = '" + rowTitle + "'";
                                (new SqlCommand(sqlUpdateCommand, connection)).ExecuteNonQuery();
                            }
                            // Иначе добавляем новый кружок в базу
                            else
                            {
                                reader.Close();
                                string sqlInsertCommand = "INSERT INTO Club (Title, SDT_Id) " +
                                    "VALUES ( '" + rowTitle + "', " + rowHeadId + ")";
                                (new SqlCommand(sqlInsertCommand, connection)).ExecuteNonQuery();
                            }
                        }
                    }
                }
                // Имитируем нажатие на выбранную ячейку в clubGridView, чтобы обновилась headLabel
                int rowIndex = clubGridView.CurrentCell.RowIndex;
                int columnIndex = clubGridView.CurrentCell.ColumnIndex;

                this.cLUBTableAdapter.Fill(this.mAYOROV_LABDataSet.CLUB); // заполняем таблицу обновленными данными

                clubGridView.CurrentCell = clubGridView[columnIndex, rowIndex];
                clubGridView.Rows[rowIndex].Cells[columnIndex].Selected = true;
            }
            repairDataGridViewHeaders();
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            if (clubGridView.CurrentCell != null)
            {
                clubGridView.CurrentCell.Selected = true;
            }
            bindingNavigatorAddNewItem1.Enabled = true;
            clubBindingNavigatorSaveItem.Enabled = true;
        }

        private void clubGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (clubGridView.CurrentRow != null && (int)clubGridView.CurrentRow.Cells[0].Value >= 0)
            {
                string sid = clubGridView.CurrentRow.Cells[0].Value.ToString();
                // Отобразить руководителя выбранного кружка
                // Формируем SQL-запрос
                string sqlFetchCommand = "SELECT First_name, Second_name FROM STUDENT s " +
                    "INNER JOIN CLUB c ON s.Id = c.SDT_Id " +
                    "WHERE c.Id = " + sid;
                // Отобразить список учеников выбранного кружка
                // Формируем SQL-запрос
                string sqlListCommand = "EXEC [ListStudentsInClub] " + sid;
                string connectionString = cLUBTableAdapter.Connection.ConnectionString;
                // Выполнение SQL-запросов
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataReader reader = (new SqlCommand(sqlFetchCommand, connection)).ExecuteReader();
                    reader.Read();
                    headLabel.Text = reader.GetString(0) + " " + reader.GetString(1);
                    reader.Close();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlListCommand, connection);
                    clubParticipantsTable.Clear();
                    adapter.Fill(clubParticipantsTable);
                }
                if (clubParticipantsTable.Rows.Count == 0)
                {
                    openChangeHeadFormButton.Enabled = false;
                }
                else
                {
                    openChangeHeadFormButton.Enabled = true;
                }
                headLabel.ForeColor = SystemColors.ControlText;
                clubChangesNotSavedLabel.Text = "";
            }
            else
            {
                clubParticipantsTable.Clear();
                openChangeHeadFormButton.Enabled = false;
                headLabel.Text = "не найден";
                headLabel.ForeColor = Color.Red;
                clubChangesNotSavedLabel.Text = "Сохраните изменения!";
            }
            repairDataGridViewHeaders();
        }

        // Если в строке есть null-значения, то заблокировать доступ к кнопкам перемещения, сохранения и добавления
        private void clubGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = clubGridView.Rows[e.RowIndex];   // текущая строка
            if (row.Cells[1].Value == null)
            {
                clubBindingNavigatorSaveItem.Enabled = false;
                bindingNavigatorAddNewItem1.Enabled = false;
                bindingNavigatorMovePreviousItem1.Enabled = false;
                bindingNavigatorMoveFirstItem1.Enabled = false;
                bindingNavigatorMoveNextItem1.Enabled = false;
                bindingNavigatorMoveLastItem1.Enabled = false;
                return;
            }
        }

        private void clubGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Проверяем, существует ли строка
            string str_count = bindingNavigatorCountItem1.Text;
            string str_number = str_count.Substring(str_count.IndexOf(' '));
            if (e.RowIndex >= int.Parse(str_number))
            {
                e.Cancel = false;
                clubBindingNavigatorSaveItem.Enabled = true;
                bindingNavigatorAddNewItem1.Enabled = true;
                bindingNavigatorMovePreviousItem1.Enabled = true;
                bindingNavigatorMoveFirstItem1.Enabled = true;
                bindingNavigatorMoveNextItem1.Enabled = true;
                bindingNavigatorMoveLastItem1.Enabled = true;
                return;
            }

            DataGridViewRow currentRow = clubGridView.Rows[e.RowIndex];  // текущая строка
            // ячейка Title в текущей строке
            DataGridViewCell titleCell = currentRow.Cells[1];

            clubBindingNavigatorSaveItem.Enabled = false;
            bindingNavigatorAddNewItem1.Enabled = false;
            bindingNavigatorMoveFirstItem1.Enabled = false;
            bindingNavigatorMovePreviousItem1.Enabled = false;
            bindingNavigatorMoveNextItem1.Enabled = false;
            bindingNavigatorMoveLastItem1.Enabled = false;

            // значение в ячейке Title пусто
            if (titleCell.Value == null || titleCell.Value.ToString().Length == 0) 
            {
                titleCell.ErrorText = "Заполните название";  // метка в ячейке Title
                currentRow.ErrorText = "Заполните название";  // метка в ошибочной строке
                e.Cancel = true;  // запрет ухода из строки
            }
            else
            {
                foreach (DataGridViewRow row in clubGridView.Rows)
                {
                    if (row.Index != currentRow.Index && 
                        row.Cells[1].Value.ToString() == currentRow.Cells[1].Value.ToString())
                    {
                        titleCell.ErrorText = "Название должно быть уникальным";  // метка в ячейке Title
                        currentRow.ErrorText = "Название должно быть уникальным";  // метка в ошибочной строке
                        e.Cancel = true;  // запрет ухода из строки
                        return;
                    }
                }
                titleCell.ErrorText = "";  // метка в ячейке Title
                currentRow.ErrorText = "";  // метка в ошибочной строке
                clubBindingNavigatorSaveItem.Enabled = true;
                bindingNavigatorAddNewItem1.Enabled = true;
                bindingNavigatorMoveFirstItem1.Enabled = true;
                bindingNavigatorMovePreviousItem1.Enabled = true;
                bindingNavigatorMoveNextItem1.Enabled = true;
                bindingNavigatorMoveLastItem1.Enabled = true;

                e.Cancel = false;
            }
            repairDataGridViewHeaders();
        }

        // При добавлении новой строки также блокируем доступ к кнопкам перемещения, сохранения и добавления
        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            clubGridView.Focus();
            clubBindingNavigatorSaveItem.Enabled = false;
            bindingNavigatorAddNewItem1.Enabled = false;
            bindingNavigatorMovePreviousItem1.Enabled = false;
            bindingNavigatorMoveFirstItem1.Enabled = false;
            bindingNavigatorMoveNextItem1.Enabled = false;
            bindingNavigatorMoveLastItem1.Enabled = false;

            string connectionString = cLUBTableAdapter.Connection.ConnectionString;
            ClubCreationForm clubCreationForm = new ClubCreationForm(connectionString);
            DialogResult result = clubCreationForm.ShowDialog();
            if (result == DialogResult.Yes)
            {
                string enteredClubTitle = clubCreationForm.EnteredClubTitle;
                clubGridView.CurrentRow.Cells[1].Value = enteredClubTitle;
                string selectedStudentId = clubCreationForm.SelectedStudentId;
                clubGridView.CurrentRow.Cells[2].Value = selectedStudentId;
                Validate();
            }
            else
            {
                clubGridView.Rows.RemoveAt(clubGridView.CurrentCell.RowIndex);
                bindingNavigatorDeleteItem1_Click(sender, e);
            }
        }

        private void openChangeHeadFormButton_Click(object sender, EventArgs e)
        {
            // Открываем форму смены руководителя текущего кружка
            string connectionString = cLUBTableAdapter.Connection.ConnectionString;
            int clubId = (int)clubGridView.CurrentRow.Cells[0].Value;
            int headId = (int)clubGridView.CurrentRow.Cells[2].Value;
            ChangeHeadForm changeHeadForm = new ChangeHeadForm(connectionString, clubId, headId);
            DialogResult result = changeHeadForm.ShowDialog();
            if (result == DialogResult.Yes)
            {
                // Сохраняем все изменения из таблицы clubGridView в базу
                clubBindingNavigatorSaveItem_Click(sender, e);

                // Имитируем нажатие на выбранную ячейку в clubGridView, чтобы обновилась headLabel
                int rowIndex = clubGridView.CurrentCell.RowIndex;
                int columnIndex = clubGridView.CurrentCell.ColumnIndex;
                this.cLUBTableAdapter.Fill(this.mAYOROV_LABDataSet.CLUB); // заполняем таблицу обновленными данными
                clubGridView.CurrentCell = clubGridView[columnIndex, rowIndex];
                clubGridView.Rows[rowIndex].Cells[columnIndex].Selected = true;
            }
            repairDataGridViewHeaders();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            if (page.Name == "clubs" && clubGridView.CurrentCell != null)
            {
                studentBindingNavigatorSaveItem_Click(sender, e);
                clubGridView.CurrentCell.Selected = true;
            }
            if (page.Name == "students" && studentGridView.CurrentCell != null)
            {
                clubBindingNavigatorSaveItem_Click(sender, e);
                studentGridView.CurrentCell.Selected = true;
            }
            if (page.Name == "heads" && headGridView.CurrentCell != null)
            {
                clubBindingNavigatorSaveItem_Click(sender, e);
                headGridView.CurrentCell.Selected = true;
            }
            repairDataGridViewHeaders();
        }

        private void bindingNavigatorDeleteItem2_Click(object sender, EventArgs e)
        {
            if (headGridView.CurrentCell != null)
            {
                headGridView.CurrentCell.Selected = true;
            }
        }

        private void headGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (headGridView.CurrentRow != null && (int)headGridView.CurrentRow.Cells[0].Value >= 0)
            {
                string sid = headGridView.CurrentRow.Cells[0].Value.ToString();
                // Отобразить кружки, возглавляемые выбранным студентом
                // Формируем SQL-запрос
                string sqlFetchClubsCommand = "SELECT Title FROM CLUB WHERE SDT_Id = " + sid;
                // Отобразить список учеников выбранного студента
                // Формируем SQL-запрос
                string sqlFetchStudentsCommand = "EXEC [FetchManagedStudents] " + sid;
                string connectionString = cLUBTableAdapter.Connection.ConnectionString;
                // Выполнение SQL-запросов
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlFetchClubsCommand, connection);
                    managedClubsTable.Clear();
                    adapter.Fill(managedClubsTable);
                    adapter = new SqlDataAdapter(sqlFetchStudentsCommand, connection);
                    managedStudentsTable.Clear();
                    adapter.Fill(managedStudentsTable);
                }
                if (managedClubsTable.Rows.Count == 0)
                {
                    bindingNavigatorDeleteItem.Enabled = true;
                    bindingNavigatorDeleteItem2.Enabled = true;
                }
                else
                {
                    bindingNavigatorDeleteItem.Enabled = false;
                    bindingNavigatorDeleteItem2.Enabled = false;
                }
            }
            else
            {
                managedClubsTable.Clear();
                managedStudentsTable.Clear();
                bindingNavigatorDeleteItem.Enabled = true;
                bindingNavigatorDeleteItem2.Enabled = true;
            }
            repairDataGridViewHeaders();
        }

        // Если в строке есть null-значения, то заблокировать доступ к кнопкам перемещения, сохранения и добавления
        private void headGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = headGridView.Rows[e.RowIndex];   // текущая строка
            for (int i = 1; i <= 2; ++i)
            {
                if (row.Cells[i].Value == null)
                {
                    headBindingNavigatorSaveItem.Enabled = false;
                    bindingNavigatorAddNewItem2.Enabled = false;
                    bindingNavigatorMovePreviousItem2.Enabled = false;
                    bindingNavigatorMoveFirstItem2.Enabled = false;
                    bindingNavigatorMoveNextItem2.Enabled = false;
                    bindingNavigatorMoveLastItem2.Enabled = false;
                    return;
                }
            }
        }
        // При добавлении новой строки также блокируем доступ к кнопкам перемещения, сохранения и добавления
        private void bindingNavigatorAddNewItem2_Click(object sender, EventArgs e)
        {
            headGridView.Focus();
            headBindingNavigatorSaveItem.Enabled = false;
            bindingNavigatorAddNewItem2.Enabled = false;
            bindingNavigatorMovePreviousItem2.Enabled = false;
            bindingNavigatorMoveFirstItem2.Enabled = false;
            bindingNavigatorMoveNextItem2.Enabled = false;
            bindingNavigatorMoveLastItem2.Enabled = false;
        }

        private void headGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Проверяем, существует ли строка
            string str_count = bindingNavigatorCountItem2.Text;
            string str_number = str_count.Substring(str_count.IndexOf(' '));
            if (e.RowIndex >= int.Parse(str_number))
            {
                e.Cancel = false;
                headBindingNavigatorSaveItem.Enabled = true;
                bindingNavigatorAddNewItem2.Enabled = true;
                bindingNavigatorMovePreviousItem2.Enabled = true;
                bindingNavigatorMoveFirstItem2.Enabled = true;
                bindingNavigatorMoveNextItem2.Enabled = true;
                bindingNavigatorMoveLastItem2.Enabled = true;
                return;
            }

            DataGridViewRow row = headGridView.Rows[e.RowIndex];  // текущая строка
            // ячейка First_name в текущей строке
            DataGridViewCell nameCell = row.Cells[1];
            // ячейка Second_name в текущей строке
            DataGridViewCell surnameCell = row.Cells[2];

            headBindingNavigatorSaveItem.Enabled = false;
            bindingNavigatorAddNewItem2.Enabled = false;
            bindingNavigatorMoveFirstItem2.Enabled = false;
            bindingNavigatorMovePreviousItem2.Enabled = false;
            bindingNavigatorMoveNextItem2.Enabled = false;
            bindingNavigatorMoveLastItem2.Enabled = false;

            // значение в ячейке First_name пусто
            if (nameCell.Value == null || nameCell.Value.ToString().Length == 0)
            {
                nameCell.ErrorText = "Заполните имя";  // метка в ячейке First_name
                row.ErrorText = "Заполните имя";  // метка в ошибочной строке
                e.Cancel = true;  // запрет ухода из строки
            }
            // значение в ячейке Second_name пусто
            else if (surnameCell.Value == null || surnameCell.Value.ToString().Length == 0)
            {
                surnameCell.ErrorText = "Заполните фамилию";  // метка в ячейке Second_name
                row.ErrorText = "Заполните фамилию";  // метка в ошибочной строке
                e.Cancel = true;  // запрет ухода из строки
            }
            else
            {
                nameCell.ErrorText = "";  // метка в ячейке First_name
                surnameCell.ErrorText = "";  // метка в ячейке Second_name
                row.ErrorText = "";  // метка в ошибочной строке
                headBindingNavigatorSaveItem.Enabled = true;
                bindingNavigatorAddNewItem2.Enabled = true;
                bindingNavigatorMoveFirstItem2.Enabled = true;
                bindingNavigatorMovePreviousItem2.Enabled = true;
                bindingNavigatorMoveNextItem2.Enabled = true;
                bindingNavigatorMoveLastItem2.Enabled = true;

                e.Cancel = false;
            }
            repairDataGridViewHeaders();
        }
        private void repairDataGridViewHeaders()
        {
            studentClubsGridView.DataSource = studentClubsTable;

            clubParticipantsGridView.DataSource = clubParticipantsTable;

            managedClubsGridView.DataSource = managedClubsTable;
            managedStudentsGridView.DataSource = managedStudentsTable;

            if (studentClubsTable.Rows.Count != 0)
            {
                studentClubsGridView.Columns[0].Visible = false;

                studentClubsGridView.Columns[1].Width = 300;
                studentClubsGridView.Columns[1].HeaderText = "Название кружка";
                studentClubsGridView.Columns[1].ReadOnly = true;
            }

            if (clubParticipantsTable.Rows.Count != 0)
            {
                clubParticipantsGridView.Columns[0].Visible = false;

                clubParticipantsGridView.Columns[1].Width = 150;
                clubParticipantsGridView.Columns[1].HeaderText = "Имя";
                clubParticipantsGridView.Columns[1].ReadOnly = true;

                clubParticipantsGridView.Columns[2].Width = 150;
                clubParticipantsGridView.Columns[2].HeaderText = "Фамилия";
                clubParticipantsGridView.Columns[2].ReadOnly = true;
            }

            if (managedClubsTable.Rows.Count != 0)
            {
                managedClubsGridView.Columns[0].Width = 300;
                managedClubsGridView.Columns[0].HeaderText = "Название кружка";
                managedClubsGridView.Columns[0].ReadOnly = true;
            }

            if (managedStudentsTable.Rows.Count != 0)
            {
                managedStudentsGridView.Columns[0].Width = 150;
                managedStudentsGridView.Columns[0].HeaderText = "Имя";
                managedStudentsGridView.Columns[0].ReadOnly = true;

                managedStudentsGridView.Columns[1].Width = 150;
                managedStudentsGridView.Columns[1].HeaderText = "Фамилия";
                managedStudentsGridView.Columns[1].ReadOnly = true;
            }
        }
    }
}
