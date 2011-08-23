using System.Collections.Generic;

namespace NinjaBone.Services.Ninja
{
    public class DummyNinjaService : INinjaService
    {
        public IEnumerable<Models.Ninja> GetAllNinjas()
        {
            yield return new Models.Ninja { Name = "Apan Ola", Phone = "0704-224284" };
        }
    }
}