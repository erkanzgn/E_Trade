﻿using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Entities;

namespace ETrade.Catalog.Dtos.ProductDtos
{
    public class ResultProductsWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
