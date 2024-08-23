using Entity.Common;
using Entity.Model;
using Entity.ViewModel;
using Extensions;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MovieManagementSelf.Controllers
{
	public class FileUploadController : Controller
	{
		[HttpPost]
		public JsonResult UploadFile()
		{
			ResponseData result = new ResponseData();

			try
			{
				var collection = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
				DocumentDetailsVM data = JsonConvert.DeserializeObject<DocumentDetailsVM>(collection["data"]);

				if (Request.Form.Files != null && Request.Form.Files.Count > 0)
				{
					var file = Request.Form.Files[0];

					//string mimeType = file?.ContentType;
					if (file != null)
					{
						if (file.Length / 1048576 > 2)
						{
							result.Message = "File size must be less then 2MB.";
							result.Success = false;
						}
						else
						{
							//xyz.pdf   -> xyz     def     pdf

							var extArray = file.FileName.Split('.');
							string fileExtension;
							if (extArray == null || extArray.Length < 2)
							{
								result.Success = false;
								result.Message = "File has invalid extension.";
								return Json(result);
							}
							fileExtension = extArray[extArray.Length - 1];
							if (string.IsNullOrEmpty(fileExtension))
							{
								result.Success = false;
								result.Message = "File has invalid extension.";
								return Json(result);
							}

							{
								ResponseData fileResult = FileHandler.UploadFile(Guid.NewGuid().ToString() + "." + fileExtension, file);
								if (fileResult.Success)
								{
									var docDetails = new
									{
										DocGuid = fileResult.Data.ToText(),
										DocTypeId = data.DocTypeId,
										MimeType = file.ContentType,
										FileExtension = fileExtension,
										BaseLocation = fileResult.Message
									};
									result.Data = docDetails;
									result.Success = true;
								}
							}
						}
					}
					else
					{
						result.Message = "Uploaded File is not valid";
						result.Success = false;
					}
				}
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}

			return Json(result);
		}

	}
}
