using System;
using SystemCheck.Implementations;
using SystemCheck.Interfaces;
using Xamarin.Forms;
using Android.Content.PM;

[assembly: Dependency(typeof(AppsServiceDroid))]
namespace SystemCheck.Implementations
{
    public class AppsServiceDroid : IAppsService
    {
        public bool IsAppInstalled(string appId)
        {
            PackageManager pm = Android.App.Application.Context.PackageManager;
            try
            {
                pm.GetApplicationInfo(appId, 0);
                return true;
            }
            catch (PackageManager.NameNotFoundException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
