﻿namespace Restaurant.Services.ProductAPI.Models.Dtos
{
    public class CreateProductDto
    {
        public string? Name_TR { get; set; }
        public string Name_EN { get; set; }
        public string? Description_TR { get; set; }
        public string Descripton_EN { get; set; }
        public double Price { get; set; }
        public string? CategoryName_TR { get; set; }
        public string CategoryName_EN { get; set; }
        public string? ImageUrl { get; set; }
    }
}
