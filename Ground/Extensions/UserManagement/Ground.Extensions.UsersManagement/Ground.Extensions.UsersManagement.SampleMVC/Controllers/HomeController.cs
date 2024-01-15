﻿using Ground.Extensions.UsersManagement.Abstractions;
using Ground.Extensions.UsersManagement.SampleMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using IdentityModel.Client;
namespace Ground.Extensions.UsersManagement.SampleMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserInfoService _userInfoService;

        public HomeController(ILogger<HomeController> logger, IUserInfoService userInfoService)
        {


            var auserInfoService = userInfoService;
            _logger = logger;
            _userInfoService = userInfoService;
        }

        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User;
            var claim = HttpContext.User.Claims.ToList();
            var t = _userInfoService.GetClaim("name");
            return View();
        }

        public async Task<IActionResult> WeatherForecast()
        {
            try
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var client = new HttpClient();
                client.SetBearerToken(token);

                var response = await client.GetAsync("https://localhost:7039/WeatherForecast");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<WeatherForecast>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(result);
                }
            }
            catch { }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
