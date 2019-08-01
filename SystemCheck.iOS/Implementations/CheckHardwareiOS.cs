using System;
using System.Collections.Generic;
using System.IO;
using SystemCheck.Implementations;
using SystemCheck.Interfaces;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(CheckHardwareiOS))]
namespace SystemCheck.Implementations
{
    public class CheckHardwareiOS : IHardwareSecurity
    {
        public bool IsJailBreaked()
        {
            List<string> pathList = new List<string>
             {
                 "/Applications/Cydia.app",
                 "/Applications/FakeCarrier.app",
                 "/Applications/Icy.app",
                 "/Applications/IntelliScreen.app",
                 "/Applications/MxTube.app",
                 "/Applications/RockApp.app",
                 "/Applications/SBSettings.app",
                 "/Applications/WinterBoard.app",
                 "/Applications/blackra1n.app",
                 "/Library/MobileSubstrate/DynamicLibraries/LiveClock.plist",
                 "/Library/MobileSubstrate/DynamicLibraries/Veency.plist",
                 "/Library/MobileSubstrate/MobileSubstrate.dylib",
                 "/System/Library/LaunchDaemons/com.ikey.bbot.plist",
                 "/System/Library/LaunchDaemons/com.saurik.Cydia.Startup.plist",
                 "/etc/apt",
                 "/private/var/lib/apt",
                 "/private/var/lib/cydia",
                 "/private/var/mobile/Library/SBSettings/Themes",
                 "/private/var/stash",
                 "/private/var/tmp/cydia.log",
                 "/usr/bin/sshd",
                 "/var/cache/apt",
                 "/var/lib/apt",
                 "/var/lib/cydia",
             };
            foreach (var fullPath in pathList)
            {
                if (File.Exists(fullPath))
                {
                    return true;
                }
            }
            try
            {
                File.WriteAllText("/private/jailbreak.txt", "This is a test.");
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        public bool IsInEmulator()
        {
            List<string> pathList = new List<string>
             {
                 "/bin/bash",
                 "/bin/sh",
                 "/etc/ssh/sshd_config",
                 "/usr/libexec/sftp-server",
                 "/usr/libexec/ssh-keysign",
                 "/usr/sbin/sshd",

             };
            foreach (var fullPath in pathList)
            {
                if (File.Exists(fullPath))
                {
                    return true;
                }
            }
            return false;
        }
    }
}