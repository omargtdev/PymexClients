using Pymex.MVC.Cache;
using Pymex.MVC.ClienteProxy;
using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.ProveedorProxy;

namespace Pymex.MVC.Models.Mapper
{
    public class PersonaMapper : IGenericMapper<ClienteDC, Cliente>, IGenericMapper<ProveedorDC, Proveedor>
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

        public ProveedorDC ToDataContract(Proveedor model)
        {
            return new ProveedorDC 
            {
                Id = model.Id,
                TipoDocumento = (ProveedorProxy.TipoDocumento)model.TipoDocumento,
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

        public Proveedor ToModel(ProveedorDC dataContract)
        {
            return new Proveedor
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