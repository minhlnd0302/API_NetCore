using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOModels
{
    public class CommentDTO
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? ProductId { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }

        public int Ratting { get; set; }
    }
}
