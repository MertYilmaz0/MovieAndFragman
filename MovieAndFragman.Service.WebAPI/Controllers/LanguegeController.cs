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
    public class LanguegeController : ControllerBase
    {
        ILanguageBLL languageBLL;

        public LanguegeController(ILanguageBLL bll)
        {
            languageBLL = bll;
        }

        List<LanguageDto> LanguageDtoList(ICollection<Language> listlanguages)
        {
            List<LanguageDto> languages = new List<LanguageDto>();
            foreach (Language item in listlanguages)
            {
                languages.Add(new LanguageDto()
                {
                    LanguageID = item.ID,
                    LanguageName = item.LanguageName,
                    Description = item.Description,
                    IsActive = item.IsActive


                }) ;
            }
            return languages;
        }
        [HttpGet]
        public IActionResult GetAllLanguage()
        {
            List<LanguageDto> languages = LanguageDtoList(languageBLL.GetAll());
            return Ok(languages);
        }
        [HttpGet]
        public IActionResult GetLanguageActive()
        {
            List<LanguageDto> languages = LanguageDtoList(languageBLL.GetAllActive());
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public IActionResult GetLanguageById(int id)
        {
            Language language = languageBLL.Get(id);
            LanguageDto languageDto = new LanguageDto();
            languageDto.LanguageID = language.ID;
            languageDto.LanguageName = language.LanguageName;
            languageDto.Description = language.Description;
            return Ok(languageDto);

        }

        void NameControl(string languageName)
        {
            ICollection<Language> languages = languageBLL.GetAll();
            foreach (Language item in languages)
            {
                if (item.LanguageName == languageName)
                {
                    throw new Exception($"{item.LanguageName} kayıtlarda bu isimde dil bulunmaktadır.");
                }
            }
        }

        [HttpPost]
        public IActionResult AddLanguage([FromBody] LanguageDto languageDto)
        {
            try
            {
                NameControl(languageDto.LanguageName);
                Language language = new Language();
                language.ID = languageDto.LanguageID;
                language.LanguageName = languageDto.LanguageName;
                language.Description = languageDto.Description;
                language.IsActive = true;
                languageBLL.Insert(language);
                return Ok(new { message = "Dil ekleme işlemi gerçekleşti", check = true });
            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }

        }

        [HttpPost]
        public IActionResult UpdateLanguage([FromBody] LanguageDto languageDto)
        {
            try
            {
                Language language = languageBLL.Get(languageDto.LanguageID);
                language.LanguageName = languageDto.LanguageName;
                language.Description = languageDto.Description;
                language.IsActive = true;
                languageBLL.Update(language);
                return Ok(new { message = "Dil güncelleme işlemi gerçekleşti", check = true });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message, check = false });
            }
        }

        [HttpGet("{id}")]
        public IActionResult DeleteLanguageById(int id)
        {
            languageBLL.DeleteById(id);
            return Ok(new { message = "Dil silme işlemi gerçekleşti", check = true });

        }

       


    }
}
