﻿using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.DAL.Interfaces
{
  public  interface IAwardsDAO
    {
        IEnumerable<Award> GetAll();

        int Add(Award award);

        void Delete(int id);

        Award Get(int id);
    }
}
