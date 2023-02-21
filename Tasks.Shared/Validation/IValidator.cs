using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Shared.Validation
{
    public interface IValidator<T>
    {
        bool Valid(T item);
    }
}
