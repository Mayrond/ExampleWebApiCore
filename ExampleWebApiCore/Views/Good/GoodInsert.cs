using System.ComponentModel.DataAnnotations;

namespace ExampleWebApiCore.Views.Good
{
    public class GoodInsert
    {
        [Required]
        public string Name { get; set; }
    }
}