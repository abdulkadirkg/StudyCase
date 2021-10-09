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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorSevice;

        public DirectorController(IDirectorService directorSevice)
        {
            _directorSevice = directorSevice;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _directorSevice.GetAll();
            return response(result);
        }
        [HttpGet("Find/Age/Greater")]
        public IActionResult GetByAgeGreaterThan(int t)
        {
            var result = _directorSevice.GetByAgeGreaterThan(t);
            return response(result); 
        }
        [HttpGet("Find/Age/Less")]
        public IActionResult GetByAgeLessThan(int t)
        {
            var result = _directorSevice.GetByAgeLessThan(t);
            return response(result);
        }
        [HttpPost("Save")]
        public IActionResult Save(Director director)
        {
            var result = _directorSevice.Add(director);
            return response(result);
        }
        private IActionResult response(IResult result)
        {
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
