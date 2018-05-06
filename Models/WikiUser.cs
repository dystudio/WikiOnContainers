using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Aiursoft.Pylon.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Aiursoft.Wiki.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public string CollectionTitle { get; set; }
        [InverseProperty(nameof(Article.Collection))]
        public List<Article> Articles { get; set; }
    }
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        [JsonIgnore]
        public string ArticleContent { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [JsonIgnore]
        public int? CollectionId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(CollectionId))]
        public Collection Collection { get; set; }
    }
}
