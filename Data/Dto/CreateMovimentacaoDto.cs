using Questao5WebApi.Models;

namespace Questao5WebApi.Data.Dto;

public class CreateMovimentacaoDto
{
    public Guid IdContaCorrente { get; set; }
    public string? DataMovimento { get; set; }
    public double Valor { get; set; }
    public enumTipoMovimentacao TipoMovimento { get; set; }
    public Idempotencia Idempotencia { get; set; }
}
