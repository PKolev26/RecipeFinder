using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Components
{
    public class MainMenuComponen : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
