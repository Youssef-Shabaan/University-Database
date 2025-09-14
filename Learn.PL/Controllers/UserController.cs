using Learn.BLL.ModelVM.Department;
using Learn.BLL.ModelVM.User;
using Learn.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Learn.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IDepartmentService departmentService;
        public UserController(IUserService userService, IDepartmentService departmentService)
        {
            this.userService = userService;
            this.departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var result = departmentService.GetAll();
            if(!result.Item1 && result.Item3 != null)
                ViewBag.Department = result.Item3;
            else
                ViewBag.Department = new List<GetAllDepartmentVM>();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserVM user)
        {
            if(ModelState.IsValid)
            {
                var result = userService.Create(user);
                if (result.Item1)
                {
                    ViewBag.ErrorMessage = result.Item2;
                    return View(user);
                }
                return RedirectToAction("GetAll","User");
            }
            else
            {
                return View(user);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = userService.GetAll();
            if(result.Item1)
            {
                ViewBag.ErrorMessage = result.Item2;
                return View();
            }
            return View(result.Item3);
        }
    }
}
