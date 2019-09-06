using System;
using System.Linq;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TelegramBot.Common
{
    /// <summary>
    ///     Фильтр для вывода имени членов перечислений
    /// </summary>
    public class EnumDescriptionFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var schemaRegistryDefinition in context.SchemaRepository.Schemas)
            {
                foreach (var property in schemaRegistryDefinition.Value.Properties)
                {
                    if (property.Value.Enum != null)
                    {
                        ModifyEnums(property.Value);
                    }
                }

                if (schemaRegistryDefinition.Value.Enum != null)
                {
                    ModifyEnums(schemaRegistryDefinition.Value);
                }
            }
        }

        private static void ModifyEnums(OpenApiSchema schema)
        {
            var values = schema.Enum.Select(en =>
            {
                var enType = en.GetType();
                if (!enType.IsEnum)
                    return string.Empty;

                var enu = (Enum)en;
                return $"{Convert.ChangeType(enu, enu.GetTypeCode())} = {Enum.GetName(enType, en)}";
            });

            var sb = new StringBuilder();
            foreach (var value in values)
            {
                sb.AppendLine(value);
            }
            schema.Description = sb.ToString();
        }
    }
}
