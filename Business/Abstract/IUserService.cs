using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int Id);
        IDataResult<UserDetailDto> GetUserDetailDtoByUserId(int id);
        IDataResult<User> GetByMail(string userMail);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate);
        IResult ToggleUserStatus(int userId);
    }
}