using System;
namespace SystemCheck.Interfaces
{
    public interface IHardwareSecurity
    {
        bool IsJailBreaked();
        bool IsInEmulator();
    }
}
