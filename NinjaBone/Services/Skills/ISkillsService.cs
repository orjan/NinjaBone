using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinjaBone.Models;

namespace NinjaBone.Services.Skills
{
    public interface ISkillsService
    {
        IEnumerable<Skill> GetSkills();
    }
}
