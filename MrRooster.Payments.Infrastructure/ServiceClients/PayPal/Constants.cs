namespace MrRooster.Payments.Infrastructure.ServiceClients.PayPal
{
    public static class PayPalEndpoints
    {
        public static string GET_TOKEN = "v1/oauth2/token";

        public static class Products
        {
            public static string GET_PRODUCTS = "v1/catalogs/products";
            public static string CREATE_PRODUCT = "v1/catalogs/products";
            public static string GET_PRODUCT = "v1/catalogs/products/";
        }

        public static class Plans
        {
            public static string CREATE_PLAN = "v1/billing/plans";
        }     
    }
}
