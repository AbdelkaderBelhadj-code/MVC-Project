using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Invitation
    {
        public DateTime DateInvitation { get; set; }
        public bool ConfirmeInvitation { get; set; }

        public int InviteFk { get; set; }

        public int FeteFk { get; set; }

        public virtual Invite Invite { get; set; }

        public virtual Fete Fete { get; set; }
    }
}
