using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Fete
    {
        [Key]
        public int IdFete { get; set; }
        [Required(ErrorMessage ="Description Fete: Champs obligatoire")]
        public string Description { get; set; }
        public TypeFete Type { get; set; }

        [Range(1, 250)]
        public int NbInviteMax { get; set; }
        public int Duree { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateFete { get; set; }

        public virtual  ICollection<Invitation> Invitations { get; set; }

        public virtual Salle Salle { get; set; }

        [ForeignKey("Salle")]
        public virtual int SalleId { get; set; }
    }

    public enum TypeFete
    {
        Anniversaire,
        Mariage,
        Autre
    }
}
