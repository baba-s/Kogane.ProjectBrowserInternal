using System.Reflection;
using UnityEditor;

namespace Kogane
{
    public static class ProjectBrowserInternal
    {
        public static void SetSearch( string searchString )
        {
            var assembly           = typeof( Editor ).Assembly;
            var projectBrowserType = assembly.GetType( "UnityEditor.ProjectBrowser" );
            var projectBrowser     = EditorWindow.GetWindow( projectBrowserType );

            var setSearchMethodInfo = projectBrowserType.GetMethod
            (
                name: "SetSearch",
                bindingAttr: BindingFlags.Public | BindingFlags.Instance,
                binder: null,
                types: new[] { typeof( string ) },
                modifiers: null
            );

            setSearchMethodInfo.Invoke
            (
                obj: projectBrowser,
                parameters: new object[] { searchString }
            );
        }
    }
}