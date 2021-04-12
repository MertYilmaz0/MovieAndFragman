using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Models
{
    public class FragmanVM
    {
        public string Namer { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }//afiş
        public int UserID { get; set; }
        public string InitialRelease { get; set; }// ilk gösterim
        public string Director { get; set; } //Yönetmen
        public string Production { get; set; } // Yapımcı
        public float IMDB { get; set; }
    }
}
