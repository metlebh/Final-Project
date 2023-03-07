using Core.Entities;
using Core.Helpers;
using Data.Repostories.Concret;
using System;

namespace Presentation.Sevices
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;
        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }
        public Admin Authorize()
        {

        LoginDes: ConsoleHelper.WriteWithColor("WELCOME DRUGSTORE PLEASE LOGIN", ConsoleColor.DarkYellow);
            
            ConsoleHelper.WriteWithColor("*--- USER NAME ---*", ConsoleColor.DarkYellow);
            string username = Console.ReadLine() ;
            ConsoleHelper.WriteWithColor("*--- USER PASSWORD ---*", ConsoleColor.DarkYellow);
            string password = Console.ReadLine();

            var admin = _adminRepository.GetByUSerNameAndPassword(username, password);
            if (admin is null)
            {
                ConsoleHelper.WriteWithColor("Username or password wrong", ConsoleColor.DarkRed);
                goto LoginDes;
            }
            return admin;

        }
    }
}
