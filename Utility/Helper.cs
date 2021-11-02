using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Utility
{
    public static class Helper
    {
        public static readonly string Admin = "Beheerder";
        public static readonly string Employee = "Medewerker";
        public static readonly string Customer = "Klant";

        public static string AppointmentAdded = "Afspraak succesvol opgeslagen.";
        public static string AppointmentConfirmed = "Afspraak bevestigd.";
        public static string AppointmentUpdated = "Afspraak succesvol gewijzigd.";
        public static string AppointmentDeleted = "Afspraak succesvol verwijderd.";
        public static string AppointmentExists = "Afspraak bestaat al op gegeven datum en tijdstip.";
        public static string AppointmentNotExists = "Afspraak bestaat niet.";
        public static string AppointmentAddError = "Er ging iets mis. Afspraak niet toegevoegd.";
        public static string AppointmentConfirmError = "Er ging iets mis. Afspraak niet bevestigd.";
        public static string SomethingWentWrong = "Er ging iets mis. Probeer het opnieuw.";
        public static string AppointmentUpdatError = "Er ging iets mis. Afspraak niet gewijzigd.";

        public static int Succes_code = 1;
        public static int Failure_code = 0;

        public static string EmailBody = ("<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body><img src='https://i.ibb.co/2jSV2kr/CCSB-Logo.png' style= width='100' height='100' /><br /><br /><div style='border-top: 3px solid #37d400'>&nbsp;</div><span style='font-family: Arial; font-size: 10pt'>Hello <b>@@FirstName</b>,<br /><br />Welkom bij CCSB, hieronder staan uw inlog gegevens waarmee u toegang krijgt tot deze geitenballen website. Ronan is een keizersnee. <br /><br /> <b>E-mail:</b> <a style='color: #37d400'>@@Email</a><br /><b>Wachtwoord:</b> <a style='color: #37d400'> @@Password</a> <br /><br />Met vriendelijke groet,<br />CCSB beheer</span></body></html>");
        
        
        
        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Admin , Text = Helper.Admin},
                new SelectListItem{ Value=Helper.Employee , Text = Helper.Employee},
                new SelectListItem{ Value=Helper.Customer , Text = Helper.Customer}
            };
            return items.OrderBy(s => s.Text).ToList();
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 10; i< 90; i+=10)
			{
                duration.Add(new SelectListItem{ Value = i.ToString(), Text = i + " minuten"});
			}
            return duration;
        }
    }
}
