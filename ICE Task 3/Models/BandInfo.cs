using System;
using System.Collections.Generic;

namespace ICE_Task_3.Models;

public partial class BandInfo
{
    public int BandId { get; set; }

    public string Name { get; set; } = null!;

    public int MemberCount { get; set; }

    public DateOnly DebutDate { get; set; }
}
