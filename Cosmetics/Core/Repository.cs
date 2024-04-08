using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics.Core
{
    public class Repository : IRepository
    {
        private readonly List<Product> products;
        private readonly List<Category> categories;
        private readonly ShoppingCart shoppingCart;

        public Repository()
        {
            this.products = new List<Product>();
            this.categories = new List<Category>();

            this.shoppingCart = new ShoppingCart();
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return new List<Category>(this.categories);
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public Product FindProductByName(string productName)
        {
            /**
             * Hint: You have to go through every product and see if one has name equal to productName.
             *       If not, "throw new ArgumentException("Product {productName} does not exist");"
             */
            foreach (Product product in this.Products)
            {
                if (product.Name == productName)
                {
                    return product;
                }
            }

            throw new ArgumentException(string.Format($"Product {productName} does not exist!"));
        }

        public Category FindCategoryByName(string categoryName)
        {
            /**
             * Hint: You have to go through every category and see if one has name equal to categoryName.
             *       If not, "throw new ArgumentException("Category {categoryName} does not exist");"
             */
            foreach (Category category in this.Categories)
            {
                if (category.Name == categoryName)
                {
                    return category;
                }
            }

            throw new ArgumentException(string.Format($"Category {categoryName} does not exist!"));
        }

        public void CreateCategory(string categoryName)
        {
            this.categories.Add(new Category(categoryName));
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            this.products.Add(new Product(name, brand, price, gender));
        }

        public bool CategoryExist(string categoryName)
        {
            /**
             * Hint: You have to go through each category and see if one has name equal to categoryName.
             *       If there is one, return true. If not, return false.
             */
            bool exists = false;

            foreach (Category category in this.Categories)
            {
                if (category.Name == categoryName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        public bool ProductExist(string productName)
        {
            /**
             * Hint: You have to go through each product and see if one has name equal to productName.
             *       If there is one, return true. If not, return false.
             */
            bool exists = false;

            foreach (Product product in this.Products)
            {
                if (product.Name == productName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
    }
}
