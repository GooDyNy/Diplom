using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prof
{
    public partial class Nastroiki : Form
    {
        public Nastroiki()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Переход в настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            EditPar editPar = new EditPar();
            editPar.Show();
            Hide();
        }
    }
}
