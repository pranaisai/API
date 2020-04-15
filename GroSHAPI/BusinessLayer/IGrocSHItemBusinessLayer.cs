using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
 	public interface IGrocSHItemBusinessLayer
	{
		int AddGroSHItem(GrocSHItem grocShItem);
		int UpdateImageName(int itemId, string imageName);
		List<Item> GetItems(string lat, string lon, int pageNumber, int rowsPerPage, int userId);
		List<Item> GetMyItems(int pageNumber, int rowsPerPage, int userId);
	}
}
