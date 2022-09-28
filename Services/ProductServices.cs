
using System.Runtime.CompilerServices;
using VeyselogluWebApiTest.Models;
using VeyselogluWebApiTest.Repositories;
using static VeyselogluWebApiTest.Models.GetAllProductResponse;

namespace VeyselogluWebApiTest.Services
{
    public class ProductServices
    {
        private IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<AllProducts> GetAllProducts()
        {
            List<AllProducts> mainList = new List<AllProducts>();
           
            mainList = _productRepository.GetAllProducts();
            if (mainList.Count != 0)
            {
                foreach (var item in mainList)
                {
                    List<ProductCategory> productCategories = new List<ProductCategory>();
                    productCategories = _productRepository.GetAllProductCategories(item.mainCategoryCode);
                    item.productCategories = productCategories;
                    if (item.productCategories.Count != 0)
                    {
                        foreach (var category in item.productCategories)
                        {
                            List<ProductSubCategory> productSubCategories = new List<ProductSubCategory>();
                            productSubCategories = _productRepository.GetSubProductCategories(category.categoryCode);
                            category.productSubCategories = productSubCategories;
                        }
                    }
                }
            }
           
            return mainList;
            
        }
    }
}
