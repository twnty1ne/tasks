using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Tasks.Application.Json;

namespace Tasks.Application.Requests
{
    public class CreateCommentRequest
    {
        [JsonConverter(typeof(JsonToByteArrayConverter))]
        public byte[] Content { get; set; }
        public byte CommentType { get; set; } 
    }
}
