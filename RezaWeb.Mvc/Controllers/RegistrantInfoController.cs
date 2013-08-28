using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RezaWeb.Mvc.Models;
using WebMatrix.WebData;

namespace RezaWeb.Mvc.Controllers
{
	[Authorize]
	public class RegistrantInfoController : Controller
	{
		private readonly RezaWebContext _context;

		public RegistrantInfoController()
		{
			_context = new RezaWebContext();
		}

		//
		// GET: /RegistrantInfo/

		public ActionResult Index(int userId = 0)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account");
			}

			if (User.IsInRole("Administrator"))
			{
				return RedirectToAction("List");
			}

			UserProfile user = null;

			user = userId == 0
							? _context.UserProfiles.Single(x => x.UserName == User.Identity.Name)
							: _context.UserProfiles.Find(userId);

			if (user.RegistrantInfo == null)
			{
				return RedirectToAction("Create", new {userId});
			}

			return RedirectToAction("ExamNumber", new {user.UserId});
		}

		[Authorize(Roles = "Administrator")]
		public ActionResult List()
		{
			return View(_context.RegistrantInfos.ToList());
		}

		public ActionResult ExamNumber(int userId)
		{
			UserProfile user = _context.UserProfiles.Find(userId);

			return View(user);
		}

		//
		// GET: /RegistrantInfo/Details/5

		public ActionResult Details(int id = 0)
		{
			RegistrantInfo registrantinfo = _context.RegistrantInfos.Find(id);
			if (registrantinfo == null)
			{
				return HttpNotFound();
			}
			return View(registrantinfo);
		}

		//
		// GET: /RegistrantInfo/Create

		public ActionResult Create(int userId)
		{
			ViewBag.UserId = userId;
			return View();
		}

		//
		// POST: /RegistrantInfo/Create

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Create(RegistrantInfo registrantinfo, int userId)
		{
			try
			{
				if (ModelState.IsValid)
				{
					UserProfile user = _context.UserProfiles.Find(userId);
					registrantinfo.ExamNumber = user.UserName + GetRandomString();
					registrantinfo.UserProfile = user;
					_context.RegistrantInfos.Add(registrantinfo);
					_context.SaveChanges();
					return RedirectToAction("ExamNumber", new {userId});
				}
			}
			catch (DataException ex)
			{
				string msg = ex + "\r\n"
							 + "Unable to save changes. Try again, and if the problem persists see your system administrator.";

				//Log the error (add a variable name after DataException)
				ModelState.AddModelError("", msg);
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
			}

			ViewBag.RegistrantInfoId = new SelectList(_context.UserProfiles, "UserId", "UserName", registrantinfo.RegistrantInfoId);
			return View(registrantinfo);
		}

		string GetRandomString()
		{
			const string chars = "0123456789";
			Random random = new Random();
			string result = new string(Enumerable.Repeat(chars, 8)
							.Select(s => s[random.Next(s.Length)])
							.ToArray());

			return result;
		}

		//
		// GET: /RegistrantInfo/Edit/5

		public ActionResult Edit(int id = 0)
		{
			RegistrantInfo registrantinfo = _context.RegistrantInfos.Find(id);
			if (registrantinfo == null)
			{
				return HttpNotFound();
			}
			ViewBag.RegistrantInfoId = new SelectList(_context.UserProfiles, "UserId", "UserName", registrantinfo.RegistrantInfoId);
			return View(registrantinfo);
		}

		//
		// POST: /RegistrantInfo/Edit/5

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Edit(RegistrantInfo registrantinfo)
		{
			try
			{
				if (ModelState.IsValid)
				{
					RegistrantInfo registrantInfoOld = _context.RegistrantInfos.Find(registrantinfo.RegistrantInfoId);
					registrantInfoOld.Update(registrantinfo);

					//_context.Entry(registrantinfo).State = EntityState.Modified;
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (DataException ex)
			{
				string msg = ex + "\r\n"
							 + "Unable to save changes. Try again, and if the problem persists see your system administrator.";

				//Log the error (add a variable name after DataException)
				ModelState.AddModelError("", msg);
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
			}
			ViewBag.RegistrantInfoId = new SelectList(_context.UserProfiles, "UserId", "UserName", registrantinfo.RegistrantInfoId);
			return View(registrantinfo);
		}

		//
		// GET: /RegistrantInfo/Delete/5

		public ActionResult Delete(bool? saveChangesError, string errorMessage, int id = 0)
		{
			if (saveChangesError.GetValueOrDefault())
			{
				string msg = errorMessage + "<br/>"
							 + "Unable to save changes. Try again, and if the problem persists see your system administrator.";
				ViewBag.ErrorMessage = 	MvcHtmlString.Create(msg);
			}
			RegistrantInfo registrantinfo = _context.RegistrantInfos.Find(id);
			if (registrantinfo == null)
			{
				return HttpNotFound();
			}
			return View(registrantinfo);
		}

		//
		// POST: /RegistrantInfo/Delete/5

		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				RegistrantInfo registrantinfo = _context.RegistrantInfos.Find(id);
				_context.RegistrantInfos.Remove(registrantinfo);
				_context.SaveChanges();				
			}
			catch (Exception ex)
			{
				//Log the error (add a variable name after DataException)
				return RedirectToAction("Delete",
										new System.Web.Routing.RouteValueDictionary
										{
											{"id", id},
											{"saveChangesError", true},
											{"errorMessage", ex.Message}
										});
			}
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
			base.Dispose(disposing);
		}
	}
}