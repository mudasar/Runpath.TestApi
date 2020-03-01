﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
