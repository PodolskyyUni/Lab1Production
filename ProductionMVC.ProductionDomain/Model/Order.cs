using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductionDomain.Model;

public partial class Order : Entity

{
    public int OrderId { get; set; }

    public int FactoryId { get; set; }

    public int ClientId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public DateOnly ApprComplDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Factory Factory { get; set; } = null!;

    public virtual ICollection<ReqProduct> ReqProducts { get; set; } = new List<ReqProduct>();
}
