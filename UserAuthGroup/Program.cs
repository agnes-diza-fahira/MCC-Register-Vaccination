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

            List<User> users = new List<User>();
            users.Add(new User(10001, "Candra", "Irawan", "candra.irawan1", "$2b$10$8tzD9anTWecp9EtPdg2uMu3Q9GU7GvokUIT1JFw2ToW/bJ1NRGEWy", "Admin", "Kuda"));
            users.Add(new User(10001, "Agnes", "Fahira", "agnes.fahira2", "$2a$12$KPHdnVHAv7E7XJxnm6l9oeuvURQodetvZWy1ZMuI5eykviCK0WH0G", "Admin", "Kucing"));

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
                Console.WriteLine("\n\tGo to login page <Enter> | Back to main menu <Esc>");
                ConsoleKeyInfo KeySelect;
                KeySelect = Console.ReadKey(true);
                // kekurangan pakai if kayak gini, user harus berhasil login, kemudian logout untuk kembali ke main menu
                if (KeySelect.Key == ConsoleKey.Enter)
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
                        AdminView(users);

                    }
                    else if (user.AuthenticationUser(users) == user.UserRole())
                    {
                        // User dengan role User.
                        MessageView(true, "Successfully login");
                        UserView(username, users);
                    }
                    else
                    {
                        // Username atau Password salah.
                        MessageView(false, "Username or Password Wrong");
                    }
                }
                else
                {
                    status = 1;
                }
            } while (status == 0);

        }

        // Function yang menampilkan Two View untuk User dengan pilihan : registration vaccination, about me dan logout.
        private static void UserView(string username, List<User> users)
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
                        AboutUserView(username, users);
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

        // Menambahkan function untuk memanggil function GetUser (Program Class)
        private static void AboutUserView(string username, List<User> users)
        {
            int status = 0;
            do
            {
                User user = new User();
                user.GetUserProfile(username, users);
                Console.WriteLine("\n\t------------------------------\n");
                Console.WriteLine("\tMenu: \n");
                Console.WriteLine("\t1. Edit profile \n\t2. Back to home page");
                Console.Write("\n\tSelect menu ~> ");
                string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        EditProfile(users);
                        break;
                    case "2":
                        status = Exit(status);
                        break;
                    default:
                        break;
                }
            } while (status == 0);

        }

        private static void EditProfile(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("\t         Edit Profile         \n");
            Console.WriteLine("\t------------------------------\n");
            Console.Write("\tFirst name \t: ");
            string firstName = Console.ReadLine();
            Console.Write("\tLast name \t: ");
            string lasstName = Console.ReadLine();
            User user = new User();
            user.EditProfile(firstName, lasstName, users);
            LoadingView();
            MessageView(true, "Profile updated");
        }

        // Function yang menampilkan Two View untuk Admin dengan pilihan : manage vaccination, manage user,dan logout.
        private static void AdminView(List<User> users)
        {
            string select;
            int status = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t         Medical House        \n");
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t1. Manage Vaccination\t");
                Console.WriteLine("\t2. Manage User\t");
                Console.WriteLine("\t3. Logout\n");
                Console.Write("\tPlease Input a Number : ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Manage Vaccination");
                        break;
                    case "2":
                        ManageUserView(users);
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

        // Function untuk menampilkan Manage User View
        private static void ManageUserView(List<User> users)
        {
            int status = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t          Manage User         \n");
                Console.WriteLine("\t------------------------------\n");
                Console.WriteLine("\t No \t Id \t Name");
                for (int i = 0; i < users.Count; i++)
                {
                    if(users[i].Role == "User")
                    Console.WriteLine($"\t {i-1}.\t {users[i].Id} \t {users[i].FirstName} {users[i].LastName}");
                }

                Console.WriteLine("\n \t [D]: Delete User");
                Console.WriteLine("\n \t Enter to return to Admin View\t");
                ConsoleKeyInfo KeySelect;
                while (true)
                {
                    KeySelect = Console.ReadKey(true);

                    // Enter untuk kembali ke Admin View.
                    if (KeySelect.Key == ConsoleKey.Enter)
                    {
                        status = 1;
                    }else if(KeySelect.Key == ConsoleKey.D)
                    {
                        DeleteUser(users);
                    }
                            
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

        //Function untuk Delete User dipilih berdasarkan id yang diinput
        private static void DeleteUser(List<User> users)
        {
            int status = 0;
            do
            {
                Console.WriteLine("\n \t Choose Account ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("\n \tAre You Sure to Delete This Account? [Y/N] :");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    users.RemoveAll(user => user.Id == id);
                }
                status = 1;
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