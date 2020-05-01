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
	[Authorize]
	public class GrocSHItemController : ApiController
    {
		
		public IGrocSHItemBusinessLayer _grocSHItemBusinessLayer;
		public GrocSHItemController(IGrocSHItemBusinessLayer grocSHItemBusinessLayer)
		{
			this._grocSHItemBusinessLayer = grocSHItemBusinessLayer;
		}

		/// <summary>
		/// This end points is use to add/update items
		/// </summary>
		/// <param name="grocSHItem"></param>
		/// <returns></returns>
		[HttpPost]
		public HttpResponseMessage AddUpdateGroshItem(GrocSHItem grocSHItem)
		{
			Response<int> response = new Response<int>();
			if (grocSHItem != null)
			{
				var result = this._grocSHItemBusinessLayer.AddGroSHItem(grocSHItem);
				if (result >0)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = grocSHItem.ItemId==0?Utility.Constants.ItemSuccessMesg : Utility.Constants.ItemUpdateMesg;
				}				
				else
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			return Request.CreateResponse(response);// Ok(response);
		}
		/// <summary>
		/// This end points is used to get items
		/// </summary>
		/// <param name="lat"></param>
		/// <param name="lon"></param>
		/// <param name="distance"></param>
		/// <param name="pageNumber"></param>
		/// <param name="numberOfRow"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpGet]
		public HttpResponseMessage GetItem(string lat, string lon,int distance, int pageNumber, int numberOfRow, int userId)
		{
			Response<List<Item>> response = new Response<List<Item>>();
			try
			{				
				List<Item> items = this._grocSHItemBusinessLayer.GetItems(lat, lon, distance, pageNumber, numberOfRow, userId);
				response.SatusCode = 200;
				response.Data = items;
				response.Message = "sucess";
			}
			catch(Exception)
			{
				response.SatusCode = 201;
				response.Data = null;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		/// <summary>
		/// This end point is used to get my item list
		/// </summary>
		/// <param name="pageNumber"></param>
		/// <param name="numberOfRow"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpGet]
		public HttpResponseMessage GetMyItem(int pageNumber, int numberOfRow, int userId)
		{
			Response<List<Item>> response = new Response<List<Item>>();
			try
			{
				List<Item> items = this._grocSHItemBusinessLayer.GetMyItems(pageNumber, numberOfRow, userId);
				response.SatusCode = 200;
				response.Data = items;
				response.Message = "sucess";
			}
			catch (Exception)
			{
				response.SatusCode = 201;
				response.Data = null;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		/// <summary>
		/// This end point is used to get filter item list
		/// </summary>
		/// <param name="lat"></param>
		/// <param name="lon"></param>
		/// <param name="distance"></param>
		/// <param name="pageNumber"></param>
		/// <param name="numberOfRow"></param>
		/// <param name="userId"></param>
		/// <param name="searchKey"></param>
		/// <returns></returns>
		[HttpGet]
		public HttpResponseMessage GetFilterItems(string lat, string lon, int distance, int pageNumber, int numberOfRow, int userId,string searchKey)
		{
			Response<List<Item>> response = new Response<List<Item>>();
			try
			{
				List<Item> items = this._grocSHItemBusinessLayer.GetFilterItems(lat, lon, distance, pageNumber, numberOfRow, userId,searchKey);
				response.SatusCode = 200;
				response.Data = items;
				response.Message = "sucess";
			}
			catch (Exception)
			{
				response.SatusCode = 201;
				response.Data = null;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}
	}
}
