using FirstTask.Core.Entities;
using FirstTask.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security.Provider;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace FirstTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }


        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");

        }



        //public ActionResult SetTime
        //{
        //    get
        //    {
        //        return View();
        //    }
        //}


        //public ActionResult ShutDown
        //{
        //    get
        //    {
        //        return View();
        //    }
        //}


        //    private readonly RoleManager<IdentityRole> roleManager;

        //    public AdministrationController(RoleManager<IdentityRole> roleManager)
        //    {
        //        this.roleManager = roleManager;

        //    }



        //    public System.Web.Mvc.ActionResult CreateRole()
        //    {
        //        return View();
        //    }

        //    [System.Web.Mvc.HttpPost]
        //    public System.Web.Mvc.ActionResult Create(IdentityRole role )
        //    {
        //        PostDbContext db = new PostDbContext();
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Roles.Add(role);
        //                db.SaveChanges();
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        catch (System.Exception)
        //        {

        //            throw;
        //        }

        //}


    }
}
