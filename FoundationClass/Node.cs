using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundationClass
{
    public class Node
    {
        public IValueable Value;
        public float Weightage;

        public Node(float weightage, IValueable value)
        {
            if( weightage < 0) throw new ArgumentException($"The inserted weightage {weightage} is not valid!.");
            if( value.Value < 0 || value.Value > 100) throw new ArgumentException($"The inserted weightage {weightage} is not valid!.");
            Weightage = weightage;
            Value = value;
        }

        public float Product
        {
            get
            {
                return Weightage * Value.Value;
            }
            
        }
    }
}
