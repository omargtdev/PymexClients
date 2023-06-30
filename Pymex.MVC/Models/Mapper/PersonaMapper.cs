using Pymex.MVC.Cache;
using Pymex.MVC.ClienteProxy;
using Pymex.MVC.Models.Mapper.Contracts;

namespace Pymex.MVC.Models.Mapper
{
    public class PersonaMapper : IGenericMapper<ClienteDC, Cliente>
    {
        public ClienteDC ToDataContract(Cliente model)
        {
            return new ClienteDC
            {
                Id = model.Id,
                TipoDocumento = (ClienteProxy.TipoDocumento)model.TipoDocumento,
                NumeroDocumento = model.NumeroDocumento,
                NombreCompleto = model.NombreCompleto,
                UsuarioAccion = UserLogged.Current.Login
            };
        }


        public Cliente ToModel(ClienteDC dataContract)
        {
            return new Cliente
            {
                Id = dataContract.Id, 
                TipoDocumento = (TipoDocumento) dataContract.TipoDocumento,
                NumeroDocumento = dataContract.NumeroDocumento,
                NombreCompleto = dataContract.NombreCompleto,
                FechaRegistro = dataContract.HistorialSeguimiento.FechaRegistro
            };
        }
    }
}