
using Redis.OM.Modeling;
using System.Net;

namespace Model
{
    [Document(StorageType = StorageType.Json)]
    public class Sale
    {
        [RedisIdField]
        [Indexed]
        public string? Id { get; set; }
        [Indexed]
        public string? EmployeeId { get; set; }
        [Indexed]
        public int Total { get; set; }
        [Indexed(CascadeDepth = 2)]
        public Address? Address { get; set; }
    }
}
