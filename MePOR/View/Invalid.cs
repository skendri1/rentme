using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MePOR.View
{
    public partial class Invalid : Form
    {
        public Invalid()
        {
            InitializeComponent();
        }

        private void RetryButtonClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
