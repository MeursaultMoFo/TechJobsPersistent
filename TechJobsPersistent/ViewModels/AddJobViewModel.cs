using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public string JobName { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; } 

        public List<Skill> Skills { get; set; }
        public Job Job { get; set; }

        public AddJobViewModel()
        { }


        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            Skills = skills;

            Employers = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });

            }

        }
        


    }
}
