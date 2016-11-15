using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using XMLParserApplication.Models;
using XMLParserApplication.Models.ViewModels;

namespace XMLParserApplication.Controllers
{
    public class HomeController : Controller
    {
        private static IEnumerable<Item> items;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Process(string link)
        {
            Rss rss;
            try
            {
                var xmlParser = new XmlParser<Rss>();
                rss = xmlParser.Parse(link);
            }catch{
                return Content("Felaktig länk!");
            }

            items = rss.Channel.Items.Take(5);
            int i = 0;
            foreach (var item in items)
            {
                item.Id = i++;
            }
            return PartialView("_Process", items);
        }


        public PartialViewResult Sort(string sortOrder, string sortName)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? " desc" : "";
            var sort = sortName + sortOrder;
            switch (sort)
            {
                case "title":
                    items = items.OrderBy(x => x.Title);
                    break;
                case "title desc":
                    items = items.OrderByDescending(x => x.Title);
                    break;
                case "date":
                    items = items.OrderBy(x => x.PublishedDate);
                    break;
                case "date desc":
                    items = items.OrderByDescending(x => x.PublishedDate);
                    break;
            }

            return PartialView("_Process", items);
        }

        [HttpPost]
        public PartialViewResult Edit(EditViewModel model)
        {
            var item = items.FirstOrDefault(x => x.Id == model.Id);
            if (item == null)
            {
                return PartialView("_Process", items);
            }
            item.Name = model.Name;
            item.Email = model.Email;
            item.Comment = model.Comment;
            return PartialView("_Process", items);
        }
    }
}