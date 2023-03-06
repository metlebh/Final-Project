﻿using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class DruggistRepository : IDruggistRepository
    {
        static int id;
        public void Add(Druggist druggist)
        {
            id++;
            druggist.Id = id;
            DbContext.Druggists.Add(druggist);
        }

        public void Delete(Druggist druggist)
        {
            DbContext.Druggists.Remove(druggist);
        }

        public Druggist Get(int id)
        {
           return DbContext.Druggists.FirstOrDefault(d => d.Id == id);
        }

        public List<Druggist> GetAll()
        {
            return DbContext.Druggists;
        }

        public void Update(Druggist druggist)
        {
            var DbDruggist = DbContext.Druggists.FirstOrDefault(d => d.Id == id);
            if (DbDruggist is not null)
            {
                DbDruggist.Name = druggist.Name;
                DbDruggist.Surname = druggist.Surname;
                DbDruggist.Age = druggist.Age;
                DbDruggist.Experience = druggist.Experience;
                DbDruggist.DrugStore = druggist.DrugStore;
            }
        }
    }
}
