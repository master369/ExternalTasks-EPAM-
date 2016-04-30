using _6._1.Common.Entities;
using System.Collections.Generic;

namespace _6._1.DAL.Abstracty
{
    public interface IAwardsDAO
    {
        int MaxId { get; set; }

        IEnumerable<Award> GetAll();

        int Add(Award award);

        void Delete(int id);

        Award Get(int id);
    }
}
