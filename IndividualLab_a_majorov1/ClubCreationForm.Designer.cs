
namespace IndividualLab_a_majorov1
{
    partial class ClubCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.availableStudentsGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.createClubButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.clubTitleTextBox = new System.Windows.Forms.TextBox();
            this.thisClubExistsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.availableStudentsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // availableStudentsGridView
            // 
            this.availableStudentsGridView.AllowUserToAddRows = false;
            this.availableStudentsGridView.AllowUserToDeleteRows = false;
            this.availableStudentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableStudentsGridView.Location = new System.Drawing.Point(121, 124);
            this.availableStudentsGridView.Margin = new System.Windows.Forms.Padding(4);
            this.availableStudentsGridView.MultiSelect = false;
            this.availableStudentsGridView.Name = "availableStudentsGridView";
            this.availableStudentsGridView.Size = new System.Drawing.Size(346, 270);
            this.availableStudentsGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(177, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выберите руководителя";
            // 
            // createClubButton
            // 
            this.createClubButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createClubButton.Location = new System.Drawing.Point(222, 514);
            this.createClubButton.Margin = new System.Windows.Forms.Padding(4);
            this.createClubButton.Name = "createClubButton";
            this.createClubButton.Size = new System.Drawing.Size(123, 51);
            this.createClubButton.TabIndex = 8;
            this.createClubButton.Text = "Создать";
            this.createClubButton.UseVisualStyleBackColor = true;
            this.createClubButton.Click += new System.EventHandler(this.createClubButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Искать по фамилии:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(170, 80);
            this.queryTextBox.MaxLength = 50;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(267, 27);
            this.queryTextBox.TabIndex = 12;
            this.queryTextBox.TextChanged += new System.EventHandler(this.queryTextBox_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(452, 80);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(88, 27);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(177, 418);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Введите название кружка";
            // 
            // clubTitleTextBox
            // 
            this.clubTitleTextBox.Location = new System.Drawing.Point(121, 457);
            this.clubTitleTextBox.MaxLength = 50;
            this.clubTitleTextBox.Name = "clubTitleTextBox";
            this.clubTitleTextBox.Size = new System.Drawing.Size(346, 27);
            this.clubTitleTextBox.TabIndex = 15;
            // 
            // thisClubExistsLabel
            // 
            this.thisClubExistsLabel.AutoSize = true;
            this.thisClubExistsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.thisClubExistsLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thisClubExistsLabel.ForeColor = System.Drawing.Color.Red;
            this.thisClubExistsLabel.Location = new System.Drawing.Point(129, 487);
            this.thisClubExistsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thisClubExistsLabel.Name = "thisClubExistsLabel";
            this.thisClubExistsLabel.Size = new System.Drawing.Size(338, 23);
            this.thisClubExistsLabel.TabIndex = 16;
            this.thisClubExistsLabel.Text = "Клуб с таким названием уже существует!";
            // 
            // ClubCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 583);
            this.Controls.Add(this.thisClubExistsLabel);
            this.Controls.Add(this.clubTitleTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.createClubButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availableStudentsGridView);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClubCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление кружка";
            this.Load += new System.EventHandler(this.ClubCreationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.availableStudentsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView availableStudentsGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createClubButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clubTitleTextBox;
        private System.Windows.Forms.Label thisClubExistsLabel;
    }
}