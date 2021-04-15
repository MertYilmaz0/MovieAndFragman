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
    public class GenreController : ControllerBase
    {
        IGenreBLL genreBLL;
        public GenreController(IGenreBLL bLL)
        {
            genreBLL = bLL;
        }
        List<GenreDto> GetGenreByFragId(int id)
        {
            List<Genre> genres = genreBLL.GetByFragId(id);
            List<GenreDto> dtos = new List<GenreDto>();
            foreach (Genre item in genres)
            {
                dtos.Add(new GenreDto()
                {
                    GenreId = item.ID,
                    Name = item.Name
                });
            }
            return dtos;
        }
    }
}
