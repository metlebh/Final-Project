using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class DrugRepository : IDrugRepository
    {
        static int id;
        public void Add(Drug drug)
        {
            id++;
            drug.Id = id;
            DbContext.Drugs.Add(drug);
        }

        public void Delete(Drug drug)
        {
            DbContext.Drugs.Remove(drug);
        }

        public Drug Get(int id)
        {
            return DbContext.Drugs.FirstOrDefault(d => d.Id == id);
        }

        public List<Drug> GetAll()
        {
            return DbContext.Drugs;
        }

        public void Update(Drug drug)
        {
            var dbDrug = DbContext.Drugs.FirstOrDefault(d=>d.Id==id);
            if (dbDrug is not null)
            {
                dbDrug.Name = drug.Name;
                dbDrug.Price = drug.Price;
                dbDrug.Count = drug.Count;
                dbDrug.DrugStore = drug.DrugStore;

            }
        }

      
            public List<Drug> GetDrugsByPrice(decimal price)
        {
            return DbContext.Drugs.Where(d => d.Price <= price).ToList();
        }
    }
}
