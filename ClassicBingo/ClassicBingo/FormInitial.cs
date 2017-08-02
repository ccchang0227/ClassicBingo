using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicBingo
{
    public partial class FormInitial : Form
    {
        public FormInitial()
        {
            InitializeComponent();

            for (int i = 0; i < ButtonCnt; i++)
            {
                Button btn = new Button()
                {
                    Text = "",
                    FlatStyle = FlatStyle.System,
                    Parent = tableLayout,
                    Dock = DockStyle.Fill,
                    Tag = i + 1,
                    Font = new Font("新細明體", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TabStop = false
                };
                btn.Click += OnButtonClick;

                buttons.Add(btn);
            }
            
            startInt = 1;

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Rectangle rc = new Rectangle(1, 
                1, 
                this.Size.Width - 2, 
                this.Size.Height - 2);
            e.Graphics.DrawRectangle(Pens.Red, rc);
        }

        private static int ButtonCnt
        {
            get
            {
                return 25;
            }
        }
        private List<Button> buttons = new List<Button>(capacity: ButtonCnt);
        private int startInt;

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = "" + (startInt++);

            btn.Enabled = false;
        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            foreach (Button btn in buttons)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
        }

        private void ButtonRand_Click(object sender, EventArgs e)
        {
            List<Button> cloneButtons = new List<Button>(buttons);
            int start = 1;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < ButtonCnt; i++)
            {
                if (cloneButtons.Count == 0)
                {
                    break;
                }

                int r = random.Next(cloneButtons.Count);
                Button btn = cloneButtons.ElementAt(r);
                btn.Text = "" + (start++);

                btn.Enabled = false;
                cloneButtons.Remove(btn);
            }

        }
    }
}
