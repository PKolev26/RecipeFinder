using RecipeFinder.Core.Models.AdminModels;

namespace RecipeFinder.Core.Contracts.Admin
{
    public interface IAdminService
    {
        Task<AdminPanelServiceModel> PanelInformationAsync();
    }
}
