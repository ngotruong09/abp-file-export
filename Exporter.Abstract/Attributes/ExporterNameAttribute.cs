﻿using JetBrains.Annotations;
using System;
using System.Linq;

namespace Exporter.Abstract.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExporterNameAttribute : Attribute, IExporterNameProvider
    {
        public virtual string ExporterName { get; }
        public ExporterNameAttribute([NotNull] string exporterName = null)
        {
            ExporterName = exporterName;
        }
        public static string GetExporterNameOrDefault([NotNull] Type type)
        {
            return type.GetCustomAttributes(true).OfType<IExporterNameProvider>()
                .FirstOrDefault()?.GetExporterName(type) ?? "EXCEL";
        }
        public virtual string GetExporterName(Type eventType)
        {
            return ExporterName;
        }
    }
}
