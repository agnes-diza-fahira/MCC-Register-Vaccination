using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthGroup
{
    public class User
    {

        public int id { get; set; }
        public string firstname     { get; set; }
        public string lastname      { get; set; }
        public string username      { get; set; }
        public string password      { get; set; }
        public string role          { get; set; }
        public string favorite { get; set; }

        public User(int id, string firstname, string lastname, string username, string password, string role, string favorite)
        {
            this.id             = id;
            this.firstname      = firstname;
            this.lastname       = lastname;
            this.username       = username;
            this.password       = password;
            this.role           = role;
            this.favorite  = favorite;
        }

        public User(string firstname, string lastname, List<User> users)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User()
        {

        }

        public int GenerateID(List<User> users)
        {
            int result = users.Count + 10001;
            return result;
        }

        public string GenerateUsername(string firstname, string lastname, List<User> users) {
            string result = firstname.ToLower().Replace(" ","") + "." + lastname.ToLower().Replace(" ", "") + (users.Count + 1);
            return result;
        }

        public string GenerateCapitalize(string sentence)
        {
            string result = char.ToUpper(sentence[0]) + sentence.Substring(1);
            return result;
        }

        public string GenerateRoleUser()
        {
            return "user";
        }

        public string GeneratePassword(string password)
        {
            string result = BCrypt.Net.BCrypt.HashPassword(password);
            return result;
        }
        
        public void ResultSearch(List<User> users, string key, int id)
        {
            int dataSize = 0;

            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (user.id == id)
                {
                    dataSize++;
                    PrintUser(user.id, user.firstname, user.lastname, user.username, user.password);
                }
            }

            if (dataSize < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t           User not found      \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ResultSearch(List<User> users, string key, string setence)
        {
            int dataSize = 0;
            for (int i = 0; i < users.Count; i++)
            {
         
                User user = users[i];
                if (key == "firstname" && user.firstname == setence)
                {
                    dataSize++;
                    PrintUser(user.id, user.firstname, user.lastname, user.username, user.password);
                }
                if (key == "lastname" && user.lastname == setence)
                {
                    dataSize++;
                    PrintUser(user.id, user.firstname, user.lastname, user.username, user.password);
                }
                if (key == "username" && user.username == setence)
                {
                    dataSize++;
                    PrintUser(user.id, user.firstname, user.lastname, user.username, user.password);
                }
            }

            if (dataSize < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t           User not found      \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void PrintUser(int id, string firstname,string lastname,string username,string password)
        {

                Console.WriteLine("");
                Console.WriteLine($"\tId            : {id}");
                Console.WriteLine($"\tFirst Name    : {firstname}");
                Console.WriteLine($"\tLast Name     : {lastname}");
                Console.WriteLine($"\tUsername      : {username}");
                Console.WriteLine("");
                Console.WriteLine("\t------------------------------\n");

        }

        public bool CheckUser(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (user.username == username && user.password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}