using PromoIphones.Dtos;

namespace PromoIphones.Interfaces
{
    public interface IPromocaoService
    {
        Task<ResultadoCompraDto> ComprarIphonePromocao(int quantidade);
        Dictionary<int, int> ObterStatusVendas();
    }
}