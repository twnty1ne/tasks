using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Buisness.Exceptions;
using Tasks.Buisness.Validators;
using Tasks.Shared.Validation;

namespace Tasks.Buisness
{
    public class ProjectEntity : Entity
    {
        private readonly IValidator<ProjectEntity> _validator = new ProjectValidator();
        public ProjectEntity()
        {
        }

        public ProjectEntity(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CreateDate = DateTime.UtcNow;
            if (!_validator.Valid(this)) throw new InvalidBuisnessException();
            
        }

        public ProjectEntity(Guid id, string name) : this(name)
        {
            Id = id;
            CreateDate = DateTime.UtcNow;

        }

        public string Name { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
        public virtual IEnumerable<TaskEntity> Tasks { get; protected set; }

    }
}
