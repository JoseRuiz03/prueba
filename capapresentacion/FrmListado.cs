using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capanegocio;

namespace capapresentacion
{
    public partial class FrmListado : Form
    {
        public FrmListado()
        {
            InitializeComponent();
            mostrarlibros();
        }


        private void mostrarlibros()
        {
            this.datalistado.DataSource = NBiblio.mostrarlibros();
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
