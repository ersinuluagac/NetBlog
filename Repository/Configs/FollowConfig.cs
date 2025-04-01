using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configs
{
    public class FollowConfig : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.Ignore(f => f.CreatedDate);
            builder.Ignore(f => f.UpdatedDate);

            builder.HasKey(f => new { f.FollowerId, f.FollowingId });
        }
    }
}
