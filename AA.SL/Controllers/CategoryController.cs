﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AA.DAL;
using AA.DAL.Models;

namespace AA.SL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
            QuickKartRepository repository;
            public CategoryController()
            {
                repository = new QuickKartRepository();
            }
        [HttpGet]
        public JsonResult GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = repository.GetAllCategories();
            }
            catch (Exception ex)
            {
                categories = null;
            }
            return Json(categories);
        }
        [HttpGet]
        public JsonResult GetCategoryById(byte id)
        {
            Category category = new Category();
            try
            {
                category = repository.GetCategoryById(id);
            }
            catch (Exception ex)
            {
                category = null;
            }
            return Json(category);
        }
        [HttpPost]
        public JsonResult AddCategory(Category category)
        {
            bool result = false;
            try
            {
                result = repository.AddCategory(category.CategoryName);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }
        [HttpPut]
        public JsonResult UpdateCategory(Category category)
        {
            bool result = false;
            try
            {
                result = repository.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }
        [HttpDelete]
        public JsonResult DeleteCategory(byte id)
        {
            bool result = false;
            try
            {
                result = repository.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }
    }
}
