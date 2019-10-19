using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Security;

namespace WebApplication1.code
{
    public class code
    {
        //域名natapp，免费版是随机生成的
        public static string web = "47.100.164.196";

        /// <summary>
        /// 用户角色类型
        /// </summary>
        public enum role
        {
            微信用户,
            //院校管理员,
            //总管理员,
        }

   
   

        /// <summary>
        /// 获取用户角色
        /// </summary>
        public role getRole()
        {
            //获得进行了Forms身份验证的用户标识  
            FormsIdentity UserIdent = (FormsIdentity)(HttpContext.Current.User.Identity);
            //从身份验证票中获得用户数据  
            FormsAuthenticationTicket ticket = UserIdent.Ticket;

            role r = (role)Enum.Parse(typeof(role), ticket.UserData.ToString().Split(',')[0]);
            return r;
        }
        
       

        /// <summary>
        /// 验证手机号是否正确
        /// </summary>
        public static bool isPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(0|86|17951)?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$");
        }

     
 

       
    }
}