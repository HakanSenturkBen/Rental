using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}
