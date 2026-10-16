using Microsoft.AspNetCore.Mvc;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto",    PricePerDay = 3000 },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
            new Car { Id = 3, Name = "Civic",   PricePerDay = 8000 }
        };

        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int id)
        {
            Car selectedCar = null;

            foreach (Car c in availableCars)
            {
                if (c.Id == id)
                {
                    selectedCar = c;
                    break;
                }
            }

            if (selectedCar == null)
            {
                return RedirectToAction("Index");
            }

            availableCars.Remove(selectedCar);
            bookedCars.Add(selectedCar);

            return RedirectToAction("Booked");
        }

        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}
