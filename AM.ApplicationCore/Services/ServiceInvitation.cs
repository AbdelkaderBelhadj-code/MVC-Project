using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceInvitation : Service<Invitation>, IServiceInvitation
    {
        public ServiceInvitation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        
    }
}
