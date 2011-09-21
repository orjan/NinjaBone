using System.Collections.Generic;
using System.Linq;
using Google.GData.Spreadsheets;

namespace NinjaBone.Services.Ninja
{
    public class GoogleNinjaService : INinjaService
    {
        private readonly ISpreadsheetConfiguration googleSpreadsheetConfiguration;
        private readonly SpreadsheetsService service;

        public GoogleNinjaService(ISpreadsheetConfiguration googleSpreadsheetConfiguration)
        {
            this.googleSpreadsheetConfiguration = googleSpreadsheetConfiguration;

            service = new SpreadsheetsService("tretton37-NinjaBook");
            service.setUserCredentials(googleSpreadsheetConfiguration.Username, googleSpreadsheetConfiguration.Password);
        }

        #region INinjaService Members

        public IEnumerable<Models.Ninja> GetAllNinjas()
        {
            ListFeed feed =
                service.Query(new ListQuery(googleSpreadsheetConfiguration.SpreadsheetKey, "1", "private", "values"));
            IEnumerable<Models.Ninja> allNinjas = from ListEntry entry in feed.Entries
                                    select new Models.Ninja
                                               {
                                                   Id = entry.Elements[11].Value.Split('@')[0],
                                                   Name = entry.Elements[0].Value,
                                                   Address = entry.Elements[1].Value,
                                                   ZipCode = entry.Elements[2].Value,
                                                   Skype = entry.Elements[3].Value,
                                                   Twitter = entry.Elements[4].Value,
                                                   Facebook = entry.Elements[5].Value,
                                                   Xbox = entry.Elements[6].Value,
                                                   Phone = entry.Elements[9].Value,
                                                   Email = entry.Elements[11].Value,
                                               };
            return allNinjas.OrderBy(o=>o.Name); //.OrderBy(x=>x.Name);

            // Namn	Adress	Postnr	Skypenamn	Twitternamn	Facebook	MSN, Gtalk eller annan IM	Playstation Network	Xbox Live	1337 Telefonnr	Annat telefonnummer	E-mail
        }

        #endregion
    }
}