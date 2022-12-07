using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
                join u in context.Users on r.UserId equals u.Id
                join car in context.Cars on r.CarId equals car.Id
                join brand in context.Brands on car.BrandId equals brand.Id
                select new RentalDetailDto
                {
                    CarId = car.Id,
                    RentalId = r.Id,
                    IsCanceled = r.IsCanceled,
                    CustomerId = u.Id,
                    CustomerName = u.FirstName + " " + u.LastName,
                    CarName = car.Name,
                    BrandName = brand.Name,
                    ReturnDate = r.ReturnDate,
                    RentalStartDate = r.RentStartDate,
                    RentalEndDate = r.RentEndDate
                };
            return result.ToList();
        }

        public void CancelRental(int rentalId)
        {
            using var context = new ReCapDbContext();
            var rental = context.Rentals.FirstOrDefault(x => x.Id == rentalId);
            rental!.IsCanceled = true;

            context.SaveChanges();
        }
    }
}