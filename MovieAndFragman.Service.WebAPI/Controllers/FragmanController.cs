using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.Model.Entities;
using MovieAndFragman.Service.WebAPI.Attributes;
using MovieAndFragman.Service.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class FragmanController : ControllerBase
    {
        IFragmanBLL fragmanBLL;
        public FragmanController(IFragmanBLL bLL)
        {
            fragmanBLL = bLL;
        }
        [HttpGet]
        public IActionResult GetLastThirdFragman()
        {
            List<Fragman> fragmans = fragmanBLL.GetLastThirdFragman().ToList();
            List<FragmanDto> dtos = new List<FragmanDto>();

            foreach (Fragman item in fragmans)
            {
                FragmanDto added =new FragmanDto()
                {
                    FragID = item.ID,
                    Description = item.Description,
                    Name = item.Name,
                    Poster = item.Poster
                };                
                dtos.Add(added);
            }
            return Ok(dtos);
        }
    }
}
