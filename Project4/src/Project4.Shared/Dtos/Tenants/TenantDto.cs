using System;

namespace Project4.Shared.Dtos.Tenants
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Uri Website { get; set; }
    }
}
