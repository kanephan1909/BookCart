using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopCart_CodeFirst.Models
{
        public class Book
        {
            [Key]
            [Display(Name = "Mã Sách")] public int BookId { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập tiêu để")]
            [Display(Name = "Tiêu Đề Sách")] public string Title { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập tên tác giả")]
            [Display(Name = "Tên Tác Giả")] public string AuthorName { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập giá tiền")]
            [Display(Name = "Đơn Giả")]
            [Range(0, float.MaxValue, ErrorMessage = "Giá tiền phải là số >= 0")] public float Price { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập năm xuất bản")]
            [Display(Name = "Năm Xuất Bản")]
            [Range(0, int.MaxValue, ErrorMessage = "Năm xuất bản phải là số >= 0")] public int Year { get; set; }
            [Display(Name = "Bìa Sách")] public string CoverPage { get; set; }
            [NotMapped] public HttpPostedFileBase ImageFile { get; set; }
            public virtual List<Chapter> Chapters { get; set; }
        }
}