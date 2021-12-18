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
            return "User";
        }

        public string GeneratePassword(string password)
        {
            string result = BCrypt.Net.BCrypt.HashPassword(password);
            return result;
        }

        public void ChangePassword(string username, string password, List<User> users) 
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (user.username == username)
                {
                    user.password = password;
                }
            }        
        }
    
        public bool NewPassword(string username,string favorite, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if ((user.username == username) && (user.favorite == favorite))
                {
                    return true;
                }
            }
            return false;
        }
        
        

      
        public string CheckUser(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (user.username == username && BCrypt.Net.BCrypt.Verify(password,GeneratePassword(password)))
                {
                    if (user.role == "User")
                    {
                        return "User";
                    }
                    else
                    {
                        return "Admin";
                    }
                } 
            }
            return "not found";
        }


    }
}