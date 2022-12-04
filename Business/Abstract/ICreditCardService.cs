using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> GetById(int id);

        IDataResult<List<CreditCard>> GetAllByUserId(int userId);

        IResult Add(CreditCard creditCard);

        IResult Delete(CreditCard creditCard);
    }
}