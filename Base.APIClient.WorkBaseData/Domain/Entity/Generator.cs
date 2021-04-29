using System.ComponentModel.DataAnnotations;

namespace Base.APIClient.WorkBaseData.Domain.Entity
{
    public class Generator : BaseEntity
    {
        [Display(Name = "Номер генератора")]
        public virtual int Number { get; set; }
        [Display(Name = "Тип генератора")]
        public virtual string TypeGenerator { get; set; }
        [Display(Name = "Полная мощность")]
        public float PowerFull { get; set; }
        [Display(Name = "Активная мощность")]
        public float PowerActive { get; set; }
        [Display(Name = "Реактивная мощность")]
        public float PowerReactive { get; set; }
        [Display(Name = "Ток статора")]
        public float CurrentGenerator { get; set; }
        [Display(Name = "Ток ротора")]
        public float CurrentRotor { get; set; }
        [Display(Name = "Напряжение статора")]
        public float VoltageGenerator { get; set; }
        [Display(Name = "Напряжение ротора")]
        public float VoltageRotor { get; set; }
        [Display(Name = "Коэффициент трансформатора тока статора")]
        public float KTTGeneratora { get; set; }
        [Display(Name = "Номер блока")]
        public int NumberBlock { get; set; }

        public Generator() : base() { }


    }
}
