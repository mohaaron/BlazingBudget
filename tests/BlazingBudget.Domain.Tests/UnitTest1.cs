using BlazingBudget.Domain.Aggregates.Account;
using BlazingBudget.Domain.ValueObjects;
using System.Text.Json;

namespace BlazingBudget.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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

            Account actualAccount = Account.Create(name.Value, email.Value, password.Value);
            
            var serialized = JsonSerializer.Serialize(actualAccount);
            var expectedAccount = JsonSerializer.Deserialize<Account>(serialized);

            Assert.Equivalent(expectedAccount, actualAccount);
        }
    }
}