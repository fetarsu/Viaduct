using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Viaduct.Resources
{
    internal static class Constants
    {
        internal static class Settigns
        {
            //internal static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api" : "http://localhost:5000/api";
            internal static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api/users/{0}" : "http://localhost:5000/api";
        }
    }
}
