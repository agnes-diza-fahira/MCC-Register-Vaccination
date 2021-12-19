using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthGroup
{
    public class UserVaccine : User
    {
        public int Type { get; set; }
        public int Date { get; set; }
        public int Place { get; set; }

        public UserVaccine(string UserName, string FirstName, string LastName, int Type, int Date, int Place)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Type = Type;
            this.Date = Date;
            this.Place = Place;
        }

        public UserVaccine()
        {

        }

        //Helper untuk jenis vaksin
        public static string[] VaccineTypes()
        {
            string[] vaccineTypes = { "Sinovac", "AstraZeneca", "Sinopharm", "Moderna", "Pfizer", "Janssen" };

            return vaccineTypes;
        }

        //Helper untuk tanggal vaksin
        public static string[] VaccineDates()
        {
            string[] vaccineDates = {"Monday, January 3, 2022", "Tuesday, January 4, 2022", "Wednesday, January 5, 2022", "Thursday, January 6, 2022", "Friday, January 7, 2022"};

            return vaccineDates;
        }

        //Helper untuk lokasi vaksin
        public static string[] VaccinePlaces()
        {
            string[] vaccinePlaces = { "Hospital", "Public Health Center" };
            return vaccinePlaces;
        }
        public UserVaccine GetVaccine(string username, List<UserVaccine> userVaccines)
        {
            for (int i = 0; i < userVaccines.Count; i++)
            {
                User user = userVaccines[i];
                if (user.UserName == username)
                {
                    return new UserVaccine(userVaccines[i].UserName, userVaccines[i].FirstName, userVaccines[i].LastName, userVaccines[i].Type, userVaccines[i].Date, userVaccines[i].Place);
                }
            }
            return new UserVaccine();
        }

        //Helper untuk meminta informasi vaksin
        public static string VaccineInfo(int number, string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(i == number) return array[i];
            }
            return "Please register your vaccination";
        }
    }
}
