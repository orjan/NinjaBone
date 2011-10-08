using System.Collections.Generic;
using NinjaBone.Models;

namespace NinjaBone.Services.Skills
{
    public class DummySkillsService : ISkillsService
    {
        public IEnumerable<Skill> GetSkills()
        {
            return new List<Skill>
                       {
                           new Skill {Name = "SQL"},
                           new Skill {Name = "C#"}
                       };
        }
    }
}