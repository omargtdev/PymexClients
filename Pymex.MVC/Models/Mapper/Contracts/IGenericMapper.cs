namespace Pymex.MVC.Models.Mapper.Contracts
{
    public interface IGenericMapper<DC, M> where DC : class where M : class
    {
        M ToModel(DC dataContract);
        DC ToDataContract(M model);
    }
}
