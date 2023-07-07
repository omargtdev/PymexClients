using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pymex.MVC.Models.Mapper.Contracts
{
    public interface ICreateMapper<DC, M> where DC : class where M : class
    {
        DC ToCreateDataContract(M model);
    }
}
