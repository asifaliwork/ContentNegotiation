using ContentNegotiation.Models.Items;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace ContentNegotiation.Extension
{
    public class TextFormat : TextOutputFormatter
    {
        public TextFormat()
        {
            SupportedMediaTypes.Add("text/html");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "text/html"; 
            var data = context.Object as IEnumerable<Item>;
            using (var writer = new StreamWriter(response.Body, Encoding.UTF8))
            {          
                await writer.WriteAsync("<html><body><h1>Items</h1><ul>");
                if (data != null)
                {
                    foreach (var product in data)
                    {             
                        await writer.WriteAsync($"<br><li>{product.Id} <br> - {product.ItemName} <br>  - ${product.Price} <br>  - {product.Message} <br> </li>");
                    }
                }
                else
                {
                    await writer.WriteAsync("<li>No items available</li>");
                }
                await writer.WriteAsync("</ul></body></html>");
            }
        }
    }
}







