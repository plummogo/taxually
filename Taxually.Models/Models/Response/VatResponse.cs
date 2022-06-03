namespace Taxually.Models.Models.Response
{
    public class VatResponse<TPayload>
    {
        public string QueueName { get; set; }
        public TPayload Payload { get; set; }
    }
}
