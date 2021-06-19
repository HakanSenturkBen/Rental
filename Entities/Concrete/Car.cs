using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public bool Active { get; set; }

        public override string ToString() => $"id:{Id} brandId: {BrandId} ColorId: {ColorId} Model year: {ModelYear} Daily price: {DailyPrice} {Description} {CreateDate}";
    }
}
