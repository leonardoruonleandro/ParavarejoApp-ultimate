using ParavarejoApp1.ViewModels;
using System;
using System.ComponentModel;

namespace ParavarejoApp1.Models
{
    public class Item : PropertyChange
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string DescriptionCalculatedValue { get; set; }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        private double _calculatedValue;
        public double CalculatedValue
        {
            get { return _calculatedValue; }
            set
            {
                _calculatedValue = value;
                OnPropertyChanged(nameof(CalculatedValue));
            }
        }

        public LucroRealVariavel Variavel { get; set; }

        public bool HasValue { get { return Value != 0; } }

        public bool HasCalculatedValue { get { return CalculatedValue != 0; } }

        public bool IsReadOnly
        {
            get
            {
                bool isReadOnly = false;

                switch (this.Variavel)
                {
                    case LucroRealVariavel.PreçoDeCusto:
                    case LucroRealVariavel.LucroBruto:
                        isReadOnly = true;
                        break;
                    default:
                        break;
                }

                return isReadOnly;
            }
        }

        public bool IsValueEditable
        {
            get
            {
                bool isEditable = true;

                switch (this.Variavel)
                {
                    case LucroRealVariavel.PreçoDeCusto:
                    case LucroRealVariavel.LucroBruto:
                        isEditable = false;
                        break;
                    default:
                        break;
                }

                return isEditable;
            }
        }

    }


}