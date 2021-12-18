using System;
using System.Collections.Generic;
using System.Threading;

namespace UserAuthGroup
{
    public class Program
    {

        private static void ViewMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t         Medical House        \n");
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t1. Login\t");
            Console.WriteLine("\t2. Registration\t");
            Console.WriteLine("\t3. Forgot Password?\t");
            Console.WriteLine("\t4. Exit\n");
            Console.Write("\tPlease Input a Number : ");
        }

        public static void Main(string[] args)
        {

            int select;
            int status = 0;

            List<User> users = new List<User>();

            do
            {
                try
                {
                    ViewMainMenu();
                    select = Convert.ToInt32(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            ViewLogin(users);
                            break;
                        case 2:
                            ViewRegistration(users);
                            break;
                        case 3:
                            ViewForgotPassword(users);
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    ExecptionMessage();
                }
                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);
                    if (KeySelect.Key == ConsoleKey.Enter) status = 0;
                    if (KeySelect.Key == ConsoleKey.Escape) status = 1;
                    break;
                }
            } while (status == 0);
        }

        private static void ViewRegistration(List<User> users)
        {
            string firstname,
            lastname,
            username,
            password,
            role,
            favorite;
            int id;
            int status = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t------------------------------\n");
                    Console.WriteLine("\t         Registration         \n");
                    Console.WriteLine("\t------------------------------\n");

                    Console.Write("\tFirst Name       : ");
                    firstname = Convert.ToString(Console.ReadLine());

                    Console.Write("\tLast Name        : ");
                    lastname = Convert.ToString(Console.ReadLine());

                    Console.Write("\tPassword         : ");
                    password = Convert.ToString(Console.ReadLine());

                    Console.Write("\tFavorit Animal   : ");
                    favorite = Convert.ToString(Console.ReadLine());

                    Console.WriteLine();

                    User user = new User();

                    id = user.GenerateID(users);

                    firstname = user.GenerateCapitalize(firstname);

                    username = user.GenerateUsername(firstname, lastname, users);

                    lastname = user.GenerateCapitalize(lastname);

                    password = user.GeneratePassword(password);

                    role = user.GenerateRoleUser();

                    favorite = user.GenerateCapitalize(favorite);

                    users.Add(new User(id, firstname, lastname, username, password, role, favorite));

                    Console.Clear();
                    Console.WriteLine("\t-----------------------------------------\n");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t	Successful Registration     \n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\t-----------------------------------------\n");
                    Console.WriteLine($"\tUsername        : {username} ");
                    Console.WriteLine("");
                    Console.WriteLine("\t-----------------------------------------\n");

                    Console.Write("\tEnter to insert again or Esc to menu");

                }
                catch (Exception)
                {
                    ExecptionMessage();
                }
                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);
                    if (KeySelect.Key == ConsoleKey.Enter) status = 0;

                    if (KeySelect.Key == ConsoleKey.Escape) status = 1;
                    ViewMainMenu();
                    break;

                }
            } while (status == 0);
        }

        private static void ViewForgotPassword(List<User> users)
        {
            string username, favorite, newPassword;
            int status = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t------------------------------\n");
                    Console.WriteLine("\t	Forgot Password        \n");
                    Console.WriteLine("\t------------------------------\n");
                    Console.Write("\tUsername	: ");
                    username = Convert.ToString(Console.ReadLine());
                    Console.Write("\tFavorit Animal	: ");
                    favorite = Convert.ToString(Console.ReadLine());


                    User user = new User();

                    favorite = user.GenerateCapitalize(favorite);


                    if (user.NewPassword(username, favorite, users))
                    {
                        MessageNotification(true, "Username available\n");
                        Console.WriteLine("\t-----------------------------------------\n");

                        Console.Write("\tNew Password	: ");
                        newPassword = Convert.ToString(Console.ReadLine());
                        newPassword = user.GeneratePassword(newPassword);

                        user.ChangePassword(username, newPassword, users);

                    }
                    else
                    {
                        MessageNotification(false, "Data not match\n");

                    }
                    Console.WriteLine("");
                    Console.WriteLine("\t-----------------------------------------\n");

                    Console.Write("\tEnter to insert again or Esc to menu");

                }
                catch (Exception)
                {
                    ExecptionMessage();
                }
                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);
                    if (KeySelect.Key == ConsoleKey.Enter) status = 0;
                    if (KeySelect.Key == ConsoleKey.Escape) status = 1;
                    ViewMainMenu();
                    break;
                }

            } while (status == 0);
        }



        private static void ViewLogin(List<User> users)
        {
            string username,
            password;
            int status = 0;
            do
            {
               
                Console.Clear();
                foreach (var item in users)
                {
                    Console.WriteLine(item.username);
                    Console.WriteLine(item.role);
                    Console.WriteLine(item.password);
                }
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t         Login User         \n");
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\tPlease Input Your Data\n");
                Console.Write("\tUsername   : ");
                username = Console.ReadLine();
                Console.Write("\tPassword   : ");
                password = Console.ReadLine();
                
                User user = new User(username, password);
   

                if (user.CheckUser(users) == "Admin")
                {
                    MessageNotification(true, "Successfully login");
                    Console.WriteLine("");
                    int load = 12;
                    Console.Write("\tLoading.");
                    for (int i = 0; i < load; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(400);
                    }
                    ViewAdmin();

                }
                else if (user.CheckUser(users) == user.GenerateRoleUser())
                {
                    MessageNotification(true, "Successfully login");
                    Console.WriteLine("");
                    int load = 12;
                    Console.Write("\tLoading.");
                    for (int i = 0; i < load; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(400);
                    }
                    ViewUser();
                }
                else
                {
                    MessageNotification(false, "Username or Password Wrong");
                }

                Console.WriteLine("Enter to return to the main menu");

                ConsoleKeyInfo keyInfo;
                while (true)
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter) status = 1;
                    break;
                }
            } while (status == 0);
        }



        private static void ViewUser()
        {
            Console.Clear();
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t         Medical House        \n");
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t1. Register Vaccination\t");
            Console.WriteLine("\t2. About Me\t");
            Console.WriteLine("\t3. Logout\t");
            Console.Write("\tPlease Input a Number : ");
        }

        private static void ViewAdmin()
        {
            Console.Clear();
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t         Medical House        \n");
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t1. Manage Vaccination\t");
            Console.WriteLine("\t2. Manage User\t");
            Console.WriteLine("\t3. Logout\t");
            Console.Write("\tPlease Input a Number : ");
        }


        private static void MessageNotification(bool status, string message)
        {
            Console.Clear();
            Console.WriteLine("\t-----------------------------------------\n");

            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"\t         {message}          \t");
            Console.ForegroundColor = ConsoleColor.White;
        }

        

        private static void ExecptionMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\tPlease match the requested, ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter to insert again or Esc to menu");
        }
    }
}