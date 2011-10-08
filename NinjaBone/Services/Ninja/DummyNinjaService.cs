using System;
using System.Collections.Generic;

namespace NinjaBone.Services.Ninja
{
    public class DummyNinjaService : INinjaService
    {
        public IEnumerable<Models.Ninja> GetAllNinjas()
        {
            yield return new Models.Ninja { Name = "Apan Ola", Phone = "0704-224284" };
        }

        public IEnumerable<Models.Ninja> GetNinjasBySkill(string skill)
        {
            yield return new Models.Ninja { Name = "Apan Ola with skills", Phone = "0704-224284" };
        }
    }
}