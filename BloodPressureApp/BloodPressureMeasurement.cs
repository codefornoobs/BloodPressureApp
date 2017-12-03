using SQLite;
using System;

namespace BloodPressureApp
{
    class BloodPressureMeasurement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string HighValue { get; set; }

        public string LowValue { get; set; }
        public DateTime InsertDate { get; set; }

        public BloodPressureMeasurement()
        {

        }
        public override string ToString()
        {
            return string.Format("{0:dddd, d MMMM, yyyy}\n   Blood Pressure\n      Low:  {1}\n      High: {2}", InsertDate, HighValue, LowValue);
        }
    }
}