
namespace IndividualLab_a_majorov1
{
    partial class ChangeHeadForm
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
            this.chooseHeadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.availableStudentsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // availableStudentsGridView
            // 
            this.availableStudentsGridView.AllowUserToAddRows = false;
            this.availableStudentsGridView.AllowUserToDeleteRows = false;
            this.availableStudentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableStudentsGridView.Location = new System.Drawing.Point(110, 131);
            this.availableStudentsGridView.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.availableStudentsGridView.MultiSelect = false;
            this.availableStudentsGridView.Name = "availableStudentsGridView";
            this.availableStudentsGridView.Size = new System.Drawing.Size(346, 270);
            this.availableStudentsGridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(149, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите нового руководителя";
            // 
            // chooseHeadButton
            // 
            this.chooseHeadButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseHeadButton.Location = new System.Drawing.Point(215, 413);
            this.chooseHeadButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chooseHeadButton.Name = "chooseHeadButton";
            this.chooseHeadButton.Size = new System.Drawing.Size(123, 51);
            this.chooseHeadButton.TabIndex = 9;
            this.chooseHeadButton.Text = "Выбрать";
            this.chooseHeadButton.UseVisualStyleBackColor = true;
            this.chooseHeadButton.Click += new System.EventHandler(this.chooseHeadButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Искать по фамилии:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(170, 80);
            this.queryTextBox.MaxLength = 50;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(267, 27);
            this.queryTextBox.TabIndex = 11;
            this.queryTextBox.TextChanged += new System.EventHandler(this.queryTextBox_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(452, 80);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(88, 27);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // ChangeHeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 492);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseHeadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availableStudentsGridView);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChangeHeadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Смена руководителя";
            this.Load += new System.EventHandler(this.ChangeHeadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.availableStudentsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView availableStudentsGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseHeadButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button clearButton;
    }
}