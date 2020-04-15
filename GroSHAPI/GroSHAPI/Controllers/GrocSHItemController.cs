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
					response.Message = grocSHItem.ItemId==0?Utility.Constants.SuccessMesg: Utility.Constants.UpdateMesg;
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

		[HttpGet]
		public HttpResponseMessage GetItem(string lat, string lon, int pageNumber, int numberOfRow, int userId)
		{
			Response<List<Item>> response = new Response<List<Item>>();
			try
			{				
				List<Item> items = this._grocSHItemBusinessLayer.GetItems(lat, lon, pageNumber, numberOfRow, userId);
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
	}
}
