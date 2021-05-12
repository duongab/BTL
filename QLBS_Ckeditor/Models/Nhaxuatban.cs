using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlybansach.Models
{

    [Table("Nhaxuatbans")]
    public class Nhaxuatban
    {
        [Key]

        [DisplayName("Mã nhà xuất bản")]
        public string manxb { get; set; }

        [DisplayName("Tên nhà xuất bản ")]
        public string tennxb { get; set; }

        [DisplayName("Địa chỉ nhà xuất bản")]
        public string diachi { get; set; }

        [DisplayName("Điện thoại ")]
        [MaxLength(15)]
        public string dienthoai { get; set; }

        public virtual ICollection<Sach> Sachs { get; set; }

    }
}