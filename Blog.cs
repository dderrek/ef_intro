﻿using EFGetStarted.Models;

namespace EFGetStarted
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; } = new();
    }
}
