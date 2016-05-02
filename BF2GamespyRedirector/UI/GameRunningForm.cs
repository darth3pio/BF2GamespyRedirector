using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace BF2GamespyRedirector
{
    public partial class GameRunningForm : MetroForm
    {
        public GameRunningForm(Form parent)
        {
            // Create form controls
            InitializeComponent();

            // Set window position to center parent
            double H = parent.Location.Y + (parent.Height / 2) - (this.Height / 2);
            double W = parent.Location.X + (parent.Width / 2) - (this.Width / 2);
            this.Location = new Point((int)Math.Round(W, 0), (int)Math.Round(H, 0));
        }
    }
}
