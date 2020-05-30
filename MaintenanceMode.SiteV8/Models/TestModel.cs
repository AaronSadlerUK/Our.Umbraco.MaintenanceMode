using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace MaintenanceMode.SiteV8.Models
{
    public class TestModel : ContentModel
    {
        public TestModel(IPublishedContent content) : base(content)
        {
        }
    }
}