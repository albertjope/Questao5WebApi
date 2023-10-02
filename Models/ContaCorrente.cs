using System.ComponentModel.DataAnnotations;

namespace Questao5WebApi.Models;

public class ContaCorrente
{
    [Key] 
    public Guid IdContaCorrente { get; set; }
    [Required]
    public int Numero { get; set; }
    [Required]
    public string? Nome { get; set; }

    [Required]
    public bool Ativo { get; set; }

    public double Saldo { get;}

    public IList<Movimentacao>? Movimentacoes { get;}

}
