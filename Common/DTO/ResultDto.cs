using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common.DTO
{
    public class ResultDto
    {
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
    }

    public class ResultDto<T>
    {
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
