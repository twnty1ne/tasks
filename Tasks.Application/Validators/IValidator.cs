using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Application.Validators
{
    public interface IValidator<T>
    {
        bool Valid(T item);
    }
}
