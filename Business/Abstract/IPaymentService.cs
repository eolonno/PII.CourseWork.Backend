using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Payment();
        IDataResult<double> GetDiscount(int userId);
    }
}