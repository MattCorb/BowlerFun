using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlerFun.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {

        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers =>_context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowler(Bowler bowler)
        {
            if (bowler.BowlerId != 0)
            {

                _context.Bowlers.Add(bowler);
                _context.SaveChanges();
            }
        }

        public void DeleteBowler(int BowlId)
        {
            Bowler bowler = _context.Bowlers.Where(x => x.BowlerId == BowlId ).FirstOrDefault();
            _context.Remove(bowler);
            _context.SaveChanges();
        }

        public void EditBowler(Bowler bowler)
        {
            _context.Update(bowler);
            _context.SaveChanges();
        }
    }

}
