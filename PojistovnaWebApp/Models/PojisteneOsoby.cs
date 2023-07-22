using System.ComponentModel.DataAnnotations;

/*
 * Model pro databázi osob v pojišťovně
*/

namespace PojistovnaWebApp.Models
{
    public class PojisteneOsoby
    {
        public PojisteneOsoby()
        {
            this.SjednanaPojisteni = new HashSet<SjednanaPojisteni>();
        }

        [Key]
        public int IdOsoby { get; set; }
        [Required(ErrorMessage = "Vyplňte jméno")]
        public string Jmeno { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte přijmení")]
        public string Prijmeni { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte email")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte telefon")]
        public string Telefon { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte ulici a číslo popisné")]
        public string Ulice { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte město")]
        public string Mesto { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte PSČ")]
        public string Psc { get; set; } = "";
        public HashSet<SjednanaPojisteni> SjednanaPojisteni { get; }
    }
}
