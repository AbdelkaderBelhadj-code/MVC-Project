using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceInvite : Service<Invite>, IServiceInvite
    {
        public ServiceInvite(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
