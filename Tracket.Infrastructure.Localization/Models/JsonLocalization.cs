﻿using System.Collections.Generic;

namespace Tracket.Infrastructure.Localization.Models
{
    public class JsonLocalization
    {
        public string Key { get; set; }
        public Dictionary<string, string> LocalizedValue = new Dictionary<string, string>();
    }
}