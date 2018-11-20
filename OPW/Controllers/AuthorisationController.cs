using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPW.DAL;
using OPW.Models;

namespace OPW.Controllers
{
    public class AuthorisationController : Controller
    {
        private OPWContext2 db = new OPWContext2();

        // GET: Authorisations
        public ActionResult Index()
        {
            return View(db.Opwauthorisation2.ToList());
        }

        // GET: Authorisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // GET: Authorisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,User_Name,User_Password,Email,Company,Usersect,Usersectcode,User_Approval_Limit,WorkId")] Authorisation authorisation)
        {
            if (ModelState.IsValid)
            {
                db.Opwauthorisation2.Add(authorisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorisation);
        }

        // GET: Authorisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // POST: Authorisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,User_Name,User_Password,Email,Company,Usersect,Usersectcode,User_Approval_Limit,WorkId")] Authorisation authorisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorisation);
        }

        // GET: Authorisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // POST: Authorisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            db.Opwauthorisation2.Remove(authorisation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Authorise(OPW.Models.Authorisation userModel)
        {
            using (OPWContext2 db = new OPWContext2())
            {
                var userDetails = db.Opwauthorisation2.Where(x => x.User_Name == userModel.User_Name && x.User_Password == userModel.User_Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.User_ID;
                    Session["userName"] = userDetails.User_Name;
                    return RedirectToAction("UserDashBoard", "Authorisation");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
