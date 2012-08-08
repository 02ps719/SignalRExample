using FubuMVC.Core;
using FubuMVC.WebForms;
using Interface.Actions.Home;

namespace Interface
{
    public class TestFubuRegistry : FubuRegistry
    {
        public TestFubuRegistry()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeClassesSuffixedWithController();

            // Policies
            Routes
                .IgnoreMethodsNamed("GET")
                .IgnoreControllerNamesEntirely()
                .IgnoreMethodSuffix("Html")
                .RootAtAssemblyNamespace()
                .IgnoreNamespaceText("actions")
                .HomeIs<IndexController>(x => x.Get());

            Import<WebFormsEngine>();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}