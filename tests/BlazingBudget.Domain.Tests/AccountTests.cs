using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System.Text.Json;

namespace BlazingBudget.Domain.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Serializes_Account_Aggregate_Successfully()
        {
            var id = AccountId.Create();
            var idSerialized = JsonSerializer.Serialize(id);
            var idDeserialized = JsonSerializer.Deserialize<AccountId>(idSerialized);

            var name = PersonName.Create("myfirstname", "mylastname");
            var nameSerialized = JsonSerializer.Serialize(name.Value);
            var nameDeserialized = JsonSerializer.Deserialize<PersonName>(nameSerialized);

            var email = Email.Create("myemail@domain.com");
            var emailSerialized = JsonSerializer.Serialize(email.Value);
            var emailDeserialized = JsonSerializer.Deserialize<Email>(emailSerialized);

            var password = Password.Create("Clit#u(0#nm$1a9");
            var passwordSerialized = JsonSerializer.Serialize(password.Value);
            var passwordDeserialized = JsonSerializer.Deserialize<Password>(passwordSerialized);

            Result<Account> actualAccountResult = Account.Create(name.Value, email.Value, password.Value);
            Account actualAccount = actualAccountResult.Value;

            var serialized = JsonSerializer.Serialize(actualAccount);
            var expectedAccount = JsonSerializer.Deserialize<Account>(serialized);

            Assert.Equivalent(expectedAccount, actualAccount);
        }
    }
}