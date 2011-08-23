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

            return from ListEntry entry in feed.Entries
                   select new Models.Ninja
                              {
                                  Name = entry.Elements[0].Value,
                                  Phone = entry.Elements[1].Value
                              };
        }

        #endregion
    }
}