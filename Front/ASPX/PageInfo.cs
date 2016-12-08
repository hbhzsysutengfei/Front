using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.ASPX
{
    public static class PageInfo
    {
        public const string PageInfoOK = "OK";

        public const string ClientUsernameNull = "用户名不能为空";
        public const string ClientUsernameNotExist        = "用户不存在";
        public const string ClientUsernameAlreadExist = "用户名已经存在";
        public const string ClientPasswordNull = "密码不能为空";
        public const string ClientPasswordError   = "密码错误";
        public const string ClientRealNameNull = "真实名字不能为空";



        public const string ClientOriginalPasswordNull = "原始密码不能为空";
        public const string ClientNewPasswordNull = "新密码不能为空";
        public const string ClientRepeatPasswordNull = "重复密码为空";
        public const string ClientNewPasswordAndRepeatPasswordNotSame = "两次密码不一致";
        public const string MessageInfo_CatalogNameNotExist = "栏目不存在！";
        public const string MessageInfo_CatalogNameNull = "栏目名称不能为空";
        public const string MessageInfo_CatalogNameExist = "栏目名称已经存在";
        public const string MessageInfo_AddCatalogError = "添加栏目失败，请联系开发者";
        public const string MessageInfo_ParamCatalogNameNull = "获取栏目名参数失败";


        public const string MessageBox_NotLogin = "请先登录";
        public const string MessageBox_NoAdministration = "对不起，你没有权限";




        public const string PathClientLogin = "/ASPX/Client/Login.aspx?path_from=";
        public const string PathClientInfo = "/ASPX/Client/ClientInfo.aspx?client_name=";
        public const string PathChangePassword = "/ASPX/Client/ChangePassword.aspx";
        public const string PathShowPage = "/Article/ShowPageMaster.aspx?articleId=";
        public const string PathCatalogArticleListPage = "/Article/CatalogArticleListMaster.aspx?catalog_name=";
        public const string PathEditPage = "/Article/EditPageMaster.aspx?articleId=";

        public const string PathCatalogAddPage = "/ASPX/Catalog/CatalogAdd.aspx";
        public const string PathCatalogAuthorizePage = "/ASPX/Catalog/CatalogAuthorize.aspx?catalog_name=";
 

        public const string PathDefaultPage = "/";

        public const string PathParamNameOfArticleId = "articleId";
        public const string PathParamNameOfCatalogName = "catalog_name";
        public const string PathParmaNameOfPathFrom = "path_from";
        public const string PathParamNameOfClientName = "client_name";
       

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



        public const int NumberOfArticleForMainPage = 6;
        public const int NumberOfArticleForUserPage = 20;
        public const int NumberOfClientForSuperAdmin = 30;






        public const string DepartmentAll = "所有部门";

       
    }
}