using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using System.Web;

namespace DataAccessLayer
{
	public class GrocSHItemDataAccess : IGrocSHItemDataAccess
	{
		/// <summary>
		/// Add or update item interface implementation
		/// </summary>
		/// <param name="grocShItem"></param>
		/// <returns></returns>
		public int AddGroSHItem(GrocSHItem grocShItem)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					if (grocShItem.ItemId == 0)
					{
						var result = db.GrocsharyItems.Add(new GrocsharyItem()
						{
							ItemName = grocShItem.ItemName,
							user_id = grocShItem.user_id,
							itemDescription = grocShItem.ItemDescription,
							exchangeItem = grocShItem.ExchangeItem,
							lat = grocShItem.Lat,
							lon = grocShItem.Lon,
							imageName = grocShItem.ImageName,
							createdDate = DateTime.Now,
							modifiedDate = DateTime.Now,
							IsActive = true
						});
						flag = db.SaveChanges();
						flag = result.itemId;
					}
					else
					{
						GrocsharyItem c = (from x in db.GrocsharyItems
										   where x.itemId == grocShItem.ItemId
										   select x).First();
						c.ItemName = grocShItem.ItemName;
						c.itemDescription = grocShItem.ItemDescription;
						c.exchangeItem = grocShItem.ExchangeItem;
						//c.imageName = grocShItem.ImageName;
						c.IsActive = grocShItem.IsActive;
						c.modifiedDate = DateTime.Now;
						flag = db.SaveChanges();
						flag = grocShItem.ItemId;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}
		/// <summary>
		/// This method is used to Get Items List
		/// </summary>
		/// <param name="lat"></param>
		/// <param name="lon"></param>
		/// <param name="pageNumber"></param>
		/// <param name="rowsPerPage"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<Item> GetItems(string lat, string lon, int distance, int pageNumber, int rowsPerPage, int userId)
		{
			List<Item> items = new List<Item>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var ctx = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
					var root = ctx + "/ItemImages";

					var result = (from grocShItem in db.GetItems(lat, lon, distance, pageNumber, rowsPerPage, userId)
								  select grocShItem).ToList();

					if (result != null)
					{
						foreach (var item in result)
						{
							Item data = new Item();
							data.ItemId = item.itemId;
							data.ItemName = item.ItemName;
							data.ItemDescription = item.itemDescription;
							data.ExchangeItem = item.exchangeItem;
							data.ImageName = item.imageName;
							data.Distance = item.distance;
							data.IsActive = true;
							if (!string.IsNullOrEmpty(item.imageName))
							{
								data.ImageUrl = root + "/" + item.imageName;
							}
							else
							{
								data.ImageUrl = string.Empty;
							}
							items.Add(data);
						}
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return items;
			//a=(from x in db.procname()select new a(){a.name=x.nze}).tolist();
		}

		public List<Item> GetFilterItems(string lat, string lon, int distance, int pageNumber, int rowsPerPage, int userId, string searchKey)
		{
			List<Item> items = new List<Item>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var ctx = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
					var root = ctx + "/ItemImages";
					if (!string.IsNullOrEmpty(searchKey))
					{
						var result = (from grocShItem in db.GetItemsWithFilter(lat, lon, distance, pageNumber, rowsPerPage, userId, searchKey)
									  select grocShItem).ToList();

						if (result != null)
						{
							foreach (var item in result)
							{
								Item data = new Item();
								data.ItemId = item.itemId;
								data.ItemName = item.ItemName;
								data.ItemDescription = item.itemDescription;
								data.ExchangeItem = item.exchangeItem;
								data.ImageName = item.imageName;
								data.Distance = item.distance;
								data.IsActive = item.IsActive;
								if (!string.IsNullOrEmpty(item.imageName))
								{
									data.ImageUrl = root + "/" + item.imageName;
								}
								else
								{
									data.ImageUrl = string.Empty;
								}
								items.Add(data);
							}
						}
					}
					else
					{
						var result = (from grocShItem in db.GetItems(lat, lon, distance, pageNumber, rowsPerPage, userId)
									  select grocShItem).ToList();

						if (result != null)
						{
							foreach (var item in result)
							{
								Item data = new Item();
								data.ItemId = item.itemId;
								data.ItemName = item.ItemName;
								data.ItemDescription = item.itemDescription;
								data.ExchangeItem = item.exchangeItem;
								data.ImageName = item.imageName;
								data.Distance = item.distance;
								data.IsActive = true;
								if (!string.IsNullOrEmpty(item.imageName))
								{
									data.ImageUrl = root + "/" + item.imageName;
								}
								else
								{
									data.ImageUrl = string.Empty;
								}
								items.Add(data);
							}
						}
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return items;
			//a=(from x in db.procname()select new a(){a.name=x.nze}).tolist();
		}

		/// <summary>
		/// This method is used to get my itme list
		/// </summary>
		/// <param name="pageNumber"></param>
		/// <param name="rowsPerPage"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<Item> GetMyItems(int pageNumber, int rowsPerPage, int userId)
		{
			List<Item> items = new List<Item>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var ctx = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
					var root = ctx + "/ItemImages";
					var result = (from grocShItem in db.GetMyItems(pageNumber, rowsPerPage, userId)
								  select grocShItem).ToList();

					if (result != null)
					{
						foreach (var item in result)
						{
							Item data = new Item();
							data.ItemId = item.itemId;
							data.ItemName = item.ItemName;
							data.ItemDescription = item.itemDescription;
							data.ExchangeItem = item.exchangeItem;
							data.ImageName = item.imageName;
							data.IsActive = item.IsActive;
							if (!string.IsNullOrEmpty(item.imageName))
							{
								data.ImageUrl = root + "/" + item.imageName;
							}
							else
							{
								data.ImageUrl = string.Empty;
							}
							items.Add(data);
						}
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return items;
		}

		/// <summary>
		/// Updated Image name interface implementation
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="imageName"></param>
		/// <returns></returns>
		public int UpdateImageName(int itemId, string imageName)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					if (itemId != 0)
					{
						GrocsharyItem c = (from x in db.GrocsharyItems
										   where x.itemId == itemId
										   select x).First();
						c.imageName = imageName;
						flag = db.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}
	}
}
