using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Owner:BaseEntitie
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DrugStores { get; set; }
    }
}
