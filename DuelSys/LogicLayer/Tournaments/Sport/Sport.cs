using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public abstract class Sport
    {
        private int id;
        private string name;

        public int Id { get { return id; } }
        public string Name { get { return name; } }

        public Sport(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public abstract Match MatchResultValidation(Match match);
    }
}
