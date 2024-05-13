using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : TemporaryBoostItem
{
    public override void Apply(Player player)
    {
        base.Apply(player);
        print("magnet applied");
    }

    public override void Cancel(Player player)
    {
        base.Cancel(player);
        print("magnet canceled");
    }
}
