using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Spreadsheets;
using NinjaBone.Models;
using NinjaBone.Services.Ninja;

namespace NinjaBone.Services.Skills
{
    public class GoogleSkillsService : ISkillsService
    {
        private readonly ISpreadsheetConfiguration _spreadsheetConfiguration;
        private readonly INinjaService _ninjaService;
        private readonly SpreadsheetsService _service;

        public GoogleSkillsService(INinjaService ninjaService)
        {
            _ninjaService = ninjaService;
        }

        public IEnumerable<Skill> GetSkills()
        {
            var skills = new List<Skill>();

            _ninjaService.GetAllNinjas().ToList().ForEach(
                x => skills.AddRange(x.GetSkills()));

            return skills.Distinct();
        }
    }
}
