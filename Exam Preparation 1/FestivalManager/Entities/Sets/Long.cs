using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public class Long : ConcertSet
    {
        public Long(string name)
            : base(name, new TimeSpan(1, 0, 0))
        {
        }
    }
}
