using PatientPortal.Domain.BusinessObjects;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.Allergies
{
    public interface IAllergiesRepository
    {
        Task<IReadOnlyCollection<Allergy>> GetAllAsync
            (CancellationToken cancellationToken = default);

        Task<IList<SelectListItemsBO>> GetSelectListItemsAsync();
    }
}
