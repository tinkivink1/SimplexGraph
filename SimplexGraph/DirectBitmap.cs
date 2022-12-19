namespace GraphSimplex
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class DirectBitmap : IDisposable
    {
        public DirectBitmap(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Bits = new int[width * height];
            this.BitsHandle = GCHandle.Alloc(this.Bits, GCHandleType.Pinned);
            this.Bitmap = new System.Drawing.Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, this.BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            if (!this.Disposed)
            {
                this.Disposed = true;
                this.Bitmap.Dispose();
                this.BitsHandle.Free();
            }
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * this.Width);
            return Color.FromArgb(this.Bits[index]);
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * this.Width);
            this.Bits[index] = colour.ToArgb();
        }

        public System.Drawing.Bitmap Bitmap { get; private set; }

        public int[] Bits { get; private set; }

        public bool Disposed { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }
    }
}
