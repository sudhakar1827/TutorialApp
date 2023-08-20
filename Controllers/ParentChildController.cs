using asp.netCoreIntro.DBContext;
using asp.netCoreIntro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.netCoreIntro.Controllers
{
    public class ParentChildController : Controller
    {
        private readonly TutorialDBContext _dBContext;

        public ParentChildController( TutorialDBContext dBContext) 
        {
            _dBContext = dBContext;
        }

        
        public IActionResult DisplayPC()
        {
            return View("ParentChild");
        }

        [HttpPost]
        public IActionResult CreateParentAndChild(ParentChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = new Parent { ParentName = model.ParentName };
                var child = new Child { ChildName = model.ChildName, Parent = parent };

                _dBContext.Parents.Add(parent);
                _dBContext.SaveChanges();

                return RedirectToAction("ParentChild");  // Redirect to a success page or action
            }

            return View(model);  // Return to the form if there are validation errors
        }
    }
}
