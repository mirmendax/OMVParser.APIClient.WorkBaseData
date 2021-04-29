namespace Base.APIClient.WorkBaseData.Domain.DomainApi
{
    public class ApiGenerator : BaseApi
    {
        public int Number { get; set; }
        public string TypeGenerator { get; set; }
        public float PowerFull { get; set; }
        public float PowerActive { get; set; }
        public float PowerReactive { get; set; }
        public float CurrentGenerator { get; set; }
        public float CurrentRotor { get; set; }
        public float VoltageGenerator { get; set; }
        public float VoltageRotor { get; set; }
        public float KTTGeneratora { get; set; }
        public int NumberBlock { get; set; }
    }
}
