using EntityPizza.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace EntityPizza.Dal
{
    public class PizzaInitializer : DropCreateDatabaseIfModelChanges<PizzaContext>
    {
        protected override void Seed(PizzaContext context)
        {
            var pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Id = 1,
                    Descricao = "Pizza de Calabresa",
                    Valor = 30
                }               
            };

            pizzas.ForEach(p => context.Pizzas.Add(p));
            context.SaveChanges();
        }
    }
}