using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tasks.Application.Json;

namespace Tasks.Application.Requests
{
    public class CreateTaskRequest
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [JsonConverter(typeof(JsonToByteArrayConverter))]
        public byte[] Description { get; set; }
    }
}
