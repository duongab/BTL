using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlybansach.Models
{
    [Table("Khachhangs")]
    public class Khachhang
    {
        [Key]
        [DisplayName("Mã khách hàng ")]
        public string makh { get; set; }

        [DisplayName("Tên khách hàng")]
        public string tenkh { get; set; }

        [DisplayName("Tài khoản khách hàng ")]
        public string taikhoan { get; set; }

        [DisplayName("Mật khẩu ")]
        public string matkhau { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Địa chỉ khách hàng ")]
        public string diachi { get; set; }

        [DisplayName("Điện thoại ")]
        [MaxLength(15)]
        public string dienthoai { get; set; }


        public virtual ICollection<Donhang> Donhangs { get; set; }

    }
}