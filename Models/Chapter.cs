using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopCart_CodeFirst.Models
{
    public class Chapter
    {
        [Key] [Display(Name = "Mã Chương")] public int ChapterId { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Tên chương sách")]
        [Display(Name = "Tên Chương")] public string ChapterName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Mô tả ngắn")]
        [Display(Name = "Mô tả Ngắn")] public string ShortContent { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")] public virtual Book Book { get; set; }
    }
}
