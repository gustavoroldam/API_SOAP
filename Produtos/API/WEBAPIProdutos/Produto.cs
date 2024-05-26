using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIProdutos
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int id { get; set; }

        [StringLength(35)]
        public string nome { get; set; }

        [StringLength(2)]
        public string medida { get; set; }

        public float preco { get; set; }

        public int qtde { get; set; }
    }
}
