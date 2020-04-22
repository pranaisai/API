using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class UserDataAccess : IUserDataAccess
	{

		/// <summary>
		/// Implement validate user interface
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public UserInfo ValidateUser(string userName, string password)
		{
			UserInfo userInfo = new UserInfo();
			GroSHDBEntities db = new GroSHDBEntities();
			try
			{
				string pass = Helpers.Util.Encrypt(password);
				var user = db.UsersInfoes.FirstOrDefault(m => (m.email == userName) && (m.password == pass));
				if (user != null)
				{
					userInfo.FirstName = user.first_Name;
					userInfo.LastName = user.last_Name;
					userInfo.Email = user.email;
					userInfo.Phone = user.phone;
					userInfo.UserId = Convert.ToString(user.id);
					userInfo.IsValid = true;
					var userAddress = db.UsersAddresses.FirstOrDefault(m => (m.userid == user.id));
					if(userAddress!=null)
					{
						userInfo.AddressLine = userAddress.addressLine;
						userInfo.Country = userAddress.country;
						userInfo.State = userAddress.state;
						userInfo.City = userAddress.city;
						userInfo.Zipcode = userAddress.zipcode;
						userInfo.Lat = userAddress.lat;
						userInfo.Lon = userAddress.@long;
					}
				}
				else
				{
					userInfo.IsValid = false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}

			return userInfo;
		}

		/// <summary>
		/// User Registration interface implementation
		/// </summary>
		/// <param name="userDetail"></param>
		/// <returns></returns>
		public int UserRegistration(UserDetails userDetail)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var outputParameter = new ObjectParameter("result", typeof(int));
					var result = db.AddNewUser(userDetail.FirstName, userDetail.LastName, userDetail.Email, userDetail.Phone, Helpers.Util.Encrypt(userDetail.Password),
							userDetail.AddressLine, userDetail.City, userDetail.State, userDetail.Country, userDetail.Zipcode, userDetail.Lat, userDetail.Lon, outputParameter);
					result.ToList();
					flag = (int)outputParameter.Value;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
			
		}

		/// <summary>
		/// Send Email interface implementations
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public int SendEmail(string email)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var user = db.UsersInfoes.FirstOrDefault(m => (m.email == email));
					if (user != null)
					{
						flag = 1;
					}
					else
					{
						flag = 2;
					}					
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}

		/// <summary>
		/// Reset pasword interface implementation
		/// </summary>
		/// <param name="email"></param>
		/// <param name="newPassword"></param>
		/// <returns></returns>
		public int ResetPassword(string email, string newPassword)
		{
			int flag = 0;
			try
			{
				string pass = Helpers.Util.Encrypt(newPassword);
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					UsersInfo c = (from x in db.UsersInfoes
									   where x.email == email
									   select x).First();
					c.password = pass;					
					flag = db.SaveChanges();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}

		/// <summary>
		/// Get Country list interface implementation
		/// </summary>
		/// <returns></returns>
		public List<DTO.Models.Country> GetCountry()
		{
			List<DTO.Models.Country> country = new List<DTO.Models.Country>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var result = (from x in db.Countries select x).ToList();
					foreach (var item in result)
					{
						DTO.Models.Country countrylst = new DTO.Models.Country();
						countrylst.CountryId = item.CountryId;
						countrylst.CountryName = item.CountryName;
						country.Add(countrylst);
					}
				};
			}
			catch (Exception ex)
			{
				DTO.Models.Country stateslst = new DTO.Models.Country();				
				stateslst.CountryId = 1001;
				stateslst.CountryName = ex.Message;
				country.Add(stateslst);
				Console.WriteLine(ex.StackTrace);
			}
			return country;
		}

		/// <summary>
		/// Get States interface implementation
		/// </summary>
		/// <param name="countryId"></param>
		/// <returns></returns>
		public List<DTO.Models.State> GetStates(int countryId)
		{
			List<DTO.Models.State> states = new List<DTO.Models.State>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var result = (from x in db.States where x.CountryId==countryId select x).ToList();
					foreach (var item in result)
					{
						DTO.Models.State stateslst = new DTO.Models.State();
						stateslst.StateId = item.StateId;
						stateslst.CountryId = item.CountryId;
						stateslst.Statename = item.StatenName;
						states.Add(stateslst);
					}
				};
			}
			catch (Exception ex)
			{				
				Console.WriteLine(ex.StackTrace);
			}
			return states;
		}

		//	using (GroSHDBEntities db = new GroSHDBEntities())
		//	{
		//		db.UsersInfoes.Add(new UsersInfo()
		//		{
		//			first_Name = userDetail.FirstName,
		//			last_Name = userDetail.LastName,
		//			email = userDetail.Email,
		//			phone = userDetail.Phone,
		//			password = userDetail.Password,
		//			createdDate = DateTime.Now.ToUniversalTime()
		//		});
		//		flag = db.SaveChanges();
		//		if (flag == 1)
		//		{
		//			var user = db.UsersInfoes.FirstOrDefault(m => (m.email == userDetail.Email) && (m.phone == userDetail.Phone));
		//			if (user != null)
		//			{
		//				db.UsersAddresses.Add(new UsersAddress()
		//				{
		//					addressLine = userDetail.AddressLine,
		//					city = userDetail.City,
		//					state = userDetail.State,
		//					country = userDetail.Country,
		//					userid =user.id
		//					//createdDate=DateTime.Now.ToUniversalTime()
		//				});
		//				db.SaveChanges();
		//			}
		//		}
		//	}
		//	return flag;
	}
}
