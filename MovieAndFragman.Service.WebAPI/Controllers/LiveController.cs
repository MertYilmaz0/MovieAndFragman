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
    public class LiveController : ControllerBase
    {
        ILiveBLL liveBLL;
        public LiveController(ILiveBLL bLL)
        {
            liveBLL = bLL;
        }

        LiveDto ConvertDto(Live live)
        {
            LiveDto dto = new LiveDto()
            {
                LiveID = live.ID,
                BroadcastPath = live.BroadcastPath,
                ImageLPath = live.ImageLPath,
                ImagePath = live.ImagePath,
                ImageSPath = live.ImageSPath,
                Name = live.Name
            };
            return dto;
        }

        List<LiveDto> ConvertDtoList(List<Live> liveList)
        {
            List<LiveDto> liveDtos = new List<LiveDto>();
            foreach (Live item in liveList)
            {
                liveDtos.Add(new LiveDto()
                {
                    LiveID = item.ID,
                    BroadcastPath = item.BroadcastPath,
                    ImageLPath = item.ImageLPath,
                    ImagePath = item.ImagePath,
                    ImageSPath = item.ImageSPath,
                    Name = item.Name
                });
            }
            return liveDtos;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                Live live = liveBLL.Get(id);
                LiveDto dto = ConvertDto(live);
                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Live> liveList = liveBLL.GetAll().ToList();
                List<LiveDto> dtoList = ConvertDtoList(liveList);
                return Ok(dtoList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Update(string path)
        {
            try
            {
                Live live = liveBLL.Get(4);
                live.BroadcastPath = path;
                liveBLL.Update(live);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
