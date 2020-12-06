using System;
using System.Net;
namespace Argon
{
    public class Network
    {
        private string url;
        private WebClient wc = new WebClient();
        public Network(string url)
        {
            this.url = url;
        }
        public string DownloadString() => wc.DownloadString(url);
        public void DownloadFile(string file) => wc.DownloadFile(url,file);
        public void SetUrl(string url) => this.url = url;
        
    }
}
