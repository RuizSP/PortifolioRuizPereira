using System.ComponentModel.DataAnnotations;

namespace PortifolioRuizPereira.Models
{
    public class Projeto
    {
        public required int ID { get; set; }
        public  required string Name { get; set; }
        public required string Description { get; set; }
        public required string Path { get; set; }
        public  List<string>? imagePaths { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; } = default(DateTime?);
    }
}
