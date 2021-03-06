﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Enterprise.Dependency
{
    public class DependencyBootstrapper
    {
        /// <summary>
        /// scan interface types and theirs first implement type and register them into IoC container
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="registerAction">first Type:interface,second type:implement type</param>
        /// <returns>unmatched interface types</returns>
        public static IEnumerable<Type> Scan(IEnumerable<Assembly> assemblies,Action<Type,Type> registerAction)
        {
            var interfaceList = new List<Type>();
            var assemblyList = assemblies.ToList();

            assemblyList.ForEach(
                    a => interfaceList.AddRange(a.GetTypes().Where(t => t.GetTypeInfo().IsInterface || t.GetTypeInfo().IsAbstract)));
            assemblyList.ForEach(a =>
            {
                var types = a.GetTypes().Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract).ToList();
                types.ForEach(t =>
                {
                    var allInterfaces = t.GetInterfaces().ToList();
                    var interfaces = allInterfaces.Where(x => !allInterfaces.Any(y => y.GetInterfaces().Contains(x))).ToList();
                    if (interfaces.Any())
                        interfaces = ExcludeBaseInterfaces(t, interfaces).ToList();
                    interfaces.ForEach(i =>
                    {
                        foreach (var type in interfaceList.Where<Type>(m => m == i))
                        {
                                registerAction(type, t);
                                interfaceList.Remove(type);
                                break;
                        }
                    });
                });
            });

            return interfaceList;
        }

        private static IEnumerable<Type> ExcludeBaseInterfaces(Type t, IEnumerable<Type> interfaces)
        {
            var baseType = t.GetTypeInfo().BaseType;
            if (baseType != null)
            {
                interfaces = interfaces.Except<Type>(baseType.GetInterfaces()).ToList();
                return ExcludeBaseInterfaces(baseType, interfaces);
            }
            return interfaces;
        }
    }
}
