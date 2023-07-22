using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PojistovnaWebApp.Models
{
    public class SjednanaPojisteni
    {
        public int Id { get; internal set; }
        public int PojistnaCastka { get; internal set; }
    }
}
