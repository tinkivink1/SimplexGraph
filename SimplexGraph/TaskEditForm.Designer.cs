using System.ComponentModel;

namespace simplex.forms.NewTaskForm
{
    partial class TaskEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.MatrixAGridView = new DataGridView();
            this.label1 = new Label();
            this.label2 = new Label();
            this.MatrixCGridView = new DataGridView();
            this.label3 = new Label();
            this.MatrixBGridView = new DataGridView();
            this.btnCancel = new Button();
            this.btnOk = new Button();
            this.BottomPanel = new Panel();
            this.TaskTypecomboBox = new ComboBox();
            ((ISupportInitialize)this.MatrixAGridView).BeginInit();
            ((ISupportInitialize)this.MatrixCGridView).BeginInit();
            ((ISupportInitialize)this.MatrixBGridView).BeginInit();
            base.SuspendLayout();
            this.MatrixAGridView.AllowUserToAddRows = false;
            this.MatrixAGridView.AllowUserToDeleteRows = false;
            this.MatrixAGridView.AllowUserToResizeColumns = false;
            this.MatrixAGridView.AllowUserToResizeRows = false;
            this.MatrixAGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixAGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixAGridView.ColumnHeadersVisible = false;
            this.MatrixAGridView.Location = new Point(15, 0x19);
            this.MatrixAGridView.Name = "MatrixAGridView";
            this.MatrixAGridView.RowHeadersVisible = false;
            this.MatrixAGridView.RowHeadersWidth = 0x19;
            this.MatrixAGridView.ScrollBars = ScrollBars.None;
            this.MatrixAGridView.ShowCellErrors = false;
            this.MatrixAGridView.ShowCellToolTips = false;
            this.MatrixAGridView.ShowEditingIcon = false;
            this.MatrixAGridView.ShowRowErrors = false;
            this.MatrixAGridView.Size = new Size(0xa5, 0x40);
            this.MatrixAGridView.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Коэф-ты ограничений:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 0x93);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Коэф-ты целевой функции:";
            this.MatrixCGridView.AllowUserToAddRows = false;
            this.MatrixCGridView.AllowUserToDeleteRows = false;
            this.MatrixCGridView.AllowUserToResizeColumns = false;
            this.MatrixCGridView.AllowUserToResizeRows = false;
            this.MatrixCGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixCGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixCGridView.ColumnHeadersVisible = false;
            this.MatrixCGridView.Location = new Point(15, 0xa3);
            this.MatrixCGridView.Name = "MatrixCGridView";
            this.MatrixCGridView.RowHeadersVisible = false;
            this.MatrixCGridView.ScrollBars = ScrollBars.None;
            this.MatrixCGridView.ShowCellErrors = false;
            this.MatrixCGridView.ShowCellToolTips = false;
            this.MatrixCGridView.ShowEditingIcon = false;
            this.MatrixCGridView.ShowRowErrors = false;
            this.MatrixCGridView.Size = new Size(0xad, 0x31);
            this.MatrixCGridView.TabIndex = 3;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x12b, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Свободные члены:";
            this.MatrixBGridView.AllowUserToAddRows = false;
            this.MatrixBGridView.AllowUserToDeleteRows = false;
            this.MatrixBGridView.AllowUserToResizeColumns = false;
            this.MatrixBGridView.AllowUserToResizeRows = false;
            this.MatrixBGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixBGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixBGridView.ColumnHeadersVisible = false;
            this.MatrixBGridView.Location = new Point(0x12e, 0x19);
            this.MatrixBGridView.Name = "MatrixBGridView";
            this.MatrixBGridView.RowHeadersVisible = false;
            this.MatrixBGridView.ScrollBars = ScrollBars.None;
            this.MatrixBGridView.Size = new Size(0x4b, 0x65);
            this.MatrixBGridView.TabIndex = 5;
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x1b3, 0xf4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOk.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnOk.Location = new Point(0x162, 0xf4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(0x4b, 0x17);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.BottomPanel.BorderStyle = BorderStyle.FixedSingle;
            this.BottomPanel.Location = new Point(15, 0xda);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new Size(200, 1);
            this.BottomPanel.TabIndex = 8;
            this.TaskTypecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.TaskTypecomboBox.FormattingEnabled = true;
            object[] items = new object[] { "Максимизировать", "Минимизировать" };
            this.TaskTypecomboBox.Items.AddRange(items);
            this.TaskTypecomboBox.Location = new Point(15, 0xf6);
            this.TaskTypecomboBox.Name = "TaskTypecomboBox";
            this.TaskTypecomboBox.Size = new Size(0xad, 0x15);
            this.TaskTypecomboBox.TabIndex = 9;
            this.TaskTypecomboBox.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged_1);
            base.AcceptButton = this.btnOk;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x20a, 0x117);
            base.Controls.Add(this.TaskTypecomboBox);
            base.Controls.Add(this.BottomPanel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.MatrixBGridView);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.MatrixCGridView);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.MatrixAGridView);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "TaskEditForm";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Новая задача";
            base.Load += new EventHandler(this.NewTaskForm_Load);
            ((ISupportInitialize)this.MatrixAGridView).EndInit();
            ((ISupportInitialize)this.MatrixCGridView).EndInit();
            ((ISupportInitialize)this.MatrixBGridView).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}