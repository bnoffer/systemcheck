using System;
using Xamarin.Forms;
using SystemCheck.Interfaces;

namespace SystemCheck
{
    public static class HardwareSecurity
    {
        public static bool IsRooted()
        {
            return DependencyService.Get<IHardwareSecurity>().IsJailBreaked();
        }

        public static bool IsEmulator()
        {
            return DependencyService.Get<IHardwareSecurity>().IsInEmulator();
        }
    }
}
