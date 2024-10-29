using System.Net;

namespace Lecture1._6_Http
{
    internal class Program
    {
        static string OpenSite(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(OpenSite("https://google.com"));
        }
    }
}
