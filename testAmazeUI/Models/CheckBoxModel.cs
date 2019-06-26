using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models
{
    public class CheckBoxModel
    {
        public CheckBoxModel(List<BtnSelected> btnSelecteds,List<int?> _HasCheckList) {
            CheckBoxsList = btnSelecteds;
            hasCheckList = _HasCheckList;
        }
        /// <summary>
        /// 选择框选项
        /// </summary>
        public List<BtnSelected> CheckBoxsList { get; set; }
        /// <summary>
        /// 已经选择的选项
        /// </summary>
        public List<int?> HasCheckList
        {
            get
            {
                if (hasCheckList == null)
                {
                    return new List<int?>();
                }
                else
                {
                    return hasCheckList;
                }
            }
            set { value = hasCheckList; }
        }

        private List<int?> hasCheckList { get; set; }
    }
}