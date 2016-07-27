using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirrors_Edge_Catalyst_TP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nsControlButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckGameStatus_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MirrorsEdgeCatalyst").Length > 0)
            {
                GameStatus.Text = "RUNNING";
                GameStatus.ForeColor = Color.Green;
            }
            else
            {
                GameStatus.Text = "NOT RUNNING";
                GameStatus.ForeColor = Color.Red;
            }
        }
    }
}
