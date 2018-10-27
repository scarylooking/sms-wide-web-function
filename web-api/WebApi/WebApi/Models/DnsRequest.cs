using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Models
{
    public class DnsRequest
    {
        public DnsRequestType RequestType { get; set; }

        /// <summary>
        /// The payload of the request.
        /// For a lookup, this is a mobile number.
        /// For a registration, this is a path.
        /// </summary>
        public string Payload { get; set; }

        public static DnsRequest FromContent(string content)
        {
            if (content[3] != ' ')
            {
                throw new BadRequestException();
            }

            if (content.StartsWith("GET"))
            {
                return new DnsRequest
                {
                    RequestType = DnsRequestType.Resolve,
                    Payload = content.Substring(4)
                };
            }

            if (content.StartsWith("REG"))
            {
                return new DnsRequest
                {
                    RequestType = DnsRequestType.Register,
                    Payload = content.Substring(4)
                };
            }

            throw new BadRequestException();
        }
    }
}
