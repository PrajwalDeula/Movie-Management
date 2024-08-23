using Entity.Common;
using Entity.ViewModel;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;


namespace Helper {

	public static class FileHandler{
		public static string GetRootTemporary = "~/Uploads/Temp";
		public static string GetRootPermanent = "~/Uploads/Perm";

		public static string GetDocumentPath()
		{
			return AppServicesHelper.HostingEnvironment.WebRootPath + "//Docs//";
		}

		public static string GetTemporaryDocumentPath()

		{
			var rootPath = "C:\\Users\\Dell\\source\\repos\\MovieManagementSelf\\MovieManagementSelf\\wwwroot";
			var uploadPath = Path.Combine(rootPath, "prajwal");
			Directory.CreateDirectory(uploadPath);
			return String.Concat(uploadPath, @"\");


		}


		public static ResponseData UploadFile(IFormFile file)
		{
			try
			{
				string uploadPath = GetTemporaryDocumentPath();
				string filePath = uploadPath + file.FileName;
				//file.SaveAs(filePath);
				if (file.Length > 0)
				{
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
				}

			}
			catch (Exception ex)
			{
				return new ResponseData() { Success = false, Data = ex.Message };
			}

			return new ResponseData() { Success = true, Data = "" };
		}

		public static ResponseData UploadFile(List<IFormFile> files)
		{
			try
			{
				string uploadPath = GetTemporaryDocumentPath();
				foreach (IFormFile file in files)
				{
					string filePath = uploadPath + file.FileName;
					//file.SaveAs(filePath);
					if (file.Length > 0)
					{
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							file.CopyTo(stream);
						}
					}
				}

			}
			catch (Exception ex)
			{
				return new ResponseData() { Success = false, Data = ex.Message };
			}

			return new ResponseData() { Success = true, Data = "" };
		}
		public static ResponseData UploadFile(string fileName, IFormFile file)
		{
			string filePath = string.Empty;
			try
			{
				string uploadPath = GetTemporaryDocumentPath(); // "D:/NewFolder/"
				filePath = uploadPath + fileName;  // "D:/NewFolder/"
												   //file.SaveAs(filePath);
				if (file.Length > 0)
				{
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
				}
			}
			catch (Exception ex)
			{
				return new ResponseData() { Success = false, Data = ex.Message };
			}

			return new ResponseData() { Success = true, Data = fileName, Message = filePath, };
		}
		public static ResponseData UploadFile(Dictionary<string, IFormFile> files)
		{
			try
			{
				string uploadPath = GetTemporaryDocumentPath();
				foreach (KeyValuePair<string, IFormFile> file in files)
				{
					string filePath = uploadPath + file.Key;
					//file.Value.SaveAs(filePath);
					if (file.Value.Length > 0)
					{
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							file.Value.CopyTo(stream);
						}
					}
				}
			}
			catch (Exception ex)
			{
				return new ResponseData() { Success = false, Data = ex.Message };
			}

			return new ResponseData() { Success = true, Data = "" };
		}
		public static ResponseData<byte[]> DownloadStagingFile(string fileName)
		{
			ResponseData<byte[]> result = new ResponseData<byte[]>();
			try
			{
				string uploadPath = GetTemporaryDocumentPath();
				string filePath = Path.Combine(uploadPath, fileName);
				if (File.Exists(filePath))
				{
					byte[] fileBytes = File.ReadAllBytes(filePath);
					result.RespData = fileBytes;
					result.Success = true;
				}
				else
				{
					result.Message = "File doesn't exist.";
					result.Success = false;
				}
			}
			catch (Exception ex)
			{

				return result;
			}
			return result;
		}

		public static ResponseData<byte[]> DownloadFile(string fileName, string baseLocation = "")
		{
			ResponseData<byte[]> result = new ResponseData<byte[]>();
			try
			{
				string uploadPath = GetDocumentPath();
				if (!string.IsNullOrEmpty(baseLocation))
				{
					uploadPath += baseLocation + "\\";

				}
				string filePath = Path.Combine(uploadPath, fileName);
				if (File.Exists(filePath))
				{
					byte[] fileBytes = File.ReadAllBytes(filePath);
					result.RespData = fileBytes;
					result.Success = true;
				}
				else
				{
					result.Message = "File doesn't exist.";
					result.Success = false;
				}
			}
			catch (Exception ex)
			{
				return result;
			}

			return result;
		}
		public static ResponseData<Dictionary<string, byte[]>> DownloadFile(List<string> fileNames)
		{
			ResponseData<Dictionary<string, byte[]>> result = new ResponseData<Dictionary<string, byte[]>>();

			try
			{
				string uploadPath = GetDocumentPath();
				foreach (var fileName in fileNames)
				{
					string filePath = Path.Combine(uploadPath, fileName);
					if (File.Exists(filePath))
					{
						byte[] fileBytes = File.ReadAllBytes(filePath);
						result.RespData.Add(fileName, fileBytes);
					}
				}

				result.Success = true;
			}
			catch (Exception ex)
			{
				return result;
			}

			return result;
		}

