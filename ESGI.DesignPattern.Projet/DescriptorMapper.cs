using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{

    public interface Mapper
    {
        void Add(String fieldName, Type forType);
    }


    public class DescriptorMapper : Mapper
    {

        public List<AttributeDescriptor> descriptors { get; }

        public DescriptorMapper()
        {
            descriptors = new List<AttributeDescriptor>();
        }

        public void Add(String fieldName, Type forType)
        {
            AttributeDescriptor attribute = DescriptorFactory.Create(fieldName, GetClass(), forType);

            this.descriptors.Add(attribute);
        }


        private Type GetClass()
        {
            return typeof(DescriptorMapper);
        }
    }
}