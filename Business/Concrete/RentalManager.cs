using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly ICarService _carService;
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _carService = carService;
            _rentalDal = rentalDal;
        }

        [SecuredOperation("user,rental.add,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("rental.delete,moderator,admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Cancel(Rental rental)
        {
            _rentalDal.CancelRental(rental.Id);
            return new SuccessResult(Messages.RentalCanceled);
        }

        [SecuredOperation("rental.update,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r =>
                    r.RentEndDate >= rental.RentStartDate &&
                    r.RentStartDate <= rental.RentEndDate
                )) return new ErrorResult(Messages.RentalNotAvailable);

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }
    }
}