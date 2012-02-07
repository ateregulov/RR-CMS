using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RrCms.Controllers.Models;
using RrCms.Models;

namespace RrCms.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [NeedEditorRole]
        public ActionResult Index()
        {
            using (var db = new ContactEntities())
            {
                return View(db.Contacts.ToList());
            }
        }

        public ActionResult GetContacts()
        {
            using (var db = new ContactEntities())
            {
                return View(db.Contacts
                    .OrderBy(contact => contact.DisplayOrder)
                    .ToList());
            }
        }

        //
        // GET: /Contact/Create
        [NeedEditorRole]
        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Contact/Create
        [NeedEditorRole]
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                using (var db = new ContactEntities())
                {
                    contact.Text = HttpUtility.UrlDecode(contact.Text, System.Text.Encoding.Default);
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contact/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new ContactEntities())
            {
                return View(db.Contacts.Find(id));
            }
        }

        //
        // GET: /Article/Edit/5
        [NeedEditorRole]
        public ActionResult Edit(int id)
        {
            using (var db = new ContactEntities())
            {
                return View(db.Contacts.Find(id));
            }
        }

        //
        // POST: /Article/Edit/5
        [NeedEditorRole]
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                using (var db = new ContactEntities())
                {
                    contact.Text = HttpUtility.UrlDecode(contact.Text, System.Text.Encoding.Default);
                    db.Entry(contact).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Article/Delete/5
        [NeedEditorRole]
        public ActionResult Delete(int id)
        {
            using (var db = new ContactEntities())
            {
                return View(db.Contacts.Find(id));
            }
        }

        //
        // POST: /Article/Delete/5
        [NeedEditorRole]
        [HttpPost]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                using (var db = new ContactEntities())
                {
                    db.Entry(db.Contacts.Find(id)).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
