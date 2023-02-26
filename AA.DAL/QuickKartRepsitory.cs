﻿using AA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AA.DAL
{
    public class QuickKartRepository
    {
        QuickKartDBContext context;
        public QuickKartRepository()
        {
            context = new QuickKartDBContext();
        }
        public List<Category> GetAllCategories()
        {
            var categoriesList = context.Categories
                                  .OrderBy(x=>x.CategoryId)
                                  .ToList();
            return categoriesList;
        }
        public Category GetCategoryById(byte id)
        {
            var category = context.Categories
                                .Where(x=>x.CategoryId == id)
                                .FirstOrDefault();
            return category;
        }
        public bool AddCategory(string categoryName)
        {
            bool status = false;
            Category category = new Category();
            category.CategoryName = categoryName;
            try
            {
               // context.Categories.Add(category);
                context.Add<Category>(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return status;
        }
        public bool DeleteCategory(byte id)
        {
            bool status = false;
            Category category = new Category();
            category.CategoryId = id;
            try
            {
                //context.Categories.Remove(category);
                context.Remove<Category>(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return status;
        }
        public bool UpdateCategory(Category c)
        {
            bool status = false;
            Category category = new Category();
            category.CategoryId = c.CategoryId;
            category.CategoryName = c.CategoryName;
            try
            {
                //context.Categories.(category);
                context.Update<Category>(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return status;
        }


    }

}
