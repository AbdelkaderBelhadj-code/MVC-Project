using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFete : Service<Fete>, IServiceFete
    {
        public ServiceFete(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Salle SallePlusUtilise()
        {

            var sallesgrouping= GetMany(f => (DateTime.Now - f.DateFete).TotalDays < 365)
                .GroupBy(f => f.Salle)
                .OrderByDescending(f=>f.Count())
                .FirstOrDefault();

            return sallesgrouping.Key;

        }

        public int NbreFete(TypeFete feteType, Salle salle)
        {
            return GetMany(f => f.Type == feteType && f.SalleId == salle.IdSalle).Count();
        }

        public int DurePlusLongue(TypeFete feteType)
        {
            return GetMany(f => f.Type == feteType).OrderByDescending(f => f.Duree).FirstOrDefault().Duree;
        }

        public List<Fete> GetfeteByDate(DateTime DateFete)
        {
            List<Fete> listfete = new List<Fete>();
            foreach (var fete in this.GetAll())
            {

                if (fete.DateFete.ToShortDateString() == DateFete.ToShortDateString())
                {
                    listfete.Add(fete);
                }
            }
            return listfete;

        }


    }
}
