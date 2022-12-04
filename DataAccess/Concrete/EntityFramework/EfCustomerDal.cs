using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDbContext>, ICustomerDal
    {
        public Customer GetByUserId(int UserId)
        {
            using var context = new ReCapDbContext();
            var result = from c in context.Customers
                join u in context.Users
                    on c.UserId equals u.Id
                where c.UserId == UserId
                select new Customer
                {
                    CompanyName = c.CompanyName,
                    Id = c.Id,
                    UserId = c.UserId
                };
            return result.First();
        }
    }
}