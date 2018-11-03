using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OptLib.Identity.Web.Helper
{
    public static class LabelExtensions
    {
        public static string Label(this HtmlHelper helper, string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }
        public class BikeViewModel
        {
            internal string imageSource;
            public string ButtonText { get; internal set; }
            public object ImageName { get; internal set; }
        }
        public static IHtmlString ImageUpload(this HtmlHelper<BikeViewModel> htmlHelper, BikeViewModel viewModel)
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("pull-left upload-img-wrapper");
            var label = new TagBuilder("label");
            label.AddCssClass("upload-img");
            label.MergeAttribute("data-content", viewModel.ButtonText);

            var image = new TagBuilder("img");
            image.AddCssClass("img-responsive");
            image.MergeAttribute("src", viewModel.imageSource);
            image.MergeAttribute("width", "250");
            image.MergeAttribute("height", "250");

            var textbox = InputExtensions.TextBoxFor(htmlHelper, m => m.ImageName, new { type = "file", style = "display:none" });

            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append(label.ToString(TagRenderMode.StartTag));
            htmlBuilder.Append(image.ToString(TagRenderMode.Normal));
            htmlBuilder.Append(label.ToString(TagRenderMode.EndTag));
            htmlBuilder.Append(textbox.ToHtmlString());
            outerDiv.InnerHtml = htmlBuilder.ToString();
            var html = outerDiv.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(html);
        }

    }
    public class LabelHelper
    {
        public static string Label(string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }
    }
}
