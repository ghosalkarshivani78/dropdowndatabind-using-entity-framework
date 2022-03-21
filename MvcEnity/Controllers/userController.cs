using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEnity.Models;

namespace MvcEnity.Controllers
{
    public class userController : Controller
    {
        //
        // GET: /user/
        test2Entities4 ts = new test2Entities4();
         
        public ActionResult Index()
        {
            userform model = new userform();
            var db = ts.users.ToList();
            List<userform> li = new List<userform>();
           
            foreach (var i in db)
            {
                userform f = new userform();
                f.id = i.id;
                f.firstname = i.firstname;
                f.lastname = i.lastname;
                f.email = i.email;
                f.address = i.address;
                f.cityid = ts.cities.Where(x=>x.cityid==i.cityid).SingleOrDefault().cityname;
                f.number = i.number;
                li.Add(f);
            }
            return View(li);
           
        }

      
        //
        // GET: /user/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /user/Create

        public ActionResult Create()
        {
            userform f = new userform();
            var citylist = ts.cities.ToList();
            f.cities = new SelectList(citylist, "cityid", "cityname");
            return View(f);
       
        } 

        //
        // POST: /user/Create

        [HttpPost]
        public ActionResult Create(userform uf)
        {
            userform p = new userform();
            try
            {
                var citylist = ts.cities.ToList();
                p.cities = new SelectList(citylist, "cityid", "cityname");
                // TODO: Add insert logic here

                var task = ts.users.Where(x => x.email == uf.email).SingleOrDefault();
                if (task == null)
                {
                    user f = new user();
                    f.firstname = uf.firstname;
                    f.lastname = uf.lastname;
                    f.email = uf.email;
                    f.address = uf.address;
                    f.cityid =Convert.ToInt32(uf.cityid);
                    f.number = uf.number;
                    ts.users.AddObject(f);
                    ts.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Already email Exist";
                    return View(p);
                }
            }
            catch
            {
                return View(p);
            }
           
        }
        
        //
        // GET: /user/Edit/5
 
        public ActionResult Edit(int id)
        {
           
            userform f = new userform();
            var citylist = ts.cities.ToList();
            f.cities = new SelectList(citylist, "cityid", "cityname");
            var t = ts.users.Where(x => x.id == id).SingleOrDefault();
            f.id = t.id;
            f.firstname = t.firstname;
            f.lastname = t.lastname;
            f.email = t.email;
            f.address = t.address;
            f.cityid = t.cityid.ToString();
            f.number = t.number;
            return View(f);
            
        }

        //
        // POST: /user/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, userform uf)
        {
            var citylist = ts.cities.ToList();
            uf.cities = new SelectList(citylist, "cityid", "cityname");
            try
            {

                // TODO: Add update logic here
                var t = ts.users.Where(x => x.id==id).SingleOrDefault();
                t.id = uf.id;
                t.firstname = uf.firstname;
                t.lastname = uf.lastname;
                t.email = uf.email;
                t.address = uf.address;
                t.cityid = Convert.ToInt32(uf.cityid);
                t.number = uf.number;
                ts.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(uf);
            }
        }

        //
        // GET: /user/Delete/5
 
        public ActionResult Delete(int id)
        {
            var t = ts.users.Where(x => x.id == id).SingleOrDefault();
            ts.DeleteObject(t);
            ts.SaveChanges();
            return RedirectToAction("Index");
          
        }

        //
        // POST: /user/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
