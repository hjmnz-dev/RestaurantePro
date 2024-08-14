

using Microsoft.Extensions.Logging;


using RestaurantePro.Cliente.Application.Base;
using RestaurantePro.Cliente.Application.Dtos;
using RestaurantePro.Cliente.Application.Interfaces;
using RestaurantePro.Cliente.Domain.Interface;
using RestaurantePro.Cliente.Application.Interfaces;
using System.Reflection.Metadata.Ecma335;
using RestaurantePro.Cliente.Persistance.Repositories;
namespace RestaurantePro.Cliente.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository ClienteRepository;
        private readonly ILogger<ClienteService> logger;

        public ClienteService (IClienteRepository ClienteRepository, ILogger<ClienteService> logger) 
        { 
             this.ClienteRepository = ClienteRepository;
             this.logger = logger;
        }

        public ServiceResult GetClientes() 
        { 
         

            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = ClienteRepository.GetAll();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los clientes";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;


        }

        public ServiceResult GetCliente(int id) 
        {

            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = ClienteRepository.GetEntityById(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el cliente";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }


        public ServiceResult updateCliente(ClienteUpdateDto clienteUpdate) 
        {


            ServiceResult result = new ServiceResult();

            try
            {
                if (clienteUpdate == null)
                {
                    result.Success = false;
                    result.Message = "El cliente no puede ser nula.";
                }

                RestaurantePro.Cliente.Domain.Entities.Cliente cliente = new RestaurantePro.Cliente.Domain.Entities.Cliente()
                {
                    id = clienteUpdate.id,
                    Total = clienteUpdate.Total,
                    Fecha = clienteUpdate.Fecha,
                    modify_date = clienteUpdate.modify_date,
                    modify_user = clienteUpdate.modify_user,   

                };

                    this.ClienteRepository.Update(cliente);
                         



            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error Actualizando los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

       public ServiceResult removeCliente(ClienteRemoveDto clienteRemove) 
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (clienteRemove == null)
                {
                    result.Success = false;
                    result.Message = "El cliente no puede ser nulo.";
                    return result;
                }

                var cliente = ClienteRepository.GetEntityById(clienteRemove.id);
                if (cliente == null)
                {
                    result.Success = false;
                    result.Message = "El cliente no existe.";
                    return result;
                }


                cliente.deleted = clienteRemove.deleted;
                cliente.delete_date = clienteRemove.delete_date;
                cliente.delete_user = clienteRemove.delete_user;

                ClienteRepository.Remove(cliente);

                result.Success = true;
                result.Message = "Cliente eliminado con éxito.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos del cliente";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public ServiceResult saveCliente(ClienteSaveDto clienteSave) 
        {
            ServiceResult result = new ServiceResult();
           
            try
            {
              if(clienteSave == null) 
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(clienteSave)} es requerido.";
                    return result;  
              }

                RestaurantePro.Cliente.Domain.Entities.Cliente cliente = new RestaurantePro.Cliente.Domain.Entities.Cliente()
                {
                    Total = clienteSave.Total,
                    Fecha = clienteSave.Fecha,
                    creation_date = clienteSave.ChangeDate,
                    creation_user = clienteSave.ChangeUser

                };

                this.ClienteRepository.Save(cliente);

               

            }


            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos del cliente";
                
            }


            return result;








        }

       
    }
}
