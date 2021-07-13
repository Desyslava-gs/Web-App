﻿using System;
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
        private readonly CarRepairDbContext _context;

        public CarsController(CarRepairDbContext context)
        {
            _context = context;
        }

        // GET: Cars1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        // GET: Cars1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
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
                FuelTypes= this.GetFuelType()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCarFormModel car)
        {
            if (ModelState.IsValid)
            {
                var carData = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    Color = car.Color,
                    Description = car.Description,
                    FuelTypeId= car.FuelTypeId,
                    PictureUrl = car.PictureUrl,
                    PlateNumber = car.PlateNumber,
                    VinNumber = car.VinNumber,
                    Year = car.Year,
                    Repairs = new List<Repair>(),

                };
                this._context.Cars.Add(carData);
                this._context.SaveChanges();

                 return RedirectToAction("Index");
            }
            return View(car);
        }

        private IEnumerable<FuelTypeViewModel> GetFuelType()
        {
            return _context
                .FuelTypes
                .Select(ft =>  new FuelTypeViewModel
                {
                    Id=ft.Id,
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

            var car = await _context.Cars.FindAsync(id);
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
                    _context.Update(car);
                    await _context.SaveChangesAsync();
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

            var car = await _context.Cars
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
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(string id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
