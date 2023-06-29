using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pymex.MVC.Models.Mapper.Contracts
{
    public interface IGenericMapper<DC, M> where DC : class where M : class
    {
        M ToModel(DC dataContract);
        DC ToDataContract(M model);
    }
}
