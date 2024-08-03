using PasswordStorageApp.WebApi.Models;

namespace PasswordStorageApp.WebApi.Persistence
{
    public static class FakdeDbContext
    {
        public static List<Account> Accounts { get; set; } =
        [
            new Account
            {
                Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                Username = "johndoe",
                Password = "P@ssw0rd123!",
                CreatedOn = DateTimeOffset.Parse("2023-03-15T09:30:00Z")
            },
            new Account
            {
                Id = Guid.Parse("b9f59eb4-5eab-4f25-9dbd-8014c9845fdb"),
                Username = "janedoe",
                Password = "SecurePass789#",
                CreatedOn = DateTimeOffset.Parse("2023-05-22T14:45:00Z")
            },
            new Account
            {
                Id = Guid.Parse("8a1c5cdf-98e9-4ab3-86c6-576a80a08c7d"),
                Username = "bobsmith",
                Password = "B0bsC0mpl3xP@ss",
                CreatedOn = DateTimeOffset.Parse("2023-08-07T11:15:00Z")
            },
            new Account
            {
                Id = Guid.Parse("6ecd8c99-4036-403d-bf84-cf8400f67836"),
                Username = "alicejohnson",
                Password = "Al1c3J0hns0n2023!",
                CreatedOn = DateTimeOffset.Parse("2023-10-30T16:20:00Z")
            },
            new Account
            {
                Id = Guid.Parse("db7b5ab3-0df2-4c26-b49c-1c84af0f6f23"),
                Username = "mikeross",
                Password = "M1k3R0ss#2024",
                CreatedOn = DateTimeOffset.Parse("2024-01-18T08:55:00Z")
            },
        ];
    }
}
