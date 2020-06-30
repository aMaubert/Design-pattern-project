﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    class DescriptorFactory
    {

        public static AttributeDescriptor Create(String field, Type mapperType, Type mappedFor)
        {

            if(mappedFor == typeof(Boolean) )
            {
                return new BooleanDescriptor(field, mapperType);
            } 
            else if(mappedFor == typeof(User) )
            {
                return new ReferenceDescriptor( field, mapperType, mappedFor);
            } else
            {
                return new DefaultDescriptor(field, mapperType, mappedFor);
            }
        }
    }
}
