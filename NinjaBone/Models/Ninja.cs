using System.Collections.Generic;

namespace NinjaBone.Models
{
    public class Ninja
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Skype { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Xbox { get; set; }

        public string Skills { get; set; }

        public IEnumerable<Skill> GetSkills()
        {
            if (string.IsNullOrWhiteSpace(Skills))
            {
                yield break;
            }

            var skills = Skills.Split(',');

            foreach (var skill in skills)
            {
                yield return new Skill {Name = skill.Trim() };
            }
        }
    }
}