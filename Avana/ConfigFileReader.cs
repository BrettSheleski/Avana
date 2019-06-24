using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Avana
{
    public class ConfigFileReader
    {
        const string SectionBeginPrefix = "############### "; // make sure to add space at the end
        const string LinePrefix = "##";
        const string SupportedByLine = "##  This parameter is supported by:";
        const string NoteLine = "##  Note: This parameter may also be set via DHCP or LLDP.";
        public async Task ParseTemplateAsync(TextReader reader)
        {
            string line = await GetNextSectionLine(reader);
            ConfigSection section = new ConfigSection
            {
                Name = GetSectionNameFromLine(line)
            };

            while (reader.Peek() > -1)
            {
                
            }
        }

        private static string GetSectionNameFromLine(string line)
        {
            return line.Substring(SectionBeginPrefix.Length).TrimEnd('#').Trim();
        }

        private static async Task<string> GetNextSectionLine(TextReader reader)
        {
            // skip until finding a SectionBeginPrefix

            string line;

            do
            {
                line = await reader.ReadLineAsync();

            } while (!line.StartsWith(SectionBeginPrefix));

            return line;
        }

        public List<ConfigSection> Sections { get; } = new List<ConfigSection>();
    }

    public class ConfigSection
    {
        public string Name { get; set; }
        public List<ConfigSetting> Settings { get; } = new List<ConfigSetting>();
    }

    public class ConfigSetting
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public string Example { get; set; }

        public List<string> SupportedBy { get; } = new List<string>();
    }
}
