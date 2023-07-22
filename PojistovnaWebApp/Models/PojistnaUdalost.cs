using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

/*
 * Model pro databázi pojistných událostí v mojí aplikaci pojišťovny
*/
namespace PojistovnaWebApp.Models
{
    public class PojistnaUdalost
    {
        [Display(Name = "Číslo pojistné události")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Povinný údaj")]
        [Display(Name = "Stručný popis události")]
        public string Popis { get; set; }
        [Required(ErrorMessage = "Povinný údaj")]
        [Display(Name = "Datum a čas události")]
        [DataType(DataType.Date)]
        public DateTime DatumUdalosti { get; set; }
        [Required(ErrorMessage = "Povinný údaj")]
        [Display(Name = "Pojistné plnění")]
        public int Plneni { get; set; }
        [Required(ErrorMessage = "Povinný údaj")]
        [Display(Name = "Číslo pojištěnce")]
        public int PojisteneOsobyId { get; set; }
        [Required(ErrorMessage = "Povinný údaj")]
        [Display(Name = "Číslo pojistné smlouvy")]
        public int SjednanaPojisteniId { get; set; }

        // Přístup ke kolekci SjednanaPojisteni
        public virtual SjednanaPojisteni? SjednanaPojisteni { get; set; }

        // Přístup ke kolekci PojisteneOsoby
        public virtual PojisteneOsoby? PojisteneOsoby { get; set; }
    }
}
