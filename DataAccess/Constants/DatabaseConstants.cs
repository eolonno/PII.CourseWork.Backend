using System.Collections.Generic;

namespace DataAccess.Constants
{
    public class DatabaseConstants
    {
        public static class OperationalClaims
        {
            public const string Admin = "admin";
            public const string Moderator = "moderator";
            public const string User = "user";

            public const string RentalGet = "rental.get";
            public const string RentalAdd = "rental.add";
            public const string RentalUpdate = "rental.update";
            public const string RentalDelete = "rental.delete";

            public const string FindeksGet = "findeks.get";
            public const string FindeksAdd = "findeks.add";
            public const string FindeksUpdate = "findeks.update";
            public const string FindeksDelete = "findeks.delete";

            public const string CustomerGet = "customer.get";
            public const string CustomerAdd = "customer.add";
            public const string CustomerUpdate = "customer.update";
            public const string CustomerDelete = "customer.delete";

            public const string CarImageDelete = "carimage.delete";
            public const string CarImageUpdate = "carimage.update";

            public const string BrandAdd = "brand.add";
            public const string BrandUpdate = "brand.update";
            public const string BrandDelete = "brand.delete";

            public const string UserGet = "user.get";
            public const string UserDelete = "user.delete";
            public const string UserUpdate = "user.update";
        }
    }
}