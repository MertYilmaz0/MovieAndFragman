using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Helper
{
    public class PostHelper<InEntity,OutEntity>
    {
        public static OutEntity PostApiEntity(string method, InEntity entityVM)
        {
            string jsonAlbum = HttpService<InEntity>.Post(method, entityVM).Result;
            return JsonConvert.DeserializeObject<OutEntity>(jsonAlbum);
        }
    }
}
