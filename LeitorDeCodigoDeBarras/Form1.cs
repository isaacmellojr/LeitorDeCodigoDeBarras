using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeitorDeCodigoDeBarras
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")] 
        private static extern bool 
            RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk); 
        [DllImport("user32.dll")] 
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id); 
        private const int HOTKEY_ID = 1; 
        private const uint MOD_ALT = 0x0001; 
        private const uint MOD_CONTROL = 0x0002; 
        private const uint MOD_SHIFT = 0x0004; 
        private const uint MOD_WIN = 0x0008;

        SelectionForm sform = new SelectionForm();

        public Form1()
        {
            InitializeComponent();
            // Registra Ctrl+Shift+B
            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_CONTROL | MOD_SHIFT, Keys.B);
            // Inicialmente escondido
            //this.Hide();
            this.Shown += MainForm_Shown;

        }
        private void MainForm_Shown(object sender, EventArgs e)
        { 
           // ReadCodBarr();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var screenArea = Screen.PrimaryScreen.WorkingArea;
            int x = (screenArea.Width - this.Width) / 2;

            this.Location = new Point(x, 10);

            int radius = 20; // raio da curva
            var path = new GraphicsPath();

            // cria retângulo arredondado
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

        }

        protected override void WndProc(ref Message m)
            {
                const int WM_HOTKEY = 0x0312;

                if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
                {
                    // Mostra o form quando a hotkey é pressionada
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    this.Activate();
                    ReadCodBarr();
                }

                base.WndProc(ref m);
            }

            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                UnregisterHotKey(this.Handle, HOTKEY_ID);
                base.OnFormClosing(e);
            }
        


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
       

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ReadCodBarr();
        }

        private void ReadCodBarr()
        {

            TxCodBarra.Text = "";

            using (sform = new SelectionForm())
            {
                if (sform.ShowDialog() == DialogResult.OK)
                {

                    Rectangle Area = sform.SelectedArea;


                    using (var bmp = ScreenCaptureService.Capture(Area))
                    {
                        /*string info = $"X: {Area.X}, Y: {Area.Y}, Width: {Area.Width}, Height: {Area.Height}";
                       MessageBox.Show($"{info}");*/
                        picDebug.Image?.Dispose();
                        picDebug.Image = (Bitmap)bmp.Clone();


                        var codigo = BarcodeReaderService.ReadFromBitmap(bmp);
                        if (codigo != null)
                        {
                            Clipboard.SetText(codigo ?? "");
                            TxCodBarra.Text = codigo;
                        }
                        else
                        {
                            TxCodBarra.Text = "Não parece um código de barras. Tente Novamente.";
                        }
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sform.Close();
            this.Hide();
        }
    }
}



