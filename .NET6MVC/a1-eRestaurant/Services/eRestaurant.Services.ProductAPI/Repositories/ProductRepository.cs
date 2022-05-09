﻿using AutoMapper;
using eRestaurant.Services.ProductAPI.DbContexts;
using eRestaurant.Services.ProductAPI.Dtos;
using eRestaurant.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Services.ProductAPI.Repositories
{

    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products
                                            .FirstOrDefaultAsync(u => u.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products
                                        .Where(x => x.ProductId == productId)
                                        .FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(productList);

        }

    }

}
