using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Models;
using WebApp.Models.Cars;

namespace WebApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRepairDbContext data;

        public CarsController(CarRepairDbContext data)
        {
            this.data = data;
        }

        // GET: Cars1
        public IActionResult Index()
        {
            //return View(new CreateCarFormModel
            //{
            //    FuelTypes= this.GetFuelType()
            //});
            return View(data.Cars.ToList());
        }

        //// GET: Cars1/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = this.data.Cars
                .Where(m => m.Id == id)
                .Select(c => new DetailsCarViewModel
                {
                    PictureUrl = c.PictureUrl,
                    Make = c.Make,
                    Model = c.Model,
                    Color = c.Color,
                    Description = c.Description,
                    Year = c.Year, 
                    FuelType = c.FuelType.Name ,//c.FuelTypeId,
                    PlateNumber = c.PlateNumber,
                    VinNumber = c.VinNumber,

                }).ToList()
                .FirstOrDefault();
             //  car.FuelType = this.GetFuelType();
            if (car == null)
            {
                return NotFound();
            }


            return View(car);
        }

        // GET: Cars1/Create
        public IActionResult Create()
        {
            return View(new CreateCarFormModel
            {
                FuelTypes = this.GetFuelType()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCarFormModel car)
        {
            if (!ModelState.IsValid)
            {
                car.FuelTypes = this.GetFuelType();
                return View(car);
            }

            var carData = new Car
            {
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                Description = car.Description,
                FuelTypeId = car.FuelTypeId,
                PictureUrl = car.PictureUrl,
                PlateNumber = car.PlateNumber,
                VinNumber = car.VinNumber,
                Year = car.Year,
                Repairs = new List<Repair>(),
            };

            this.data.Cars.Add(carData);
            this.data.SaveChanges();
            return RedirectToAction("Index");

        }

        private IEnumerable<FuelTypeViewModel> GetFuelType()
        {
            return data
                .FuelTypes
                .Select(ft => new FuelTypeViewModel
                {
                    Id = ft.Id,
                    Name = ft.Name,

                }).ToList();


        }
        // GET: Cars1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await data.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Make,Model,Year,Color,PlateNumber,Fuel,VinNumber,PictureUrl,Description")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    data.Update(car);
                    await data.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await data.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var car = await data.Cars.FindAsync(id);
            data.Cars.Remove(car);
            await data.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(string id)
        {
            return data.Cars.Any(e => e.Id == id);
        }
    }
}
