using MovieAndFragman.UI.CoreMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Helper
{
    public class ApiJsonHelper<EntityVM>
    {
        public static EntityVM GetApiEntity(string method)
        {
            string jsonAlbum = HttpService<EntityVM>.Get(method).Result;
            return JsonConvert.DeserializeObject<EntityVM>(jsonAlbum);
        }
        public static List<EntityVM> GetApiEntityList(string method)
        {
            string jsonAlbum = HttpService<EntityVM>.Get(method).Result;
            return JsonConvert.DeserializeObject<List<EntityVM>>(jsonAlbum);
        }
        public static PostVM PostApiEntity(string method, EntityVM entityVM)
        {
            string jsonAlbum = HttpService<EntityVM>.Post(method, entityVM).Result;
            return JsonConvert.DeserializeObject<PostVM>(jsonAlbum);
        }        
    }
}
