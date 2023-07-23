using System.ComponentModel.DataAnnotations;
/*
 * Model pro databázi seznamu pojištění, které pojišťovna nabízí.
*/
namespace PojistovnaWebApp.Models
{
    public class SeznamPojisteni
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vyplňte nazev pojištění")]
        public string NazevPojisteni { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte perex pojištění")]
        public string Perex { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popis pojištění")]
        public string Popis { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte cenu pojištění")]
        public string Cena { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte datum začátku pojištění")]
        public string PojisteniOd { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte datum konce pojištění")]
        public string PojisteniDo { get; set; } = "";

    }
}
