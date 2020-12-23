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
        public Job Job { get; set; }


        // TODO: "In AddJob() pass an instance of AddJobViewModel to the view." is that here or somewhere else?

        public AddJobViewModel(Job theJob, List<Job> possibleJobs)
        {
            Employers = new List<SelectListItem>();

            foreach (var job in possibleJobs)
            {
                Employers.Add(new SelectListItem
                {
                    Value = job.EmployerId.ToString(),
                    Text = job.Name
                });
            }

            Job = theJob;
        }
        public AddJobViewModel()
        { }

    }
}
