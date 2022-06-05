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

            //public class UrlFacotry
            //{
            //    public string MainUrl => "" ? "";

            //    public string User => $"{MainUrl}/user";

            //    public string UserId(string id) => $"{User}/{id}";
            //}

            //internal static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api" : "http://localhost:5000/api";
            //factory na urle
            internal static string RestUrl = "https://viaductapi.azurewebsites.net/user/{0}";
        }
    }
}
