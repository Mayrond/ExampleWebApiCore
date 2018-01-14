using System.ComponentModel.DataAnnotations;
using ExampleWebApiCore.Models.General;

namespace ExampleWebApiCore.Models
{
    public class Good : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}