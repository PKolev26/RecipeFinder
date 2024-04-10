using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.AdminModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Admin
{
    public interface IAdminService
    {
        Task<AdminPanelServiceModel> PanelInformationAsync();
    }
}
