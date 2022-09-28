using VeyselogluWebApiTest.Models;
using static VeyselogluWebApiTest.Models.GetAllProductResponse;

namespace VeyselogluWebApiTest.Repositories
{
    public interface IProductRepository
    {
        List<AllProducts> GetAllProducts();
        List<ProductCategory> GetAllProductCategories(string mainCategoryCode);
        List<ProductSubCategory> GetSubProductCategories(string productCategoryCode);
    }
}
