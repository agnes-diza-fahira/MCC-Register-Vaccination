using System;
using System.Collections.Generic;
using System.Threading;

namespace UserAuthGroup
{
    public class Program
    {
        // Function yang menampilkan First View dengan pilihan : login, registration, dan forgot password.
        private static void GuestView()
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

            string select;
            int status = 0;

            List<User> users = new List<User>() { new User() { Id = 10001, FirstName = "Candra", LastName = "Irawan", UserName = "candra.irawan1", Password = "$2b$10$8tzD9anTWecp9EtPdg2uMu3Q9GU7GvokUIT1JFw2ToW/bJ1NRGEWy", Role = "Admin", Favorite = "Kuda" } };

            do
            {
                GuestView();
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        LoginView(users);
                        break;
                    case "2":
                        RegistrationView(users);
                        break;
                    case "3":
                        ForgotPasswordView(users);
                        break;
                    case "4":
                        status = Exit(status);
                        break;
                    default:
                        break;
                }
            } while (status == 0);
        }

        private static int Exit(int status)
        {
            Console.WriteLine("\nAre you sure ? Press <Enter> to confirm or <Esc> to cancel");

            ConsoleKeyInfo KeySelect;
            KeySelect = Console.ReadKey(true);

            // Esc untuk kembali ke Guest View.
            if (KeySelect.Key == ConsoleKey.Escape) status = 0;

            // Enter untuk keluar.
            if (KeySelect.Key == ConsoleKey.Enter) status = 1;
            return status;
        }

        // Function yang menampilkan Login View dengan user diminta mengisi username dan password
        private static void LoginView(List<User> users)
        {
            string username,
            password;
            int status = 0;
            do
            {

                Console.Clear();
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t         Login User         \n");
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\tPlease Input Your Data\n");

                Console.Write("\tUsername   : ");
                username = Console.ReadLine();

                Console.Write("\tPassword   : ");
                password = Console.ReadLine();

                // Membuat object baru dengan mengisi parameter dari username dan password.
                User user = new User(username, password);

                LoadingView();

                // Memanggil function AuthenticationUser untuk melakukan verifikasi data sudah sesuai atau belum dengan data dilist Users.
                if (user.AuthenticationUser(users) == user.AdminRole())
                {
                    // User dengan role Admin.
                    MessageView(true, "Successfully login");
                    AdminView();

                }
                else if (user.AuthenticationUser(users) == user.UserRole())
                {
                    // User dengan role User.
                    MessageView(true, "Successfully login");
                    UserView();
                }
                else
                {
                    // Username atau Password salah.
                    MessageView(false, "Username or Password Wrong");
                }

                //Console.WriteLine("\tEnter to return to the main menu");
            } while (status == 0);
        }

        // Function yang menampilkan Two View untuk User dengan pilihan : registration vaccination, about me dan logout.
        private static void UserView()
        {
            string select;
            int status = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t         Medical House        \n");
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t1. Registration Vaccination\t");
                Console.WriteLine("\t2. About Me\t");
                Console.WriteLine("\t3. Logout\n");
                Console.Write("\tPlease Input a Number : ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Registration Vaccination");
                        break;
                    case "2":
                        Console.WriteLine("About Me");
                        break;
                    case "3":
                        status = Exit(status);
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            } while (status == 0);

        }

        // Function yang menampilkan Two View untuk Admin dengan pilihan : manage vaccination, manage user,dan logout.
        private static void AdminView()
        {
            int select;
            int status = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t------------------------------\n");
                    Console.WriteLine("\t         Medical House        \n");
                    Console.WriteLine("\t------------------------------\n");
                    Console.WriteLine("\t1. Manage Vaccination\t");
                    Console.WriteLine("\t2. Manage User\t");
                    Console.WriteLine("\t3. Logout\n");
                    Console.Write("\tPlease Input a Number : ");
                    select = Convert.ToInt32(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            Console.WriteLine("Manage Vaccination");
                            break;
                        case 2:
                            Console.WriteLine("Manage User");
                            break;
                        case 3:
                            GuestView();
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    ExecptionView();
                }

                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);

                    // Enter untuk kembali ke Admin View.
                    if (KeySelect.Key == ConsoleKey.Enter) status = 0;
                    break;
                }
            } while (status == 0);
        }

        // Function yang menampilkan Registration View dengan user diminta melengkapi data.
        private static void RegistrationView(List<User> users)
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

                    // Membuat object baru tanpa parameter.
                    User user = new User();

                    // Memanggi Function GenerateId di User class.
                    id = user.GenerateID(users);

                    // Memanggi Function Convert To Capitalize di User class.
                    firstname = user.GenerateCapitalize(firstname);
                    lastname = user.GenerateCapitalize(lastname);
                    favorite = user.GenerateCapitalize(favorite);

                    // Memanggi Function GenerateUsername di User class.
                    username = user.GenerateUsername(firstname, lastname, users);

                    // Memanggi Function GeneratePassword di User class.
                    password = user.GeneratePassword(password);

                    // Memanggi Function UserRole di User class.
                    role = user.UserRole();

                    users.Add(new User(id, firstname, lastname, username, password, role, favorite));

                    LoadingView();
                    MessageRegistrationView();

                    // Menampilkan username hasil generate dari Function GenerateUsername.
                    Console.WriteLine("\t-----------------------------------------\n");
                    Console.WriteLine($"\tUsername        : {username} ");
                    Console.WriteLine("");
                    Console.WriteLine("\t-----------------------------------------\n");

                    Console.Write("\tEnter to insert again or Esc to menu");

                }
                catch (Exception)
                {
                    ExecptionView();
                }
                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);
                    if (KeySelect.Key == ConsoleKey.Enter) status = 0;

                    if (KeySelect.Key == ConsoleKey.Escape) status = 1;
                    GuestView();
                    break;

                }
            } while (status == 0);
        }

        // Function yang menampilkan Forgot Password  dengan user diminta melengkapi data username dan favorite.
        private static void ForgotPasswordView(List<User> users)
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

                    // Membuat object baru dengan tanpa parameter.
                    User user = new User();

                    // Memanggi Function Convert To Capitalize di User class.
                    favorite = user.GenerateCapitalize(favorite);

                    LoadingView();

                    // Memanggil function AuthenticationPassword untuk melakukan verifikasi data sudah sesuai atau belum dengan data dilist Users.
                    if (user.AuthenticationPassword(username, favorite, users))
                    {
                        // Data user berhasil diverifikasi.
                        MessageView(true, "Username available");

                        Console.Write("\tNew Password	: ");
                        newPassword = Convert.ToString(Console.ReadLine());
                        newPassword = user.GeneratePassword(newPassword);

                        // Memanggil function ChangePassword untuk melakukan pengaturan password yang baru.
                        user.ChangePassword(username, newPassword, users);
                        LoadingView();
                        MessageView(true, "Password change");
                    }
                    else
                    {
                        MessageView(false, "Data not match");

                    }
                    Console.Write("\tEnter to insert again or Esc to menu");
                }
                catch (Exception)
                {
                    ExecptionView();
                }
                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);
                    if (KeySelect.Key == ConsoleKey.Enter) status = 0;
                    if (KeySelect.Key == ConsoleKey.Escape) status = 1;
                    GuestView();
                    break;
                }

            } while (status == 0);
        }

        // Helper untuk menampilkan Loading.
        private static void LoadingView()
        {
            Console.WriteLine("");
            int load = 20;
            Console.Write("\tLoading.");
            for (int i = 0; i < load; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
        }

        // Helper untuk menampilkan pesan success atau error.
        private static void MessageView(bool status, string message)
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

            Console.WriteLine($"\t         {message}          \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t-----------------------------------------\n");
            Thread.Sleep(1500);
        }

        // Helper untuk menampilkan pesan sukses registration.
        private static void MessageRegistrationView()
        {
            Console.Clear();
            Console.WriteLine("\t-----------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t       Successfully registration        \n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1500);
        }

        // Helper untuk menampilkan execption error.
        private static void ExecptionView()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\tPlease match the requested, ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter to insert again or Esc to menu");
        }
    }
}