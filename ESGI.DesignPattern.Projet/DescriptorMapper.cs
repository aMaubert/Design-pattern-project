using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{

    public interface GeneratorDescriptor
    {
        AttributeDescriptor generate(String field, Type mapperType, Type forType);
    }

    public class GeneratorDescriptorType : GeneratorDescriptor
    {
        public AttributeDescriptor generate(String field, Type mapperType, Type forType)
        {
            if (forType == typeof(Boolean))
            {
                return new BooleanDescriptor(field, mapperType);
            }
            else if (forType == typeof(User))
            {
                return new ReferenceDescriptor(field, mapperType, forType);
            }
            else
            {
                return new DefaultDescriptor(field, mapperType, forType);
            }
        }
    }

    class GeneratorDescriptorFieldName : GeneratorDescriptor
    {
        public AttributeDescriptor generate(String field, Type mapperType, Type forType)
        {
            if ( field.Contains("isOk")  ) //isOk, isActivated, isAdmin, etc...
            {
                return new BooleanDescriptor(field, mapperType);
            }
            else if (field.Contains("createdBy") || field.Contains("createdBy"))
            {
                return new ReferenceDescriptor(field, mapperType, forType);
            }
            else
            {
                return new DefaultDescriptor(field, mapperType, forType);
            }
        }
    }


    public class DescriptorMapper
    {
        public GeneratorDescriptor generatorDescriptor;

        public DescriptorMapper(GeneratorDescriptor generatorDescriptor)
        {
            this.generatorDescriptor = generatorDescriptor;
        }   
           
        public void Add(List<AttributeDescriptor> descriptors, String field, Type type)
        {
            AttributeDescriptor attributeDescriptor = generatorDescriptor.generate(field, GetClass(), type);
            descriptors.Add(attributeDescriptor) ;
        }

        protected List<AttributeDescriptor> CreateAttributeDescriptors() {
            var result = new List<AttributeDescriptor>();


            result.Add( generatorDescriptor.generate("remoteId", GetClass(), typeof(int)) );
            result.Add( generatorDescriptor.generate("createdDate", GetClass(), typeof(DateTime)) );
            result.Add( generatorDescriptor.generate("lastChangedDate", GetClass(), typeof(DateTime)) );
            result.Add( generatorDescriptor.generate("createdBy", GetClass(), typeof(User)) );
            result.Add( generatorDescriptor.generate("lastChangedBy", GetClass(), typeof(User)) );
            result.Add( generatorDescriptor.generate("optimisticLockVersion", GetClass(), typeof(int)) );
            result.Add( generatorDescriptor.generate("isOk", GetClass(), typeof(Boolean)) );


            return result;
        }

        private Type GetClass()
        {
            return typeof(DescriptorMapper);
        }
    }
}