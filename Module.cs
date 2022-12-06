using System;
using System.Management.Automation;
using IdeapadToolkit.Models;
using IdeapadToolkit.Services;

namespace src
{

    [Cmdlet(VerbsCommon.Get, "LenovoChargingMode")]
    [Alias("glncm")]
    [OutputType(typeof(ChargingMode))]
    public class GetChargingMode : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(Service.GetChargingMode());
        }
    }

    [Cmdlet(VerbsCommon.Get, "LenovoPowerPlan")]
    [Alias("glnpp")]
    [OutputType(typeof(PowerPlan))]
    public class GetPowerPlan : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(Service.GetPowerPlan());
        }
    }

    [Cmdlet(VerbsCommon.Get, "LenovoAlwaysOnUSB")]
    [Alias("glnusb")]
    [OutputType(typeof(bool))]
    public class LenovoAlwaysOnUSB : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(Service.IsAlwaysOnUsbEnabled());
        }
    }

    [Cmdlet(VerbsCommon.Get, "LenovoAlwaysOnUsbBattery")]
    [Alias("glnusbb")]
    [OutputType(typeof(bool))]
    public class LenovoAlwaysOnUSBBattery : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(Service.IsAlwaysOnUsbBatteryEnabled());
        }
    }

    [Cmdlet(VerbsCommon.Set, "LenovoChargingMode")]
    [Alias("slncm")]
    public class SetChargingMode : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Mode { get; set; }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            ChargingMode chargeMode;
            chargeMode =
                Helper.HasInBeggining(Mode, "conservation") ? ChargingMode.Conservation :
                Helper.HasInBeggining(Mode, "rapid") ? ChargingMode.Rapid :
                Helper.HasInBeggining(Mode, "normal") ? ChargingMode.Normal : ChargingMode.None;

            if (chargeMode == ChargingMode.None)
            {
                throw new Exception(@"Invalid charging mode!
Valid options: Normal, Conservation, Rapid");
            }

            Service.SetChargingMode(chargeMode);
        }

        [Cmdlet(VerbsCommon.Set, "LenovoPowerPlan")]
        [Alias("slnpp")]
        public class SetPowerPlan : PSCmdlet
        {
            [Parameter(Mandatory = true, Position = 0)]
            public string Plan { get; set; }

            // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
            protected override void ProcessRecord()
            {
                PowerPlan powerPlan;
                powerPlan =
                    Helper.HasInBeggining(Plan, "efficiency") ? PowerPlan.EfficiencyMode :
                    Helper.HasInBeggining(Plan, "extreme") ? PowerPlan.ExtremePerformance :
                    Helper.HasInBeggining(Plan, "intelligentcooling") ? PowerPlan.IntelligentCooling : PowerPlan.None;

                if (powerPlan == PowerPlan.None)
                {
                    throw new Exception(@"Invalid power mode!
Valid options: Efficiency, Extreme, IntelligentCooling");
                }

                Service.SetPowerPlan(powerPlan);
            }
        }

        [Cmdlet(VerbsCommon.Set, "LenovoAlwaysOnUSB")]
        [Alias("slnusb")]
        public class SetLenovoAlwaysOnUSB : PSCmdlet
        {
            [Parameter(Mandatory = true, Position = 0)]
            public bool Flag { get; set; }

            // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
            protected override void ProcessRecord()
            {
               Service.SetAlwaysOnUsb(Flag);
            }
        }
        
        [Cmdlet(VerbsCommon.Set, "LenovoAlwaysOnUsbBattery")]
        [Alias("slnusbb")]
        public class SetLenovoAlwaysOnUsbBattery : PSCmdlet
        {
            [Parameter(Mandatory = true, Position = 0)]
            public bool Flag { get; set; }

            // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
            protected override void ProcessRecord()
            {
               Service.SetAlwaysOnUsbBattery(Flag);
            }
        }
    }



    class Service
    {
        public static LenovoPowerSettingsService _service = new LenovoPowerSettingsService();

        public static ChargingMode GetChargingMode() => _service.GetChargingMode();
        public static void SetChargingMode(ChargingMode value) => _service.SetChargingMode(value);
        public static PowerPlan GetPowerPlan() => _service.GetPowerPlan();
        public static void SetPowerPlan(PowerPlan value) => _service.SetPowerPlan(value);
        public static bool IsAlwaysOnUsbBatteryEnabled() => _service.IsAlwaysOnUsbBatteryEnabled();
        public static void SetAlwaysOnUsbBattery(bool value) => _service.SetAlwaysOnUsbBattery(value);
        public static bool IsAlwaysOnUsbEnabled() => _service.IsAlwaysOnUsbEnabled();
        public static void SetAlwaysOnUsb(bool value) => _service.SetAlwaysOnUsb(value);
    }

    class Helper
    {
        static public bool HasInBeggining(string needle, string haystack)
        {
            return haystack.IndexOf(needle.ToLower()) == 0;
        }
    }
}