using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlybansach.Models
{
    [Table("Donhangs")]
    public class Donhang
    {

        [Key]
        [DisplayName("Mã đơn hàng ")]
        public string madh { get; set; }

        [DisplayName("Tình trạng đơn hàng")]
        public string tinhtrangdonhang { get; set; }

        [DisplayName("Ngày đặt hàng ")]
        public string ngaydat { get; set; }

        [DisplayName("Ngày giao hàng ")]
        public string ngaygiao { get; set; }

        public virtual Khachhang Khachhang { get; set; }

       [DisplayName("Mã khách hàng ")]
        public string makh { get; set; }


        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }

    }
}