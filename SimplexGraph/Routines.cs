namespace simplex.Classes
{
    using System;
    using System.Windows.Forms;

    internal class Routines
    {
        public static void InitGridView(DataGridView dataGridView)
        {
            int num = 0;
            while (num < dataGridView.ColumnCount)
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 >= dataGridView.RowCount)
                    {
                        num++;
                        break;
                    }
                    dataGridView[num, num2].Value = 0;
                    num2++;
                }
            }
        }
    }
}
