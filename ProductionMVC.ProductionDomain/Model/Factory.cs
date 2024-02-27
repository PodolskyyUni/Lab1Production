using System;
using System.Collections.Generic;

namespace ProductionDomain.Model;

public partial class Factory : Entity
{
    public int FactoryId { get; set; }

    public string Adress { get; set; } = null!;

    public string Maintenance { get; set; } = null!;

    public string FactoryName { get; set; } = null!;

    public virtual ICollection<FactoryProduct> FactoryProducts { get; set; } = new List<FactoryProduct>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
