using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjaBone.Models;
using NinjaBone.Services.Ninja;
using NinjaBone.Services.Skills;

namespace NinjaBone.Web.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillsService skillsService;
        private readonly INinjaService ninjaService;

        public SkillsController(ISkillsService skillsService, INinjaService ninjaService)
        {
            this.skillsService = skillsService;
            this.ninjaService = ninjaService;
        }

        //
        // GET: /Skills/

        public ActionResult Index()
        {

            return View(skillsService.GetSkills());
        }

        public ActionResult Show(string skillName)
        {
            var skillShowViewModel = new SkillShowViewModel()
                                         {
                                             Skill = skillName,
                                             Ninjas = ninjaService.GetNinjasBySkill(skillName)
                                         };
            return View(skillShowViewModel);
        }

    }

    public class SkillShowViewModel
    {
        public string Skill { get; set; }
        public IEnumerable<Ninja> Ninjas { get; set; }
    }
}
