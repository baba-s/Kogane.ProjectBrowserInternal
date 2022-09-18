using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Kogane
{
    public static class ProjectBrowserInternal
    {
        private static readonly Type PROJECT_BROWSER_TYPE = typeof( Editor ).Assembly.GetType( "UnityEditor.ProjectBrowser" );

        public static string SearchFieldText
        {
            get
            {
                var projectBrowser = GetProjectBrowser();

                var fieldInfo = PROJECT_BROWSER_TYPE.GetField
                (
                    name: "m_SearchFieldText",
                    bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance
                );

                return ( string )fieldInfo.GetValue( projectBrowser );
            }
        }

        public static void SetSearch( string searchString )
        {
            var projectBrowser = GetProjectBrowser();

            var methodInfo = PROJECT_BROWSER_TYPE.GetMethod
            (
                name: "SetSearch",
                bindingAttr: BindingFlags.Public | BindingFlags.Instance,
                binder: null,
                types: new[] { typeof( string ) },
                modifiers: null
            );

            methodInfo.Invoke
            (
                obj: projectBrowser,
                parameters: new object[] { searchString }
            );
        }

        private static EditorWindow GetProjectBrowser()
        {
            return Resources
                    .FindObjectsOfTypeAll<EditorWindow>()
                    .FirstOrDefault( x => x.GetType().ToString() == "UnityEditor.ProjectBrowser" )
                ;
        }
    }
}