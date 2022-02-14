using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tedliu.WebApp01.Models;

namespace Tedliu.WebApp01.Controllers
{
    public class GuestbooksController : Controller
    {
        private EFModel db = new EFModel();

        // GET: Guestbooks
        public async Task<ActionResult> Index()
        {
            return View(await db.Guestbooks.ToListAsync());
        }

        // GET: Guestbooks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guestbook guestbook = await db.Guestbooks.FindAsync(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        // GET: Guestbooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guestbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Content,CreateTime,Reply,ReplyTime")] Guestbook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.Guestbooks.Add(guestbook);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(guestbook);
        }

        // GET: Guestbooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guestbook guestbook = await db.Guestbooks.FindAsync(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        // POST: Guestbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Content,CreateTime,Reply,ReplyTime")] Guestbook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestbook).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(guestbook);
        }

        // GET: Guestbooks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guestbook guestbook = await db.Guestbooks.FindAsync(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        // POST: Guestbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Guestbook guestbook = await db.Guestbooks.FindAsync(id);
            db.Guestbooks.Remove(guestbook);
            await db.SaveChangesAsync();
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
    }
}
