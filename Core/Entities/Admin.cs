using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Admin:BaseEntitie
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
