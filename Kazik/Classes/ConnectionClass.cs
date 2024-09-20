using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazik.DBModel;

namespace Kazik.Classes
{
    internal class ConnectionClass
    {
        public static KazinoProjectEntities connect = new KazinoProjectEntities();
    }
}