		public static ResponseData<Dictionary<string, byte[]>> GetTemporaryFiles(List<string> guids)
		{
			ResponseData<Dictionary<string, byte[]>> result = new ResponseData<Dictionary<string, byte[]>>();

			try
			{
				result.RespData = new Dictionary<string, byte[]>();
				string uploadPath = GetTemporaryDocumentPath();
				foreach (var fileName in guids)
				{
					string filePath = Path.Combine(uploadPath, fileName);
					if (File.Exists(filePath))
					{
						byte[] fileBytes = File.ReadAllBytes(filePath);
						result.RespData.Add(fileName, fileBytes);
					}
				}

				result.Success = true;
			}
			catch (Exception ex)
			{
				return result;
			}

			return result;
		}
		public static ResponseData DeleteFile(string fileName)
		{
			var file = Path.Combine(GetDocumentPath(), fileName);
			if (File.Exists(file))
			{
				File.Delete(file);
			}

			return new ResponseData() { Success = true };
		}
		public static ResponseData DeleteFile(List<string> fileNames)
		{
			ResponseData result = new ResponseData();
			foreach (var item in fileNames)
			{
				var file = Path.Combine(GetDocumentPath(), item);
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
			return new ResponseData() { Success = true };
		}

		public static ResponseData DeleteStagingFile(string fileName)
		{
			var file = Path.Combine(GetTemporaryDocumentPath(), fileName);
			if (File.Exists(file))
			{
				File.Delete(file);
			}

			return new ResponseData() { Success = true };
		}

		public static ResponseData DeleteStagingFile(List<string> fileNames)
		{
			foreach (var item in fileNames)
			{
				var file = Path.Combine(GetTemporaryDocumentPath(), item);
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}

			return new ResponseData() { Success = true };
		}

		public static ResponseData MoveFileToFinalLocation(List<string> guids)
		{
			ResponseData result = new ResponseData();
			List<Tuple<string, string>> movedFiles = new List<Tuple<string, string>>();
			try
			{
				string tempPath = GetTemporaryDocumentPath();
				string finalPath = GetDocumentPath();
				foreach (var name in guids)
				{
					string tempFilePath = Path.Combine(tempPath, name);
					string finalFilePath = Path.Combine(finalPath, name);
					if (File.Exists(tempFilePath))
					{
						//Move File From Temporary to Final Location
						File.Move(tempFilePath, finalFilePath);
						movedFiles.Add(new Tuple<string, string>(tempFilePath, finalFilePath));
					}
				}

				result.Success = true;
			}
			catch (IOException ioException)
			{
				//Item1 is tempLocation, Item2 is finalLocation
				foreach (Tuple<string, string> file in movedFiles)
				{
					if (File.Exists(file.Item2))
					{
						//Revert File From Final to Temporary Location
						File.Move(file.Item2, file.Item1);
					}
				}

				result.Success = false;
			}
			catch (Exception ex)
			{
				return result;
			}

			return result;
		}


		public static ResponseData MoveFileToTempLocation(List<string> guids)
		{
			ResponseData result = new ResponseData();
			try
			{
				string tempPath = GetTemporaryDocumentPath();
				string finalPath = GetDocumentPath();
				foreach (var name in guids)
				{
					string tempFilePath = Path.Combine(tempPath, name);
					string finalFilePath = Path.Combine(finalPath, name);
					if (File.Exists(finalFilePath))
					{
						//Move File From Temporary to Final Location
						File.Move(finalFilePath, tempFilePath);
					}
				}

				result.Success = true;
			}
			catch (IOException ioException)
			{
				result.Success = false;
			}
			catch (Exception ex)
			{
				return result;
			}

			return result;
		}

		public static ResponseData SaveFile(List<string> saveList, List<string> deleteList)
		{
			ResponseData result = new ResponseData();
			result = FileHandler.MoveFileToFinalLocation(saveList);
			if (!result.Success) return result;
			result = FileHandler.MoveFileToTempLocation(deleteList);
			if (!result.Success)
			{
				FileHandler.MoveFileToTempLocation(saveList);
				return result;
			}
			result.Success = true;
			return result;
		}

		public static ResponseData FinalizeFileSave(List<string> saveList, List<string> deleteList)
		{
			ResponseData result = new ResponseData();
			result = FileHandler.DeleteStagingFile(deleteList);
			if (!result.Success) return result;
			result.Success = true;
			return result;
		}



		public static void FinalizeFileCopy(List<DocumentDetailsVM> vm, string finalLocation, bool copyWithExtension = false)
		{
			List<string> toDelete = vm.Where(x => x.IsDeleted == true).Select(x =>
				(string)x.DocGuid
			).ToList();
			DeleteStagingFile(toDelete);

			string tempPath = GetTemporaryDocumentPath();
			string finalPath = finalLocation;

			foreach (var item in vm)
			{
				string tempFilePath = Path.Combine(tempPath, item.DocGuid);
				string finalFilePath = finalPath + Path.GetFileName(tempFilePath);
				if (copyWithExtension)
				{
					finalFilePath += @"." + item.FileExtension;
				}
				if (File.Exists(tempFilePath))
				{
					File.Move(tempFilePath, finalFilePath);
				}
			}
		}
		public static DocumentDetailsVM DevelopDocumentDetail(string docGuid, string loc, string uiFilename)
		{
			string fileName = loc + docGuid;
			var toReturn = new DocumentDetailsVM();
			FileInfo fi = new FileInfo(fileName);
			toReturn.FileExtension = fi.Extension;
			toReturn.Filename = uiFilename;
			toReturn.IsChange = false;
			toReturn.IsDeleted = false;
			toReturn.DocGuid = fi.Name.Split(".").Length > 0 ? fi.Name.Split(".")[0] : string.Empty;

			return toReturn;
		}
	}


}

