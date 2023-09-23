using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundationClass
{
    public class ValueNode : IValueable
    {
        float value;

        public ValueNode(float v)
        {
            value = v;
        }

        public float Value
        {
            get
            {
                return value;
            }
        }
    }
}
