using System;
using Xamarin.Forms;
using SystemCheck.Interfaces;

namespace SystemCheck
{
    public static class AppsService
    {
        public static bool IsAppInstalled(string appId)
        {
            return DependencyService.Get<IAppsService>().IsAppInstalled(appId);
        }
    }
}
