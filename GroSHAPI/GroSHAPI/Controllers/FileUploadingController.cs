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

		[HttpPost]
		[Route("UploadFile")]
		//[Authorize]
		public async Task<string> UploadFile()
		{
			string userID = string.Empty;
			string result = string.Empty;
			var ctx = HttpContext.Current;
			var root = ctx.Server.MapPath("~/ItemImages");
			var provider = new MultipartFormDataStreamProvider(root);
			try
			{
				await Request.Content.ReadAsMultipartAsync(provider);
				System.Collections.Specialized.NameValueCollection formData = provider.FormData;
				if (formData.HasKeys() == true)
				{
					 userID = formData["ItemID"];
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
						var output = this._grocSHItemBusinessLayer.UpdateImageName(Convert.ToInt32(userID), name);
						if (output == 1)
						{
							result = "Success";
						}
						else
						{
							result = "Failed";
						}
					}
					else
					{
						result = "AlreadyExists";
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
