﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.ASPX
{
    public static class PageInfo
    {
        public const string PageInfoOK = "OK";

        public const string ClientUsernameNull = "用户名不能为空";
        public const string ClientNotExist        = "用户不存在";
        public const string ClientPasswordNull = "密码不能为空";
        public const string ClientPasswordError   = "密码错误";


        public const string MessageBox_NotLogin = "请先登录";
        public const string MessageBox_NoAdministration = "对不起，你没有权限";




        public const string PathClientLogin = "/ASPX/Client/Login.aspx";
        public const string PathShowPage = "/Article/ShowPageMaster.aspx?articleId=";
        public const string PathCatalogArticleListPage = "/Article/CatalogArticleListMaster.aspx?catalog_name=";
        public const string PathEditPage = "/Article/EditPageMaster.aspx?articleId=";

        public const string PathParamNameOfArticleId = "articleId";
        public const string PathParamNameOfCatalogName = "catalog_name";

        public const string SessionKey_Client = "session_client";
        

        public const string ASPXPageTextLogin = "登录";

        public const string ASPXPageTextSubmit = "发布";
        public const string ASPXPageTextUpdate = "更新";



        public const string RoleTypeAdmin = "admin";
        public const string RoleTypeSuperAdmin = "superadmin";
        public const string RoleTypeClient = "client";


        public const int CatalogLocTop = 0;
        public const int CatalogLocHeader = 1;
        public const int CatalogLocNavigator = 2;
        public const int CatalogLocContent = 3;

        //自己修改
        public const int CatalogNumForMainPage = 4;
        public const string CatalogFirst=   "审批";
        public const string CatalogSecond = "审批1";
        public const string CatalogThird =  "申请";
        public const string CatalogForth =  "调研文章";
        public static string[] CatalogForMainPage = { CatalogFirst, CatalogSecond, CatalogThird, CatalogForth };


       
        public const int ArticlePerPage = 6;

    }
}