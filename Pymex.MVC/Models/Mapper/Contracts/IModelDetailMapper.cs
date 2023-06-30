namespace Pymex.MVC.Models.Mapper.Contracts
{
    public interface IModelDetailMapper<DC, M> where DC : class where M : class
    {
        M ToDetailModel(DC dataContract);
    }
}