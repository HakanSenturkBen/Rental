using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal claimDal;
        public UserOperationClaimManager(IUserOperationClaimDal _claimDal)
        {
            claimDal = _claimDal;
        }

        public IResult Add(UserOperationClaim claim)
        {
            claimDal.Add(claim);
            return new SuccessResult("işlem yapma hakları" + claim.OperationClaimId + "olarak" + Messages.Updated);
        }
    }
}
