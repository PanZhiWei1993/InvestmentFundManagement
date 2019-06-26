using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testAmazeUI.Controllers
{
    public class UploadController : BaseController
    {
        // GET: Upload
        public ActionResult UpLoadProcess(string id, string name, string type, string lastModifiedDate, int size, HttpPostedFileBase file,string UpType)
        {
            try
            {
                if (Request.Files.Count == 0)
                {
                    return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
                }
                string filePathName = string.Empty;

                string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                localPath = Path.Combine(localPath, DateTime.Now.ToString("yyyyMM"));
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                string ex = Path.GetExtension(file.FileName);
                string fileType = ex.Replace(".", "");
                localPath = Path.Combine(localPath, fileType);
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                string fileID = Guid.NewGuid().ToString("N");
                filePathName = fileID + ex;
                string filePath = Path.Combine(localPath, filePathName);
                file.SaveAs(filePath);
                //相对路径
                filePath = filePath.Replace(HttpRuntime.AppDomainAppPath, "~\\");
                _FileBusiness.AddFileInfo(fileID, name, filePath, fileType, size, UpType, loginUser.Id);
                ef.SaveChanges();
                return Json(new
                {
                    jsonrpc = "2.0",
                    id,                   
                    FileId = fileID,
                    FilePath= filePath
                });
            }
            catch (DbEntityValidationException dex) {
                dex.ToString();
                return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
          }
    }
}