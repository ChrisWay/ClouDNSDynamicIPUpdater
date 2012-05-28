using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClouDNSIPUpdater.Library;

namespace ClouDNSIPUpdater.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var updater = new DynamicUrlUpdater();

            updater.Update();
        }
    }
}
