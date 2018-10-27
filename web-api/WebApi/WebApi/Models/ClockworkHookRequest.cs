using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Models
{
    public class ClockworkHookRequest
    {
        /// <summary>
        /// Your Clockwork mobile number or shortcode
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Phone number that sent the message, this will be in international format e.g. 441625588620.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Text of the message
        /// </summary>
        public string Content { get; set; }

        public static ClockworkHookRequest FromQueryString(IQueryCollection query)
        {
            var to = query["to"];
            var from = query["from"];
            var content = query["content"];

            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (string.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException(nameof(from));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            return new ClockworkHookRequest
            {
                To = to,
                From = from,
                Content = content
            };
        }
    }
}
