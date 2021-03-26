using System.ComponentModel.DataAnnotations;

namespace EntityPizza.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }
    }
}