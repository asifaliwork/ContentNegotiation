using ContentNegotiation.Models.Items;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections;
using System.Text;

namespace ContentNegotiation.Extension
{
    public class TextPlain : TextOutputFormatter
    {
        public TextPlain()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {

            var response = context.HttpContext.Response;

            var buffer = new StringBuilder();

            var data = context.Object as IEnumerable<Item>;

            if (data != null)
            {
                foreach (var record in data)
                {

                    buffer.Append("ID:  ").Append(record.Id).Append("  Item Name:  ").Append(record.ItemName).Append("    Price:  ").Append(record.Price).Append("    Message:  ").Append(record.Message);
                    //buffer.Append(string.Join("", record));

                    // buffer.AppendLine();
                }


            }

            await response.WriteAsync(buffer.ToString());
        }
    }
}
