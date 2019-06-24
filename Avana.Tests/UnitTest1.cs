using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Avana.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // setup
            const string url = "ftp://ftp.avaya.com/incoming/Up1cku9/tsoweb/46xxsettings/05282018/46xxsettings.txt";
            string configFileTemplate;
            using (var wc = new WebClient())
            {
                configFileTemplate = await wc.DownloadStringTaskAsync(url);
            }
            ConfigFileReader configFileReader = new ConfigFileReader();

            // act
            using (TextReader reader = new StringReader(configFileTemplate))
            {
                await configFileReader.ParseTemplateAsync(reader);
            }

            // verify


        }
    }
}
