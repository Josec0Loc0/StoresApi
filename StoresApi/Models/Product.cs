﻿namespace StoresApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }  // Relación con Store
    }
}
