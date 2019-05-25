﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJsonSchema.Generation;

namespace NSwag.Generation.WebApi.Tests
{
    public class B
    {
        public C C { get; set; }
    }

    public class C { }

    [TestClass]
    public class TypesToSwaggerTests
    {
        [TestMethod]
        public async Task When_generating_multiple_types_then_they_are_appended_to_the_definitions()
        {
            //// Arrange
            var classNames = new[]
            {
                "NSwag.Generation.WebApi.Tests.B",
                "NSwag.Generation.WebApi.Tests.C"
            };

            //// Act
            var document = new OpenApiDocument();
            var settings = new JsonSchemaGeneratorSettings();
            var schemaResolver = new OpenApiSchemaResolver(document, settings);
            var generator = new JsonSchemaGenerator(settings);
            foreach (var className in classNames)
            {
                var type = typeof(TypesToSwaggerTests).Assembly.GetType(className);
                await generator.GenerateAsync(type, schemaResolver).ConfigureAwait(false);
            }
            var json = document.ToJson();

            //// Assert
            Assert.IsNotNull(json);
            Assert.AreEqual(2, document.Definitions.Count);
        }
    }
}