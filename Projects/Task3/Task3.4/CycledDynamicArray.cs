using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._4
{
    class CycledDynamicArray //: DynamicArray
    {
        

        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                foreach (var item in this)
                {
                    yield return item;
                }
            }
        }
    }
}
