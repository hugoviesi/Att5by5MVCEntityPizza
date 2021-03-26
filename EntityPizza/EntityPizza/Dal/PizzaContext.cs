using EntityPizza.Models;
using System.Data.Entity;

namespace EntityPizza.Dal
{
    public class PizzaContext : DbContext
    {
        public PizzaContext() : base("PizzaContext")
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}