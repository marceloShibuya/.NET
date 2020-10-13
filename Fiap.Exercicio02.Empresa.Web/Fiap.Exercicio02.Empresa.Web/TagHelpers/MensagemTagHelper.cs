using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public String Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "alert alert-sucess");
                output.Content.SetContent(Texto);
            }
        }
    }
}
