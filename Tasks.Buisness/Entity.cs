using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Buisness
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
