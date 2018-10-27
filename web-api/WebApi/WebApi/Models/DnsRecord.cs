using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Models
{
    public class DnsRecord : TableEntity
    {
        public static string Partition = nameof(DnsRecord);

        public string Address { get; set; }

        public DnsRecord(string domain, string address)
        {
            PartitionKey = Partition;
            RowKey = domain;
            Address = address;
        }
    }
}
