using System;
using System.Collections.Generic;
using System.Linq;
using AdventureGame;

public static class CollectionHelper
{
    public static T FindByName<T>(List<T> list, string name) where T : IIdentifiable
    {
        return list.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
