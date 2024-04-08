using Cosmetics.Helpers;
using System;
using System.Text;

namespace Cosmetics.Models
{
    public class Product
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private double price;
        private string name;
        private string brand;
        private readonly GenderType gender;

        // "Each product in the system has name, brand, price and gender."

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Price = price;
            this.Name = name;
            this.Brand = brand;
            this.gender = gender;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price should not be negative.");
                }
                this.price = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                string errorMessage = string.Format($"Name should be between {NameMinLength} and {NameMaxLength} symbols.");
                ValidationHelpers.ValidateIntRange(NameMinLength, NameMaxLength, value.Length, errorMessage);
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                string errorMessage = string.Format($"Brand should be between {BrandMinLength} and {BrandMaxLength} symbols.");
                ValidationHelpers.ValidateIntRange(BrandMinLength, BrandMaxLength, value.Length, errorMessage);
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {
            // Format:
            // #[Name] [Brand]
            // #Price: [Price]
            // #Gender: [Gender]
            var sb = new StringBuilder();
            sb.AppendLine($" #{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: ${this.Price:0.##}");
            sb.AppendLine($" #Gender: {this.Gender}");
            return sb.ToString().TrimEnd();
        }

        public override bool Equals(object p)
        {
            if (p == null || !(p is Product))
            {
                return false;
            }

            if (this == p)
            {
                return true;
            }

            Product otherProduct = (Product)p;

            return this.Price == otherProduct.Price
                    && this.Name == otherProduct.Name
                    && this.Brand == otherProduct.Brand
                    && this.Gender == otherProduct.Gender;
        }
    }
}