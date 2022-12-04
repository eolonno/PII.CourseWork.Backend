using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using var context = new ReCapDbContext();
            var result = from r in context.Rentals
                join u in context.Users
                    on r.UserId equals u.Id
                join car in context.Cars
                    on r.CarId equals car.Id
                select new RentalDetailDto
                {
                    CarId = car.Id,
                    CustomerId = u.Id,
                    CustomerName = u.FirstName + " " + u.LastName,
                    CarName = car.Name,
                    BrandName = car.BrandId.ToString(),
                    ReturnDate = r.ReturnDate
                };
            return result.ToList();
        }
    }
}