using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.ASPX.Catalog
{
    public class CatalogHelper
    {
        public class CatalogMainBodyLoc
        {
            public const int LocMainBodyFirst = 1;
            public const int LocMainBodySecond = 2;
            public const int LocMainBodyThird = 3;
            public const int LocMainBodyForth = 4;
        }
        public const int CatalogMainBodyLocStart    = 1;
        public const int CatalogMainBodyLocEnd      = 4;

        public static string[] CatalogLocInfo = new string[4] { "主页位置1","主页位置2","主页位置3","主页位置4"};

       

    }
}