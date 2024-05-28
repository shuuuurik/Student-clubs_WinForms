
namespace IndividualLab_a_majorov1
{
    partial class EnrollmentForm
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
            this.availableClubsGridView = new System.Windows.Forms.DataGridView();
            this.enrollmentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.availableClubsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // availableClubsGridView
            // 
            this.availableClubsGridView.AllowUserToAddRows = false;
            this.availableClubsGridView.AllowUserToDeleteRows = false;
            this.availableClubsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableClubsGridView.Location = new System.Drawing.Point(138, 119);
            this.availableClubsGridView.Name = "availableClubsGridView";
            this.availableClubsGridView.Size = new System.Drawing.Size(300, 254);
            this.availableClubsGridView.TabIndex = 4;
            // 
            // enrollmentButton
            // 
            this.enrollmentButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enrollmentButton.Location = new System.Drawing.Point(235, 392);
            this.enrollmentButton.Name = "enrollmentButton";
            this.enrollmentButton.Size = new System.Drawing.Size(123, 51);
            this.enrollmentButton.TabIndex = 5;
            this.enrollmentButton.Text = "Записаться";
            this.enrollmentButton.UseVisualStyleBackColor = true;
            this.enrollmentButton.Click += new System.EventHandler(this.enrollmentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(67, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выберите кружки, на которые желаете записаться";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Искать по названию:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(171, 67);
            this.queryTextBox.MaxLength = 50;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(267, 27);
            this.queryTextBox.TabIndex = 8;
            this.queryTextBox.TextChanged += new System.EventHandler(this.queryTextBox_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(453, 67);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(88, 27);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 474);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enrollmentButton);
            this.Controls.Add(this.availableClubsGridView);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Запись на кружки";
            this.Load += new System.EventHandler(this.EnrollmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.availableClubsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView availableClubsGridView;
        private System.Windows.Forms.Button enrollmentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button clearButton;
    }
}