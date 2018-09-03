using System;

namespace react.DTO
{
    public class ResponseAuthorization
    {
        public bool Success { get; set; }
        public int UserId { get; set; }
        public string Details {get;set;}
    }
}