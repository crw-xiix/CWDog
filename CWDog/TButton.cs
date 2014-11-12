using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWDog
{
    public class TButton : ButtonBase, IButtonControl
    {
        private Color mborderColor = Color.Black;
        private int mBorderWidth = 1;
        private int mRadius = -1;

        [Browsable(true)]
        [Category("Appearance")]
        public int Radius
        {
            get { return mRadius; }
            set
            {
                mRadius = value;
                Refresh();
            }
        }


        //So it's visible in designer
        [Browsable(true)]
        [Category("Appearance")]
        public Color BorderColor
        {
            get
            {

                return mborderColor;
            }
            set
            {
                mborderColor = value;
                Refresh();
            }
        }
        //So it's visible in designer
        [Browsable(true)]
        [Category("Appearance")]
        public int BorderWidth
        {
            get
            {

                return mBorderWidth;
            }
            set
            {
                mBorderWidth = value;
                Refresh();
            }

        }
        private DialogResult myDialogResult;
        public TButton()
        {
            BorderWidth = 0;
            this.SetStyle(
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.ResizeRedraw |
                        ControlStyles.UserPaint, true);
            //default this to left side for compatibility;
            this.ImageAlign = ContentAlignment.MiddleLeft;

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        bool mHover = false;
        bool mouseDown = false;
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            mouseDown = true;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            mouseDown = false;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs eventargs)
        {

            mHover = true;
            this.Refresh();
            base.OnMouseEnter(eventargs);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            mHover = false;
            this.Refresh();
            base.OnMouseCaptureChanged(e);
        }

        public int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .241 +
            c.G * c.G * .691 +
            c.B * c.B * .068);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int dRadius = Height / 2;
            if (Radius >= 0) dRadius = Radius;
            //This part copies the background so we can be transparent
            if (this.Parent != null)
            {
                GraphicsContainer cstate = pevent.Graphics.BeginContainer();
                pevent.Graphics.TranslateTransform(-this.Left, -this.Top);
                Rectangle clip = pevent.ClipRectangle;
                clip.Offset(this.Left, this.Top);
                PaintEventArgs pe = new PaintEventArgs(pevent.Graphics, clip);

                //paint the container's bg
                InvokePaintBackground(this.Parent, pe);
                //paints the container fg
                InvokePaint(this.Parent, pe);
                //restores graphics to its original state
                pevent.Graphics.EndContainer(cstate);
            }
            //This draws the button
            Graphics g = pevent.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;

            //This is to get the paint color based on hover, down status
            Color fillColor = Color.FromArgb(255, BackColor);
            if (mouseDown)
            {
                fillColor = GrHelper.MergeColor(fillColor, Color.Black, 4);
            }
            else
            {
                if (mHover)
                {
                    fillColor = GrHelper.MergeColor(fillColor, Color.White, 4);
                }
            }
            //Make it fit - 1 pixel less
            Rectangle temp = Rectangle.Inflate(ClientRectangle, -1, -1);
            //Inside gradient color
            LinearGradientBrush insideC = new LinearGradientBrush(
                Rectangle.Inflate(temp, 0, -(Height / 4)),
                GrHelper.MergeColor(fillColor, Color.White, 9),
                GrHelper.MergeColor(fillColor, Color.Black, 9),
                LinearGradientMode.Vertical);
            insideC.WrapMode = WrapMode.TileFlipX;
            //insideC.Blend = 


            //Border color
            LinearGradientBrush borderC = new LinearGradientBrush(
                temp,
                GrHelper.MergeColor(BorderColor, Color.Black, 9),
                GrHelper.MergeColor(BorderColor, Color.White, 9),
                LinearGradientMode.Vertical);
            //GrHelper.DrawRoundedRectangle(g, temp, Height / 2, new Pen(borderC,mBorderWidth), insideC);
            if (BorderWidth > 0)
            //if (true) //Force borderless buttons for this
            {

                GrHelper.DrawRoundedRectangle(g, temp, dRadius, new Pen(borderC, mBorderWidth), insideC);
            }
            else
            {
                GrHelper.DrawRoundedRectangle(g, temp, dRadius, new Pen(insideC, 1), insideC);
            }
            //new Moodgfx stuff
            Rectangle highlight = Rectangle.Inflate(temp, 0, 0);
            highlight.Height = highlight.Height * 5 / 8;
            highlight.Width -= 4;
            highlight.X += 2;
            highlight.Y += 2;




            LinearGradientBrush hC = new LinearGradientBrush(
                highlight,
                Color.FromArgb(0x40, 255, 255, 255),
                Color.FromArgb(0x01, 255, 255, 255),
                LinearGradientMode.Vertical);
            hC.WrapMode = WrapMode.TileFlipX;

            GraphicsPath ourPath = GrHelper.GetRoundedRectanglePath(highlight, dRadius - 1);
            g.FillPath(hC, ourPath);



            //This will keep the drawing in the area - notouside.
            g.SetClip(ourPath);
            highlight.Y -= highlight.Height / 2;

            int w = highlight.Width;
            highlight.X = highlight.X - w / 2;
            highlight.Width = w * 2;


            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(highlight);

            // Use the path to construct a brush.
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);

            // Set the color at the center of the path to blue.
            pthGrBrush.CenterColor = Color.FromArgb(128, 255, 255, 255);

            // Set the color along the entire boundary  
            // of the path to aqua.
            Color[] colors = { Color.FromArgb(0, 255, 255, 255) };
            pthGrBrush.SurroundColors = colors;

            g.FillEllipse(pthGrBrush, highlight);
            //To show the fill area.
            //g.DrawEllipse(new Pen(Color.White), highlight);

            Rectangle botOverlay = new Rectangle();
            botOverlay.X = temp.X;
            botOverlay.Y = temp.Y + ((temp.Height * 5) / 6);
            botOverlay.Width = temp.Width;
            botOverlay.Height = temp.Height / 6;

            GraphicsPath botPath = new GraphicsPath();
            botPath.AddEllipse(botOverlay);

            PathGradientBrush pthGrBrushBot = new PathGradientBrush(path);
            pthGrBrushBot.CenterColor = Color.FromArgb(128, 255, 255, 255);

            // Set the color along the entire boundary  
            // of the path to aqua.
            Color[] colors2 = { Color.FromArgb(0, 255, 255, 255) };
            pthGrBrushBot.SurroundColors = colors2;
            g.FillEllipse(pthGrBrushBot, botOverlay);
            //g.DrawEllipse(new Pen(Color.White), botOverlay);

            DrawImage(g);
            DrawText(g);

        }

        public virtual void DrawText(Graphics g)
        {
            Rectangle temp = Rectangle.Inflate(ClientRectangle, -4, -4);
            //Now to draw our text on the screen...............
            StringFormat sf = new StringFormat();
            //override for now - no text align
            //override for now - no image align
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;


            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            Font ourFont = Font;
            if (!Enabled) ourFont = new Font(Font, FontStyle.Strikeout);
            Color foreColor = (PerceivedBrightness(BackColor) > 130 ? Color.Black : Color.White);
            LinearGradientBrush textC = new LinearGradientBrush(
                temp,
                GrHelper.MergeColor(foreColor, Color.White, 5),
                GrHelper.MergeColor(foreColor, Color.Black, 5),
                LinearGradientMode.Vertical);
            g.SetClip(this.ClientRectangle);
            //Image first
            DrawImage(g);
            g.DrawString(Text, ourFont, textC, ClientRectangle, sf);
        }

        public virtual void DrawImage(Graphics g)
        {
            int x = 0, y = 0;
            int margin = 4;
            if (this.Image == null) return;

            int top = 0x00f;
            int mid = 0x0f0;
            int bot = 0xf00;
            int left = 0x111;
            int hmid = 0x222;
            int right = 0x444;

            if ((((int)ImageAlign) & top) > 0) y = margin;
            if ((((int)ImageAlign) & mid) > 0) y = (Height - Image.Height) / 2;
            if ((((int)ImageAlign) & bot) > 0) y = Height - margin - Image.Height;

            if ((((int)ImageAlign) & left) > 0) x = margin;
            if ((((int)ImageAlign) & hmid) > 0) x = (Width - Image.Width) / 2;
            if ((((int)ImageAlign) & right) > 0) x = Width - margin - Image.Width;

            g.DrawImage(Image, new Point(x, y));

        }
        //This is basic button stuff, nothing custom
        public DialogResult DialogResult
        {
            get
            {
                return this.myDialogResult;
            }

            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    this.myDialogResult = value;
                }
            }
        }

        // Add implementation to the IButtonControl.NotifyDefault method. 
        public void NotifyDefault(bool value)
        {
            if (this.IsDefault != value)
            {
                this.IsDefault = value;
            }
        }

        // Add implementation to the IButtonControl.PerformClick method. 
        public void PerformClick()
        {
            if (this.CanSelect)
            {
                this.OnClick(EventArgs.Empty);
            }
        }



    }

}
