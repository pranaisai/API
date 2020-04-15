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

		public List<Item> GetItems(string lat, string lon, int pageNumber, int rowsPerPage, int userId)
		{
			return this._grocSHItemDataAccess.GetItems(lat, lon,pageNumber,rowsPerPage,userId);
		}

		public List<Item> GetMyItems(int pageNumber, int rowsPerPage, int userId)
		{
			return this._grocSHItemDataAccess.GetMyItems( pageNumber, rowsPerPage, userId);
		}

		public int UpdateImageName(int itemId, string imageName)
		{
			return this._grocSHItemDataAccess.UpdateImageName(itemId,imageName);
		}
	}
}
