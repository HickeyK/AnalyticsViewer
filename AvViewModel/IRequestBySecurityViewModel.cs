using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvDataAccess;

namespace AvViewModel
{
    public interface IRequestBySecurityViewModel
    {
        IUnitOfWork AvDataContext { get; set; }
    }
}
