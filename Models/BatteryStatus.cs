using IdeapadToolkit.Models;

namespace PwshLenovoBattery.Models
{
    public struct BatteryStatus
    {
        public ChargingMode ChargingMode {get; private set;}
        public PowerPlan PowerPlan {get; private set;}
        public bool AlwaysOnUsbEnabled {get; private set;}
        public bool AlwaysOnUsbBatteryEnabled {get; private set;}

        public BatteryStatus(ChargingMode chargingMode, PowerPlan powerPlan, bool alwaysOnUsbEnabled, bool alwaysOnUsbBatteryEnabled)
        {
            ChargingMode = chargingMode;
            PowerPlan = powerPlan;
            AlwaysOnUsbEnabled = alwaysOnUsbEnabled;
            AlwaysOnUsbBatteryEnabled = alwaysOnUsbBatteryEnabled;
        }
    }
}