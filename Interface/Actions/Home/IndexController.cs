using FubuMVC.WebForms;

namespace Interface.Actions.Home
{
    public class IndexController
    {
         public IndexModel Get()
         {
             return new IndexModel();
         }
    }

    public class IndexModel{}
    public class Index : FubuPage<IndexModel> {}
}