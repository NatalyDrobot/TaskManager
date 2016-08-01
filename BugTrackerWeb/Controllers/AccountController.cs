using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using TaskManager.Models.ViewModels;
using TaskManagerBLL.Services;
using TaskManagerDTO.Entities;

namespace FormsAuthApp.Controllers
{
    public class AccountController : Controller
    {
        private ServiceEntities service = new ServiceEntities();

        public ActionResult Login()
        {
            ViewBag.SidebarVisible = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            ViewBag.SidebarVisible = false;

            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
            UserDTO user = service.GetUserByLoginAndPassword(model.Login, model.Password);
            Session["User"] = user;

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                return RedirectToAction("Register", "Account");
            }
          }

          return View(model);
        }

        public ActionResult Register()
        {
            ViewBag.SidebarVisible = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            ViewBag.SidebarVisible = false;

            UserDTO user = null;

            if (ModelState.IsValid)
            {
                user = service.GetUserByLogin( model.Login);

                if (user == null)
                {
                    // создаем нового пользователя
                    service.AddOrUpdateUser(new UserDTO { Email = model.Email, Password = model.Password, Login = model.Login });

                    user = service.GetUserByLoginAndPassword(model.Login, model.Password);
                    Session["User"] = user;

                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else { return RedirectToAction("Register", "Account"); }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return RedirectToAction("Register", "Account");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}