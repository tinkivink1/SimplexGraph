namespace simplex.forms.NewTaskForm
{
    using simplex.Classes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class TaskEditForm : Form
    {
        private int m = 2;
        private int n = 2;
        private List<ComboBox> signs = new List<ComboBox>();
        public double[,] MatrixA = new double[100, 100];
        public double[] Vectorb = new double[100];
        public double[] Vectorc = new double[100];
        public int[] Signs = new int[100];
        
        private DataGridView MatrixAGridView;
        private Label label1;
        private Label label2;
        private DataGridView MatrixCGridView;
        private Label label3;
        private DataGridView MatrixBGridView;
        private Button btnCancel;
        private Button btnOk;
        private Panel BottomPanel;
        private ComboBox TaskTypecomboBox;

        public TaskEditForm()
        {
            this.InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.btnOk.DialogResult = DialogResult.OK;
            int index = 0;
            while (true)
            {
                if (index >= this.m)
                {
                    int num2 = 0;
                    while (true)
                    {
                        if (num2 >= this.MatrixAGridView.RowCount)
                        {
                            int num4 = 0;
                            while (true)
                            {
                                if (num4 >= this.MatrixBGridView.RowCount)
                                {
                                    int num5 = 0;
                                    while (true)
                                    {
                                        if (num5 >= this.MatrixCGridView.ColumnCount)
                                        {
                                            if (this.btnOk.DialogResult == DialogResult.OK)
                                            {
                                                base.DialogResult = DialogResult.OK;
                                            }
                                            return;
                                        }
                                        try
                                        {
                                            this.Vectorc[num5] = Convert.ToDouble(this.MatrixCGridView[num5, 0].Value);
                                        }
                                        catch
                                        {
                                            this.btnOk.DialogResult = DialogResult.None;
                                            MessageBox.Show("Неправильный формат числа: \"" + this.MatrixCGridView[num5, 0].Value.ToString() + "\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        }
                                        num5++;
                                    }
                                }
                                try
                                {
                                    this.Vectorb[num4] = Convert.ToDouble(this.MatrixBGridView[0, num4].Value);
                                }
                                catch
                                {
                                    this.btnOk.DialogResult = DialogResult.None;
                                    MessageBox.Show("Неправильный формат числа: \"" + this.MatrixBGridView[0, num4].Value.ToString() + "\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                num4++;
                            }
                        }
                        int num3 = 0;
                        while (true)
                        {
                            if (num3 >= this.MatrixAGridView.ColumnCount)
                            {
                                num2++;
                                break;
                            }
                            try
                            {
                                this.MatrixA[num2, num3] = Convert.ToDouble(this.MatrixAGridView[num3, num2].Value);
                            }
                            catch
                            {
                                this.btnOk.DialogResult = DialogResult.None;
                                MessageBox.Show("Неправильный формат числа: \"" + this.MatrixAGridView[num3, num2].Value.ToString() + "\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            num3++;
                        }
                    }
                }
                this.Signs[index] = this.signs[index].SelectedIndex;
                index++;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        

        public void InitForm(int an, int am)
        {
            this.n = an;
            this.m = am;
            this.MatrixAGridView.RowCount = this.m;
            this.MatrixAGridView.ColumnCount = this.n;
            this.MatrixAGridView.Height = (this.MatrixAGridView.RowCount * this.MatrixAGridView.RowTemplate.Height) + 3;
            this.MatrixAGridView.Width = this.MatrixAGridView.ColumnCount * 50;
            this.signs.Clear();
            int num = 0;
            while (true)
            {
                if (num >= this.m)
                {
                    this.label3.Left = (this.MatrixAGridView.Left + this.MatrixAGridView.Width) + 80;
                    this.MatrixBGridView.Left = (this.MatrixAGridView.Left + this.MatrixAGridView.Width) + 80;
                    this.MatrixBGridView.Height = (this.MatrixAGridView.RowCount * this.MatrixAGridView.RowTemplate.Height) + 3;
                    this.MatrixBGridView.RowCount = this.m;
                    this.MatrixBGridView.ColumnCount = 1;
                    this.label2.Top = (this.MatrixAGridView.Top + this.MatrixAGridView.Height) + 15;
                    this.MatrixCGridView.Top = (this.label2.Top + this.label2.Height) + 5;
                    this.MatrixCGridView.RowCount = 1;
                    this.MatrixCGridView.ColumnCount = this.n;
                    this.MatrixCGridView.Width = this.MatrixCGridView.ColumnCount * 50;
                    this.MatrixCGridView.Height = (this.MatrixCGridView.RowCount * this.MatrixCGridView.RowTemplate.Height) + 3;
                    this.BottomPanel.Top = (this.MatrixCGridView.Top + this.MatrixCGridView.Height) + 15;
                    this.BottomPanel.Width = (this.label3.Width >= this.MatrixBGridView.Width) ? ((this.label3.Left + this.label3.Width) - this.BottomPanel.Left) : ((this.MatrixBGridView.Left + this.MatrixBGridView.Width) - this.BottomPanel.Left);
                    base.Width = (this.BottomPanel.Left + this.BottomPanel.Width) + 0x37;
                    base.Height = (this.BottomPanel.Top + this.BottomPanel.Height) + 90;
                    Routines.InitGridView(this.MatrixAGridView);
                    Routines.InitGridView(this.MatrixBGridView);
                    Routines.InitGridView(this.MatrixCGridView);
                    this.TaskTypecomboBox.Top = this.btnOk.Top;
                    if (this.TaskTypecomboBox.Bounds.Right > this.btnOk.Left)
                    {
                        this.TaskTypecomboBox.Width = this.btnOk.Left - 30;
                    }
                    this.TaskTypecomboBox.SelectedIndex = 0;
                    return;
                }
                ComboBox item = new ComboBox
                {
                    Parent = this,
                    Width = 50,
                    Items = {
                        "=",
                        ">=",
                        "<="
                    },
                    SelectedIndex = 0,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Left = (this.MatrixAGridView.Left + this.MatrixAGridView.Width) + 15,
                    Top = this.MatrixAGridView.Top + (num * this.MatrixAGridView.RowTemplate.Height)
                };
                this.signs.Add(item);
                num++;
            }
        }

        

        private void NewTaskForm_Load(object sender, EventArgs e)
        {
        }

        public int N =>
            this.n;

        public int M =>
            this.m;

        public int TaskType =>
            this.TaskTypecomboBox.SelectedIndex;
    }
}
