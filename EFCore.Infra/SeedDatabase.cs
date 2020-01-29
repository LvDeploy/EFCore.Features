using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EFCore.Model;

namespace EFCore.Infra
{
    public class SeedDatabase
    {
        public static void Seed(Context db)
        {
            db.Database.EnsureDeleted();
            if (db.Database.EnsureCreated())
            {
                var itemCount = 0;

                db.Set<Livro>().Add(new Livro
                {
                    AnoPublicacao = 1986,
                    Autor = new Autor
                    {
                        Idade = 50 ,
                        Nome = $"MARCELO DOS SANTOS"
                    },
                    NumPaginas = 120,
                    Nome = "LIVRO FINANCEIRO"
                });

                var autor = new Autor
                {
                    Idade = 42,
                    Nome = $"JOÃO DOS SANTOS"
                };

                do
                {
                    db.Set<Livro>().Add(new Livro {
                        AnoPublicacao = 1986 + itemCount,
                        Autor = autor,
                        NumPaginas = 300 + itemCount,
                        Nome = "LIVRO DE SOFTWARE VOL. " + itemCount
                    });
                    itemCount++;
                } while (itemCount <= 10);

                db.SaveChanges();
            }
        }
    }
}
