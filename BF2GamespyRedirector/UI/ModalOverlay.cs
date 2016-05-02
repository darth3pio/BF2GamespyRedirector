using System;
using System.Drawing;
using System.Windows.Forms;

namespace BF2GamespyRedirector
{
    public sealed class ModalOverlay : Form
    {
        public ModalOverlay(Form parent, double Opacity = 0.50)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.Opacity = Opacity;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = parent.ClientSize;
            this.Location = parent.PointToScreen(Point.Empty);
            parent.Move += AdjustPosition;
            parent.SizeChanged += AdjustPosition;
        }

        private void AdjustPosition(object sender, EventArgs e)
        {
            Form parent = sender as Form;
            this.Location = parent.PointToScreen(Point.Empty);
            this.ClientSize = parent.ClientSize;
        }
    }
}
