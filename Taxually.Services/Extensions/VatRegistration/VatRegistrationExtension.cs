using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Taxually.Models;
using Taxually.Models.Models.Response;

namespace Taxually.Services.Extensions.VatRegistrationExtension
{
    public static class VatRegistrationExtension
    {
        public static VatResponse<string> GermanVat(this VatRegistration request)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistration));
                serializer.Serialize(stringwriter, request);
                var xml = stringwriter.ToString();

                return new VatResponse<string> { Payload = xml, QueueName = "vat-registration-xml" };
            }
        }

        public static VatResponse<byte[]> FranceVat(this VatRegistration request)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");

            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            return new VatResponse<byte[]> { Payload = csv, QueueName = "vat-registration-csv" };
        }
    }
}
