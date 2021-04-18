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
                FragmanDto added = new FragmanDto()
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

        List<FragmanDto> FragmanDTOList(ICollection<Fragman> listFragman)
        {
            List<FragmanDto> fragmanDtos = new List<FragmanDto>();
            foreach (Fragman item in listFragman)
            {
                fragmanDtos.Add(new FragmanDto()
                {
                    FragID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    Poster = item.Poster
                });
            }

            return fragmanDtos;
        }

        public IActionResult GetAllFragman()
        {
            List<FragmanDto> fragmans = FragmanDTOList(fragmanBLL.GetAll());
            return Ok(fragmans);
        }
        public IActionResult Get(int id)
        {
            Fragman fragman = fragmanBLL.Get(id);
            if (fragman != null)
            {
                FragmanDto dto = new FragmanDto()
                {
                    FragID = fragman.ID,
                    Description = fragman.Description,
                    Name = fragman.Name,
                    Poster = fragman.Poster
                };
                return Ok(dto);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetByGenreId(int id)
        {
            List<Fragman> fragmans = fragmanBLL.GetAll().ToList();
            List<Fragman> sended = new List<Fragman>();
            List<FragmanDto> dtos = new List<FragmanDto>();
            foreach (Fragman frag in fragmans)
            {
                bool check = false;
                foreach (GenreFragman genre in frag.GenreFragmens)
                {
                    if (genre.GenreID == id)
                    {
                        check = true;
                    }
                }
                if (check)
                {
                    sended.Add(frag);
                }
            }
            return Ok(FragmanDTOList(sended));
        }
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            List<Fragman> fragmans = fragmanBLL.GetByName(name).ToList();
            return Ok(FragmanDTOList(fragmans));
        }
        [HttpGet]
        public IActionResult GetFragRating(int id)
        {
            Fragman fragman = fragmanBLL.Get(id);
            RatingDto dto = new RatingDto()
            {
                CounterDislike = fragman.CounterDisLike,
                CounterLike = fragman.CounterLike,
                Ratio = fragman.Ratio
            };
            
            return Ok(dto);
        }
        [HttpGet]
        public IActionResult UpdateRating(int fid,int uid,char token)
        {
            try
            {
                fragmanBLL.UpdateRating(fid, uid, token);
                return Ok(new { check = true, message = "Oyladığınız için teşekkür ederiz." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult AddRating(int fid,int uid)
        {
            try
            {
                fragmanBLL.AddRating(fid, uid);
                return Ok(new { check = true });
            }
            catch (Exception ex)
            {
                return Ok(new { check = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllListForAdmin()
        {
            List<Fragman> fragmans = fragmanBLL.GetAll().ToList();
            List<FragmanForAdminDto> dtos = new List<FragmanForAdminDto>();
            foreach (Fragman item in fragmans)
            {
                dtos.Add(new FragmanForAdminDto()
                {
                    CounterDisLike = item.CounterDisLike,
                    CounterLike = item.CounterLike,
                    Description = item.Description,
                    Name = item.Name,
                    Ratio = item.Ratio
                });
            }
            return Ok(dtos);
        }
    }
}
