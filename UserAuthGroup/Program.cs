using System;
using System.Collections.Generic;
using System.Linq;

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
			IntiateUser(users);

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
							Console.WriteLine(3);
							break;
						case 4:
							Console.WriteLine(4);
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

        private static void IntiateUser(List<User> users)
        {
			users.Add(new User(10001, "Agnes", "Fahira", "AgFa", "123456", "Admin", "Fish"));
			users.Add(new User(10002, "Muhammad", "Candra", "MuCa", "123456", "Admin", "Cat"));
			users.Add(new User(10003, "Abdul", "Jabar", "AbJa", "123456", "Admin", "Bird"));
			users.Add(new User(10004, "Sofia", "Nadia", "SoNa", "123456", "user", "Bird"));
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


		private static void ViewUser(List<User> listUser)
		{
			int status = 0;
			do
			{
				Console.Clear();
				Console.WriteLine("\t------------------------------\n");
				Console.WriteLine("\t          List User         \n");
				Console.WriteLine("\t------------------------------\n");
				if (listUser.Count == 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\t           No User            \n");
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("\tBe the first user,\n");
					Console.WriteLine("\tPress enter to back to the main menu and create your own account!\t");
				}
				else
				{
					for (int i = 0; i < listUser.Count; i++)
					{
						Console.WriteLine("");
						Console.WriteLine($"\tId            : {listUser[i].id}");
						Console.WriteLine($"\tFirst Name    : {listUser[i].firstname}");
						Console.WriteLine($"\tLast Name     : {listUser[i].lastname}");
						Console.WriteLine($"\tUsername      : {listUser[i].username}");
						Console.WriteLine("");
						Console.WriteLine("\t------------------------------\n");

					}
					Console.WriteLine("");
					Console.WriteLine("\tPress enter to back to the main menu\t");
				}

				ConsoleKeyInfo keyInfo;
				while (true)
				{
					keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.Enter) status = 1;
					break;
				}

			} while (status == 0);
		}

		private static void ViewSearch(List<User> listUser)
		{
			Console.Clear();
			Console.WriteLine("\t------------------------------\n");
			Console.WriteLine("\t            Search            \n");
			Console.WriteLine("\t------------------------------\n");
			Console.WriteLine("\tOption: \t");
			Console.WriteLine("\t1. by id\t");
			Console.WriteLine("\t2. by firstname\t");
			Console.WriteLine("\t3. by lastname\t");
			Console.WriteLine("\t4. by username\n");
			Console.Write("\tSearch by: \t");
			String searchOption = Console.ReadLine();
			switch (searchOption)
			{
				case "1":
					SearchUser(listUser, "id");
					break;
				case "2":
					SearchUser(listUser, "firstname");
					break;
				case "3":
					SearchUser(listUser, "lastname");
					break;
				case "4":
					SearchUser(listUser, "username");
					break;
				default:
					break;
			}
		}

		private static void SearchUser(List<User> listUser, string key)
		{
			int status = 0;
			int input;
			string setence;
			do
			{
				try
				{
					Console.Clear();
					Console.WriteLine("\t------------------------------\n");
					Console.WriteLine($"\t          Search {key}            \n");
					Console.WriteLine("\t------------------------------\n");
					Console.Write($"\tEnter user {key}: \t");
					User user = new User();
					if (key == "id")
					{
						input = Convert.ToInt32(Console.ReadLine());
						user.ResultSearch(listUser, key, input);
					}
					else
					{
						setence = Convert.ToString(Console.ReadLine());
						user.ResultSearch(listUser, key, setence);
					}

				}
				catch (Exception)
				{
					Console.WriteLine("\tSomething wrong");
				}

				ConsoleKeyInfo keyInfo;
				while (true)
				{
					keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.Enter) status = 1;
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
				Console.WriteLine("\t======================\n");
				Console.WriteLine("\t      Login User      \n");
				Console.WriteLine("\t======================\n");
				Console.WriteLine("\tPlease Input Your Data\n");
				Console.Write("\tUsername   : ");
				username = Console.ReadLine();
				Console.Write("\tPassword   : ");
				password = Console.ReadLine();

				User user = new User(username, password);

				if (user.CheckUser(users))
                {
                    SuccessLoginView(users, user);
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

        private static void SuccessLoginView(List<User> users, User user)
        {
			List<string> usernameList = users.Select(ur => ur.username).ToList();
			int id = usernameList.IndexOf(user.username);
			string role = users[id].role;

			int status = 0;
			do
			{
				MessageNotification(true, "Successfully login");
				Console.WriteLine("Enter to the next page");
				ConsoleKeyInfo keyInfo;
				while (true)
				{
					keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.Enter)
					{
						status = 1;

					}
					break;
				}

				if (role == "user")
				{
					UserView(users, user, id);
				}
				else
				{
					AdminView(users, user, id);
				}


			} while (status == 0);
        }

        private static void UserView(List<User> users, User user, int id)
        {
			int status = 0;
			do
			{
				Console.Clear();
				Console.WriteLine("\t======================\n");
				Console.WriteLine($"\t   Wellcome {users[id].firstname}\n");
				Console.WriteLine("\t======================\n");
				Console.WriteLine("\t1. Register Vaccination");
				Console.WriteLine("\t2. About Me			");
				Console.WriteLine("\t3. Logout				");
				ConsoleKeyInfo keyInfo;
				while (true)
				{
					keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.Enter) status = 1;
					break;
				}
			} while (status == 0);
		}

        private static void AdminView(List<User> users, User user, int id)
        {
			int status = 0;
			do
			{
				Console.Clear();
				Console.WriteLine("\t======================\n");
				Console.WriteLine($"\t   You're Admin      \n");
				Console.WriteLine("\t======================\n");
				Console.WriteLine("\t1. Manage Vaccination");
				Console.WriteLine("\t2. Manage User		  ");
				Console.WriteLine("\t3. Logout			  ");

				ConsoleKeyInfo keyInfo;
				while (true)
				{
					keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.Enter) status = 1;
					break;
				}

			} while (status == 0);
		}

        private static void MessageNotification(bool status, string message)
		{

			if (status)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"\t         {message}          \t");
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"\t         {message}          \t");
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		private static void ExecptionMessage()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("\tPlease match the requested, ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Enter to insert again or Esc to menu");
		}
		private static void DeleteUser(List<User> listUser, string userName, string password)
		{
			int exitDA = 0;
			do
			{
				Console.Clear();
				Console.WriteLine("=========================");
				Console.WriteLine("Remove Account      ");
				Console.WriteLine("=========================");

				bool exist = listUser.Exists(item => item.username == userName);
				bool passTrue = listUser.Exists(item => item.password == password);
				Console.WriteLine("Are You Sure to Delete This Account? [Y/N] :");

				if (exist & Console.ReadKey().Key == ConsoleKey.Y)
				{
					Console.Write("Password:    ");
					string inputPassword = Convert.ToString(Console.ReadLine());
					if (passTrue)
					{
						listUser.RemoveAll(item => item.username == userName);
						Console.WriteLine("\n Remove Success");
						Console.ReadKey();
						exitDA = 1;
					}
				}
			} while (exitDA == 0);
		}
	}
}
