using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Spaceship;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ICarsServices _carsServices;

        public CarsController
            (
                TARge21ShopContext context,
                ICarsServices carsServices
            )
        {
            _context = context;
            _carsServices = carsServices;
        }


        public IActionResult Index()
        {
            var result = _context.Cars                
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Passengers = x.Passengers,
                    EnginePower = x.EnginePower
                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Crew = vm.Crew,
                Passengers = vm.Passengers,
                CargoWeight = vm.CargoWeight,
                FullTripsCount = vm.FullTripsCount,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower
                
            };

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarCreateUpdateViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
                Crew = car.Crew,
                Passengers = car.Passengers,
                CargoWeight = car.CargoWeight,
                FullTripsCount = car.FullTripsCount,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                EnginePower = car.EnginePower,
            };

            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Crew = vm.Crew,
                Passengers = vm.Passengers,
                CargoWeight = vm.CargoWeight,
                FullTripsCount = vm.FullTripsCount,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
                Crew = car.Crew,
                Passengers = car.Passengers,
                CargoWeight = car.CargoWeight,
                FullTripsCount = car.FullTripsCount,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                EnginePower = car.EnginePower
            };

            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
                Crew = car.Crew,
                Passengers = car.Passengers,
                CargoWeight = car.CargoWeight,
                FullTripsCount = car.FullTripsCount,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                EnginePower = car.EnginePower,
            };

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceshipId = await _carsServices.Delete(id);

            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
