using Business.Abstract;
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

        public void Add(Company company)
        {
            companyDal.Add(company);
        }

        public void Delete(Company company)
        {
            companyDal.Delete(company);
        }

        public void Update(Company company)
        {
            companyDal.Update(company);
        }
    }
}
