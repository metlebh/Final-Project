using Core.Entities;
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
    public class DruggistService
    {
        private readonly DrugStoreService _drugStoreService;
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly DruggistRepository _druggistRepository;
        public DruggistService()
        {
            _drugStoreService = new DrugStoreService();
            _drugStoreRepository = new DrugStoreRepository();
            _druggistRepository = new DruggistRepository();
        }

        public void Create()
        {
            if (true)
            {
                _drugStoreRepository.GetAll();
                if (_drugStoreRepository.GetAll().Count == 0)
                {
                NotFoundDes: ConsoleHelper.WriteWithColor("*---There is no drugstore, you want to create-- - *\n ||| y or n ||| ", ConsoleColor.DarkGray);
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
                        _drugStoreService.Creat();
                    }
                    if (decision == 'n')
                    {
                        return;
                    }
                }
                else
                {
                    ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST NAME ---*", ConsoleColor.DarkCyan);
                    string name = Console.ReadLine();
                    ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST SURNAME ---*", ConsoleColor.DarkCyan);
                    string surname = Console.ReadLine();
                    AgeDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST AGE ---*", ConsoleColor.DarkCyan);
                    int age;
                    bool isSucceeded = int.TryParse(Console.ReadLine(), out age);
                    if (!isSucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Age is not correct format", ConsoleColor.DarkRed);
                        goto AgeDes;
                    }
                    if (age>65)
                    {
                        ConsoleHelper.WriteWithColor("The druggist cannot be older than 65", ConsoleColor.DarkRed);
                        goto AgeDes;
                    }
                    ExperienceDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST EXPERIENCE ---*", ConsoleColor.DarkCyan);
                    int experience;
                    isSucceeded = int.TryParse(Console.ReadLine(),out experience);
                    if (!isSucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Age is not correct format", ConsoleColor.DarkRed);
                        goto ExperienceDes;
                    }
                    if (experience>age-18)
                    {
                        ConsoleHelper.WriteWithColor("Experience cannot be greater than age", ConsoleColor.DarkRed);
                        goto ExperienceDes;
                    }
                    _drugStoreService.GetAll();
                    StoreIdDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUG STORE ID ---*", ConsoleColor.DarkCyan);
                    int drugStoreId;
                    isSucceeded = int.TryParse(Console.ReadLine(),out drugStoreId);
                    if (!isSucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Store Id is not correct format", ConsoleColor.DarkRed);
                        goto StoreIdDes;
                    }
                    var drugStore = _drugStoreRepository.Get(drugStoreId);
                    if (drugStore is  null)
                    {
                        ConsoleHelper.WriteWithColor("Inputed ID is not exsist");
                        goto StoreIdDes;
                    }
                    var druggist = new Druggist
                    {
                        Name = name,
                        Surname = surname,
                        Age = age,
                        Experience = experience,
                        DrugStore = drugStore,
                    };
                    drugStore.Druggists.Add(druggist);
                    _druggistRepository.Add(druggist);
                    ConsoleHelper.WriteWithColor($"{druggist.Name} {druggist.Surname} is succesfuly created", ConsoleColor.DarkGreen);
                    
                }
            }
        }
        public void GetAll()
        {
            var druggists = _druggistRepository.GetAll();
            ConsoleHelper.WriteWithColor("*--- ALL DRUGISTS ---*", ConsoleColor.DarkCyan);
            if (druggists.Count==0)
            {
                ConsoleHelper.WriteWithColor("There is no any Druggists", ConsoleColor.DarkRed);
                return;
            }
            foreach (var druggist in druggists)
            {
                ConsoleHelper.WriteWithColor($"ID : {druggist.Id}\nName : {druggist.Name}\nSurname : {druggist.Surname}\nAge : {druggist.Age}\nDrugStore : {druggist.DrugStore.Name}", ConsoleColor.DarkYellow);
            }
        }
        public void Delete()
        {
            GetAll();
            if (_druggistRepository.GetAll().Count==0)
            {
                ConsoleHelper.WriteWithColor("There no any Druggists", ConsoleColor.DarkRed);
                return;
            }
            DeleteDes: ConsoleHelper.WriteWithColor("Enter Druggist ID", ConsoleColor.DarkCyan);

            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format", ConsoleColor.DarkRed);
                goto DeleteDes;
            }
            var dbDruggist = _druggistRepository.Get(id);
            if (dbDruggist is  null)
            {
                ConsoleHelper.WriteWithColor("There is no any Druggist this ID", ConsoleColor.DarkRed);
                goto DeleteDes;
            }
            _druggistRepository.Delete(dbDruggist);
            ConsoleHelper.WriteWithColor("Druggist is succesfully deleted", ConsoleColor.DarkGreen);

        }
        public void Update()
        {
            GetAll();
            if (_druggistRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There no any Druggists", ConsoleColor.DarkRed);
                return;
            }
        UpdateDes: ConsoleHelper.WriteWithColor("Enter Druggist ID", ConsoleColor.DarkCyan);

            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format", ConsoleColor.DarkRed);
                goto UpdateDes;
            }
            var druggist = _druggistRepository.Get(id);
            if (druggist is null)
            {
                ConsoleHelper.WriteWithColor("There no any Druggists this ID", ConsoleColor.DarkRed);
                goto UpdateDes;
            }

            ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST NEW NAME ---*", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST NEW SURNAME ---*", ConsoleColor.DarkCyan);
            string surname = Console.ReadLine();
            AgeDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST NEW AGE ---*", ConsoleColor.DarkCyan);
            int age;
            isSucceeded = int.TryParse(Console.ReadLine(), out age);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed age is not correct format", ConsoleColor.DarkRed);
                goto AgeDes;
            }
            if (age>65)
            {
                ConsoleHelper.WriteWithColor("The druggist cannot be older than 65", ConsoleColor.DarkRed);
                goto AgeDes;
            }
        ExperDes: ConsoleHelper.WriteWithColor("*--- ENTER DRUGGIST NEW EXPERIENCE ---*", ConsoleColor.DarkCyan);
            int experience;
            isSucceeded = int.TryParse(Console.ReadLine(), out experience);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Age is not correct format", ConsoleColor.DarkRed);
                goto ExperDes;
            }
            if (experience > age - 18)
            {
                ConsoleHelper.WriteWithColor("Experience cannot be greater than age", ConsoleColor.DarkRed);
                goto ExperDes;
            }
            _drugStoreService.GetAll();
        StoreIdDes: ConsoleHelper.WriteWithColor("*--- ENTER NEW DRUG STORE ID ---*", ConsoleColor.DarkCyan);
            int drugStoreId;
            isSucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Store Id is not correct format", ConsoleColor.DarkRed);
                goto StoreIdDes;
            }
            var drugStore = _drugStoreRepository.Get(drugStoreId);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exsist",ConsoleColor.DarkRed);
            }
            druggist.Name = name;
            druggist.Surname = surname;
            druggist.Age = age;
            druggist.Experience = experience;
            druggist.DrugStore = drugStore;
            _druggistRepository.Update(druggist);
            ConsoleHelper.WriteWithColor("Druggist is succeduly updated", ConsoleColor.DarkGreen);







        }
    }
}
