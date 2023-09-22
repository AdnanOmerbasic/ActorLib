using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorLib
{
    public interface IActorRepository
    {
        public Actor Add(Actor actor);
        public Actor GetById(int? id);
        public Actor? Delete(int id);
        public Actor Update(int id, Actor actor);
        public IEnumerable<Actor> Get(int? birthYearBefore, int? birthYearAfter, string? name, string? sortBy);
    }
}
