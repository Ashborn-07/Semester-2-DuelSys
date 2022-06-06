using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Football : Sport
    {
        public Football(int id, string name) : base(id, name)
        {
        }

        public override Match MatchResultValidation(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
