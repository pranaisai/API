using BusinessLayer;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroSHAPI.Controllers
{
	//[Authorize]
	[AllowAnonymous]	
	public class UserController : ApiController
    {
		public IUserBusinessLayer _userBusinessLayer;
		public UserController(IUserBusinessLayer userBusinessLayer)
		{
			this._userBusinessLayer = userBusinessLayer;
		}

		//[AllowAnonymous]
		[HttpPost]		
		public HttpResponseMessage UserRegistration(UserDetails userDetails)
		{
			Response<int> response = new Response<int>();
			if (userDetails != null)
			{				
				var result = this._userBusinessLayer.UserRegistration(userDetails);
				if (result >= 1)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = Utility.Constants.SuccessMesg;
				}
				else if(result==-1)
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.UserAlreadyExist;
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		//[AllowAnonymous]
		[HttpPost]		
		public HttpResponseMessage SendEmail([FromUri] string email)
		{
			Response<string> response = new Response<string>();
			if (!string.IsNullOrEmpty(email))
			{
				var result = this._userBusinessLayer.SendEmail(email);
				if (result == 1)
				{
					string otp = Utility.Common.RandomString(4,true);
					EmailModel emailModel = new EmailModel();
					emailModel.ToEmail = email;
					emailModel.Body = otp;
					bool output = true; //Utility.Common.SendEmail(emailModel);
					if (output)
					{
						response.SatusCode = 200;
						response.Data = otp;
						response.Message = Utility.Constants.EmailExists;
					}
					else
					{
						response.SatusCode = 500;
						response.Data = string.Empty;
						response.Message = Utility.Constants.FailedMesg;
					}
				}
				else if (result == 2)
				{
					response.SatusCode = 201;
					response.Data = string.Empty;
					response.Message = Utility.Constants.EmailNotExist;
				}
				else
				{
					response.SatusCode = 500;
					response.Data = string.Empty;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			else
			{
				response.SatusCode = 500;
				response.Data = string.Empty;
				response.Message = Utility.Constants.EmailBlank;
			}
			return Request.CreateResponse(response);// Ok(response);
		}
				

		[HttpPost]
		public HttpResponseMessage ResetPassword([FromUri] string email, string newPassword)
		{
			Response<int> response = new Response<int>();
			if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(newPassword))
			{
				var result = this._userBusinessLayer.ResetPassword(email, newPassword);
				if (result == 1)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = Utility.Constants.PassReset;
				}
				else if (result == 2)
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.EmailNotExist;
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			else
			{
				response.SatusCode = 500;
				response.Data = 1;
				response.Message = "Email and password can not be left blank";
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		//[AllowAnonymous]
		[HttpGet]
		public HttpResponseMessage GetCountries()
		{
			Response<List<Country>> response = new Response<List<Country>>();
			var result = this._userBusinessLayer.GetCountry();
			if (result.Count > 0)
			{
				response.SatusCode = 200;
				response.Data = result;
				response.Message = "Success";
			}
			else
			{
				response.SatusCode = 500;
				response.Data = result;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		//[AllowAnonymous]
		[HttpGet]
		public HttpResponseMessage GetStates(int countryId)
		{
			Response<List<State>> response = new Response<List<State>>();
			var result = this._userBusinessLayer.GetStates(countryId);
			if (result.Count > 0)
			{
				response.SatusCode = 200;
				response.Data = result;
				response.Message = "Success";
			}
			else
			{
				response.SatusCode = 500;
				response.Data = result;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}
	}
}
