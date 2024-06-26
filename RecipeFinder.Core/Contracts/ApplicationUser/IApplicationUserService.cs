﻿using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.ApplicationUserModels;

namespace RecipeFinder.Core.Contracts.User
{
    public interface IApplicationUserService
    {
        Task<UserQueryServiceModel> AllUsersAsync(
            string? id = null,
            string? firstName = null,
            string? lastName = null,
            UserSorting sorting = UserSorting.EmailDescending,
            int currentPage = 1,
            int usersPerPage = 1);

        Task<UsersDetailsServiceModel> UserDetailsAsync(string id);

        Task PromoteUserAsync(string id);

        Task DemoteUserAsync(string id);

        Task DeleteAsync(string userId);

        Task<bool> ExistsAsync(string id);

        Task<bool> IsAdminAsync(string id);
    }
}
