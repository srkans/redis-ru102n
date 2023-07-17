﻿using Redis.OM.Modeling;

namespace Model
{
    public class Address
    {
        [Searchable]
        public string? StreetAddress { get; set; }
        [Indexed]
        public string? PostalCode { get; set; }
        [Indexed]
        public GeoLoc Location { get; set; }
        [Indexed(CascadeDepth = 1)]
        public Address? ForwardingAddress { get; set; }
    }
}
