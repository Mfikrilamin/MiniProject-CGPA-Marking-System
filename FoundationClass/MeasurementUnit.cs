using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundationClass
{
    public class MeasurementUnit : IValueable
    {
        public string Id;
        Node[] Nodes;

        public MeasurementUnit(string id, Node[] nodes)
        {
            Id = id;
            Nodes = nodes;
        }

        public float Sum
        {
            get
            {
                float totalWeight = 0;
                float totalSum = 0;
                foreach(Node node in Nodes)
                {
                    totalWeight += node.Weightage;
                    totalSum += node.Product;
                }
                return totalSum / totalWeight;
            }
        }

        virtual public float XNormalize
        {
            get
            {
                return Sum;
            }
        }

        public float Value
        {
            get
            {
                return (float)Math.Round(XNormalize , 2);
            }
        }
    }
}
