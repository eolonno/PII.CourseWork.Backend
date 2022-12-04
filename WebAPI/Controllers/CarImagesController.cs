using System;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = "CarId")] int carId)
        {
            var carImage = new CarImage
            {
                CarId = carId
            };

            var result = _carImageService.Add(file, carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = "Id")] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;

            var result = _carImageService.Delete(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = "Id")] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;
            var result = _carImageService.Update(file, carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _carImageService.Get(Id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        //resmin url'si gönderiliyor.
        [HttpGet("getfilebyid")]
        public IActionResult GetFileById(int id)
        {
            var result = _carImageService.Get(id);

            if (result.Success)
            {
                var path = "wwwroot" + result.Data.ImagePath;
                var b = System.IO.File.ReadAllBytes(path);
                return File(b, "image/png");
            }

            return BadRequest(result);
        }
    }
}