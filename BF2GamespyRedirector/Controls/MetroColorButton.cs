using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;

namespace BF2GamespyRedirector
{
    public class MetroColorButton : MetroFramework.Controls.MetroTextBox.MetroTextButton, IMetroControl
    {
        #region Fields

        private bool isHovered = false;
        private bool isPressed = false;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
        }

        #endregion

        private Bitmap _image = null;

        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
                if (value == null) return;
                _image = ApplyInvert(new Bitmap(value));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = MetroPaint.ForeColor.Button.Press(Theme);
            Color backColor = MetroPaint.GetStyleColor(Style);

            // Apply button shading
            if (isHovered && !isPressed && Enabled)
            {
                backColor = ControlPaint.Light(backColor, float.Parse("0.25"));
            }
            else if (isHovered && isPressed && Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Press(Theme);
                backColor = MetroPaint.GetStyleColor(Style);
            }
            else if (!Enabled)
            {
                foreColor = MetroPaint.ForeColor.Button.Disabled(Theme);
                backColor = MetroPaint.BackColor.Button.Disabled(Theme);
            }
            else
            {
                foreColor = MetroPaint.ForeColor.Button.Press(Theme);
            }

            e.Graphics.Clear(backColor);
            Font buttonFont = MetroFonts.Button(MetroButtonSize.Small, MetroButtonWeight.Bold);
            TextRenderer.DrawText(e.Graphics, Text, buttonFont, ClientRectangle, foreColor, backColor, 
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
            );
        }

        #region Mouse Methods

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            Invalidate();

            base.OnMouseLeave(e);
        }

        #endregion
    }
}
