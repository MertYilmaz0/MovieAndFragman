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
        List<GenreDto> GetGenreLByFragId(int id)
        {
            List<Genre> genres = genreBLL.GetByFragId(id);
            List<GenreDto> dtos = new List<GenreDto>();
            foreach (Genre item in genres)
            {
                dtos.Add(new GenreDto()
                {
                    GenreId = item.ID,
                    Name = item.Name,
                    IsActive=item.IsActive
                   
                });
            }
            return dtos;
        }
        [HttpGet]
        public IActionResult GetGenreListByFragId(int id)
        {
            return Ok(GetGenreLByFragId(id));
        }
        [HttpGet]
        public IActionResult GetAllGenre()
        {
            List<Genre> genres = genreBLL.GetAll().ToList();
            List<GenreDto> genreDtos = new List<GenreDto>();
            foreach (Genre item in genres)
            {
                genreDtos.Add(new GenreDto()
                {
                    GenreId = item.ID,
                    Name = item.Name,
                    IsActive=item.IsActive

                });
            }
            return Ok(genreDtos);
        }



        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreDto genreDto )
        {
            try
            {
                Genre genre = new Genre();
                genre.ID = genreDto.GenreId;
                genre.Name = genreDto.Name;
                genreBLL.Insert(genre);
                return Ok(new { message = "Tür ekleme işlemi gerçekleşti", check = true });
            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }


        [HttpPost]
        public IActionResult UpdateGenre([FromBody] GenreDto genreDto)
        {
            try
            {
                Genre genre = genreBLL.Get(genreDto.GenreId);
                genre.Name = genreDto.Name;
                genre.IsActive = true;
                genreBLL.Update(genre);
                return Ok(new { message = "Güncelleme işlemi gerçekleşti", check = true });
            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }

        [HttpGet("{id}")]
        public IActionResult DeleteGenreById(int id)
        {
            genreBLL.DeleteById(id);
            return Ok(new { message = "Silme işlemi gerçekleşti", check = true });
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            Genre genre = genreBLL.Get(id);
            GenreDto genreDto = new GenreDto() 
            {
                GenreId = genre.ID,
                Name = genre.Name,
                IsActive = genre.IsActive 
            };
            return Ok(genreDto);
            

        }

    }
}
