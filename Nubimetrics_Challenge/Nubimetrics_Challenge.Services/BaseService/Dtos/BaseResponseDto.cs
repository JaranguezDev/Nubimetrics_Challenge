using Newtonsoft.Json;

namespace Nubimetrics_Challenge.Services.BaseService.Dtos
{
    public class BaseResponseDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; } = 200;

        [JsonProperty("cause")]
        public object[] Cause { get; set; }
    }
}