﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exeptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerSevice;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerSevice, DepartmentService departmentService)
        {
            _sellerSevice = sellerSevice;
            _departmentService = departmentService;
        }

        // GET: Sellers
        public IActionResult Index()
        {
            var list = _sellerSevice.FindAll();
            return View(list);
        }

       public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerSevice.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerSevice.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerSevice.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller = _sellerSevice.FindById(id.Value);

            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerSevice.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { seller = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {   
            if(id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerSevice.Update(seller);
                return RedirectToAction(nameof(Index));
            }catch(NotFoundException)
            {
                return NotFound();
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
