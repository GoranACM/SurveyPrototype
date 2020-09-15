/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using System.Web;

namespace SurveyPrototype.SurveyUtilities
{
    public class SurveyUtil
    {
        /// <summary>
        /// Method for getting the IP address of the User
        /// </summary>
        /// <returns>IP Address as a string</returns>
        public static string getUserIP()
        {
            // Get IP through PROXY
            HttpContext context = HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            // return ipAddress;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] address = ipAddress.Split(',');
                if (address.Length != 0)
                {
                    return address[0];
                }
            }
            
            // Get IP with WEB HTTP REQUEST
            ipAddress = context.Request.UserHostAddress;

            if (ipAddress.Trim() == "::1")
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = System.Net.Dns.GetHostName();
                //Get Ip Host Entry
                System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    ipAddress = arrIpAddress[1].ToString();
                }
                catch
                {
                    try
                    {
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                            ipAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            ipAddress = "127.0.0.1";
                        }
                    }
                }
            }
            return ipAddress;
        }

    }
}