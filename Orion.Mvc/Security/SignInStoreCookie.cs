using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public class SignInStoreCookie : ISignInStore
    {
        private static string _storeName = FormsAuthentication.FormsCookieName;


		/// <summary></summary>
		public FormsAuthenticationTicket Get()
        {
            HttpContext httpContext = HttpContext.Current;


            /*Cookies 不存在，跳過不處理*/
            if (false == httpContext.Request.Cookies.AllKeys.Contains(_storeName)) { return null; }

            var cookie = httpContext.Request.Cookies[_storeName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
			
            return new FormsAuthenticationTicket(
                1,
                ticket.Name,
                ticket.IssueDate,
                ticket.Expiration, 
                false,
				decompress(ticket.UserData),
                FormsAuthentication.FormsCookiePath
            ); 
        }



		/// <summary></summary>
		public void Set(FormsAuthenticationTicket ticket)
        {
            ticket = new FormsAuthenticationTicket(
                1,
                ticket.Name,
                ticket.IssueDate,
                ticket.Expiration, 
                false,
                compress(ticket.UserData),
                FormsAuthentication.FormsCookiePath
            ); 


            string encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(_storeName, encTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }



		/// <summary></summary>
		public void Remove()
        {
            HttpContext httpContext = HttpContext.Current;
            httpContext.Response.Cookies.Add(new HttpCookie(_storeName, null));
        }




		/*壓縮*/
        private static string compress(string text)
        {
            if (string.IsNullOrEmpty(text)) { return ""; }


            byte[] buffer = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (var zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }


		/*解壓縮*/
        private static string decompress(string compressedText)
        {
            if (string.IsNullOrEmpty(compressedText)) { return ""; }


            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (var ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (var zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }


    }
}
