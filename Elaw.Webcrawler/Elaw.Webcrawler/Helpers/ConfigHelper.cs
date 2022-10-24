using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Elaw.Webcrawler.Helpers;

public class ConfigHelper
{
    public static string getConfigValue(string ConfigName)
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

        var config = builder.Build();

        string ConfigValue = string.Empty;

        if (config[ConfigName] != null)
            ConfigValue = config[ConfigName];

        return ConfigValue;

    }
}
