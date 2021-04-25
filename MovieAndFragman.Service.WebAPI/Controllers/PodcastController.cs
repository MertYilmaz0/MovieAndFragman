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
    public class PodcastController : ControllerBase
    {
        IPodcastBLL podcastBLL;
        public PodcastController(IPodcastBLL bLL)
        {
            podcastBLL = bLL;
        }

        PodcastDto ConvertDto(Podcast podcast)
        {
            PodcastDto dto = new PodcastDto()
            {
                PodcastID = podcast.ID,
                BroadcastPath = podcast.BroadcastPath,
                ImageLPath = podcast.ImageLPath,
                ImagePath = podcast.ImagePath,
                ImageSPath = podcast.ImageSPath,
                Name = podcast.Name
            };
            return dto;
        }

        List<PodcastDto> ConvertDtoList(List<Podcast> podList)
        {
            List<PodcastDto> podDtos = new List<PodcastDto>();
            foreach (Podcast item in podList)
            {
                podDtos.Add(new PodcastDto()
                {
                    PodcastID = item.ID,
                    BroadcastPath = item.BroadcastPath,
                    ImageLPath = item.ImageLPath,
                    ImagePath = item.ImagePath,
                    ImageSPath = item.ImageSPath,
                    Name = item.Name
                });
            }
            return podDtos;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                Podcast podcast = podcastBLL.Get(id);
                PodcastDto dto = ConvertDto(podcast);
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
                List<Podcast> podList = podcastBLL.GetAll().ToList();
                List<PodcastDto> dtoList = ConvertDtoList(podList);
                return Ok(dtoList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
