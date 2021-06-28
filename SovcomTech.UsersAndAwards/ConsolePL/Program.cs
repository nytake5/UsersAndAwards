using Entity_User.MyException;
using SovcomTech.UsersAndAwards.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SovcomTech.UsersAndAwards.Entity_Award;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"^[a-zA-Zа-яА-Я]+$");
            
            var userLogic = Dependencies.userLogic;
            var awardLogic = Dependencies.awardLogic;

            while (true)
            {
                foreach (var item in userLogic.GetAll())
                {
                    Console.WriteLine(item.ToString());
                }
                foreach (var item in awardLogic.GetAwards())
                {
                    Console.WriteLine(item.ToString());
                }
                foreach (var item in userLogic.GetUserAward())
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить юзера");
                Console.WriteLine("2 - Добавить награду");
                Console.WriteLine("3 - Добавить связь пользователь-награда");
                Console.WriteLine("4 - Удалить юзера");
                Console.WriteLine("5 - Удалить награду");
                Console.WriteLine("6 - Удалить связь");
                Console.WriteLine("7 - Найти награды юзера");
                Console.WriteLine("8 - Найти юзеров по награде");
                Console.WriteLine("9 - Найти юзера по Id");

                string line = "";
                string[] st;
                int tempId, tempId2;
                Match match;

                int varibleK; 
                bool flag = int.TryParse(Console.ReadLine(), out varibleK);
                if (!flag)
                {
                    Console.WriteLine("Введите корректный ключ!");
                }
                else
                {
                    switch (varibleK)
                    {
                        case 1:
                            Console.WriteLine("Введите имя и дату рождения(дд.мм.гггг) пользователя через пробел:");
                            line = Console.ReadLine();
                            st = line.Split(' ');
                            DateTime dob;
                            match = reg.Match(st[0]);
                            if (!match.Success)
                            {
                                Console.WriteLine("Введите корректное имя!");
                                break;
                            }
                            if (!DateTime.TryParseExact(st[1], "dd.MM.yyyy", null, DateTimeStyles.None, out dob))
                            {
                                Console.WriteLine("Введите корректную дату рождения!");
                                break;
                            }
                            userLogic.AddUser(match.Value, dob);
                            break;
                        case 2:
                            Console.WriteLine("Введите название награды:");
                            match = reg.Match(Console.ReadLine());
                            if (!match.Success)
                            {
                                Console.WriteLine("Введите корректное название!");
                                break;
                            }
                            awardLogic.AddAward(match.Value);
                            break;
                        case 3:
                            Console.WriteLine("Введите два значения, сначала Id пользователя, потом Id награды:");
                            line = Console.ReadLine();
                            st = line.Split(' ');
                            try
                            {
                                userLogic.AddUserAward(int.Parse(st[0]), int.Parse(st[1]));
                            }
                            catch
                            {
                                Console.WriteLine("Произошла ошибка, введите существующие Id"); ;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Введите Id удаляемого пользователя:");
                            line = Console.ReadLine();
                            if (!int.TryParse(line, out tempId))
                            {
                                Console.WriteLine("Введите корректное Id");
                                break;
                            }
                            foreach (var item in userLogic.DeleteUser(tempId))
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 5:
                            Console.WriteLine("Введите Id удаляемой награды:");
                            line = Console.ReadLine();
                            if (!int.TryParse(line, out tempId))
                            {
                                Console.WriteLine("Введите корректное Id");
                                break;
                            }
                            foreach (var item in awardLogic.DeleteAward(tempId))
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 6:
                            Console.WriteLine("Введите два Id, пользователя и награды, которые будут удалены:");
                            line = Console.ReadLine();
                            st = line.Split(' ');
                            if (!int.TryParse(st[0], out tempId) || !int.TryParse(st[1], out tempId2))
                            {
                                Console.WriteLine("Введите корректные Id");
                                break;
                            }
                            userLogic.DeleteUserAward(tempId, tempId2);
                            break;
                        case 7:
                            Console.WriteLine("Введите Id юзера:");
                            line = Console.ReadLine();
                            if (!int.TryParse(line, out tempId))
                            {
                                Console.WriteLine("Введите корректное Id");
                                break;
                            }
                            foreach (var item in awardLogic.GetAwardsAtUser(tempId))
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 8:
                            Console.WriteLine("Введите Id награды:");
                            line = Console.ReadLine();
                            if (!int.TryParse(line, out tempId))
                            {
                                Console.WriteLine("Введите корректное Id");
                                break;
                            }
                            foreach (var item in userLogic.FindAtAwards(tempId))
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 9:
                            Console.WriteLine("Введите Id юзера");
                            line = Console.ReadLine();
                            if (!int.TryParse(line, out tempId))
                            {
                                Console.WriteLine("Введите корректное Id");
                                break;
                            }
                            Console.WriteLine(userLogic.GetById(tempId).ToString());
                            break;

                        default:
                            Console.WriteLine("Введите корректное значение!");
                            break;
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
