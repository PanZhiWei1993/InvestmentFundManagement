using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models
{
    public class SelBtnModel
    {
        public SelBtnModel(List<BtnSelected> _data,string _deValue) {
            data = _data;
            deValue = _deValue;
        }
        public List<BtnSelected> data { get; set; }
        public string deValue { get; set; }
    }
}