using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomNayAnGi.Models.Enum
{
    /// <summary>
    /// Status of a recipe
    /// </summary>
    public enum RecipeStatusEnum
    {
        Waiting = 1,
        Approved = 2,
        Rejected = 3,
    }

    /// <summary>
    /// Premium or free recipe
    /// </summary>
    public enum RecipeTypeEnum
    {
        Free = 1,
        Premium = 2
    }
}