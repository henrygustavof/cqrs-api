using System;
using System.Collections.Generic;

namespace Project.Domain.Entity
{
    public class Zone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<District> Districts { get; set; }
    }

    public class District
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
