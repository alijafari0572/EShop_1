using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels.Product
{
    public class AddProduct_ViewModel
    {
        [Required(ErrorMessage = "{0} را درست وارد کنید")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0} را درست وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} را درست وارد کنید")]
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Required(ErrorMessage = "{0} را درست وارد کنید")]
        [Display(Name = "تعداد")]
        public int Number { get; set; }
    }
}
