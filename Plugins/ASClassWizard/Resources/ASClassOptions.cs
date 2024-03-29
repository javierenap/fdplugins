﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ASClassWizard.Resources
{
    public class AS3ClassOptions
    {
        public bool createInheritedMethods;
        public bool createConstructor;
        public string superClass;
        public List<string> interfaces;
        public bool isPublic;
        public bool isDynamic;
        public bool isFinal;
        public string Language;

        public AS3ClassOptions(
            string language,
            string super_class, 
            List<string> Interfaces, 
            bool is_public, 
            bool is_dynamic, 
            bool is_final, 
            bool create_inherited, 
            bool create_constructor)
        {
            Language = language;
            createConstructor = create_constructor;
            createInheritedMethods = create_inherited;
            superClass = super_class;
            interfaces = Interfaces;
            isPublic = is_public;
            isDynamic = is_dynamic;
            isFinal = is_final;

        }
    }
}
