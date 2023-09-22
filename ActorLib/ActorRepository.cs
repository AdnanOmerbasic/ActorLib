using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorLib
{
    public class ActorRepository : IActorRepository
    {
        private readonly List<Actor> _actors = new List<Actor>();
        private int _nextId;

        public ActorRepository()
        {
            _actors = new List<Actor>();
            _actors.Add(new Actor() { Id = _nextId++, Name = "Adnann", BirthYear = 1920});
            _actors.Add(new Actor() { Id = _nextId++, Name = "Adnan2", BirthYear = 1927 });
            _actors.Add(new Actor() { Id = _nextId++, Name = "Adnan4", BirthYear = 1950 });
            _actors.Add(new Actor() { Id = _nextId++, Name = "Adnann6", BirthYear = 1966 });
            _actors.Add(new Actor() { Id = _nextId++, Name = "Adnann8", BirthYear = 1993 });
        }
        public Actor Add(Actor actor)
        {
            actor.Validate();
            actor.Id = _nextId;
            _actors.Add(actor);
            return actor;
        }

        public Actor Delete(int id)
        {
         Actor? actor = GetById(id);
         if(actor != null)
            {
              _actors.Remove(actor);
              return actor;
            }
            return null;
        }

        public IEnumerable<Actor> Get(int? birthYearBefore, int? birthYearAfter, string? name, string? sortBy)
        {
            IEnumerable<Actor> actors = new List<Actor>();
            if(birthYearBefore != null)
            {
                actors = actors.Where(a => a.BirthYear == birthYearBefore);
            }
            if(birthYearAfter != null)
            {
                actors = actors.Where(a => a.BirthYear == birthYearAfter);
            }
            if(name != null)
            {
                actors = actors.Where(a => a.Name.Contains(name));
            }
            if(sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "name":
                    case "name_asc":
                        actors = actors.OrderBy(a => a.Name);
                        break;
                    case "name_desc":
                        actors = actors.OrderByDescending(a => a.Name);
                        break;
                    case "BirthYear":
                    case "BirthYear_asc":
                        actors.OrderBy(a => a.BirthYear);
                        break;
                    case "BirthYear_desc":
                        actors.OrderByDescending(a => a.BirthYear);
                        break;
                    default:
                        break;

                }
            }
            return actors;
        }

        public Actor? GetById(int? id)
        {
            return _actors.Find(actor => actor.Id == id);
        }

        public Actor Update(int id, Actor actor)
        {
            actor.Validate();
            Actor? actors = GetById(id);
            if(actors == null)
            {
                return null;
            }
            actors.Id = actor.Id;
            actors.Name = actor.Name;
            actors.BirthYear = actor.BirthYear;
            return actors;
        }
    }
}
