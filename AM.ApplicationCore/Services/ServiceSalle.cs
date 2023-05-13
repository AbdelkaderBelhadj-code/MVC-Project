using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class ServiceSalle : Service<Salle>, IServiceSalle
    {
        public ServiceSalle(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        
    }
}
