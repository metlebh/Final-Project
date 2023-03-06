using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    interface IDrugRepository : IRepository<Drug>
    {
        List<Drug> GetDrugsByPrice(decimal price);
    }
}
