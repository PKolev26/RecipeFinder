using Microsoft.AspNetCore.Identity;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Home
{
    public interface IHomeService
    {
        Task<bool> UserHasUnfinishedRecipeAsync(ApplicationUser user);
    }
}
