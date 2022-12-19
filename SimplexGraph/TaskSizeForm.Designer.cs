using System.ComponentModel;

namespace GraphSimplex
{
    partial class TaskSizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        private Label label1;
        private TextBox mtextBox;
        private ContextMenuStrip contextMenuStrip1;
        private Button OKButton;
        private Button CancelButton;

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
            this.components = new Container();
            this.label1 = new Label();
            this.mtextBox = new TextBox();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.OKButton = new Button();
            this.CancelButton = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            this.label1.Location = new Point(0x23, 0x2b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x12e, 0x1d);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во ограничений (m):";
            this.mtextBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            this.mtextBox.Location = new Point(40, 0x5b);
            this.mtextBox.Name = "mtextBox";
            this.mtextBox.Size = new Size(0xf9, 0x23);
            this.mtextBox.TabIndex = 1;
            this.mtextBox.Text = "2";
            this.contextMenuStrip1.ImageScalingSize = new Size(0x18, 0x18);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x3d, 4);
            this.OKButton.DialogResult = DialogResult.OK;
            this.OKButton.Location = new Point(40, 0xad);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new Size(0xbd, 0x2f);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.CancelButton.DialogResult = DialogResult.Cancel;
            this.CancelButton.Location = new Point(250, 0xad);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(0xbd, 0x2f);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(9f, 20f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1dd, 250);
            base.Controls.Add(this.CancelButton);
            base.Controls.Add(this.OKButton);
            base.Controls.Add(this.mtextBox);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "TaskSizeForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Новая задача";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}