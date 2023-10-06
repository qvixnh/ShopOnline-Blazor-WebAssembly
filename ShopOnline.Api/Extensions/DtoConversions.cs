﻿using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;
using System.Net.NetworkInformation;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {

        public static IEnumerable<ProductCategoryDto> ConvertToDto(this IEnumerable<ProductCategory> categories)
        {
            return (from cat in categories
                    select new ProductCategoryDto
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        IconCSS = cat.IconCSS,
                    }).ToList();
        }
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products)
        {
            return (from product in products
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.ProductCategory.Id,
                        CategoryName = product.ProductCategory.Name,
                    }).ToList();
        }
        public static ProductDto ConvertToDto(this Product product  )
        {
            return new ProductDto
                   {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.ProductCategory.Id,
                        CategoryName = product.ProductCategory.Name,
                   };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Price * cartItem.Qty
                    }).ToList();
        }

        //for getitem(id) action
        public static CartItemDto ConvertToDto(this CartItem cartItem, Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,
                TotalPrice = product.Price * cartItem.Qty
            };
        }
    }
}
