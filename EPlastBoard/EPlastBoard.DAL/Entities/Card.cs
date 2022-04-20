using System.ComponentModel.DataAnnotations;

namespace EPlastBoard.DAL.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(220)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [MaxLength(1000)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public int ColumnId { get; set; }

        public Column Column { get; set; }

    }
}
