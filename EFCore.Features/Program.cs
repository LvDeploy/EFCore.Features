using EFCore.Infra;
using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Features
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                SeedDatabase.Seed(db);

                var consultaGroupBY = db.Set<Livro>()
                    //.AsNoTracking() //Obs.: Recurso do LazyLoad não funciona com o As No Tracking
                    .Where(x => x.AnoPublicacao > 1990)
                    .GroupBy(x => x.Autor.Nome) //Não tente agrupar apenas pela propriedade de navegação, escolha uma propriedade de tipo primitivo 
                    .Select(x => new
                    {
                        x.Key,
                        Qtd = x.Count()
                    })
                    .ToList();

                foreach (var item in consultaGroupBY)
                {
                    Console.WriteLine($"{item}");
                }
            }

            Console.ReadKey();
        }
    }
}
