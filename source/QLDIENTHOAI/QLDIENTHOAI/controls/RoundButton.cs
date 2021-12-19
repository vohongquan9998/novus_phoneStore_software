using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.controls
{
    class RoundButton : Button
    {
        GraphicsPath GetRoundPath(RectangleF rect,int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            gp.AddLine(rect.X + r2, rect.Y, rect.Width - r2, rect.Y);
            gp.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            gp.AddLine(rect.Width, rect.Y + r2, rect.Width, rect.Height - r2);
            gp.AddArc(rect.X + rect.Width - radius,
                             rect.Y + rect.Height - radius, radius, radius, 0, 90);
            gp.AddLine(rect.Width - r2, rect.Height, rect.X + r2, rect.Height);
            gp.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            gp.AddLine(rect.X, rect.Height - r2, rect.X, rect.Y + r2);
            gp.CloseFigure();
            return gp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int borderRadius = 30;
            float borderThickness = 0f;
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath GraphPath = GetRoundPath(Rect, borderRadius);

            this.Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.Silver, borderThickness))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, GraphPath);
            }
        }
    }
}
