using System.ComponentModel;

namespace GraphSimplex
{
    partial class MainForm
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
            this.GraphPaintBox = new Panel();
            this.menuStrip1 = new MenuStrip();
            this.MainMenuItem = new ToolStripMenuItem();
            this.NewTaskMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem3 = new ToolStripSeparator();
            this.CloseMenuItem = new ToolStripMenuItem();
            this.textBox = new TextBox();
            this.menuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.GraphPaintBox.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.GraphPaintBox.BackColor = Color.White;
            this.GraphPaintBox.Location = new Point(0x197, 0x24);
            this.GraphPaintBox.Name = "GraphPaintBox";
            this.GraphPaintBox.Size = new Size(0x4dc, 0x48b);
            this.GraphPaintBox.TabIndex = 0;
            this.GraphPaintBox.Paint += new PaintEventHandler(this.GraphPaintBox_Paint);
            this.GraphPaintBox.Resize += new EventHandler(this.GraphPaintBox_Resize);
            this.menuStrip1.ImageScalingSize = new Size(0x18, 0x18);
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.MainMenuItem };
            this.menuStrip1.Items.AddRange(toolStripItems);
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x67f, 0x21);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            ToolStripItem[] itemArray2 = new ToolStripItem[] { this.NewTaskMenuItem, this.toolStripMenuItem3, this.CloseMenuItem };
            this.MainMenuItem.DropDownItems.AddRange(itemArray2);
            this.MainMenuItem.Name = "MainMenuItem";
            this.MainMenuItem.Size = new Size(0x51, 0x1d);
            this.MainMenuItem.Text = "Задача";
            this.MainMenuItem.Click += new EventHandler(this.MainMenuItem_Click);
            this.NewTaskMenuItem.Name = "NewTaskMenuItem";
            this.NewTaskMenuItem.Size = new Size(0xfc, 30);
            this.NewTaskMenuItem.Text = "Новая задача";
            this.NewTaskMenuItem.Click += new EventHandler(this.NewTaskMenuItem_Click);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(0xf9, 6);
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new Size(0xfc, 30);
            this.CloseMenuItem.Text = "Выход";
            this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);
            this.textBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.textBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            this.textBox.Location = new Point(0, 0x24);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new Size(0x191, 0x48b);
            this.textBox.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(9f, 20f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x67f, 0x4bb);
            base.Controls.Add(this.textBox);
            base.Controls.Add(this.GraphPaintBox);
            base.Controls.Add(this.menuStrip1);
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "MainForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Графическое решение ЗЛП";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        #endregion
    }
}