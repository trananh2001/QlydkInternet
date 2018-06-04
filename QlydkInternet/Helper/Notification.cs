﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlydkInternet.Helper
{
    public class Notification
    {
        public string Title { get; set; }
        public string MessageType { get; set; }
        public string Icon { get; set; }
        public string Content { get; set; }
        public string Button { get; set; }
        public string ExtraAction { get; set; }
        public string ExtraData { get; set; }
    }
}
