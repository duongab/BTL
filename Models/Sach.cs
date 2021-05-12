using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlybansach.Models
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        [DisplayName("Mã sách ")]
        public string masach { get; set; }

        [DisplayName("Tên sách ")]
        public string tensach { get; set; }

        [DisplayName("Gía bán ")]
        [Column(TypeName = "numeric")]
        public decimal? giaban { get; set; }

        [DisplayName("Mô tả ")]
        [AllowHtml]
        public string mota { get; set; }

        [DisplayName("Ảnh bìa")]
        [StringLength(50)]
        [AllowHtml]
        public string anhbia { get; set; }

        [DisplayName("Ngày cập nhật ")]
        public DateTime? ngaycapnhat { get; set; }

        [DisplayName(" Số lượng tồn")]
        public string soluongton { get; set; }

        [DisplayName("Mã chủ đề ")]
        public string machude { get; set; }

        [DisplayName("Mã nhà xuất bản ")]
        public string manxb { get; set; }

        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
       public virtual Nhaxuatban Nhaxuatban { get; set; }
        public virtual Chude Chude { get; set; }

    }
}