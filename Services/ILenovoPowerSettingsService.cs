using IdeapadToolkit.Models;

namespace IdeapadToolkit.Services
{
    public interface ILenovoPowerSettingsService
    {
        PowerPlan GetPowerPlan();
        void SetPowerPlan(PowerPlan plan);

        PowerPlan GetChargingMode();
        void SetChargingMode(PowerPlan chargingMode);

        bool IsAlwaysOnUsbEnabled();
        void SetAlwaysOnUsb(bool alwaysOnUsbEnabled);

        bool IsAlwaysOnUsbBatteryEnabled();
        void SetAlwaysOnUsbBattery(bool alwaysOnUsbBattryEnabled);
    }
}
