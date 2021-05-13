﻿using Core.Entities;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }


}
