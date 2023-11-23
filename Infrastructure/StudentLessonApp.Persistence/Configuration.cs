﻿using Microsoft.Extensions.Configuration;


namespace StudentLessonApp.Persistence
{
    public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("defaultConnection");
            }
        }
    }
}
