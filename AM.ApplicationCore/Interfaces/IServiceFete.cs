using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFete : IService<Fete>
    {
        Salle SallePlusUtilise();
        int NbreFete(TypeFete feteType, Salle salle);

        int DurePlusLongue(TypeFete feteType);

        List<Fete> GetfeteByDate(DateTime DateFete);
    }
}
