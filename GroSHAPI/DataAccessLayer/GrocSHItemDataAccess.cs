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
						db.GrocsharyItems.Add(new GrocsharyItem()
						{
							ItemName = grocShItem.ItemName,
							user_id = grocShItem.user_id,
							itemDescription = grocShItem.ItemDescription,
							exchangeItem = grocShItem.ExchangeItem,
							lat = grocShItem.Lat,
							lon = grocShItem.Lon,
							imageName = grocShItem.ImageName,
							createdDate = DateTime.Now,
							modifiedDate = DateTime.Now
						});
						flag = db.SaveChanges();
						flag = (from record in db.GrocsharyItems orderby record.itemId select record.itemId).Last();
					}
					else
					{
						GrocsharyItem c = (from x in db.GrocsharyItems
										   where x.itemId == grocShItem.ItemId
										   select x).First();
						c.ItemName = grocShItem.ImageName;
						c.itemDescription = grocShItem.ItemDescription;
						c.exchangeItem = grocShItem.ExchangeItem;
						c.imageName = grocShItem.ImageName;
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

		public List<Item> GetItems(string lat, string lon, int pageNumber, int rowsPerPage, int userId)
		{
			List<Item> items = new List<Item>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var ctx = HttpContext.Current;
					var root = ctx.Server.MapPath("~/ItemImages");

					var result = (from grocShItem in db.GetItems(lat, lon, pageNumber, rowsPerPage, userId)
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
							data.ImageUrl = root;
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

		public List<Item> GetMyItems(int pageNumber, int rowsPerPage, int userId)
		{
			List<Item> items = new List<Item>();
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var ctx = HttpContext.Current;
					var root = ctx.Server.MapPath("~/ItemImages");

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
							data.ImageUrl = root;
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
