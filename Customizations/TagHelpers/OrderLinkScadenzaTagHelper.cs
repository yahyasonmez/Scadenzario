using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Scadenzario.Models.InputModels.Scadenze;

namespace Scadenzario.Customizations.TagHelpers
{
    public class OrderLinkScadenzaTagHelper : AnchorTagHelper
    {
        public string OrderBy { get; set; }
        public ScadenzaListInputModel Input { get; set; }

        public OrderLinkScadenzaTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            //Imposto i valori del link
            RouteValues["search"] = Input.Search;
            RouteValues["orderby"] = OrderBy;
            RouteValues["ascending"] = (Input.OrderBy == OrderBy ? !Input.Ascending : Input.Ascending).ToString().ToLowerInvariant();
            
            //Faccio generare l'output all'AnchorTagHelper
            base.Process(context, output);

            //Aggiungo l'indicatore di direzione
            if (Input.OrderBy == OrderBy)
            {
                var direction = Input.Ascending ? "up" : "down";
                output.PostContent.SetHtmlContent($" <i class=\"fas fa-caret-{direction}\"></i>");
            }
        }
    }
}