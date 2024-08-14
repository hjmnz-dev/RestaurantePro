using RestaurantePro.Cliente.Application.Base;
using RestaurantePro.Cliente.Application.Dtos;

namespace RestaurantePro.Cliente.Application.Interfaces
{
    public interface IClienteService
    {
       ServiceResult GetClientes();

        ServiceResult GetCliente(int id);

        ServiceResult updateCliente(ClienteUpdateDto clienteUpdate);

        ServiceResult removeCliente(ClienteRemoveDto clienteRemove);

        ServiceResult saveCliente(ClienteSaveDto clienteSave);


    }
}
