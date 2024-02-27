﻿using System;
using System.Collections.Generic;

namespace ProductionDomain.Model;

public partial class ReqProduct : Entity
{
    public int ReqProductId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int ReqProductAmount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
