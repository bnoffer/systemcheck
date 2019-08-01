using System;
namespace SystemCheck.Interfaces
{
    public interface IAppsService
    {
        bool IsAppInstalled(string appId);
    }
}
