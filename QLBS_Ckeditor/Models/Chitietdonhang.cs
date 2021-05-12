using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlybansach.Models
{
    [Table("Chitietdonhangs")]
    public class Chitietdonhang
    {
        [Key]

        [DisplayName("Số lượng đơn hàng ")]
        public string soluong { get; set; }

        [DisplayName("Đơn giá")]
        public string dongia { get; set; }

        [DisplayName("Mã đơn hàng ")]

        public string madh { get; set; }

        [DisplayName("Mã sách ")]
        public string masach { get; set; }


        public virtual Donhang Donhang { get; set; }
        public virtual Sach Sach { get; set; }
    }
}