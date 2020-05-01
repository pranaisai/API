using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace BusinessLayer
{
	public class UserBusinessLayer : IUserBusinessLayer
	{
		private IUserDataAccess _userDataAccessLayer;
		public UserBusinessLayer(IUserDataAccess userAccessDataLayer)
		{
			this._userDataAccessLayer = userAccessDataLayer;
		}	
		/// <summary>
		/// User registrtion method
		/// </summary>
		/// <param name="userDetail"></param>
		/// <returns></returns>
		public int UserRegistration(UserDetails userDetail)
		{
			return this._userDataAccessLayer.UserRegistration(userDetail);
		}

		/// <summary>
		/// Send Email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public int SendEmail(string email)
		{
			return this._userDataAccessLayer.SendEmail(email);
		}

		public int ResetPassword(string email, string newPassword)
		{
			return this._userDataAccessLayer.ResetPassword(email,newPassword);
		}

		public List<DTO.Models.Country> GetCountry()
		{
			return this._userDataAccessLayer.GetCountry();
		}

		public List<DTO.Models.State> GetStates(int countryId)
		{
			return this._userDataAccessLayer.GetStates(countryId);
		}
	}
}
