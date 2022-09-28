namespace VeyselogluWebApiTest.Models
{
    public class GetAllProductResponse
    {
        
        public class ProductCategory
        {
            public string? categoryCode { get; set; }
            public string? categoryName { get; set; }
            public List<ProductSubCategory> productSubCategories { get; set; }
        }

        public class ProductSubCategory
        {
            public string? subCategoryCode { get; set; }
            public string? subCategoryName { get; set; }
        }

        public class AllProducts
        {
            public string? mainCategoryCode { get; set; }
            public string? mainCategoryName { get; set; }
            public List<ProductCategory> productCategories { get; set; }
        }
    }
}
