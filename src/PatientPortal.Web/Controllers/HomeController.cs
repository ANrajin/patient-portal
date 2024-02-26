using Microsoft.AspNetCore.Mvc;
using PatientPortal.Web.Models;
using PatientPortal.Web.Models.HomeModels;
using System.Diagnostics;

namespace PatientPortal.Web.Controllers
{
    public class HomeController(IServiceScopeFactory serviceScopeFactory,
        ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                using var serviceScope = serviceScopeFactory.CreateScope();

                var model = serviceScope.ServiceProvider.GetRequiredService<HomeModel>();

                await model.LoadModelData();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Patients(int id)
        {
            try
            {
                using var serviceScope = serviceScopeFactory.CreateScope();

                var model = serviceScope.ServiceProvider.GetRequiredService<PatientViewModel>();

                await model.LoadModelData(id);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                using var serviceScope = serviceScopeFactory.CreateScope();

                var model = serviceScope.ServiceProvider.GetRequiredService<PatientViewModel>();

                await model.LoadModelData(id);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
