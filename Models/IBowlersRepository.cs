using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlerFun.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }


        public void SaveBowler(Bowler bowler);

        public void DeleteBowler(int AppId);

        public void EditBowler(Bowler bower);
    }
}
