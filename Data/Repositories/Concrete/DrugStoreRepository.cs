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
    public class DrugStoreRepository : IDrugStoreRepository
    {
        static int id;
        public void Add(DrugStore drugStore)
        {
            id++;
            drugStore.Id = id;
            DbContext.DrugStores.Add(drugStore);
        }

        public void Delete(DrugStore drugStore)
        {
            DbContext.DrugStores.Remove(drugStore);
        }

        public DrugStore Get(int id)
        {
            return DbContext.DrugStores.FirstOrDefault(d => d.Id == id);
        }

        public List<DrugStore> GetAll()
        {
            return DbContext.DrugStores;
        }

        public void Update(DrugStore drugStore)
        {
            var DbDrugStore = DbContext.DrugStores.FirstOrDefault(g => g.Id == id);
            if (DbDrugStore is not null)
            {
                DbDrugStore.Name = drugStore.Name;
                DbDrugStore.Address = drugStore.Address;
                DbDrugStore.ContactNumber = drugStore.ContactNumber;
                DbDrugStore.Email = drugStore.Email;
                DbDrugStore.Druggists = drugStore.Druggists;
                DbDrugStore.Drugs = drugStore.Drugs;
            }
        }
       
        
    }
}
