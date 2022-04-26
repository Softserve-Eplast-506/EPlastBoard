using System.ComponentModel.DataAnnotations;

namespace EPlastBoard.DAL.Entities
{
    public class Column
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(220)]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        public int BoardId { get; set; }

        public ICollection<Card>? Cards { get; set; }

        public Board Board { get; set; }
    }
}
