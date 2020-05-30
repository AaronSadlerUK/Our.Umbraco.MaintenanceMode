using System.Web.Mvc;
using MaintenanceMode.SiteV8.Models;
using Umbraco.Web.Models;

public class TestPageController : Umbraco.Web.Mvc.RenderMvcController
{
    // Any request for the 'ProductAmpPage' template will be handled by this Action
    public ActionResult TestTemplatePage(ContentModel contentModel)
    {
        var model = new TestModel(contentModel.Content);
        // Create AMP specific content here...
        return CurrentTemplate(model);
    }
    // All other request, eg the ProductPage template will be handled by the default 'Index' action
    public override ActionResult Index(ContentModel contentModel)
    {
        // you are in control here!

        // return a 'model' to the selected template/view for this page.
        return CurrentTemplate(contentModel);
    }
}