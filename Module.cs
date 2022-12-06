using System;
using System.Management.Automation;
using IdeapadToolkit.Models;
using IdeapadToolkit.Services;

namespace src
{

    [Cmdlet(VerbsCommon.Set, "LenovoChargingMode")]
    [Alias("slncm")]
    public class SetChargingMode : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Mode { get; set; }

        private bool HasInBeggining(string needle, string haystack)
        {
            return haystack.IndexOf(needle.ToLower()) == 0;
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            ChargingMode chargeMode;
            chargeMode = 
                HasInBeggining(Mode, "conservation") ? ChargingMode.Conservation :
                HasInBeggining(Mode, "rapid") ? ChargingMode.Rapid :
                HasInBeggining(Mode, "normal") ? ChargingMode.Normal : ChargingMode.None;
            
            if (chargeMode == ChargingMode.None)
            {
                throw new Exception(@"Invalid charging mode!
Valid options: Normal, Conservation, Rapid");
            }

            Service.SetChargingMode(chargeMode);
        }
    }

    [Cmdlet(VerbsCommon.Get, "LenovoChargingMode")]
    [Alias("glncm")]
    [OutputType(typeof(ChargingMode))]
    public class GetChargingMode : PSCmdlet
    {
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            WriteObject(Service.GetChargingMode());
        }
    }

    public class FavoriteStuff
    {
        public int FavoriteNumber { get; set; }
        public string FavoritePet { get; set; }
    }

    class Service
    {
        public static LenovoPowerSettingsService _service = new LenovoPowerSettingsService();

        public static ChargingMode GetChargingMode() => _service.GetChargingMode();
        public static void SetChargingMode(ChargingMode mode) => _service.SetChargingMode(mode);

    }
}
