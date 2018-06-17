using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using XiaoHan;

namespace Forum.Common
{
    public class EmailHelper
    {
        public static void SendEmail(string email, string body)
        {
            string fromUserName = "1103892709@qq.com";
            using (Mail m = new Mail(fromUserName, "blepkeutmaqrjdeb", "smtp.qq.com", 25)) // 非常奇葩，不能用变量
            {
                m.Message.From = new MailAddress(fromUserName, "HKR project");
                m.Message.Body = body;
                m.Message.Subject = "Register";
                m.Message.To.Add(email);

                m.Client.EnableSsl = true;
                m.Send();
            }

        }
    }
}