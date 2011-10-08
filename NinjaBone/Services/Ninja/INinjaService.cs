using System.Collections.Generic;

namespace NinjaBone.Services.Ninja
{
    public interface INinjaService
    {
        IEnumerable<Models.Ninja> GetAllNinjas();
        IEnumerable<Models.Ninja> GetNinjasBySkill(string skill);
    }
}