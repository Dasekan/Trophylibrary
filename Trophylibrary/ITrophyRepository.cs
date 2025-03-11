using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophylibrary
{
    public interface ITrophyRepository
    {
        Trophy Add(Trophy trophy);

        IEnumerable<Trophy> Get(int? Year = null, string? competitionIncludes = null, string orderBy = null);

        Trophy? GetById(int id);

        Trophy? Delete(int id);

        Trophy? Update(int i, Trophy trophy);

       
    }
}
