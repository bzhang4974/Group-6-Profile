using Group6_Profile.DTO.DTO;
using Group6_Profile.Service.Entity;
using Group6_Profile.Service.Service;

using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Group6_Profile.web.Controllers
{

    public class UpFileController : Controller
    {
        private readonly SFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpFileController(SFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }
        /// <summary>
        /// download picture
        /// </summary>
        /// <param name="key">pic Id</param>
        /// <returns></returns>
        public ActionResult DownFile(long key)
        {
            SFileDTO upFile = _fileService.GetDataAsync(key);
            if (upFile == null)
            {
                return null;
            }
            string oracleFile = PubPath.UpLoadPath + upFile.FilePath;
            //pic type
            var contentTypDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image//vnd.wap.wbmp"},
                {"rp","image/vnd.rn-realpix"}
            };
            var contentTypeStr = "image/jpeg";
            var imgTypeSplit = upFile.FileType.Split('.');
            var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();
            {
                contentTypeStr = contentTypDict[imgType];
            }
            using (var sw = new FileStream(oracleFile, FileMode.Open))
            {
                var bytes = new byte[sw.Length];
                sw.Read(bytes, 0, bytes.Length);
                sw.Close();
                return new FileContentResult(bytes, contentTypeStr);
            }
        }
        /// <summary>
        /// download picture
        /// </summary>
        /// <param name="key">pic Id</param>
        /// <returns></returns>
        public ActionResult DownFile2(long key)
        {
            var contentTypeStr = "image/jpeg";
            var contentTypDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image//vnd.wap.wbmp"},
                {"rp","image/vnd.rn-realpix"}
            };
            SFileDTO upFile = _fileService.GetDataByDataIdAsync(key);
            string oracleFile = _webHostEnvironment.WebRootFileProvider.GetFileInfo("images/5db11ff4gw1e77d3nqrv8j203b03cweg.jpg")?.PhysicalPath;
            if (upFile != null)
            {
                oracleFile = PubPath.UpLoadPath + upFile.FilePath;

                var imgTypeSplit = upFile.FileType.Split('.');
                var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();

                contentTypeStr = contentTypDict[imgType];
            }
           
             
            using (var sw = new FileStream(oracleFile, FileMode.Open))
            {
                var bytes = new byte[sw.Length];
                sw.Read(bytes, 0, bytes.Length);
                sw.Close();
                return new FileContentResult(bytes, contentTypeStr);
            }
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
