using System;
using System.Collections.Generic;
using System.Text;

namespace ParavarejoApp1.Models
{
    public class LucroRealModel
    {

        public void Calculate(List<Item> items)
        {

            int i = 0;
            foreach (var item in items)
            {
                item.CalculatedValue = ++i;
            }
        }
    }
}
