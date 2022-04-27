using System.ComponentModel.DataAnnotations;

namespace EPlastBoard.DAL.Entities
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(220)]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        public ICollection<Column>? Columns { get; set; }
    }
}
