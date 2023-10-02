using MediatR;
using Questao5WebApi.Data.Dto;

namespace Questao5WebApi.Services.Commands;

public record ContaCorrenteGetByIdCommand(string Id) : IRequest<ReadSaldoContaCorrenteDto>;
