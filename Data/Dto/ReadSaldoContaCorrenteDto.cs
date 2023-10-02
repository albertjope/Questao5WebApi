using System.ComponentModel.DataAnnotations;

namespace Questao5WebApi.Data.Dto;

public class ReadSaldoContaCorrenteDto
{
    public Guid IdContaCorrente { get; set; }
    public int Numero { get; set; }
    public string? Nome { get; set; }
    public bool Ativo { get; set; }
    public double Saldo { get; set; }
    public DateTime DataHora { get; set; }
}
