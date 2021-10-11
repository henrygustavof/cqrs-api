using System;
using System.Collections.Generic;

namespace Project.Application.Consumes.Dto
{
    public class ConsumeDistrictDto
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public List<ConsumeMonthlyDto> Consumes { get; set; }
    }

    public class ConsumeMonthlyDto
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public double Consume { get; set; }

        public string DateOfFirstDayOfTheMonth { get; set; }
    }

    public class ConsumeDistrictMonthlyDto: ConsumeMonthlyDto
    {
        public Guid DistrictId { get; set; }
    }
}
