using Covid19.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Domain.Entities
{
    public class ChatItem : AuditableEntity
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
    }
}
