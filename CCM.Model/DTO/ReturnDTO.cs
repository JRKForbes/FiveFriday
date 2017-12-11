using System;

namespace CCM.Model
{
    public class ReturnDTO
    {
        public ReturnDTO()
        {
            IsError = false;
        }
        public string Result { get; set; }
        public bool IsError { get; set; }
        public string Error { get; set; }
        public string StackTrace { get; set; }
        public string InnerStackTrace { get; set; }
        public string Source { get; set; }
        public string InnerSource { get; set; }
        public long Id { get; set; }
    }
}
