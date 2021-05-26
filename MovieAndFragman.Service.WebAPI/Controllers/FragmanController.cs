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
            try
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
                        Poster = item.Poster,
                        SmallPoster = item.SmallPoster,
                        MediumPoster = item.MediumPoster,
                        //Documents = item.Documents.ToList()
                        
                    };

                    dtos.Add(added);
                }
                return Ok(dtos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
                    Poster = item.Poster,
                    MediumPoster = item.MediumPoster,
                    SmallPoster = item.SmallPoster,
                    //Documents = item.Documents.ToList()

                });
            }

            return fragmanDtos;
        }

        //Fragman ConvertFragman(AddFragmanDTO addFragmanDTO)
        //{
        //    Fragman fragman = new Fragman()
        //    {
        //        ID = addFragmanDTO.FragID,
        //        CreatedDate = DateTime.Now,
        //        Name = addFragmanDTO.Name,
        //        CounterDisLike = addFragmanDTO.CounterDisLike,
        //        CounterLike = addFragmanDTO.CounterLike,
        //        CounterView = addFragmanDTO.CounterView,
        //        Description = addFragmanDTO.Description,
        //        Documents = addFragmanDTO.Documents,
        //        IsActive = true,
        //        Poster = addFragmanDTO.Poster,
        //        MediumPoster = addFragmanDTO.MediumPoster,
        //        SmallPoster = addFragmanDTO.SmallPoster,

        //    };
        //}

        [HttpPost]
        public IActionResult AddFragman([FromBody] AddFragmanDTO addfragmanDto)
        {
            try
            {
                Fragman fragman = new Fragman();
                fragman.Name = addfragmanDto.Name;
                fragman.Description = addfragmanDto.Description;
                fragman.Poster = addfragmanDto.Poster;
                fragman.SmallPoster = addfragmanDto.SmallPoster;
                fragman.MediumPoster = addfragmanDto.MediumPoster;
                //fragman.Documents = addfragmanDto.Documents;
                fragman.CounterLike = 0;
                fragman.CounterDisLike = 0;
                fragman.CounterView = 0;
                fragman.Ratio = 0;
                fragmanBLL.Insert(fragman);

                List<Url> urls = new List<Url>();

                foreach (UrlDto item in addfragmanDto.UrlDto)
                {
                    urls.Add(new Url { ID = item.UrlId, FragmanID = fragman.ID, LanguageID = item.LanguageID, UrlPath = item.UrlPath });
                }
                List<Genre> genres = new List<Genre>();
                foreach (GenreDto item in addfragmanDto.GenreDtos)
                {
                    genres.Add(new Genre { ID = item.GenreId, Name = item.Name });
                }

                fragmanBLL.Update(fragman);

                return Ok(new { message = "Tür ekleme işlemi gerçekleşti", check = true });

            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }

        public IActionResult GetAllFragman()
        {
            try
            {
                List<FragmanDto> fragmans = FragmanDTOList(fragmanBLL.GetAll());
                return Ok(fragmans);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IActionResult Get(int id)
        {
            try
            {
                Fragman fragman = fragmanBLL.Get(id);
                if (fragman != null)
                {
                    FragmanDto dto = new FragmanDto()
                    {
                        FragID = fragman.ID,
                        Description = fragman.Description,
                        Name = fragman.Name,
                        Poster = fragman.Poster,
                        SmallPoster=fragman.SmallPoster,
                        MediumPoster=fragman.MediumPoster
                    };
                    dto.FirstUrl = fragman.Urls.First().UrlPath;
                    return Ok(dto);
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetByGenreId(int id)
        {
            try
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
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            try
            {
                List<Fragman> fragmans = fragmanBLL.GetByName(name).ToList();
                return Ok(FragmanDTOList(fragmans));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult GetFragRating(int id)
        {
            try
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
            catch (Exception)
            {
                return BadRequest();
            }
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
            try
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
                        Ratio = item.Ratio,
                        CounterView = item.CounterView
                    });
                }
                return Ok(dtos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
