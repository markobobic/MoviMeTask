using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;


namespace MovieMe.Logger
{
    public static class Logger<T> where T : class
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(T));

    }
}