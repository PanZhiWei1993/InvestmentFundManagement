using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.resultModel
{
    public class FileDocmentInfo
    {
        public string Id { get; set; }
        public string FileDesc { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public string Account { get; set; }
        public string NoticeId { get; set; }
        public string FileId { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public string FileSName { get; set; }
        public Nullable<int> FileSize { get; set; }
    }
}