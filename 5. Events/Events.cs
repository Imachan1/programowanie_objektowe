using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia
{
	internal class Program
	{
		public enum Role
		{
			Administrator,
			Manager,
			User
		}

		public class User
		{
			public string Username { get; set; }
			public List<Role> Roles { get; set;}
			public User(string username)
			{
				Username = username;
				Roles = new List<Role>();
			}
			public void AddRole(Role role)
			{
				if (!Roles.Contains(role)) 
				{ 
					Roles.Add(role);
				}

			}
		}
		public class RBAC //Role Base Access Control
		{
			private readonly Dictionary<Role, List<string>> _rolePermissions;
			public RBAC()
			{
				_rolePermissions = new Dictionary<Role, List<string>>
				{
					{ Role.Administrator, new List<string> {"Read","Write","Delete"} },
					{ Role.Manager, new List<string> {"Read","Write"} },
					{ Role.User, new List<string> {"Read"} },
				};
			}

			public bool HasPermission(User user, string permission)
			{
				foreach (var role in user.Roles)
				{
					if (_rolePermissions.ContainsKey(role) && _rolePermissions[role].Contains(permission))
					{
						return true;
					}
				}
				return false;
			}
		}

		public class PasswordManager
		{
			private const string _passwordFilePath = "userPasswords.txt";
			public static event Action<string, bool> PasswordVerified;

			static PasswordManager()
			{
				if (!File.Exists(_passwordFilePath)) 
				{
					File.Create(_passwordFilePath).Dispose();
				}
			}

			public static void SavePassword(string username, string password)
			{
				if (File.ReadLines(_passwordFilePath).Any(line => line.Split(',')[0]) == username))
				{
                    Console.WriteLine($"User {username} exists");
					return;
                }

				string hashedPassword = HashPassword(password);
				File.AppendAllText(_passwordFilePath, $"{username},{hashedPassword}");
                Console.WriteLine($"User {username} added");
            }

			private static string HashPassword(string password)
			{
				using(var sha256 = SHA256.Create())
				{
					var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
					return Convert.ToBase64String(bytes);
				}
			}

			private static bool VerifyPassword(string username, string password)
			{
				string hashedPassword = HashPassword(password);
				foreach(var line in File.ReadLines(_passwordFilePath))
				{
					var parts = line.Split(',');
					if (parts[0] == username && parts[1] == hashedPassword)
					{
						PasswordVerified?.Invoke(username, true);
						return true;
					}
				}
				PasswordVerified?.Invoke(username, false);
				return false;
			}
		}


		static void Main(string[] args)
		{
			PasswordManager.PasswordVerified += (username, success) => Console.WriteLine($"Log in {username} :{(success? "successful":"fail")}");
			PasswordManager.SavePassword("admin", "pass");

            Console.WriteLine("\nEnter username:");
			string username = Console.ReadLine();
            Console.WriteLine();
        }
	}
}
