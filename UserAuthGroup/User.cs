using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthGroup
{
    public class User
    {

        // Getter dan Setter untuk class User.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Favorite { get; set; }

        // Constructor untuk menyimpan data user pada saat registration.
        public User(int id, string firstname, string lastname, string username, string password, string role, string favorite)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.UserName = username;
            this.Password = password;
            this.Role = role;
            this.Favorite = favorite;
        }

        // Constructor untuk login.
        public User(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        // Constructor tanpa parameter.
        public User()
        {

        }


        // Function untuk verifikasi data dengan melakukan cek data username dan password sama dengan database, jika sama maka akan melihat role dari user yang login.
        public string AuthenticationUser(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];

                if (user.UserName == UserName && BCrypt.Net.BCrypt.Verify(Password, user.Password))
                {
                    if (user.Role == UserRole())
                    {
                        return UserRole();
                    }
                    else if (user.Role == AdminRole())
                    {
                        return AdminRole();
                    }
                }
            }
            return UsernamePasswordWrong();
        }

        // Function untuk verifikasi data dengan melakukan cek data username dan favorite sama dengan database, jika sama dapat melakukan pengaturan password baru.
        public bool AuthenticationPassword(string username, string favorite, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if ((user.UserName == username) && (user.Favorite == favorite))
                {
                    return true;
                }
            }
            return false;
        }

        // Function untuk mengubah password lama ke password yang baru.
        public void ChangePassword(string username, string password, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (user.UserName == username)
                {
                    user.Password = password;
                }
            }
        }

        public void EditProfile(string firstName, string lastName, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                user.FirstName = firstName;
                user.LastName = lastName;
            }
        }


        // Helper untuk mengembalikan role Admin.
        public string AdminRole()
        {
            return "Admin";
        }


        // Helper untuk mengembalikan role User.
        public string UserRole()
        {
            return "User";
        }

        // Helper untuk mengembalikan username atau password salah.
        public string UsernamePasswordWrong()
        {
            return "Username or Password is wrong";
        }

        // Helper untuk generate ID user baru.
        public int GenerateID(List<User> users)
        {
            int result = users.Count + 10001;
            return result;
        }

        // Helper untuk convert string dengan format capitalize.
        public string GenerateCapitalize(string sentence)
        {
            string result = char.ToUpper(sentence[0]) + sentence.Substring(1);
            return result;
        }

        // Helper untuk convert string dengan generate username dengan kombinasi firstname,lastname dan jumlah user.
        public string GenerateUsername(string firstname, string lastname, List<User> users)
        {
            string result = firstname.ToLower().Replace(" ", "") + "." + lastname.ToLower().Replace(" ", "") + (users.Count + 1);
            return result;
        }

        // Helper untuk convert string to HashPassword.
        public string GeneratePassword(string password)
        {
            string result = BCrypt.Net.BCrypt.HashPassword(password);
            return result;
        }

        // Menampilkan detail dari user yang login (User Class)

        public void GetUserProfile(string username, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (user.UserName == username)
                {
                    Console.Clear();
                    Console.WriteLine("\t------------------------------\n");
                    Console.WriteLine("\t            About Me          \n");
                    Console.WriteLine("\t------------------------------\n");
                    Console.WriteLine($"\tName \t: {user.FirstName} {user.LastName}");
                }
            }

        }
    }
}