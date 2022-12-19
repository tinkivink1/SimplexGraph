namespace GraphSimplex
{
    using simplex.forms.NewTaskForm;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private const int TASK_TYPE_MAX = 0;
        private const int TASK_TYPE_MIN = 1;
        private int m = 0;
        private int taskType;
        private float[,] A;
        private float[] B;
        private float[] C;
        private int[] S;
        private bool taskSolved;
        private float graphScale = 1f;
        private float Maxsx;
        private float Maxsy;
        private float sx;
        private float sy;
        private int halfWidth;
        private int halfHeight;
        private Font drawFont;
        private Font smalFont;
        private SolidBrush drawBrush;
        private StringFormat drawFormat;
        private BufferedGraphics buffer;
        private BufferedGraphicsContext bufferContext = null;
        
        private Panel GraphPaintBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MainMenuItem;
        private ToolStripMenuItem NewTaskMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem CloseMenuItem;
        private TextBox textBox;

        public MainForm()
        {
            this.InitializeComponent();
            this.drawFont = new Font("Arial", 14f);
            this.smalFont = new Font("Arial", 10f);
            this.drawBrush = new SolidBrush(Color.Black);
            this.drawFormat = new StringFormat();
            this.bufferContext = BufferedGraphicsManager.Current;
            this.buffer = this.bufferContext.Allocate(this.GraphPaintBox.CreateGraphics(), this.GraphPaintBox.DisplayRectangle);
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        

        private void DrawCoordinateAxis(Graphics g)
        {
            g.DrawLine(Pens.Black, this.halfWidth, this.GraphPaintBox.Height, this.halfWidth, 0);
            g.DrawLine(Pens.Black, this.halfWidth, 0, this.halfWidth - 5, 10);
            g.DrawLine(Pens.Black, this.halfWidth - 5, 10, this.halfWidth + 5, 10);
            g.DrawLine(Pens.Black, this.halfWidth + 5, 10, this.halfWidth, 0);
            g.DrawLine(Pens.Black, 0, this.halfHeight, this.GraphPaintBox.Width, this.halfHeight);
            g.DrawLine(Pens.Black, this.GraphPaintBox.Width, this.halfHeight, this.GraphPaintBox.Width - 10, this.halfHeight - 5);
            g.DrawLine(Pens.Black, (int)(this.GraphPaintBox.Width - 10), (int)(this.halfHeight - 5), (int)(this.GraphPaintBox.Width - 10), (int)(this.halfHeight + 5));
            g.DrawLine(Pens.Black, this.GraphPaintBox.Width - 10, this.halfHeight + 5, this.GraphPaintBox.Width, this.halfHeight);
            g.DrawString("x1", this.drawFont, this.drawBrush, (float)(this.GraphPaintBox.Width - 30), (float)(this.halfHeight + 30), this.drawFormat);
            g.DrawString("x2", this.drawFont, this.drawBrush, (float)(this.halfWidth + 30), 2f, this.drawFormat);
        }

        private void DrawDirectVector(Graphics g)
        {
            float num3 = 0f;
            float num4 = 0f;
            if ((this.C[0] != 0f) || (this.C[1] != 0f))
            {
                float num9;
                float num10;
                float num = this.C[0];
                float num2 = this.C[1];
                float num14 = (float)Math.Sqrt((double)((num * num) + (num2 * num2)));
                if (!(num == 0f))
                {
                    num3 = num / num14;
                }
                if (!(num2 == 0f))
                {
                    num4 = num2 / num14;
                }
                num = num3;
                num2 = num4;
                if (this.halfWidth < this.halfHeight)
                {
                    num9 = this.halfWidth + (num * this.halfWidth);
                    num10 = this.halfHeight + (-num2 * this.halfWidth);
                }
                else
                {
                    num9 = this.halfWidth + (num * this.halfHeight);
                    num10 = this.halfHeight + (-num2 * this.halfHeight);
                }
                Pen pen = new Pen(Color.Red, 2f);
                g.DrawLine(pen, (float)this.halfWidth, (float)this.halfHeight, num9, num10);
                float num12 = (-1f * num) * 20f;
                float num13 = num2 * 20f;
                float num11 = 0.2617994f;
                float num5 = num9 + ((num12 * ((float)Math.Cos((double)num11))) - (num13 * ((float)Math.Sin((double)num11))));
                float num6 = num10 + ((num12 * ((float)Math.Sin((double)num11))) + (num13 * ((float)Math.Cos((double)num11))));
                g.DrawLine(pen, num9, num10, num5, num6);
                num11 = -0.2617994f;
                num5 = num9 + ((num12 * ((float)Math.Cos((double)num11))) - (num13 * ((float)Math.Sin((double)num11))));
                num6 = num10 + ((num12 * ((float)Math.Sin((double)num11))) + (num13 * ((float)Math.Cos((double)num11))));
                g.DrawLine(pen, num9, num10, num5, num6);
                g.DrawLine(pen, num5, num6, num5, num6);
                if (this.taskSolved)
                {
                    if (!(this.C[1] == 0f))
                    {
                        num3 = -(((float)this.halfWidth) / this.graphScale);
                        num4 = ((-this.C[0] * (num3 - this.sx)) / this.C[1]) + this.sy;
                        num5 = ((float)this.halfWidth) / this.graphScale;
                        num6 = ((-this.C[0] * (num5 - this.sx)) / this.C[1]) + this.sy;
                    }
                    else
                    {
                        num4 = -(((float)this.halfHeight) / this.graphScale);
                        if (!(this.C[0] == 0f))
                        {
                            num3 = ((-this.C[1] * (num4 - this.sy)) / this.C[0]) + this.sx;
                        }
                        num6 = ((float)this.halfHeight) / this.graphScale;
                        if (!(this.C[0] == 0f))
                        {
                            num5 = ((-this.C[1] * (num6 - this.sy)) / this.C[0]) + this.sx;
                        }
                    }
                }
                g.DrawLine(pen, (float)(this.halfWidth + (num3 * this.graphScale)), (float)(this.halfHeight + (-num4 * this.graphScale)), (float)(this.halfWidth + (num5 * this.graphScale)), (float)(this.halfHeight + (-num6 * this.graphScale)));
            }
        }

        private void DrawFunctionDomain(Bitmap b, Graphics g)
        {
            DirectBitmap bitmap = new DirectBitmap(this.halfWidth, this.halfHeight);
            int x = 0;
            while (true)
            {
                if (x >= this.halfWidth)
                {
                    g.DrawImage(bitmap.Bitmap, new Point(this.halfWidth, 0));
                    return;
                }
                int y = 0;
                while (true)
                {
                    if (y >= this.halfHeight)
                    {
                        x++;
                        break;
                    }
                    PointF pointf = new PointF(((float)x) / this.graphScale, ((float)(this.halfHeight - y)) / this.graphScale);
                    if (this.taskSolved)
                    {
                        if (this.PointBelongsRestDomain(pointf))
                        {
                            bitmap.SetPixel(x, y, Color.LightGreen);
                        }
                    }
                    else
                    {
                        int aRestIndex = 0;
                        while (true)
                        {
                            if (aRestIndex >= this.m)
                            {
                                break;
                            }
                            if (this.PointBelongsRest(pointf, aRestIndex))
                            {
                                bitmap.SetPixel(x, y, Color.LightGreen);
                            }
                            aRestIndex++;
                        }
                    }
                    y++;
                }
            }
        }

        private void DrawGraph(Graphics g)
        {
            Bitmap image = new Bitmap(this.GraphPaintBox.Width, this.GraphPaintBox.Height);
            Graphics graphics = Graphics.FromImage(image);
            this.halfWidth = this.GraphPaintBox.Width / 2;
            this.halfHeight = this.GraphPaintBox.Height / 2;
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, this.GraphPaintBox.Width, this.GraphPaintBox.Height));
            if (this.m <= 0)
            {
                this.graphScale = 50f;
            }
            else
            {
                float num = (this.Maxsx == 0f) ? float.MaxValue : (((float)(this.halfWidth / 2)) / this.Maxsx);
                float num2 = (this.Maxsy == 0f) ? float.MaxValue : (((float)(this.halfHeight / 2)) / this.Maxsy);
                this.graphScale = (num >= num2) ? num2 : num;
                if (this.graphScale >= 0x3e8f)
                {
                    this.graphScale = (this.halfWidth / 2) / 3;
                }
            }
            if (this.m > 0)
            {
                this.DrawFunctionDomain(image, graphics);
            }
            this.DrawCoordinateAxis(graphics);
            this.DrawGrid(graphics);
            float[,] numArray = new float[this.m, 4];
            float[,] numArray2 = new float[this.m, 4];
            bool[] flagArray = new bool[this.m];
            int index = 0;
            while (true)
            {
                if (index >= this.m)
                {
                    if ((this.m > 0) && this.taskSolved)
                    {
                        this.DrawDirectVector(graphics);
                    }
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                    return;
                }
                if ((this.A[index, 0] != 0f) || (this.A[index, 1] != 0f))
                {
                    int num3 = 1;
                    numArray = new float[this.m, 4];
                    numArray2 = new float[this.m, 4];
                    if (!(this.A[index, 1] == 0f))
                    {
                        float num5 = ((float)this.halfWidth) / this.graphScale;
                        float num6 = (this.B[index] - (this.A[index, 0] * num5)) / this.A[index, 1];
                        if (Math.Abs(num6) <= (((float)this.halfHeight) / this.graphScale))
                        {
                            numArray[index, num3] = this.halfWidth + (num5 * this.graphScale);
                            numArray2[index, num3] = this.halfHeight + (-num6 * this.graphScale);
                            num3++;
                        }
                    }
                    if (!(this.A[index, 1] == 0f))
                    {
                        float num7 = ((float)-this.halfWidth) / this.graphScale;
                        float num8 = (this.B[index] - (this.A[index, 0] * num7)) / this.A[index, 1];
                        if (Math.Abs(num8) <= (((float)this.halfHeight) / this.graphScale))
                        {
                            numArray[index, num3] = this.halfWidth + (num7 * this.graphScale);
                            numArray2[index, num3] = this.halfHeight + (-num8 * this.graphScale);
                            num3++;
                        }
                    }
                    if (!(this.A[index, 0] == 0f))
                    {
                        float num9 = ((float)this.halfHeight) / this.graphScale;
                        float num10 = (this.B[index] - (this.A[index, 1] * num9)) / this.A[index, 0];
                        if (Math.Abs(num10) <= (((float)this.halfWidth) / this.graphScale))
                        {
                            numArray[index, num3] = this.halfWidth + (num10 * this.graphScale);
                            numArray2[index, num3] = this.halfHeight + (-num9 * this.graphScale);
                            num3++;
                        }
                    }
                    if (!(this.A[index, 0] == 0f))
                    {
                        float num11 = ((float)-this.halfHeight) / this.graphScale;
                        float num12 = (this.B[index] - (this.A[index, 1] * num11)) / this.A[index, 0];
                        if (Math.Abs(num12) <= (((float)this.halfWidth) / this.graphScale))
                        {
                            numArray[index, num3] = this.halfWidth + (num12 * this.graphScale);
                            numArray2[index, num3] = this.halfHeight + (-num11 * this.graphScale);
                            num3++;
                        }
                    }
                    if (num3 <= 1)
                    {
                        flagArray[index] = false;
                    }
                    else
                    {
                        flagArray[index] = true;
                        graphics.DrawLine(new Pen(Color.Black, 2f), numArray[index, 1], numArray2[index, 1], numArray[index, 2], numArray2[index, 2]);
                        this.DrawGuideLines(image, graphics, numArray[index, 1], numArray2[index, 1], numArray[index, 2], numArray2[index, 2], index);
                    }
                }
                index++;
            }
        }

        private void DrawGrid(Graphics g)
        {
            float num3 = 0f;
            int num4 = 1;
            while (true)
            {
                if (num4 <= 30)
                {
                    num3 = this.graphScale * num4;
                    if (!(((num3 < 0x19f) || (num3 > 30f)) ? (num3 > 30f) : true))
                    {
                        num4++;
                        continue;
                    }
                }
                float num2 = num3 / this.graphScale;
                int num = (this.halfHeight <= this.halfWidth) ? ((int)(((float)this.halfWidth) / num3)) : ((int)(((float)this.halfHeight) / num3));
                int num5 = 1;
                while (true)
                {
                    if (num5 > num)
                    {
                        for (int i = 1; i <= num; i++)
                        {
                            g.DrawString(((int)(-i * num2)).ToString(), this.smalFont, this.drawBrush, (float)(this.halfWidth - (((int)num3) * i)), (float)this.halfHeight, this.drawFormat);
                            g.DrawString(((int)(i * num2)).ToString(), this.smalFont, this.drawBrush, (float)(this.halfWidth + (((int)num3) * i)), (float)this.halfHeight, this.drawFormat);
                            g.DrawString(((int)(-i * num2)).ToString(), this.smalFont, this.drawBrush, (float)(this.halfWidth + 5), (float)(this.halfHeight + (((int)num3) * i)), this.drawFormat);
                            g.DrawString(((int)(i * num2)).ToString(), this.smalFont, this.drawBrush, (float)(this.halfWidth + 5), (float)(this.halfHeight - (((int)num3) * i)), this.drawFormat);
                        }
                        return;
                    }
                    Pen pen = new Pen(Color.Blue, 1f)
                    {
                        DashStyle = DashStyle.DashDot
                    };
                    g.DrawLine(pen, 0, this.halfHeight - (((int)num3) * num5), this.GraphPaintBox.Width, this.halfHeight - (((int)num3) * num5));
                    g.DrawLine(pen, 0, this.halfHeight + (((int)num3) * num5), this.GraphPaintBox.Width, this.halfHeight + (((int)num3) * num5));
                    g.DrawLine(pen, this.halfWidth - (((int)num3) * num5), 0, this.halfWidth - (((int)num3) * num5), this.GraphPaintBox.Height);
                    g.DrawLine(pen, this.halfWidth + (((int)num3) * num5), 0, this.halfWidth + (((int)num3) * num5), this.GraphPaintBox.Height);
                    num5++;
                }
            }
        }

        private void DrawGuideLines(Bitmap b, Graphics g, float x1, float y1, float x2, float y2, int ARestIndex)
        {
            int num = 0;
            int num2 = 0;
            float[] numArray = new float[2];
            float[] numArray2 = new float[2];
            int num3 = 10;
            int num5 = ((int)Math.Sqrt(Math.Pow((double)(x2 - x1), 2.0) + Math.Pow((double)(y2 - y1), 2.0))) / num3;
            double num6 = Math.Sqrt(Math.Pow((double)(x2 - x1), 2.0) + Math.Pow((double)(y2 - y1), 2.0));
            numArray[0] = (float)(((double)(x2 - x1)) / num6);
            numArray[1] = (float)(((double)(y2 - y1)) / num6);
            for (int i = 0; i <= num5; i++)
            {
                float num8;
                float num9;
                float num10 = (numArray[1] * num) + y1;
                float num11 = (numArray[0] * num) + x1;
                if (!(numArray[1] == 0f))
                {
                    num9 = num11 + 5f;
                    num8 = ((-numArray[0] * (num9 - num11)) / numArray[1]) + num10;
                }
                else
                {
                    num8 = num10 + 5f;
                    num9 = ((-numArray[1] * (num8 - num10)) / numArray[0]) + num11;
                }
                num6 = Math.Sqrt(Math.Pow((double)(num11 - num9), 2.0) + Math.Pow((double)(num10 - num8), 2.0));
                numArray2[0] = (float)(((double)(num11 - num9)) / num6);
                numArray2[1] = (float)(((double)(num10 - num8)) / num6);
                if (i == 0)
                {
                    num8 = (numArray2[1] * 15f) + num10;
                    PointF pointf = new PointF((((numArray2[0] * 15f) + num11) - this.halfWidth) / this.graphScale, (this.halfHeight - num8) / this.graphScale);
                    num2 = this.PointBelongsRest(pointf, ARestIndex) ? 1 : -1;
                }
                Pen pen = new Pen(Color.Green, 1f);
                g.DrawLine(pen, num11, num10, (num2 * (numArray2[0] * 15f)) + num11, (num2 * (numArray2[1] * 15f)) + num10);
                if (i > 0)
                {
                    num += num3;
                }
            }
        }

        private void GraphPaintBox_Paint(object sender, PaintEventArgs e)
        {
            this.DrawGraph(this.buffer.Graphics);
            this.buffer.Render(e.Graphics);
        }

        private void GraphPaintBox_Resize(object sender, EventArgs e)
        {
            if (this.bufferContext != null)
            {
                this.bufferContext.MaximumBuffer = new Size(base.Width + 1, base.Height + 1);
                if (this.buffer != null)
                {
                    this.buffer.Dispose();
                    this.buffer = null;
                }
                this.buffer = this.bufferContext.Allocate(base.CreateGraphics(), new Rectangle(0, 0, base.Width, base.Height));
                this.DrawGraph(this.buffer.Graphics);
                this.Refresh();
            }
        }

        

        private bool LineToPoint(float a1, float b1, float c1, float a2, float b2, float c2, ref PointF pointf)
        {
            bool flag2;
            float num = (a1 * b2) - (b1 * a2);
            if (num == 0f)
            {
                flag2 = false;
            }
            else
            {
                float num2 = (-c1 * b2) + (b1 * c2);
                float num3 = (-a1 * c2) + (c1 * a2);
                pointf.X = -num2 / num;
                pointf.Y = -num3 / num;
                flag2 = true;
            }
            return flag2;
        }

        private void MainMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void NewTaskMenuItem_Click(object sender, EventArgs e)
        {
            TaskSizeForm form = new TaskSizeForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                TaskEditForm form2 = new TaskEditForm();
                form2.InitForm(2, form.m());
                if (form2.ShowDialog(this) == DialogResult.OK)
                {
                    this.m = form.m();
                    this.taskType = form2.TaskType;
                    this.A = new float[this.m, 2];
                    this.B = new float[this.m];
                    this.C = new float[2];
                    this.S = new int[this.m];
                    int index = 0;
                    while (true)
                    {
                        if (index >= 2)
                        {
                            int num3 = 0;
                            while (true)
                            {
                                if (num3 >= this.m)
                                {
                                    this.SolveTask();
                                    this.GraphPaintBox.Refresh();
                                    break;
                                }
                                this.B[num3] = (float)form2.Vectorb[num3];
                                this.S[num3] = form2.Signs[num3];
                                num3++;
                            }
                            break;
                        }
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= this.m)
                            {
                                this.C[index] = (float)form2.Vectorc[index];
                                index++;
                                break;
                            }
                            this.A[num2, index] = (float)form2.MatrixA[num2, index];
                            num2++;
                        }
                    }
                }
            }
        }

        private bool PointBelongsRest(PointF pointf, int ARestIndex)
        {
            float num = (this.A[ARestIndex, 0] * pointf.X) + (this.A[ARestIndex, 1] * pointf.Y);
            float num2 = this.B[ARestIndex];
            switch (this.S[ARestIndex])
            {
                case 0:
                    if (num == num2)
                    {
                        break;
                    }
                    return false;

                case 1:
                    if (num >= num2)
                    {
                        break;
                    }
                    return false;

                case 2:
                    if (num <= num2)
                    {
                        break;
                    }
                    return false;

                default:
                    break;
            }
            return true;
        }

        private bool PointBelongsRestDomain(PointF pointf)
        {
            bool flag3;
            if ((pointf.X < 0f) || (pointf.Y < 0f))
            {
                flag3 = false;
            }
            else
            {
                bool flag = true;
                int aRestIndex = 0;
                while (true)
                {
                    if (aRestIndex < this.m)
                    {
                        if (this.PointBelongsRest(pointf, aRestIndex))
                        {
                            aRestIndex++;
                            continue;
                        }
                        flag = false;
                    }
                    flag3 = flag;
                    break;
                }
            }
            return flag3;
        }

        private void SolveTask()
        {
            this.Maxsx = 0f;
            this.Maxsy = 0f;
            this.taskSolved = false;
            float maxValue = float.MaxValue;
            if (this.taskType == 0)
            {
                maxValue = float.MinValue;
            }
            List<PointF> list = new List<PointF>();
            PointF item = new PointF
            {
                X = 0f,
                Y = 0f
            };
            list.Add(item);
            int index = 0;
            while (true)
            {
                if (index >= this.m)
                {
                    int num4 = 0;
                    while (true)
                    {
                        if (num4 >= list.Count)
                        {
                            this.textBox.Clear();
                            if ((this.C[0] == 0f) && (this.C[1] == 0f))
                            {
                                this.textBox.AppendText("Целевая функция не задана!" + Environment.NewLine);
                            }
                            else if (!this.taskSolved)
                            {
                                this.textBox.AppendText("Задача не имеет допустимого решения! Т.к. ее ограничения несовместны.");
                            }
                            else if (this.TestForInfinite(maxValue))
                            {
                                this.textBox.AppendText("Задача имеет бесконечное множество решений! Т.к. ее ограничения не замкнуты и область их определения уходит в бесконечность.");
                            }
                            else
                            {
                                this.textBox.AppendText("Задача решена!" + Environment.NewLine);
                                this.textBox.AppendText(Environment.NewLine);
                                if (this.taskType == 0)
                                {
                                    this.textBox.AppendText("Целевая функция достигает своего максимального значения в точке:" + Environment.NewLine);
                                }
                                else
                                {
                                    this.textBox.AppendText("Целевая функция достигает своего минимального значения в точке:" + Environment.NewLine);
                                }
                                this.textBox.AppendText("x1 = " + this.sx.ToString() + Environment.NewLine);
                                this.textBox.AppendText("x2 = " + this.sy.ToString() + Environment.NewLine);
                                this.textBox.AppendText(Environment.NewLine);
                                this.textBox.AppendText("Значение целевой функции:" + Environment.NewLine);
                                this.textBox.AppendText("f(x1, x2) = " + maxValue.ToString());
                            }
                            return;
                        }
                        item = list[num4];
                        if (this.PointBelongsRestDomain(item))
                        {
                            float num5 = (item.X * this.C[0]) + (item.Y * this.C[1]);
                            if (((maxValue >= num5) || (this.taskType != 0)) ? ((maxValue > num5) && (this.taskType == 1)) : true)
                            {
                                this.sx = item.X;
                                this.sy = item.Y;
                                this.taskSolved = true;
                                maxValue = (item.X * this.C[0]) + (item.Y * this.C[1]);
                                if (Math.Abs(item.X) > this.Maxsx)
                                {
                                    this.Maxsx = Math.Abs(item.X);
                                }
                                if (Math.Abs(item.Y) > this.Maxsy)
                                {
                                    this.Maxsy = Math.Abs(item.Y);
                                }
                            }
                        }
                        num4++;
                    }
                }
                if (!(this.A[index, 0] == 0f))
                {
                    item = new PointF
                    {
                        X = this.B[index] / this.A[index, 0],
                        Y = 0f
                    };
                    list.Add(item);
                }
                if (!(this.A[index, 1] == 0f))
                {
                    item = new PointF
                    {
                        X = 0f,
                        Y = this.B[index] / this.A[index, 1]
                    };
                    list.Add(item);
                }
                int num3 = 0;
                while (true)
                {
                    if (num3 >= this.m)
                    {
                        index++;
                        break;
                    }
                    bool flag4 = index != num3;
                    if (flag4 && this.LineToPoint(this.A[index, 0], this.A[index, 1], this.B[index], this.A[num3, 0], this.A[num3, 1], this.B[num3], ref item))
                    {
                        item = new PointF();
                        list.Add(item);
                    }
                    num3++;
                }
            }
        }

        private bool TestForInfinite(float minMaxValue)
        {
            bool flag = false;
            PointF item = new PointF();
            List<PointF> list = new List<PointF>();
            if (this.sx == 0f)
            {
                item = new PointF
                {
                    X = 0f,
                    Y = this.sy + 1f
                };
                list.Add(item);
                item = new PointF
                {
                    X = 0f,
                    Y = this.sy - 1f
                };
                list.Add(item);
            }
            if (this.sy == 0f)
            {
                item = new PointF
                {
                    X = this.sx + 1f,
                    Y = 0f
                };
                list.Add(item);
                item = new PointF
                {
                    X = this.sx - 1f,
                    Y = 0f
                };
                list.Add(item);
            }
            int index = 0;
            while (true)
            {
                if (index >= this.m)
                {
                    bool flag11;
                    int num7 = 0;
                    while (true)
                    {
                        if (num7 >= list.Count)
                        {
                            flag11 = flag;
                            break;
                        }
                        item = list[num7];
                        if (this.PointBelongsRestDomain(item) && ((this.taskType != 0) ? (((item.X * this.C[0]) + (item.Y * this.C[1])) < minMaxValue) : (((item.X * this.C[0]) + (item.Y * this.C[1])) > minMaxValue)))
                        {
                            flag11 = true;
                            break;
                        }
                        num7++;
                    }
                    return flag11;
                }
                bool flag4 = ((this.A[index, 0] * this.sx) + (this.A[index, 1] * this.sy)) == this.B[index];
                if (flag4 && ((this.A[index, 0] != 0f) || !(this.A[index, 1] == 0f)))
                {
                    float num2;
                    float num3;
                    float num4;
                    float num5;
                    if (!(this.A[index, 1] == 0f))
                    {
                        num2 = -1f;
                        num3 = (this.B[index] - (this.A[index, 0] * num2)) / this.A[index, 1];
                        num4 = 1f;
                        num5 = (this.B[index] - (this.A[index, 0] * num4)) / this.A[index, 1];
                    }
                    else
                    {
                        num3 = -1f;
                        num2 = (this.B[index] - (this.A[index, 1] * num3)) / this.A[index, 0];
                        num5 = 1f;
                        num4 = (this.B[index] - (this.A[index, 1] * num5)) / this.A[index, 0];
                    }
                    item = new PointF();
                    float num6 = 10f;
                    item.X = num2 + ((num4 - num2) * num6);
                    item.Y = num3 + ((num5 - num3) * num6);
                    list.Add(item);
                    item = new PointF();
                    num6 = -10f;
                    item.X = num2 + ((num4 - num2) * num6);
                    item.Y = num3 + ((num5 - num3) * num6);
                    list.Add(item);
                }
                index++;
            }
        }
    }
}
