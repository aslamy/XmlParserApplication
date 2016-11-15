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

        public PartialViewResult Process(string link)
        {
 
         /*   var valid = IsValidUrl(link);
            if (!valid)
            {
                return Content("Felaktig länk!"); ;
            }*/
            var xmlParser = new XmlParser<Rss>();
            
            var rss = xmlParser.Parse(link);
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


        private static bool IsValidUrl(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                if (request != null)
                {
                    request.Method = "HEAD";
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    if (response != null)
                    {
                        response.Close();
                        return (response.StatusCode == HttpStatusCode.OK);
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}