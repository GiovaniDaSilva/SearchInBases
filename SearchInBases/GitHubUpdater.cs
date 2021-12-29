using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace SearchInBases
{
    class GitHubUpdater
    {

        private const string URL = "https://api.github.com/repos/GiovaniDaSilva/SearchInBases/releases/latest";

    
        public static void CheckNewVersion()
        {
            WebClient webClient = new();
            webClient.Headers.Add("User-Agent", "request");

            string data;
            try
            {
                data = webClient.DownloadString(URL);
            }
            catch (WebException)
            {
                return;
            }

            var info = JsonConvert.DeserializeObject<ReleaseInfo>(data);

            if (info.tag_name.StartsWith("v")) info.tag_name = info.tag_name.Substring(1);
            info.tag_name = info.tag_name.Replace(Vars.appName, "").Trim();

            if (info.tag_name != Vars.appVersion)
            {                
                if (Message.Question($"Existe uma nova versão de {Vars.appName} disponível!" + Environment.NewLine +
                    Environment.NewLine +
                    "Nova versão: " + info.tag_name + Environment.NewLine +
                    "Publicada em: " + info.published_at.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine +
                    Environment.NewLine +
                    "Você deseja baixar a nova versão do GitHub agora?"))
                {
                    Process.Start("explorer", info.html_url);
                }             
            }
        }

#pragma warning disable 0649
        private class ReleaseInfo
        {
            public string html_url;
            public string tag_name;
            public string name;
            public DateTime published_at;
            public List<ReleaseAssetInfo> assets;
            public string body;
        }

        private class ReleaseAssetInfo
        {
            public string name;
            public long size;
            public string browser_download_url;
        }
#pragma warning restore 0649

    }
}
