using Microsoft.AspNetCore.Mvc;
using PatientPortal.Web.Models.HomeModels;

namespace PatientPortal.Web.Controllers
{
    public class PatientsController(IServiceScopeFactory serviceScopeFactory,
        ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

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

                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> View(int id)
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

                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                using var serviceScope = serviceScopeFactory.CreateScope();

                var model = serviceScope.ServiceProvider.GetRequiredService<PatientEditModel>();

                await model.LoadModelData(id);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
