using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework.Configurations;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
	public void Configure(EntityTypeBuilder<Account> builder)
	{
		builder.ToTable("Accounts");

		builder.HasKey(a => a.Id);

		builder.Property(a => a.Id)
			.HasConversion(id => id.Value, value => AccountId.Create());

		builder.OwnsOne(a => a.Name, builder =>
		{
			builder.Property(n => n.FirstName)
				.HasColumnName("FirstName")
				.HasMaxLength(100);

			builder.Property(n => n.LastName)
				.HasColumnName("LastName")
				.HasMaxLength(100);
		});

		builder.Property(a => a.Email)
			.HasConversion(v => v.Value, value => Email.Create(value).Value)
			.HasColumnName("Email")
			.HasMaxLength(100);

		builder.Property(a => a.Password)
			.HasColumnName("Password")
			.HasMaxLength(100);
	}
}