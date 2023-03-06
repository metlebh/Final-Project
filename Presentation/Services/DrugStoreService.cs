using Core.Entities;
using Core.Extension;
using Core.Helpers;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class DrugStoreService
    {
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly OwnerRepository _ownerRepository;
        private readonly OwnerService _ownerService;
        private readonly DrugRepository _drugRepository;
        public DrugStoreService()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _ownerService = new OwnerService();
            _drugRepository = new DrugRepository();
        }

        public void GetAll()
        {
            if (_ownerRepository.GetAll().Count == 0)
            {
            NewGroupDes: ConsoleHelper.WriteWithColor("*--- There is no owner, you want to create---*\n |||y or n|||", ConsoleColor.Red);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.Red);
                    goto NewGroupDes;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.Red);
                    goto NewGroupDes;
                }

                if (decision == 'y')
                {
                    _ownerService.Create();
                }
                if (decision == 'n')
                {
                    return;
                }
            }
            else
            {
                var drugstores = _drugStoreRepository.GetAll();
                ConsoleHelper.WriteWithColor("*--- ALL DRUGSTORES ---*", ConsoleColor.DarkCyan);

                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteWithColor($"ID : {drugstore.Id}\nName : {drugstore.Name}\nAdress : {drugstore.Address}\nDrugstoresOwner : {drugstore.Owner.Name}\nDrugstore Number : {drugstore.ContactNumber}\nDrug Store Email : {drugstore.Email}", ConsoleColor.Blue);
                }

            }
        }
        public void Delete()
        {
            GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
            NewGroupDes: ConsoleHelper.WriteWithColor("*--- There is no owner, you want to create---*\n |||y or n|||", ConsoleColor.Red);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.Red);
                    goto NewGroupDes;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.Red);
                    goto NewGroupDes;
                }

                if (decision == 'y')
                {
                    _ownerService.Create();
                }
                if (decision == 'n')
                {
                    return;
                }
            }
            else
            {
            IdDes: ConsoleHelper.WriteWithColor("*--- ENTER ID ---*", ConsoleColor.DarkCyan);
                int id;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not coorect format", ConsoleColor.DarkRed);
                    goto IdDes;
                }
                var DrugStore = _drugStoreRepository.Get(id);
                if (DrugStore is null)
                {
                    ConsoleHelper.WriteWithColor("Owner not found this ID", ConsoleColor.DarkRed);
                    goto IdDes;
                }
                else
                {
                    _drugStoreRepository.Delete(DrugStore);
                    ConsoleHelper.WriteWithColor($"{DrugStore.Id} {DrugStore.Name} succesfuly deleted", ConsoleColor.DarkGreen);

                }
            }
        }
        public void Creat()
        {
            _ownerRepository.GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
            NotFoundDes: ConsoleHelper.WriteWithColor("*---There is no owner, you want to create-- - *\n ||| y or n ||| ", ConsoleColor.DarkGray);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.Red);
                    goto NotFoundDes;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.Red);
                    goto NotFoundDes;
                }

                if (decision == 'y')
                {
                    _ownerService.Create();
                }
                if (decision == 'n')
                {
                    return;
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor("*---- ENTER DRUGSTORE NAME ----*", ConsoleColor.DarkCyan);
                string name = Console.ReadLine();
                ConsoleHelper.WriteWithColor("*---- ENTER DRUGSTORE ADRESS ----*", ConsoleColor.DarkCyan);
                string address = Console.ReadLine();
                ConsoleHelper.WriteWithColor("*---- ENTER DRUGSTORE NUMBER ----*", ConsoleColor.DarkCyan);
                int contactnumber;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out contactnumber);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("Entered number is not correct format", ConsoleColor.DarkRed);
                }
            EmailDes: ConsoleHelper.WriteWithColor("*---- ENTER DRUGSTORE EMAIL ----*", ConsoleColor.DarkCyan);
                string email = Console.ReadLine();
                if (email.IsEmail() == false)
                {
                    ConsoleHelper.WriteWithColor("Email is not correct format", ConsoleColor.DarkRed);
                    goto EmailDes;
                }

                ConsoleHelper.WriteWithColor("*---- ENTER OWNER ID ----*", ConsoleColor.DarkCyan);
                _ownerService.GetAll();
                int id;
                isSucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not coorect format", ConsoleColor.DarkRed);
                }
                var owner = _ownerRepository.Get(id);
                if (owner is null)
                {
                    ConsoleHelper.WriteWithColor("There is no any owner this Id", ConsoleColor.DarkRed);
                }
                var drugStore = new DrugStore
                {
                    Name = name,
                    Address = address,
                    Email = email,
                    Owner = owner,
                    ContactNumber = contactnumber
                };
                _drugStoreRepository.Add(drugStore);
                ConsoleHelper.WriteWithColor($"{drugStore.Name} drugstore is succesfully created");

            }

        }
        public void Update()
        {
            GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
            NewGroupDes: ConsoleHelper.WriteWithColor("*---There is no owner, you want to create-- - *\n ||| y or n ||| ", ConsoleColor.DarkGray);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.Red);
                    goto NewGroupDes;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.Red);
                    goto NewGroupDes;
                }

                if (decision == 'y')
                {
                    _ownerService.Create();
                }
                if (decision == 'n')
                {
                    return;
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor("ENTER NEW NAME", ConsoleColor.DarkCyan);
                string name = Console.ReadLine();
                ConsoleHelper.WriteWithColor("ENTER NEW ADRESS", ConsoleColor.DarkCyan);
                string adress = Console.ReadLine();
            NumDes: ConsoleHelper.WriteWithColor("ENTER NEW CONTACTNUMBER", ConsoleColor.DarkCyan);
                int contactnumber;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out contactnumber);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("Number is not correct format", ConsoleColor.DarkRed);
                    goto NumDes;
                }
                ConsoleHelper.WriteWithColor("ENTER NEW EMAIL", ConsoleColor.DarkCyan);
                string email = Console.ReadLine();
                ConsoleHelper.WriteWithColor("ENTER NEW Druggists", ConsoleColor.DarkCyan);
                string druggists = Console.ReadLine();
                var drugStore = new DrugStore();
                drugStore.Name = name;
                drugStore.Address = adress;
                drugStore.ContactNumber = contactnumber;
                drugStore.Email = email;
                _drugStoreRepository.Update(drugStore);
                ConsoleHelper.WriteWithColor("Store is succesfuly updated", ConsoleColor.DarkGreen);





            }
        }
        public void Sale()
        {
            var drugstores = _drugStoreRepository.GetAll();
            foreach (var drugstore in drugstores)
            {
                ConsoleHelper.WriteWithColor($"ID : {drugstore.Id} Name : {drugstore} ");
            }
        StoreIdDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUGSTORE ID", ConsoleColor.DarkCyan);
            int drugstoreid;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out drugstoreid);
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
           ConsoleHelper.WriteWithColor("*--- ALL DRUGS---*", ConsoleColor.DarkCyan);

            foreach (var drug in drugStore.Drugs)
            {
                ConsoleHelper.WriteWithColor($"Id : {drug.Id}\nName : {drug.Name}\nPrice : {drug.Price}\nCount : {drug.Count}\nDrugstore : {drugStore.Name}", ConsoleColor.Blue);
            }
            DrugID: ConsoleHelper.WriteWithColor("*--- ENTER DRUG ID ---*", ConsoleColor.Cyan);
            int id;
            isSucceeded= int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Entered id is not correct format", ConsoleColor.DarkRed);
                goto DrugID;
            }
            var dbDrug = _drugRepository.Get(id);
            if (dbDrug is null)
            {
                ConsoleHelper.WriteWithColor("Entered id is not exist", ConsoleColor.DarkRed);
                goto StoreIdDes;
            }
            countdes: ConsoleHelper.WriteWithColor("*--- ENTER COUNT ---*", ConsoleColor.Cyan);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (count>dbDrug.Count)
            {
                ConsoleHelper.WriteWithColor($"You can buy {dbDrug.Count} {dbDrug.Name}",ConsoleColor.DarkRed);
                goto countdes;
            }
            int sum;
            sum = (int)(count * dbDrug.Price);
            if (count<=dbDrug.Count)
            {
                ConsoleHelper.WriteWithColor($"Your Order\nName : {dbDrug.Name}\nCount : {count}\nPrice : {dbDrug.Price}\nTotal Price = {sum}", ConsoleColor.Green);
               
            }
            dbDrug.Count = dbDrug.Count - count;

        }



    }


}

