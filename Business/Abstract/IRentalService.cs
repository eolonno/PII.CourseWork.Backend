using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<Rental> GetById(int Id);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Cancel(Rental rental);

        IResult Update(Rental rental);

        //IResult CheckReturnDateByCarId(int carId);    //=>rentalmanager
        IResult IsRentable(Rental rental);
    }
}