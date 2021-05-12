using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlybansach.Models
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        [StringLength(100)]
        public string ArticleID { get; set; }

        [StringLength(100)]
        public string Author { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}