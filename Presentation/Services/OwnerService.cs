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
    public class OwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService()
        {
            _ownerRepository = new OwnerRepository();
        }
        public void GetAll()
        {

            var owners = _ownerRepository.GetAll();
            if (owners.Count == 0)
            {
            NewGroupDes: ConsoleHelper.WriteWithColor("*--- There is no owner, you want to create---*\n |||y or n|||", ConsoleColor.DarkRed);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.DarkRed);
                    goto NewGroupDes;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.DarkRed);
                    goto NewGroupDes;
                }

                if (decision == 'y')
                {
                    Create();
                }
                if (decision == 'n')
                {
                    return;
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor("*--- ALL OWNERS ---*", ConsoleColor.DarkCyan);

                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteWithColor($"ID : {owner.Id}\nName : {owner.Name}\nSurname : {owner.Surname}", ConsoleColor.Blue);
                }

            }


        }

        

        public void Delete()
        {
            GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
            NewGroupDes: ConsoleHelper.WriteWithColor("*--- There is no owner, you want to create---*\n |||y or n|||", ConsoleColor.DarkRed);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.DarkRed);
                    goto NewGroupDes;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.DarkRed);
                    goto NewGroupDes;
                }

                if (decision == 'y')
                {
                    Create();
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
                var owner = _ownerRepository.Get(id);
                if (owner is null)
                {
                    ConsoleHelper.WriteWithColor("Owner not found this ID", ConsoleColor.DarkRed);
                    goto IdDes;
                }
                else
                {
                    _ownerRepository.Delete(owner);
                    ConsoleHelper.WriteWithColor($"{owner.Name} {owner.Surname} succesfuly deleted", ConsoleColor.DarkGreen);

                }
            }



        }
        public void Create()
        {
            ConsoleHelper.WriteWithColor("*---- ENTER OWNER NAME ----*", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("*---- ENTER OWNER SURNAME ----*", ConsoleColor.DarkCyan);
            string surname = Console.ReadLine();

            var owners = new Owner
            {
                Name = name,
                Surname = surname,
            };

            _ownerRepository.Add(owners);
            ConsoleHelper.WriteWithColor($"{owners.Surname} {owners.Surname} is succesfuly created", ConsoleColor.DarkGreen);
        }
        public void Update()
        {
            GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
            NewGroupDes3: ConsoleHelper.WriteWithColor("*--- There is no owner, you want to create---*\n |||y or n|||", ConsoleColor.DarkRed);
                char decision;
                bool isSucceededResult = char.TryParse(Console.ReadLine(), out decision);
                if (!isSucceededResult)
                {
                    ConsoleHelper.WriteWithColor("Your selection is not in the correct format\n*Pleace write y/n", ConsoleColor.DarkRed);
                    goto NewGroupDes3;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Your selection is not correct ", ConsoleColor.DarkRed);
                    goto NewGroupDes3;
                }

                if (decision == 'y')
                {
                    Create();
                }
                if (decision == 'n')
                {
                    return;
                }
            }
            else
            {
            IdDEs: ConsoleHelper.WriteWithColor("*--- ENTER OWNER ID---* ", ConsoleColor.DarkCyan);
                int id;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not coorect format", ConsoleColor.DarkRed);
                    goto IdDEs;
                }
                var owner = _ownerRepository.Get(id);
                if (owner is null)
                {
                    ConsoleHelper.WriteWithColor("There is no any owner this id", ConsoleColor.DarkRed);
                    goto IdDEs;
                }
                ConsoleHelper.WriteWithColor("*--- ENTER NEW NAME ---*", ConsoleColor.DarkCyan);
                string name = Console.ReadLine();
                ConsoleHelper.WriteWithColor("*--- ENTER NEW SURNAME ---*", ConsoleColor.DarkCyan);
                string surname = Console.ReadLine();

                owner.Name = name;
                owner.Surname = surname;

                _ownerRepository.Update(owner);
                ConsoleHelper.WriteWithColor("Owner is succesfully updated", ConsoleColor.DarkGreen);
            }

        }

    }

}
