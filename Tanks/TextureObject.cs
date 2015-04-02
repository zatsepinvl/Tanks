using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;


namespace Tanks
{


    [Serializable()]
    public class GraphicsObject
    {
        public static Color defaultColor = Color.Gray;
        public static Size defaultSize = new Size(10, 10);
        public static PointF defaultLocation = new PointF(10, 10);

        protected RectangleF rect;
        [Category("Фигура")]
        public Color Color { get; set; }
        public Action<Graphics> Draw;
        public GraphicsObject() 
        {
            rect = new RectangleF(defaultLocation, defaultSize);
            Color = defaultColor;
            Draw = DrawSimple;
        }
        public GraphicsObject(PointF location, SizeF size, Color color)
        {
            Color = color;
            rect = new RectangleF(location, size);
            Draw = DrawSimple;
        }
        protected virtual void DrawSimple(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), rect);
        }

        [Browsable(false)]
        public RectangleF Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        public virtual void Move(float dx, float dy)
        {
            rect.X += dx;
            rect.Y += dy;
        }
        public virtual void SetSize(float width)
        {
            rect.Size = new SizeF(width, width);
        }
        public virtual void SetSize(SizeF size)
        {
            rect.Size = size;
        }
        public virtual void SetLocation(PointF p)
        {
            rect.Location = p;
        }
        public virtual void SetLocation(float x, float y)
        {
            rect.Location = new PointF(x, y);
        }
       
        [Category("Фигура")]
        public SizeF Size
        {
            get { return rect.Size; }
            set { rect.Size = value; }
        }
        [Category("Фигура")]
        public float X
        {
            get { return rect.X; }
            set { rect.X = value; }
        }
        [Category("Фигура")]
        public float Y
        {
            get { return rect.Y; }
            set { rect.X = value; }
        }
    }

    [Serializable()]
    public class TextureObject : GraphicsObject
    {
        protected Bitmap image = null;
        bool showImage = false;
        public TextureObject():base()
        {
            
        }
        public TextureObject(PointF location, SizeF size, Color color)
            : base(location, size, color)
        {
        }

        protected virtual void DrawImage(Graphics g)
        {
            g.DrawImage(image, rect);
        }

        public virtual void LoadImage(string filename)
        {
            image = new Bitmap((int)rect.Width, (int)rect.Height);
            image = new Bitmap(filename);
            Draw = DrawImage;
        }
        public virtual void SetImage(Bitmap img)
        {
            image = img;
            Draw = DrawImage;
        }
        public void DisposeImage()
        {
            Draw = DrawSimple;
            image.Dispose();
        }

        [Category("Изображение")]
        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                Draw = DrawImage;
                ShowImage = true;
            }
        }
        [Category("Изображение")]
        public bool ShowImage
        {
            get { return showImage; }
            set
            {
                showImage = value;
                if (showImage)
                {
                    if (image != null)
                    {

                        Draw = DrawImage;

                    }
                    else
                    {
                        showImage = false;
                        Draw = DrawSimple;
                    }
                }
                else
                {
                    Draw = DrawSimple;
                }
            }
        }


    }
}
