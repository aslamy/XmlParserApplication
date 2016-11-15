using System.ComponentModel.DataAnnotations;

namespace XMLParserApplication.Models.ViewModels
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Comment { get; set; }
    }
}