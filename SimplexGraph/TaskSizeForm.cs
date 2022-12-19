namespace GraphSimplex
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class TaskSizeForm : Form
    {
        public TaskSizeForm()
        {
            this.InitializeComponent();
        }

        public int m() =>
            int.Parse(this.mtextBox.Text);
    }
}
