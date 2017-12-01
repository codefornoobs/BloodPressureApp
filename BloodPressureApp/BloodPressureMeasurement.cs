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
            return string.Format("High Value={0}, Low Value={1}, Inserted Date={2}",
                 HighValue, LowValue, InsertDate);
        }
    }
}