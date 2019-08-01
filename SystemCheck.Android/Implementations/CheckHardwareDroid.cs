using System;
using System.Collections.Generic;
using System.IO;
using SystemCheck.Implementations;
using SystemCheck.Interfaces;
using Xamarin.Forms;
using Android.App;
using Android.OS;
using Android.Content.PM;

[assembly: Dependency(typeof(CheckHardwareDroid))]
namespace SystemCheck.Implementations
{
    public class CheckHardwareDroid : IHardwareSecurity
    {
        public bool IsJailBreaked()
        {
            List<string> list = new List<string>
             {
                 "/sbin",
                 "/system/bin",
                 "/system/xbin",
                 "/data/local/xbin",
                 "/data/local/bin",
                 "/system/sd/xbin",
                 "/system/bin/failsafe",
                 "/data/local"
             };

            foreach (var path in list)
            {
                var fullPath = Path.Combine(path, "su");
                if (File.Exists(fullPath)) return true;
            }
            var paths = System.Environment.GetEnvironmentVariable("PATH");
            var pathsArray = paths.Split(':');
            foreach (var each in pathsArray)
            {
                string fullPath = Path.Combine(each, "su");
                if (File.Exists(fullPath))
                    return true;
            }
            IList<ActivityManager.RunningAppProcessInfo> processList
                                 = ActivityManager.FromContext(Android.App.Application.Context).RunningAppProcesses;
            foreach (var eachProcess in processList)
            {
                if (eachProcess.ProcessName.Contains("supersu"))
                    return true;
                if (eachProcess.ProcessName.Contains("superuser"))
                    return true;
            }
            if (IsHooked()) return true;
            return false;
        }

        public bool IsInEmulator()
        {
            string str = Build.Tags;
            return str.Contains("test-keys");
        }

        public bool IsDebuggable()
        {

            return ((Android.App.Application.Context.ApplicationContext.ApplicationInfo.Flags & ApplicationInfoFlags.Debuggable) != 0);
        }

        public bool IsDebuggerConnected()
        {
            return Debug.IsDebuggerConnected;
        }

        public bool IsHooked()
        {
            PackageManager packageManager = Android.App.Application.Context.PackageManager;
            var applicationInfoList = packageManager.GetInstalledApplications(PackageInfoFlags.MetaData);

            foreach (var applicationInfo in applicationInfoList)
            {
                if (applicationInfo.PackageName == "de.robv.android.xposed.installer")
                {
                    return true;
                }
                if (applicationInfo.PackageName == "com.saurik.substrate")
                {
                    return true;
                }
            }
            return false;
        }
    }
}