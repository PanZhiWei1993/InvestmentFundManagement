using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class FileBusiness:BaseBusiness
    {
        public FileBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        public IQueryable<tb_FileInfo> GetUserIcon() {
            return GetFileByUpType("userIcon");
        }

        public IQueryable<tb_FileInfo> GetNoticeFile() {
            return GetFileByUpType("noticeFile");
        }

        public IQueryable<tb_FileInfo> GetProjectFile()
        {
            return GetFileByUpType("projectFile");
        }
        public IQueryable<tb_FileInfo> GetProjectImg() {
            return GetFileByUpType("projectImg");
        }

        private IQueryable<tb_FileInfo> GetFileByUpType(string upType) {
            return GetAllData().Where(f => f.UpType == upType);
        }

        public IQueryable<tb_FileInfo> GetAllData() {
            return ef.tb_FileInfo;
        }
        #endregion
        #region ##新增##
        public tb_FileInfo AddFileInfo(string Id, string FileSName, string FilePath, string FileType,Nullable<int> FileSize, string UpType,string AddUser) {
            tb_FileInfo newData = new tb_FileInfo();
            newData.Id = Id;
            newData.FileSName = FileSName;
            newData.FilePath = FilePath;
            newData.FileSize = FileSize;
            newData.UpType = UpType;
            newData.FileType = FileType;
            newData.AddUser = AddUser;
            newData.InsertTime = DateTime.Now;
            ef.tb_FileInfo.Add(newData);
            return newData;
        }
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        #endregion
        #region ##私有方法##
        #endregion
    }
}