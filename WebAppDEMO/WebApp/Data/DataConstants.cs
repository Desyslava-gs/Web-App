using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public class DataConstants
    {
        public const int CarMakeMaxLength = 20;
        public const int CarModelMaxLength = 30;
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2100;

        public const int CarPlateNumberMaxLength = 8;
        public const int CarVinNumberMaxLength = 50;
        public const int CarColorMaxLength = 10;

        public const int CarMakeMinLength = 2;
        public const int CarModelMinLength = 2;
        public const int CarColorMinLength = 3;
        public const int CarVinNumberMinLength = 6;
        public const int CarDescriptionMinLength = 4;
    }
}
