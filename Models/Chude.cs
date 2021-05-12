using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlybansach.Models
{
    [Table("Chudes")]
    public class Chude
    {
        [Key]
        [DisplayName("Mã chủ đề ")]
        public string machude { get; set; }

        [DisplayName("Tên chủ đề")]
        public string tenchude { get; set; }

        public virtual ICollection<Sach> Sachs { get; set; }
        public HashSet<Chude> Chudes { get; }

    }
}