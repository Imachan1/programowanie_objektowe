using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
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
		}


		static void Main(string[] args)
		{
		}
	}
}
