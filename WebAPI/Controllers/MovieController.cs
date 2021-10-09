using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result = _movieService.GetAll();
            return response(result);
        }

        [HttpPost("Save")]
        public IActionResult Save(Movie movie) 
        {
            var result = _movieService.Add(movie);
            return response(result);
        }

        [HttpGet("Find/YearMonth")]
        public IActionResult FindByMonthAndYear(int y, int m)
        {
            var result = _movieService.GetByYearAndMonth(y, m);
            return response(result);
        }

        [HttpGet("Find/Year")]
        public IActionResult FindByYear(int y)
        {
            var result = _movieService.GetByYear(y);
            return response(result);
        }

        [HttpGet("Find/Director")]
        public IActionResult FindByDirector(int id)
        {
            var result = _movieService.GetByDirectorId(id);
            return response(result);
        }

        private IActionResult response(IResult result) 
        {
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
