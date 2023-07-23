using System.ComponentModel.DataAnnotations;

/*
 * Model pro databázi osob v pojišťovně
*/

namespace PojistovnaWebApp.Models
{
    public class PojisteneOsoby
    {
        [Key]
        public int IdOsoby { get; set; }
        [Required(ErrorMessage = "Vyplňte jméno")]
        public string Jmeno { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte přijmení")]
        public string Prijmeni { get; set; } = "";
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Zadejte platnou e-mailovou adresu.")]
        [Required(ErrorMessage = "Vyplňte email")]
        public string Email { get; set; } = "";
        [RegularExpression(@"^\d{3}\s\d{3}\s\d{3}$|^\d{9}$", ErrorMessage = "Telefonní číslo musí mít formát XXX XXX XXX nebo XXXXXXXXX.")]
        [Required(ErrorMessage = "Vyplňte telefon")]
        public string Telefon { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte ulici a číslo popisné")]
        public string Ulice { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte město")]
        public string Mesto { get; set; } = "";
        [RegularExpression(@"^\d{5}$|^\d{3}\s\d{2}$", ErrorMessage = "PSČ musí být ve formátu XXXXX nebo XXX XX.")]
        [Required(ErrorMessage = "Vyplňte PSČ")]
        public string Psc { get; set; } = "";

    }
}
