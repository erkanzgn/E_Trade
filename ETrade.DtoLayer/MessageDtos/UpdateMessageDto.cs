﻿namespace ETrade.DtoLayer.MessageDtos
{
    public class UpdateMessageDto
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string? SenderName { get; set; }
        public string ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
