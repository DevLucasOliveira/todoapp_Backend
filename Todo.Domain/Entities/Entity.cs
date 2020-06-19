using System;
using System.Collections.Generic;
using System.Text;

namespace todo.domain.Entities
{
    abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
