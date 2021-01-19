using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HomeAutoApp.Models
{
    public static class Scraper
    {
        public static string getHtml(string url)
        {
            string html = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (String.IsNullOrWhiteSpace(response.CharacterSet))
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    html = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();
                }
            }
            catch (WebException webExcp)
            {
                WebExceptionStatus status = webExcp.Status;

                if (status == WebExceptionStatus.ProtocolError)
                {
                    // Check the HTTP status code.  
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    Console.WriteLine($"{(int)httpResponse.StatusCode}-{httpResponse.StatusCode}");
                }
            }


            return html;
        }
    }
}
