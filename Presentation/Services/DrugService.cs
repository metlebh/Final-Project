using Core.Entities;
using Core.Helpers;
using Data.Contexts;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class DrugService
    {
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly DrugStoreService _drugStoreService;
        private readonly DrugRepository _drugRepository;
        public DrugService()
        {

            _drugStoreRepository = new DrugStoreRepository();
            _drugStoreService = new DrugStoreService();
            _drugRepository = new DrugRepository();
        }

        public void Creat()
        {
            if (_drugStoreRepository.GetAll().Count is 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first");
                return;
            }
            ConsoleHelper.WriteWithColor("*--- ENTER DRUG NAME---*", ConsoleColor.Blue);
            string name = Console.ReadLine();
        PriceDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUG PRICE---*", ConsoleColor.Blue);
            double price;
            bool isSucceeded = double.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Entered price is not correct format", ConsoleColor.DarkRed);
                goto PriceDes;
            }
        CountDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUG COUNT---*", ConsoleColor.Blue);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Entered count is not correct format");
            }
            if (count <= 0)
            {
                ConsoleHelper.WriteWithColor("Drug count cannot be 0 or negative", ConsoleColor.DarkRed);

            }
            _drugStoreService.GetAll();
        StoreIdDes: ConsoleHelper.WriteWithColor("*---ENTER STORE ID---*", ConsoleColor.Blue);
            int drugstoreid;
            isSucceeded = int.TryParse(Console.ReadLine(), out drugstoreid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Entered id is not correct format", ConsoleColor.DarkRed);
                goto StoreIdDes;
            }
            var drugStore = _drugStoreRepository.Get(drugstoreid);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Entered id is not exist", ConsoleColor.DarkRed);
                goto StoreIdDes;
            }
            var drug = new Drug
            {
                Name = name,
                Count = count,
                Price = (decimal)price,
                DrugStore = drugStore
            };
            drugStore.Drugs.Add(drug);
            _drugRepository.Add(drug);
            ConsoleHelper.WriteWithColor($"{drug.Name} is succesfully created", ConsoleColor.Green);
        }
        public void Update()
        {
            if (_drugRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create Drug first", ConsoleColor.DarkRed);
                return;
            }
            if (_drugStoreRepository.GetAll().Count is 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first");
                return;
            }

            GetAll();
        EnterIdDesc: ConsoleHelper.WriteWithColor("*--- ENTER DRUG ID ---*", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            Drug drug = _drugRepository.Get(id);
            if (drug is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                return;
            }
            ConsoleHelper.WriteWithColor("*--- ENTER NEW NAME ---*", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();
        PriceDes: ConsoleHelper.WriteWithColor("*--- ENTER NEW PRICE ---*", ConsoleColor.DarkCyan);
            double price;
            isSucceeded = double.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Entered price is not correct format", ConsoleColor.DarkRed);
                goto PriceDes;
            }
        CountDes: ConsoleHelper.WriteWithColor("*--- ENTER NEW COUNT ---*", ConsoleColor.DarkCyan);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed count is not correct format!", ConsoleColor.Red);
                goto CountDes;
            }
            _drugStoreService.GetAll();
        NEWID: ConsoleHelper.WriteWithColor("*--- ENTER NEW DRUGSTORE ID ---*", ConsoleColor.DarkCyan);
            int drugStoreid;
            isSucceeded = int.TryParse(Console.ReadLine(), out drugStoreid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto NEWID;
            }
            var drugstore = _drugStoreRepository.Get(drugStoreid);
            if (drugstore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto NEWID;
            }
            drug.Name = name;
            drug.Price = (decimal)price;
            drug.Count = count;
            drug.DrugStore = drugstore;


            ConsoleHelper.WriteWithColor($"{drug.Name}  is succesfully updated", ConsoleColor.Green);



        }
        public void GetAll()
        {
            var drugs = _drugRepository.GetAll();

            ConsoleHelper.WriteWithColor("*--- ALL DRUGS ---*", ConsoleColor.Cyan);

            foreach (var drug in drugs)
            {
                ConsoleHelper.WriteWithColor($"Id : {drug.Id}\nName : {drug.Name}\nPrice : {drug.Price}\nCount : {drug.Count}\nDrugstore : {drug.DrugStore.Name}", ConsoleColor.Blue);
            }
        }
        public void Delete()
        {
            if (_drugRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create Drug first", ConsoleColor.DarkRed);
                return;
            }
            if (_drugStoreRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first");
                return;
            }

            GetAll();
        DELETEID: ConsoleHelper.WriteWithColor("*--- ENTER ID FOR DELETING ---*", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto DELETEID;
            }

            Drug dbdrug = _drugRepository.Get(id);
            if (dbdrug is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                return;
            }

            _drugRepository.Delete(dbdrug);
            ConsoleHelper.WriteWithColor("Drug is succesfully deleted", ConsoleColor.Green);
        }
        public void GetDrugsByDrugstore()
        {
            if (_drugRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create Drug first", ConsoleColor.DarkRed);
                return;
            }
            if (_drugStoreRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first");
                return;
            }
            _drugStoreService.GetAll();
        EnterId: ConsoleHelper.WriteWithColor("*--- ENTER DRUGSTORE ID ---*");
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterId;
            }
            var drugStore = _drugStoreRepository.Get(id);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterId;
            }

            var drugs = _drugRepository.GetAll();
            ConsoleHelper.WriteWithColor("*--- ALL DURGS ---**",ConsoleColor.DarkYellow);

            foreach (var drug in drugStore.Drugs)
            {
                ConsoleHelper.WriteWithColor($"ID:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}",ConsoleColor.Blue);
            }
        }
        public void Filter()
        {
            var drugs = _drugRepository.GetAll();
        PriceDes: ConsoleHelper.WriteWithColor("*--- ENTER PRICE FOR FILTER ---*", ConsoleColor.DarkCyan);
            decimal price;
            bool isSucceeded = decimal.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Entered price is not correct format", ConsoleColor.DarkRed);
                goto PriceDes;
            }
            var dbdrugs=_drugRepository.GetDrugsByPrice(price);
            if (dbdrugs.Count==0)
            {
                ConsoleHelper.WriteWithColor($"There is no drug in datanase under this{price} ",ConsoleColor.DarkRed);

            }

            foreach (var drug in dbdrugs)
            {
               
               ConsoleHelper.WriteWithColor($"NAME : {drug.Name}\nCount : {drug.Count}\nPrice : {drug.Price}\nDrugstore {drug.DrugStore.Name} ", ConsoleColor.Blue);

               
            }
        }
    }
}
