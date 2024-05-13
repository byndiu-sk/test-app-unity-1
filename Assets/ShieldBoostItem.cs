using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoostItem : TemporaryBoostItem
{
    public override void Apply(Player player)
    {
        base.Apply(player);
        print("shield applied");
    }

    public override void Cancel(Player player)
    {
        base.Cancel(player);
        print("shield canceled");
        
    }
    
    
}