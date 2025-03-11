using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophylibrary
{
    public class TrophyRepository : ITrophyRepository
    {
        private List<Trophy> _trophies = new List<Trophy>();
        private int _nextId = 1;

        public Trophy? GetById(int id)
        {
            return _trophies.Find(trophy => trophy.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            if (trophy == null)

            throw new ArgumentNullException(nameof(trophy));

            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy Delete(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                return null;
            }
            _trophies.Remove(trophy);
            return trophy;
        }

        public Trophy? Update(int id, Trophy trophy)
        {
            Trophy? existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                return null;
            }
            existingTrophy.Id = id;
            existingTrophy.Competition = trophy.Competition;
            existingTrophy.Year = trophy.Year; 
            return existingTrophy;
        }

        public IEnumerable<Trophy> Get(int? yearAfter = null, string? competitionIncludes = null, string orderBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);

            if (yearAfter != null)
            {
                result = result.Where(t => t.Year >  yearAfter);
            }

            if (competitionIncludes != null)
            {
                result = result.Where(t => t.Competition.Contains(competitionIncludes));
            }

           if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition":
                    case "competitiion_asc":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "competition_desc":
                        result = result.OrderByDescending(t => t.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(t => t.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(t => t.Year);
                        break;
                    default:
                        break;
                }
            }
           return result;
        }

    }
}
