namespace Project.Application.Consumes.Dto
{
    public class ConsumeDeviceMonthlyDto
    {
        public int YearNumber { get; set; }
        public int MonthNumber { get; set; }
        public double Consume { get; set; }
        public string DateOfFirstDayOfTheMonth { get; set; }
    }
}
