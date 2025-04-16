
using System;

namespace GamingRoom
{
    // parent class for game team and player entities
    public class Entity
    {
        private long id;
        private string name;

        
        private Entity() 
        { }

        // gives entity with id and name
        public Entity(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

        //unqiue identifier for entity
        public long Id
        {
            get { return id; }
        }

        // gets name to entity
        public string Name
        {
            get { return name; }
        }

        // return string of entity
        public override string ToString()
        {
            return $"Entity [id={id}, name={name}]";
        }

    }
}
