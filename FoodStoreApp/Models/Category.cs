using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace FoodStoreApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string? Title { get; set; }
        [DisplayName("Описание")]
        public string? Description { get; set; }
        [DisplayName("Рейтинг")]
        [Required(ErrorMessage ="Поле не может быть пустым")]
        [Range(1,int.MaxValue,ErrorMessage ="Значение должно быть больше нуля")]
        public string Raiting { get; set; }

    }
}
