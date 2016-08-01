using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskManagerBLL.Services;
using TaskManagerDTO.Entities;

public enum FilterParam { today, tomorrow, week}

namespace TaskManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ServiceEntities service = new ServiceEntities();

        //[HttpPost]
        //public ActionResult Authorization()
        //{
        //    //HttpCookie cookie = new HttpCookie("cookieName");
        //    ////cookie.Name = "Name";
        //    //cookie.Value = "Cookie";
        //    //cookie.Expires = DateTime.Now.AddSeconds(40);
        //    //HttpContext.Response.Cookies.Add(cookie);
        //    ViewBag.SidebarVisible = false;
        //    return View();
        //}

        //public string Index()
        //{
        //    var cookies = Request.Cookies["cookieName"];
        //    return cookies.Name;

        //}

        public ActionResult Index()
        {
           
            if (!User.Identity.IsAuthenticated)
            {
                //result = "Ваш логин: " + User.Identity.Name;
               //string result = "Вы не авторизованы";
                ViewBag.SidebarVisible = false;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var tickets = service.GetTicket();
                ViewBag.Title = "Полный список задач";
                ViewBag.AllTicket = "active";
                ViewBag.SidebarVisible = true;

                return View(tickets);
            }
        }

        public ActionResult StatusTickets(int? id)
        {
            var tickets = service.GetTicket().Where(p => (p.StatusId == id));
            ViewBag.StatusTickets = "active";
            return View("Index", tickets);
        }

        public ActionResult FilterTicketsByCategory(int? id)
        {
            var tickets = service.GetTicket().Where(p => (p.CategoryId == id));
            ViewBag.Title = "";
            ViewBag.FilterTicketsByCategory = "active";
            return View("Index", tickets);
        }

        public ActionResult FilterTicketsByDate(FilterParam id)
        {
            IEnumerable<TicketDTO> tickets;
            switch (id)
            {
                case FilterParam.today:
                    {   tickets = service.GetTicket().Where(p => (p.Date == DateTime.Today.Date));
                        break;}
                case FilterParam.tomorrow:
                    {
                        tickets = service.GetTicket().Where(p => (p.Date == DateTime.Today.AddDays(1)));
                        break;
                    }
                case FilterParam.week:
                    {
                        tickets = service.GetTicket().Where(p => (p.Date <= DateTime.Today.AddDays(7)) && (p.Date >= (DateTime.Today.Date)));
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }
            ViewBag.Title = "";
            ViewBag.FilterTicketsByDate = "active";
            ViewBag.SidebarVisible = true;
            return View("Index", tickets.ToList());
        }

        [HttpGet]
        public ActionResult CreateEntry()
        {
            ViewBag.Statuses = service.GetStatuses();/* db.Statuses.ToList<Status>();*/
            ViewBag.Categories = service.GetCategories();
            ViewBag.Users = service.GetUsers();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEntry(TicketDTO ticket)
        {
            ViewBag.Title = "Задача сохранена";

            StatusDTO status = service.GetStatuses().FirstOrDefault(p => p.StatusId == ticket.StatusId);
            CategoryDTO category = service.GetCategories().FirstOrDefault(p => p.CategoryId == ticket.CategoryId); 
            UserDTO user = service.GetUsers().FirstOrDefault(p => p.UserId == ticket.UserId);

            ticket.Status = status;
            ticket.Category = category;
            ticket.User = user;

            service.AddOrUpdateTicket(ticket);

            return View("RegisteredTicket");
        }

        [HttpGet]
        public ActionResult EditEntry(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TicketDTO ticket = service.GetTicket().FirstOrDefault(p => p.TicketId == id);

            if (ticket == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.CategoryId = new SelectList(service.GetCategories(), "CategoryId", "Title", ticket.CategoryId);
                ViewBag.StatusId = new SelectList(service.GetStatuses(), "StatusId", "Title", ticket.StatusId);
                ViewBag.UserId = new SelectList(service.GetUsers(), "UserId", "FirstName", ticket.UserId);
            }
            return View(ticket);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditEntry([Bind(Include = "TicketId,Title,Description,Date,CategoryId,StatusId,UserId")] TicketDTO ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        service.AddOrUpdateTicket(ticket);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(service.GetCategories(), "CategoryId", "Title", ticket.CategoryId);
        //    ViewBag.StatusId = new SelectList(service.GetStatuses(), "StatusId", "Title", ticket.StatusId);
        //    ViewBag.UserId = new SelectList(service.GetUsers(), "UserId", "FirstName", ticket.UserId);
        //    return View(ticket);
        //}

        [HttpPost]
        public ActionResult EditEntry()
        {
            var model = new TicketDTO();
            if (TryUpdateModel(model))
            {
                service.AddOrUpdateTicket(model);
            }
            else
            {
                ViewBag.Message = "Во время редактирования возникли ошибки!";
            } 
             
          return RedirectToAction("Index");
        }



[HttpGet]
        public ActionResult DeleteEntry(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketDTO ticket = service.GetTicket().FirstOrDefault(p => p.TicketId == id);

            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        [HttpPost, ActionName("DeleteEntry")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketDTO ticket = service.GetTicket().FirstOrDefault(p => p.TicketId == id);
            service.RemoveTicket(ticket);
            return RedirectToAction("Index");
        }


        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var model = service.GetCategories();
            return PartialView("ListCategories", model);
        }

        [Authorize]
        public ActionResult ProfileUser()
        {
            //User.Identity.Name

            return View((UserDTO)Session["User"]);
        }
    }
}
