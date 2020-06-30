using System;

namespace ESGI.DesignPattern.Projet
{
    public class BooleanDescriptor : AttributeDescriptor
    {

        public BooleanDescriptor(string descriptorName, Type mapperType) 
            : base(descriptorName, mapperType, typeof(Boolean))
        {
        }
    }
}