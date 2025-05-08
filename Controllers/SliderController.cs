using Construction_site.Models;
using Construction_site.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Construction_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IRepository<Slider> _sliderRepository;

        public SliderController(IRepository<Slider> slidertRepository)
        {
            _sliderRepository = slidertRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliders()
        {
            var sliders = await _sliderRepository.GetAll();
            return Ok(sliders);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderById(int id)
        {
            var slider = await _sliderRepository.GetById(id);
            return Ok(slider);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddSlider([FromBody] Slider slider)
        {
            await _sliderRepository.Add(slider);
            return Ok();

        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider(int id, [FromBody] Slider slider)
        {
            var existingSlider = await _sliderRepository.GetById(id);
            if (existingSlider == null) return NotFound();

            existingSlider.Title = slider.Title;
            existingSlider.Description = slider.Description;
            existingSlider.ImageUrl = slider.ImageUrl;
            existingSlider.IsActive = slider.IsActive;
            existingSlider.DisplayOrder = slider.DisplayOrder;

            await _sliderRepository.Update(existingSlider);
            return Ok(existingSlider);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _sliderRepository.Delete(id);
            return Ok();
        }
    }
}
