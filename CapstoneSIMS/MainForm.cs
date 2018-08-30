using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneSIMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var obj = new SIMSLogin();
            obj.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(obj);
        }
    }
}
