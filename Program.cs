using System.Net;
using System.IO;


namespace webdav.yandex;
class Program
{
    static void Main(string[] args)
    {
        var folder  = "";
        var url     = "https://webdav.yandex.ru/";
        var user    = "";
        var passwd  = "";
        var request = HttpWebRequest.Create(url) as HttpWebRequest;

        var lines = File.ReadAllLines("/inRamA/passwd");
        user   = lines[0].Trim();
        passwd = lines[1].Trim();
        url    = lines[2].Trim();

        request.Credentials = new NetworkCredential(user, passwd);
        // request.Method      = "PROPFIND";
        request.Method      = "GET";
        request.Headers.Add("Depth", "1");
        var response        = (HttpWebResponse) request.GetResponse();
        var code            = response.StatusCode;

        Console.WriteLine(code);

        if (code == HttpStatusCode.OK || code == HttpStatusCode.MultiStatus)
        {
            long contentLength = long.Parse(response.GetResponseHeader("Content-Length"));
            Console.WriteLine(contentLength);

            byte[] bytes = new byte[contentLength];

            using (Stream s = response.GetResponseStream())
            {
                for (var i = 0; i < contentLength; )
                    i += s.Read(bytes, i, bytes.Length - i);
            }

            File.WriteAllBytes("bytes",  bytes);
        }
    }
}
