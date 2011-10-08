using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjaBone.Services.Skills;

namespace NinjaBone.Web.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        //
        // GET: /Skills/

        public ActionResult Index()
        {

            return View(skillsService.GetSkills());
        }

    }
}
