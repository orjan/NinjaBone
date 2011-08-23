using System.Collections.Generic;

namespace NinjaBone.Services.Ninja
{
    public interface INinjaService
    {
        IEnumerable<Models.Ninja> GetAllNinjas();
    }
}