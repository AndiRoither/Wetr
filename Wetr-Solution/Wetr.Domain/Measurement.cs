﻿using System;

namespace Wetr.Domain
{
    public class Measurement
    {

        public int MeasurementId { get; set; }
        public int StationId { get; set; }
        public int MeasurementTypeId { get; set; }
        public int UnitId { get; set; }
        public double Value { get; set; }
        public DateTime TimesStamp { get; set; }

        public override string ToString() =>
            $"[{MeasurementId}] {StationId} {MeasurementTypeId} {UnitId} {Value} {TimesStamp}";

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Measurement temp = (Measurement)obj;
                return ((this.MeasurementId == temp.MeasurementId) && (this.StationId == temp.StationId) 
                    && (this.MeasurementTypeId == temp.MeasurementTypeId) && (this.UnitId == temp.UnitId)
                    && (this.Value == temp.Value));
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -510074534;
            hashCode = hashCode * -1521134295 + MeasurementId.GetHashCode();
            hashCode = hashCode * -1521134295 + StationId.GetHashCode();
            hashCode = hashCode * -1521134295 + MeasurementTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + UnitId.GetHashCode();
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + TimesStamp.GetHashCode();
            return hashCode;
        }
    }
}