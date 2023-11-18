using Group6_Profile.DTO.DTO;
using Group6_Profile.Service.Service;

using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.web.Controllers
{
    [CheckCustomer]
    public class UpFileController : Controller
    {
        private readonly SFileService _fileService;
        public UpFileController(SFileService fileService)
        {
            _fileService = fileService;
        }
        /// <summary>
        /// upload file
        /// </summary>
        /// <param name="Code">file type code</param>
        /// <param name="id"></param>
        /// <param name="name">filename</param>
        /// <param name="type">file type</param>
        /// <param name="lastModifiedDate"></param>
        /// <param name="size"></param>
        /// <param name="chunk"></param>
        /// <param name="chunks"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<ActionResult> UploadFile(string Code, IFormFile file)
        {
            try
            {
                string filePathName = string.Empty;
                string localPath = System.DateTime.Now.Year + "\\" + System.DateTime.Now.Month + "\\" + System.DateTime.Now.Day + "\\";

                if (Directory.Exists(PubPath.UpLoadPath + localPath) == false)
                {
                    Directory.CreateDirectory(PubPath.UpLoadPath + localPath);
                }

                string ex = file.FileName;
                filePathName = localPath + Guid.NewGuid().ToString("N") + Path.GetExtension(ex);
                // System.IO.File.sa(Path.Combine(PubPath.UpLoadPath, filePathName));
                using (var stream = System.IO.File.Create(PubPath.UpLoadPath + filePathName))
                {
                    await file.CopyToAsync(stream);
                }
                SFileDTO sUpload = new SFileDTO();
                sUpload.FileText = Path.GetFileNameWithoutExtension(file.FileName);
                sUpload.FilePath = filePathName;
                sUpload.FileSize = file.Length;
                sUpload.FileType = Path.GetExtension(file.FileName); ;
                sUpload.Code = Code;
                long? Id = await _fileService.SaveData(sUpload);
                if (Id.HasValue)
                {
                    return Json(new
                    {
                        code = 0,
                        msg = sUpload.FileText,
                        data = Id
                    });
                }
                else
                {
                    return Json(new
                    {
                        code = 1,
                        msg = "save file fail",
                        data = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 1,
                    msg = "save file fail",
                    data = ""
                });
            }
        }
    }
}
