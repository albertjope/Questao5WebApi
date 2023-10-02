namespace Questao5WebApi.Models;
public class Idempotencia
{
    public Guid Chave_Idempotencia { get; set; }
    public string Requisicao { get; set; }
    public string Resultado { get; set; }
}
