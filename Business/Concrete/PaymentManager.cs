using System;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IRentalDal _rentalDal;

        public PaymentManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Payment()
        {
            var rd = new Random().Next(2);
            if (rd == 0) return new ErrorResult(Messages.PaymentFailed);

            return new SuccessResult(Messages.PaymentSuccessful);
        }

        public IDataResult<double> GetDiscount(int userId)
        {
            var rentalDetails = _rentalDal.GetRentalDetails();

            try
            {
                var numberOfRentalDays = (double)rentalDetails
                    .Where(x => !x.IsCanceled)
                    .Select(x => x.RentalStartDate - x.RentalEndDate)
                    .Aggregate((x, y) => x.Add(y))
                    .Days;

                numberOfRentalDays = numberOfRentalDays > 100 ? 100 : numberOfRentalDays;

                return new SuccessDataResult<double>(Math.Round(40 / numberOfRentalDays, 2));
            }
            catch (Exception e)
            {
                return new SuccessDataResult<double>(0);
            }
        }
    }
}