using asp.netCoreIntro.DBContext;
using asp.netCoreIntro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.netCoreIntro.Controllers
{
    public class TutorialController : Controller
    {
        // GET: TutorialController

        private readonly TutorialDBContext _tutorialDBContext;

      public  TutorialController (TutorialDBContext context)
        {
            _tutorialDBContext = context;
        }

        public ActionResult CreateTutorial()
        {
            return View("CreateTutorial");
        }

        // GET: TutorialController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TutorialController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TutorialController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TutorialController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TutorialController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TutorialController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TutorialController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateTutorial(Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string name = !string.IsNullOrEmpty(tutorial.Name) ? tutorial.Name : "NULL";
                    string description = !string.IsNullOrEmpty(tutorial.Description) ? tutorial.Description : "NULL";

                    _tutorialDBContext.Add(tutorial);
                    int stateEntries = _tutorialDBContext.SaveChanges();

                    if (stateEntries > 0)
                    {
                        // Set a success message in TempData
                        TempData["SuccessMessage"] = $"{stateEntries} tutorial(s) added successfully.";
                        // Redirect to the Index action and display the success message
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Set an error message in TempData if no state entries were affected
                        TempData["ErrorMessage"] = "No tutorials were added.";
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception, log it, and provide an error message if needed
                    TempData["ErrorMessage"] = "An error occurred while saving the tutorial.";
                    // You can also log the exception details using a logging framework
                    // logger.LogError(ex, "An error occurred while saving the tutorial.");

                    // Return to the Create view with the error message
                    return View("CreateTutorial");
                }
            }

            // If ModelState is not valid or if no data was added successfully,
            // return to the "Create" view
            return View("CreateTutorial");
        }


        [HttpGet]
        public IActionResult Contact() {
            var allTutorials = new List<Tutorial>();
             allTutorials = _tutorialDBContext.Tutorial.ToList();
            //if(allTutorials?.AsyncState == true)
            //{
            //    return allTutorials;
            //}
            return View("DisplayTutorials",allTutorials);
        }

        public async Task<IActionResult> getSingleDetails(int id)
        {
           var results= await _tutorialDBContext.Set<Tutorial>().FindAsync(id);
            return View("DisplayTutorialDetails", results);
        }


    }
}
