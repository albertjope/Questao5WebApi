using System.ComponentModel;

namespace Questao5WebApi.Models;
public enum enumTipoResultado
{
    Started  = 0,
    Finished = 1,
}

public class Idempotencia
{
    public Guid Chave_Idempotencia { get; set; }
    public string Requisicao { get; set; }
    public enumTipoResultado Resultado { get; set; }
}
