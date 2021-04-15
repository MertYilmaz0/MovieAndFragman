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
    public class UrlController : ControllerBase
    {
        IUrlBLL urlBLL;
        public UrlController(IUrlBLL bLL)
        {
            urlBLL = bLL;
        }
        [HttpGet]
        public IActionResult GetUrlByFragId(int id)
        {
            List<Url> urls = urlBLL.GetListByFragId(id).ToList();
            List<UrlDto> dtos = new List<UrlDto>();
            foreach (Url item in urls)
            {
                dtos.Add(new UrlDto()
                {
                    UrlId = item.ID,
                    UrlPath = item.UrlPath,
                    LanguageID = item.LanguageID,
                    Language = item.Language.LanguageName
                });
            }
            return Ok(dtos);
        }
    }
}
