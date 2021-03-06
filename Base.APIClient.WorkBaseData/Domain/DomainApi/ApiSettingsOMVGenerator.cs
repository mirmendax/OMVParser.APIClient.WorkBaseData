using System;
using System.ComponentModel.DataAnnotations;

namespace Base.APIClient.WorkBaseData.Domain.DomainApi
{
    public class ApiSettingsOMVGenerator : BaseApi
    {
        [Display(Name = "Ссылка на генератор")]
        public Guid GeneratorId { get; set; }
        [Display(Name = "Первая точка по активной мощности")]
        public float P1 { get; set; }
        [Display(Name = "Вторая точка по активной мощности")]
        public float P2 { get; set; }
        [Display(Name = "Третья точка по активной мощности")]
        public float P3 { get; set; }
        [Display(Name = "Четвертая точка по активной мощности")]
        public float P4 { get; set; }

        [Display(Name = "Точка по реактивной мощности при 0 точке активной и напряжении 0.9")]
        public float QlP0 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 1 точке активной и напряжении 0.9")]
        public float QlP1 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 2 точке активной и напряжении 0.9")]
        public float QlP2 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 3 точке активной и напряжении 0.9")]
        public float QlP3 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 4 точке активной и напряжении 0.9")]
        public float QlP4 { get; set; }

        [Display(Name = "Точка по реактивной мощности при 0 точке активной и напряжении 1.0")]
        public float QmP0 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 1 точке активной и напряжении 1.0")]
        public float QmP1 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 2 точке активной и напряжении 1.0")]
        public float QmP2 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 3 точке активной и напряжении 1.0")]
        public float QmP3 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 4 точке активной и напряжении 1.0")]
        public float QmP4 { get; set; }

        [Display(Name = "Точка по реактивной мощности при 0 точке активной и напряжении 1.1")]
        public float QhP0 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 1 точке активной и напряжении 1.1")]
        public float QhP1 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 2 точке активной и напряжении 1.1")]
        public float QhP2 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 3 точке активной и напряжении 1.1")]
        public float QhP3 { get; set; }
        [Display(Name = "Точка по реактивной мощности при 4 точке активной и напряжении 1.1")]
        public float QhP4 { get; set; }
    }
}
