using System;

namespace EFCore.Model
{
    public class Livro : BaseModel
    {
        public string Nome { get; set; }
        public int NumPaginas { get; set; }
        public int AnoPublicacao { get; set; }
        public virtual Autor Autor { get; set; }
        public Guid AutorId { get; set; }
    }
}
