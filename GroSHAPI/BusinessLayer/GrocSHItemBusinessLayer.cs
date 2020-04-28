using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DataAccessLayer;

namespace BusinessLayer
{
	public class GrocSHItemBusinessLayer: IGrocSHItemBusinessLayer
	{
		private IGrocSHItemDataAccess _grocSHItemDataAccess;
		public GrocSHItemBusinessLayer(IGrocSHItemDataAccess grocSHItemDataAccess)
		{
			this._grocSHItemDataAccess = grocSHItemDataAccess;
		}

		public int AddGroSHItem(GrocSHItem grocShItem)
		{
			return this._grocSHItemDataAccess.AddGroSHItem(grocShItem);
		}

		public List<Item> GetItems(string lat, string lon, int distance, int pageNumber, int rowsPerPage, int userId)
		{
			return this._grocSHItemDataAccess.GetItems(lat, lon, distance,pageNumber, rowsPerPage,userId);
		}

		public List<Item> GetFilterItems(string lat, string lon, int distance, int pageNumber, int rowsPerPage, int userId,string searchKey)
		{
			return this._grocSHItemDataAccess.GetFilterItems(lat, lon, distance, pageNumber, rowsPerPage, userId, searchKey);
		}

		public List<Item> GetMyItems(int pageNumber, int rowsPerPage, int userId)
		{
			return this._grocSHItemDataAccess.GetMyItems( pageNumber, rowsPerPage, userId);
		}
		//List<Item> GetFilterItems(string lat, string lon, int distance, int pageNumber, int rowsPerPage, int userId, string searchKey);
		public int UpdateImageName(int itemId, string imageName)
		{
			return this._grocSHItemDataAccess.UpdateImageName(itemId,imageName);
		}
	}
}
