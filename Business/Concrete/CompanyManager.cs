using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal companyDal;

        public CompanyManager(ICompanyDal _companyDal)
        {
            companyDal = _companyDal;
        }

        public IResult Add(Company company)
        {
            companyDal.Add(company);
            return new SuccessResult(company.Id.ToString());
        }

        public IResult Delete(Company company)
        {
            companyDal.Delete(company);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Company company)
        {
            companyDal.Update(company);
            return new SuccessResult(Messages.Updated);
        }
    }
}
