using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlybansach.Models
{
    [Table("Tacgias")]
    public class Tacgia
    {
        [Key]
        [DisplayName(" Mã tác giả ")]
        public string matacgia { get; set; }

        [DisplayName(" Tên tác giả  ")]
        public string tentacgia { get; set; }

        [DisplayName("Địa chỉ tác giả  ")]
        public string diachi { get; set; }

        [DisplayName(" Số điện thoại ")]
        [MaxLength(15)]
        public string dienthoai { get; set; }

    }
}