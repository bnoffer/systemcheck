using System;
using SystemCheck.Implementations;
using SystemCheck.Interfaces;
using Xamarin.Forms;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(AppsServiceiOS))]
namespace SystemCheck.Implementations
{
    public class AppsServiceiOS : IAppsService
    {
        public bool IsAppInstalled(string appId)
        {
            try
            {
                if (UIApplication.SharedApplication.CanOpenUrl(new NSUrl(new NSString(appId))))
                    return true;
                else
                    return false;
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
