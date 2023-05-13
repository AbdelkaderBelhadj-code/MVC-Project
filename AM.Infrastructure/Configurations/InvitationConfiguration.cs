using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AM.ApplicationCore.Domain;

namespace AM.Infrastructure.Configurations
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(t => new
            {
                t.FeteFk,
                t.InviteFk,
                t.DateInvitation,

            });

            builder.HasOne(t => t.Fete)
               .WithMany(f => f.Invitations)
               .HasForeignKey(t => t.FeteFk);

            builder.HasOne(t => t.Invite)
              .WithMany(p => p.Invitations)
              .HasForeignKey(t => t.InviteFk);
        }
    }
}
