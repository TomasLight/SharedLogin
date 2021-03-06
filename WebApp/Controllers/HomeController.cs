﻿namespace WebApp.Controllers
{
	using System.Diagnostics;
	using Microsoft.AspNetCore.Mvc;
	using WebApp.Models;

	public class HomeController : Controller
	{
		public HomeController()
		{
		}

		public IActionResult Index()
		{
			return View("~/Views/Home/App.cshtml");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
