using System.ComponentModel.DataAnnotations;

namespace CarrosAPI.DTOs
{
    public class UpdateCarroDTO
    {
        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        [Range(1970, 2022, ErrorMessage = "O ano deve ser entre 1970 e 2022")]
        public int Ano { get; set; }
    }
}
