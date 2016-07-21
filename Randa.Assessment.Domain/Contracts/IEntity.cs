using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Randa.Assessment.Domain.Contracts
{
    interface IEntity
    {
        bool IsValid(out IList<ValidationFailure> errors);
    }
}
