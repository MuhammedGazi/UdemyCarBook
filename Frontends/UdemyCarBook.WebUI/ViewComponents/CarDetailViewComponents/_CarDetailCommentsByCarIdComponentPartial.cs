using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.ReviewDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value =await _apiService.GetApiAsync<List<ResultReviewByCarIddTO>>("https://localhost:7243/api/Review?id="+id);
            return View(value);
        }
    }
}
