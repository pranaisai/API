using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GroSHAPI.Controllers
{
	[RoutePrefix("api/FileUploading")]
	public class FileUploadingController : ApiController
    {	

		public IGrocSHItemBusinessLayer _grocSHItemBusinessLayer;
		public FileUploadingController(IGrocSHItemBusinessLayer grocSHItemBusinessLayer)
		{
			this._grocSHItemBusinessLayer = grocSHItemBusinessLayer;
		}

		/// <summary>
		/// This end points is used to uplod images on server
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("UploadFile")]
		[Authorize]
		public async Task<string> UploadFile()
		{
			string itemId = string.Empty;
			string result = string.Empty;
			var ctx = HttpContext.Current;
			var root = ctx.Server.MapPath(Utility.Constants.ImageFolder);
			var provider = new MultipartFormDataStreamProvider(root);
			try
			{
				await Request.Content.ReadAsMultipartAsync(provider);
				System.Collections.Specialized.NameValueCollection formData = provider.FormData;
				if (formData.HasKeys() == true)
				{
					 itemId = formData[Utility.Constants.ItemID];
				}
				foreach (var file in provider.FileData)
				{
					var name = file.Headers.ContentDisposition.FileName;
					//remove  double quotes form string
					name = name.Trim('"');
					var localFileName = file.LocalFileName;
					var filePath = Path.Combine(root, name);
					if (!File.Exists(filePath))
					{
						File.Move(localFileName, filePath);
						var output = this._grocSHItemBusinessLayer.UpdateImageName(Convert.ToInt32(itemId), name);
						if (output == 1)
						{
							result = Utility.Constants.Success;
						}
						else
						{
							result = Utility.Constants.Failed;
						}
					}
					else
					{
						File.Delete(filePath);
						File.Move(localFileName, filePath);
						result = Utility.Constants.Success;
					}
				}
			}
			catch (Exception ex)
			{
				return $"Error :{ ex.Message}";
			}
			return result;
		}

	}
}
