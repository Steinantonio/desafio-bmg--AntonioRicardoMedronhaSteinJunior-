using PromoIphones.Dtos;
using PromoIphones.Interfaces;
using System.Collections.Concurrent;

namespace PromoIphones.Services
{
    public class PromocaoService : IPromocaoService
    {
        private readonly ConcurrentDictionary<int, int> _vendasPorHora = new();
        private readonly object _lock = new();

        public PromocaoService()
        {
            for (int i = 0; i < 24; i++)
            {
                _vendasPorHora[i] = 0;
            }
        }

        public Task<ResultadoCompraDto> ComprarIphonePromocao(int quantidade)
        {
            if (quantidade <= 0)
                return Task.FromResult(new ResultadoCompraDto { Sucesso = false, Mensagem = "Deve conter valor maior que zero" });

            if (quantidade > 5)
                return Task.FromResult(new ResultadoCompraDto { Sucesso = false, Mensagem = "Máximo de 5 iPhones por compra" });

            var horaAtual = DateTime.Now.Hour;

            lock (_lock)
            {
                if (_vendasPorHora[horaAtual] + quantidade > 100)
                {
                    int disponiveis = 100 - _vendasPorHora[horaAtual];
                    return Task.FromResult(new ResultadoCompraDto
                    {
                        Sucesso = false,
                        Mensagem = $"Limite excedido para esta hora. Apenas {disponiveis} iPhones disponíveis."
                    });
                }

                _vendasPorHora[horaAtual] += quantidade;

                return Task.FromResult(new ResultadoCompraDto
                {
                    Sucesso = true,
                    Mensagem = $"Compra realizada com sucesso! {quantidade} iPhone(s) por R$ {quantidade * 1.00:F2}"
                });
            }
        }

        public Dictionary<int, int> ObterStatusVendas()
        {
            return _vendasPorHora.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}