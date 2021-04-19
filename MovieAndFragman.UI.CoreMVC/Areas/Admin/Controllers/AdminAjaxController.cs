using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Areas.Admin.Models;
using MovieAndFragman.UI.CoreMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAjaxController : Controller
    {
        [HttpGet]
        public IActionResult GetGenreList()
        {
            List<GenreVM> vms = ApiJsonHelper<GenreVM>.GetApiEntityList("Genre/GetAllGenre");
            return PartialView("_genreList", vms);
        }
        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreVM genre)
        {
            try
            {
                ApiJsonHelper<GenreVM>.PostApi("Genre/AddGenre", genre);
                return Ok(new { check = true, message = "Tür eklendi." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = true, message = ex.Message });
            }
        }
        public IActionResult UpdateGenre(int id,string name)
        {
            try
            {
                ApiJsonHelper<GenreVM>.GetApi("Genre/UpdateGenre?id=" +id+ "&name=" + name);
                return Ok(new { check = true, message = "Tür güncellendi." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = true, message = ex.Message });
            }
        }
        public IActionResult DeleteGenreById(int id)
        {
            try
            {
                ApiJsonHelper<GenreVM>.GetApi("Genre/DeleteGenreById/" + id);
                return Ok(new { check = true, message = "Tür silindi." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = true, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllLanguage()
        {
            List<LanguageVM> vms = ApiJsonHelper<LanguageVM>.GetApiEntityList("Languege/GetAllLanguage");
            return PartialView("_languageList", vms);
        }
        [HttpGet]
        public IActionResult AddLanguage(int id, string name, string description)
        {
            try
            {
                ApiJsonHelper<LanguageVM>.GetApi("Languege/AddLanguage?id=" +id + "&name=" + name + "&description=" + description);
                return Ok(new { check = true, message = "Dil eklendi." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = true, message = ex.Message });
            }
        }
        public IActionResult DeleteLanguageById(int id)
        {
            try
            {
                ApiJsonHelper<LanguageVM>.GetApi("Languege/DeleteLanguageById?id=" + id);
                return Ok(new { check = true, message = "Tür silindi." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = true, message = ex.Message });
            }
        }
        public IActionResult UpdateLanguage(int id, string name,string description)
        {
            try
            {
                ApiJsonHelper<LanguageVM>.GetApi("Languege/UpdateLanguage?id=" + id + "&name=" + name + "&description=" + description);
                return Ok(new { check = true, message = "Tür güncellendi." });
            }
            catch (Exception ex)
            {
                return Ok(new { check = true, message = ex.Message });
            }
        }
    }
}
