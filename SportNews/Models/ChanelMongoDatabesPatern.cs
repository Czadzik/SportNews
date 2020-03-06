using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace SportNews.Models
{
   

public class Enclosure
    {
        public string url { get; set; }
        public string length { get; set; }
        public string type { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public string guid { get; set; }
        public IList<Enclosure> enclosure { get; set; }
    }

    public class ChanelMongoDatabesPatern
    {
        public ObjectId _id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string copyright { get; set; }
        public string lastBuildDate { get; set; }
        public IList<Item> item { get; set; }
    }



}
