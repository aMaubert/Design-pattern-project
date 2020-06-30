using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class DescriptorMapper
    {

        //protected List<AttributeDescriptor> descriptors { get; }

        //public DescriptorMapper()
        //{
        //    descriptors = new List<AttributeDescriptor>();
        //}

        //public void Add(String fieldName, Type forType )
        //{
        //    AttributeDescriptor DescriptorFactory(fieldName, forType);

        //}



        protected List<AttributeDescriptor> CreateAttributeDescriptors() {
            var result = new List<AttributeDescriptor>();

            result.Add(new DefaultDescriptor("remoteId", GetClass(), typeof(int)));
            result.Add(new DefaultDescriptor("createdDate", GetClass(), typeof(DateTime)));
            result.Add(new DefaultDescriptor("lastChangedDate", GetClass(), typeof(DateTime)));
            result.Add(new ReferenceDescriptor("createdBy", GetClass(), typeof(User)));
            result.Add(new ReferenceDescriptor("lastChangedBy", GetClass(), typeof(User)));
            result.Add(new DefaultDescriptor("optimisticLockVersion", GetClass(), typeof(int)));
            result.Add(new BooleanDescriptor("isOk", GetClass()));

            result.Add( DescriptorFactory.Create("isOk", GetClass(), typeof(Boolean) ));
            return result;
        }




        private Type GetClass()
        {
            return typeof(DescriptorMapper);
        }
    }
}