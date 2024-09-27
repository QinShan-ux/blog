using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using System.Xml.XPath;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Blog.Service.ApiService.Filter;

public class MySchemaFilter : ISchemaFilter
{
    private const string XmlCommentsFilePath = "Blog.Service.ApiService.xml";

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsClass)
        {
            Console.WriteLine(schema.Description);
        }
        if (context.MemberInfo != null)
        {
            var memberName = context.MemberInfo.Name;
            var xmlComments = LoadXmlComments();
            var memberXPath = $"/members/member[@name='P:{context.Type.FullName}.{memberName}' or @name='F:{context.Type.FullName}.{memberName}' or @name='M:{context.Type.FullName}.{memberName}']";
            Console.WriteLine(memberName + " -- : --" + memberXPath);
            var memberElement = xmlComments.CreateNavigator().SelectSingleNode(memberXPath);
            // if (memberElement != null)
            // {
            //     var summaryElement = memberElement.SelectSingleNode("summary");
            //     if (summaryElement != null)
            //     {
            //         schema.Description = summaryElement.Value.Trim();
            //     }
            // }
            schema.Description = "牛逼";
        }
    }

    private XPathDocument LoadXmlComments()
    {
        return new XPathDocument(XmlCommentsFilePath);
    }
}