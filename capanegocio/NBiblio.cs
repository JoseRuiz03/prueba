using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capanegocio;
using System.Data;
using capadatos;

namespace capanegocio
{
    public class NBiblio
    {
        public static DataTable mostrarlibros()
        {
            DBiblio objeto = new DBiblio();
            return objeto.mostrarlibros();

        }
    }
}
