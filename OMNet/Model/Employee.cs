using Redis.OM.Modeling;
using System.Net;

namespace Model
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Employee" }, IndexName = "employees")]
    public class Employee
    {
        [RedisIdField]
        [Indexed]
        public string? Id { get; set; }
        [Indexed]
        public List<string>? Sales { get; set; }
        [Indexed(JsonPath = "$.Location")]
        [Indexed(JsonPath = "$.PostalCode")]
        public Address? Address { get; set; }
        [Indexed]
        public string? Name { get; set; }
    }
}
