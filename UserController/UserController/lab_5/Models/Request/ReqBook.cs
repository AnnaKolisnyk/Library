using System.ComponentModel.DataAnnotations;

namespace lab_5.Models.Request
{
    public class ReqBook
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CopyAmount { get; set; }
    }
}
