using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class Usuario
    {
        slEntities db;
        public Usuario()
        {
            db = new slEntities();
        }
        public void Dispose()
        {
            db.Dispose();
        }

    }
}
