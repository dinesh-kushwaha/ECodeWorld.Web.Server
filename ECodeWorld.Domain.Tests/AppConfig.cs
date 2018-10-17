﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Tests
{
    public class AppConfig
    {
        public string ApplicationName { get; set; }
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public ApiSettingsConfig ApiSettings { get; set; }

        public class ConnectionStringsConfig
        {
            public string MyDb { get; set; }
            public string ECodeWorldDatabase { get; set; }
        }

        public class ApiSettingsConfig
        {
            public string Url { get; set; }
            public string ApiKey { get; set; }
            public bool UseCache { get; set; }
        }
    }
}
