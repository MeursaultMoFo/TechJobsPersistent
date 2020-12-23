using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        // GET: /<controller>/

        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
            /*Employer employer = new Employer();
            return View(employer);*/
        }

        /*[HttpPost]
        [Route("Employer/Add")]
        public IActionResult Add(Employer employer)
        {
            if (ModelState.IsValid)
            {
                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/Employer/");
            }

            return View("Add", employer);
        }*/

        /*public IActionResult AddJob(int id)
        {
            Job theJob = context.Jobs.Find(id);
            List<Employer> possibleEmployers = context.Employers.ToList();
            //AddEmployerViewModel viewModel = new AddEmployerViewModel(theJob, possibleEmployers);
            return View(viewModel);
        }*/

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {

                string nameId = addEmployerViewModel.Name;
                string locationId = addEmployerViewModel.Location;

                List<Employer> existingItems = context.Employers
                    .Where(js => js.Name == nameId)
                    .Where(js => js.Location == locationId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    Employer employer = new Employer
                    {
                        Name = nameId,
                        Location = locationId
                    };
                    context.Employers.Add(employer);
                    context.SaveChanges();
                }

                return Redirect("Index");
            }

            return View(addEmployerViewModel);
            /*Employer newEmployer = new Employer
            {
                Name = addEmployerViewModel.NameId,
                Location = addEmployerViewModel.LocationId

            };

            context.Employers.Add(newEmployer);
            context.SaveChanges();

            return Redirect("/Employers");
        }
        return View(addEmployerViewModel);*/
        }

        public IActionResult About(int id)
        {

            Employer employer = context.Employers.Find(id);

            // TODO: need to modify
            /*foreach (int id in Id)
            {
                ViewBag.employers = context.Employers.Find();
            }
            return View();*/


            /*.Where(js => js.Id == id)
            .Include(js => js.Name)
            .Include(js => js.Location)
            .ToList();*/

            return View(employer);
        }
    }
}
