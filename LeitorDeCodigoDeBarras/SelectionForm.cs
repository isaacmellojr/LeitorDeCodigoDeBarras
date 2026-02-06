using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeitorDeCodigoDeBarras
{
    public partial class SelectionForm : Form
    {
        public Rectangle SelectedArea { get; private set; }


        private Point _start;
        private Rectangle _selection;
        private bool _dragging;
        public SelectionForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.50;
            this.Cursor = Cursors.Cross;
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.None;
            this.TransparencyKey = Color.Magenta;
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void SelectionForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _dragging = true;
            _start = e.Location;
            _selection = new Rectangle(e.Location, Size.Empty);
        }

        private void SelectionForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging) return;

            var x = Math.Min(e.X, _start.X);
            var y = Math.Min(e.Y, _start.Y);
            var w = Math.Abs(e.X - _start.X);
            var h = Math.Abs(e.Y - _start.Y);

            _selection = new Rectangle(x, y, w, h);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_selection.Width <= 0 || _selection.Height <= 0) return;

            using (var pen = new Pen(Color.Yellow, 3))
            {
                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, _selection);
                using (var brush = new SolidBrush(Color.Magenta)) 
                { 
                    e.Graphics.FillRectangle(brush, _selection); 
                }
            }
        }

        private void SelectionForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_dragging) return;

            _dragging = false;
            SelectedArea = _selection;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
