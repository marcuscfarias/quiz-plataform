using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //TODO: complete other properties and rules
        
        builder.ToTable("User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Username)
            .HasMaxLength(30)
            .IsRequired();
    }
    
}