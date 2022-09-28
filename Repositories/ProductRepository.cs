using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using VeyselogluWebApiTest.Models;
using VeyselogluWebApiTest.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using static VeyselogluWebApiTest.Models.GetAllProductResponse;

namespace VeyselogluWebApiTest.Repositories
{
    public class ProductRepository:IProductRepository
    {
        string connectionString = null;
        public ProductRepository(string conn)
        {
            connectionString = conn;
        }

        public List<AllProducts> GetAllProducts()
        {
            using (IDbConnection db=new SqlConnection(connectionString))
            {
                return db.Query<AllProducts>("select distinct(MainCategoryCode), MainCategoryName from  dbo.Products").ToList();
            }
        }

        public List<ProductCategory> GetAllProductCategories(string mainCategoryCode)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ProductCategory>($@"select distinct(CategoryCode), CategoryName from  dbo.Products where MainCategoryCode='{mainCategoryCode}'").ToList();
            }
        }

        public List<ProductSubCategory> GetSubProductCategories(string productCategoryCode)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ProductSubCategory>($@"select distinct(SubCategoryCode), SubCategoryName from  dbo.Products where CategoryCode='{productCategoryCode}'").ToList();
            }
        }
    }
}
