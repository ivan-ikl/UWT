using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Models.Extensions;

namespace UWT.Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {

        public bool SendMessage(int product, string text)
        {
            string userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var dbProduct = db.Products.IncludeAll().FirstOrDefault(p => p.Id == product);
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (dbProduct == null || user == null)
                {
                    return false;
                }
                var owner = dbProduct.Shop.Owner;
                var msg = new Message
                {
                    DateSent = DateTime.UtcNow,
                    DateRecieved = DateTime.MaxValue,
                    Product = dbProduct,
                    Sender = user,
                    Reciever = owner,
                    Text = "I want this"
                };
                db.Messages.Add(msg);
                db.SaveChanges();
            }
            return true;
        }

        public Message[] NewMessages()
        {
            string userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                return db.Messages.Where(m => m.Reciever.Id == userId && m.DateRecieved > DateTime.UtcNow).ToArray();
            }
        }

        public bool Dismiss()
        {
            string userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var messages = db.Messages.Where(m => m.Reciever.Id == userId && m.DateRecieved > DateTime.UtcNow).ToList();
                messages.ForEach(m => m.DateRecieved = DateTime.UtcNow);
                db.SaveChanges();
            }
            return true;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var messages = db.Messages.Where(m => m.Reciever.Id == userId && m.DateRecieved > DateTime.UtcNow).Include(m => m.Product.Shop).ToList();
                return View(messages);
            }
        }

    }
}