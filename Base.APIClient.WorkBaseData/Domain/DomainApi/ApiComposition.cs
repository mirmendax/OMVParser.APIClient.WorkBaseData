using System;
using System.ComponentModel.DataAnnotations;

namespace Base.APIClient.WorkBaseData.Domain.DomainApi
{
    public class ApiComposition : BaseApi
    {
        [Display(Name = "Ссылка на генератор")]
        public Guid GeneratorId { get; set; }
        [Display(Name = "АЩУ Панель постоянного тока")]
        public string DCPanel { get; set; }
        [Display(Name = "АЩУ Панель оператора")]
        public string OperatorPanel { get; set; }
        [Display(Name = "АЩУ Панель АСКУЭ")]
        public string ASKUEPanel { get; set; }

        [Display(Name = "АЩУ Панель МПРЗ")]
        public string MRPPanel { get; set; }

        [Display(Name = "ЩПТ")]
        public string DCBoard { get; set; }
        [Display(Name = "АНВ")]
        public string DCFuseNumber { get; set; }
        [Display(Name = "Номер Накладок отключения блока")]
        public string PadOffBlock { get; set; }
        [Display(Name = "Описание Накладок отключения блока")]
        public string PadOffBlockName { get; set; }
        [Display(Name = "Номер накладок отключенияя выключателя")]
        public string PadOffSwitch { get; set; }
        [Display(Name = "Описание накладок отключенияя выключателя")]
        public string PadOffSwitchName { get; set; }
        [Display(Name = "Номер накладок ускорения МТЗ")]
        public string PadAccelerationMTZ { get; set; }
        [Display(Name = "Описание накладок ускорения МТЗ")]
        public string PadAccelerationMTZName { get; set; }
        [Display(Name = "Номер накладки ДЗТ блока")]
        public string PadDZTName { get; set; }
        [Display(Name = "Панель установки накладки ДЗТ блока")]
        public string PanelDZTBPad { get; set; }
        [Display(Name = "Номер испытательного блока ДЗТ блока (плечо генератора)")]
        public string TestBlockDZTName { get; set; }
        [Display(Name = "Панель установки ИБ ДЗТ блока (плечо генератора)")]
        public string PanelDZTTestBlock { get; set; }
        [Display(Name = "Автоматы цепей напряжения 1ТН")]
        public string CircuitBreakersTV1 { get; set; }
        [Display(Name = "ИБ цепей напряжения 1ТН")]
        public string TestBlocksTV1 { get; set; }
        [Display(Name = "Автоматы цепей напряжения 2ТН")]
        public string CircuitBreakersTV2 { get; set; }
        [Display(Name = "ИБ цепей напряжения 2ТН")]
        public string TestBlocksTV2 { get; set; }
    }
}
