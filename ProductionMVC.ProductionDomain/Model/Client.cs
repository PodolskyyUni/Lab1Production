using System;
using System.Collections.Generic;

namespace ProductionDomain.Model;

public partial class Client: Entity
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string Contacts { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
