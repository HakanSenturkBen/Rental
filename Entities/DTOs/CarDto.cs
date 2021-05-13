using Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice { get; set; }

        public override string ToString() => $"id: {CarId}; Marka: {BrandName}; Renk: {ColorName}; Araç Yaşı: {ModelYear}; Günlük Ücreti: {DailyPrice}";

    }
}
