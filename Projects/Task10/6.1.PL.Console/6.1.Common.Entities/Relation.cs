using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.Common.Entities
{
   public class Relation
    {
        public int Id { get; set; }
        public int AwardId { get; set; }
        public int UserId { get; set; }

        public Relation(int userId, int awardId)
        {
            this.UserId = userId;
            this.AwardId = awardId;
        }

        public override string ToString()
        {
            return AwardId + " " + UserId;
        }
    }
}
