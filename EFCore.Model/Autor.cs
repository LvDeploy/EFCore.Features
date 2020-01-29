using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model
{
    public class Autor : BaseModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}
