using SQLite;
using System;

namespace BloodPressureApp
{
    class BlodPressureMeasurement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string HighValue { get; set; }

        public string LowValue { get; set; }
        public DateTime InsertDate { get; set; }

        public BlodPressureMeasurement()
        {

        }
        public override string ToString()
        {
            return string.Format("[Person: ID={0}, HighValue={1}, LowValue={2}, InsertDate={3}]",
                ID, HighValue, LowValue, InsertDate);
        }
    }
}