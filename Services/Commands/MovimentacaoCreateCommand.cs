using MediatR;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services.Commands;
public record MovimentacaoCreateCommand(CreateMovimentacaoDto movimentacao) : IRequest;


