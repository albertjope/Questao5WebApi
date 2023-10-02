using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Questao5WebApi.Models;

public enum enumTipoMovimentacao
{
    [Description("Crédito")]
    C = 0,
    [Description("Débito")]
    D = 1
}

public class Movimentacao
{
    [Key]
    public Guid IdMovimentacao { get; set; }
    [Required]
    public Guid IdContaCorrente { get; set; }
    [Required]
    public string? DataMovimento { get; set; }
    [Required]
    public double Valor { get; set; }

    public enumTipoMovimentacao TipoMovimento { get; set; }
}
