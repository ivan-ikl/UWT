namespace UWT.Web.Models {

    public class ShopDiscountModel : ShopViewModel {

        public int Discount { get; set; }

        public CategoryDiscountModel[] Categories { get; set; }

        public ProductDiscountModel[] Products { get; set; }

    }

    public class CategoryDiscountModel : CategoryViewModel
    {

        public int Discount { get; set; }

    }

    public class ProductDiscountModel : ProductViewModel
    {

        public int Discount { get; set; }

    }

}