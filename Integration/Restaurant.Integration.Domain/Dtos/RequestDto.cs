﻿using Restaurant.Integration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Integration.Domain.Dtos
{
    public class RequestDto<T> 
    {
        public ActionType ActionType { get; set; } = ActionType.GET;
        public string Url { get; set; }
        public T? Data { get; set; }
        public string? AccessToken { get; set; }
        public SystemLanguage Language { get; set; } = SystemLanguage.en_EN;
    }
}
