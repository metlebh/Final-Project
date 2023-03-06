using Core.Constant;
using Core.Helpers;
using Data;
using Presentation.Services;
using Presentation.Sevices;
using System;

namespace Presentation
{
    public static class Program
    {
        private readonly static AdminService _adminService;
        private readonly static OwnerService _ownerService;
        private readonly static DrugStoreService _drugStoreService;
        private readonly static DruggistService _druggistService;
        private readonly static DrugService _drugService;
        static Program()
        {
            DbInitilalizer.SeeAdmins();
            _adminService = new AdminService();
            _ownerService = new OwnerService();
            _drugStoreService = new DrugStoreService();
            _druggistService = new DruggistService();
            _drugService = new DrugService();
        }
        static void Main(string[] args)
        {
            _adminService.Authorize();
            
                while (true)
                {
                    ConsoleHelper.WriteWithColor("---Welcome---", ConsoleColor.DarkCyan);
                MainMenuDes: ConsoleHelper.WriteWithColor("\n{1} - Owners", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("{2} - Drugstores", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("{3} - Druggists", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("{4} - Drugs", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("{5} - Logout", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("\n<<--Choose option-->>", ConsoleColor.DarkBlue);


                    int number;
                    bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                    if (!isSucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Number is not coorect format", ConsoleColor.DarkRed);
                        goto MainMenuDes;
                    }
                    switch (number)
                    {
                        case (int)MainMenuOptions.Owners:
                            while (true)
                            {
                            OwnerDes: ConsoleHelper.WriteWithColor("{1} - Creat Owner ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{2} - Update Owner ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{3} - Delete Owner ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{4} - Get All Owners ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{0} - Back To Main Menu ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("\n<<--Choose option-->>", ConsoleColor.DarkBlue);

                                isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Number is not coorect format", ConsoleColor.DarkRed);
                                    goto OwnerDes;
                                }
                                switch (number)
                                {
                                    case (int)OwnerOptions.Create:
                                        _ownerService.Create();
                                        break;
                                    case (int)OwnerOptions.Delete:
                                        _ownerService.Delete();
                                        break;
                                    case (int)OwnerOptions.GetAll:
                                        _ownerService.GetAll();
                                        break;
                                    case (int)OwnerOptions.Update:
                                        _ownerService.Update();
                                        break;
                                    case (int)OwnerOptions.BackToMainMenu:
                                        goto MainMenuDes;
                                        break;
                                    default:
                                        ConsoleHelper.WriteWithColor("Your choice is not true\nTry again", ConsoleColor.DarkRed);
                                        goto OwnerDes;
                                        break;
                                }
                            }
                        case (int)MainMenuOptions.Drugstores:
                            while (true)
                            {
                            DrugDes: ConsoleHelper.WriteWithColor("{1} - Creat Drugstore ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{2} - Update Drugstore ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{3} - Delete Drugstore ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{4} - Get All Drugstores ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{5} - Sale ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{0} - Back To Main Menu ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("\n<<--Choose option-->>", ConsoleColor.DarkBlue);
                                isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Number is not coorect format", ConsoleColor.DarkRed);
                                    goto MainMenuDes;
                                }
                                switch (number)
                                {
                                    case (int)DrugStoreOptions.Create:
                                        _drugStoreService.Creat();
                                        break;
                                    case (int)DrugStoreOptions.Delete:
                                        _drugStoreService.Delete();
                                        break;
                                    case (int)DrugStoreOptions.GetAll:
                                        _drugStoreService.GetAll();
                                        break;
                                    case (int)DrugStoreOptions.Update:
                                        _drugStoreService.Update();
                                        break;
                                    case (int)DrugStoreOptions.BackToMainMenu:
                                        goto MainMenuDes;
                                    case (int)DrugStoreOptions.Sale:
                                        _drugStoreService.Sale();
                                        break;
                                    default:
                                        ConsoleHelper.WriteWithColor("Your choice is not true\nTry again", ConsoleColor.DarkRed);
                                        goto MainMenuDes;
                                        break;
                                }
                            }
                        case (int)MainMenuOptions.Druggists:
                            while (true)
                            {
                            Druggists: ConsoleHelper.WriteWithColor("{1} - Creat Druggist ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{2} - Update Druggist ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{3} - Delete Druggist ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{4} - Get All Druggist ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{0} - Back To Main Menu ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("\n<<--Choose option-->>", ConsoleColor.DarkBlue);
                                isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Number is not coorect format", ConsoleColor.DarkRed);
                                    goto MainMenuDes;
                                }
                                switch (number)
                                {
                                    case (int)DruggistOptions.Create:
                                        _druggistService.Create();
                                        break;
                                    case (int)DruggistOptions.Delete:
                                        _druggistService.Delete();
                                        break;
                                    case (int)DruggistOptions.GetAll:
                                        _druggistService.GetAll();
                                        break;
                                    case (int)DruggistOptions.Update:
                                        _druggistService.Update();
                                        break;
                                    case (int)DruggistOptions.BackToMainMenu:
                                        goto MainMenuDes;
                                        break;
                                    default:
                                        ConsoleHelper.WriteWithColor("Your choice is not true\nTry again", ConsoleColor.DarkRed);
                                        goto MainMenuDes;
                                        break;
                                }
                            }
                        case (int)MainMenuOptions.Drugs:
                            while (true)
                            {
                            Drug: ConsoleHelper.WriteWithColor("{1} - Creat Drug ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{2} - Update Drug ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{3} - Delete Drug ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{4} - Get All Drug ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{5} - Get Drugs  By DrugStore ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{6} - Filter", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("{0} - Back To Main Menu ", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("\n<<--Choose option-->>", ConsoleColor.DarkBlue);
                                isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Number is not coorect format", ConsoleColor.DarkRed);
                                    goto MainMenuDes;
                                }
                                switch (number)
                                {
                                    case (int)DrugOptions.Create:
                                        _drugService.Creat();
                                        break;
                                    case (int)DrugOptions.Delete:
                                        _drugService.Delete();
                                        break;
                                    case (int)DrugOptions.GetAll:
                                        _drugService.GetAll();
                                        break;
                                    case (int)DrugOptions.Update:
                                        _drugService.Update();
                                        break;
                                    case (int)DrugOptions.GetAllDrugsByDrugstore:
                                        _drugService.GetDrugsByDrugstore();
                                        break;
                                    case (int)DrugOptions.Filter:
                                        _drugService.Filter();
                                        break;
                                    case (int)DruggistOptions.BackToMainMenu:
                                        goto MainMenuDes;
                                        break;
                                    default:
                                        ConsoleHelper.WriteWithColor("Your choice is not true\nTry again", ConsoleColor.DarkRed);
                                        goto MainMenuDes;
                                        break;
                                }







                            }


                    }
                }
            

        
        }
    }
}
