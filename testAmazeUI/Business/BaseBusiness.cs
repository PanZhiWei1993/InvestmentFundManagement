using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class BaseBusiness
    {
        public BaseBusiness(FUNDEntities fUNDEntities)
        {
            ef = fUNDEntities;
        }
        protected FUNDEntities ef ;
    }
}