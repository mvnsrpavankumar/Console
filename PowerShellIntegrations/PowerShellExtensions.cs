using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.CompilerServices;
using Microsoft.PowerShell.Commands;
using Sitecore.Shell.Applications.WebEdit.Commands;

namespace Cognifide.PowerShell.PowerShellIntegrations
{
    static internal class PowerShellExtensions
    {
        public static object BaseObject(this object obj)
        {
            while ((obj is PSObject))
            {
                obj = (obj as PSObject).ImmediateBaseObject;
            }
            return obj;
        }

        public static List<T> BaseList<T>(this object enumarable) where T : class
        {
            List<T> newList = new List<T>();
            if (enumarable is IEnumerable)
            {
                foreach (var val in enumarable as IEnumerable)
                {
                    object newVal = val.BaseObject();
                    if (newVal is T)
                    {
                        newList.Add(newVal as T);
                    }
                }
            }
            return newList;
        }
    }
}