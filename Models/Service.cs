using System;

namespace WebApplication1.Models
{
    [Serializable]
    public class Service
    {
        public string Name { get; set; }
        public string Port { get; set; }
        public string Maintainer { get; set; }
        public string[] Labels { get; set; }
        public int Id { get; set; }
    }
}