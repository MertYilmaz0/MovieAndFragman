using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Models.MyList
{
    public class MyList
    {
        static private Dictionary<int, ListItem> myList = new Dictionary<int, ListItem>();
        public List<ListItem> GetAllCartItem => myList.Values.ToList();
        public bool AddCart(ListItem listItem)
        {
            if (myList.ContainsKey(listItem.Id))
            {
                return false;
            }
            myList.Add(listItem.Id, listItem);
            return true;
        }
        
        public void DeleteCart(int id)
        {
            if (myList.ContainsKey(id))
            {
                myList.Remove(id);
            }
        }
        public int Total => myList.Values.Count;
    }
}
