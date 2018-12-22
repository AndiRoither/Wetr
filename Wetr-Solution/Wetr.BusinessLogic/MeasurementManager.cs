﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wetr.BusinessLogic.Interface;
using Wetr.Dal.Factory;
using Wetr.Dal.Interface;
using Wetr.Domain;

namespace Wetr.BusinessLogic
{
    public class MeasurementManager : IMeasurementManager
    {
        private IMeasurementDao measurementDao;
        public MeasurementManager(IMeasurementDao measurementDao)
        {
            this.measurementDao = measurementDao;

      
        }

        public async Task<bool> AddMeasurement(Measurement m)
        {
            return await measurementDao.InsertAsync(m);
        }

        #region functions



        public async Task<double[]> GetDashbardTemperaturesAsync()
        {
            try
            {
                return await measurementDao.GetDayAverageOfLastXDaysAsync((int)EMeasurementType.Temperature, 7);
            }
            catch (Common.Dal.Ado.MySqlException ex)
            {
                throw new BusinessSqlException(ex.Message, ex.InnerException);
            }
        }

        public async Task<double[]> GetDashboardRainValuesAsync()
        {
            try
            {
                return await measurementDao.GetDayAverageOfLastXDaysAsync((int)EMeasurementType.Rain, 7);
            }
            catch (Common.Dal.Ado.MySqlException ex)
            {
                throw new BusinessSqlException(ex.Message, ex.InnerException);
            }
        }

        public async Task<long> GetNumberOfMeasurementsAsync()
        {
            try
            {
                return await measurementDao.GetTotalNumberOfMeasurementsAsync();
            }
            catch (Common.Dal.Ado.MySqlException ex)
            {
                throw new BusinessSqlException(ex.Message, ex.InnerException);
            }
        }

        public async Task<long> GetNumberOfMeasurementsOfWeekAsync()
        {
            try
            {
                return await measurementDao.GetNumberOfMeasurementsFromTheLastXDaysAsync(7);
            }
            catch (Common.Dal.Ado.MySqlException ex)
            {
                throw new BusinessSqlException(ex.Message, ex.InnerException);
            }
        }

        public async Task<double[]> GetQueryResult(DateTime start, DateTime end, int measurementTypeId, int reductionTypeId, int groupingTypeId, List<Station> stations, Community community)
        {
            return await measurementDao.GetQueryResult(start, end, measurementTypeId, reductionTypeId, groupingTypeId,  stations, community);
        }

        public async Task<double[]> GetQueryResult(DateTime start, DateTime end, int measurementTypeId, int reductionTypeId, int groupingTypeId, List<Station> stations, decimal lat, decimal lon, int radius)
        {
            return await measurementDao.GetQueryResult(start, end, measurementTypeId, reductionTypeId, groupingTypeId, stations, lat, lon, radius);
        }

        #endregion functions
    }
}