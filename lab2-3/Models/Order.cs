using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookShop.Models
{
    public class Order
    {
        [BindNever]
        public int ID { get; set; }
        
        [Display(Name = "Имя")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не должна превышать 10-ти символов")]
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина фамилии не должна превышать 10-ти символов")]
        public string Surname { get; set; }
        
        [Display(Name = "Адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина адреса не должна превышать 20-ти символов")]
        public string Adress { get; set; }
        
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [Required(ErrorMessage = "Длина номера не должна превышать 11-ти цифр")]
        public string Phone { get; set; }
        
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина E-mail не должна превышать 30-ти символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
