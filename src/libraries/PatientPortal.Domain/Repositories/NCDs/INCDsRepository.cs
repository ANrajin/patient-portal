using PatientPortal.Domain.BusinessObjects;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.NCDs
{
    public interface INCDsRepository
    {
        Task<IReadOnlyCollection<NCD>> GetAllAsync
            (CancellationToken cancellationToken = default);

        Task<IList<SelectListItemsBO>> GetSelectListItemsAsync();
    }
}
