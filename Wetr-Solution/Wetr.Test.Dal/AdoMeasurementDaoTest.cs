﻿using Common.Dal.Ado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wetr.Dal.Ado;
using Wetr.Dal.Factory;
using Wetr.Dal.Interface;
using Wetr.Domain;

namespace Wetr.Test.Dal
{
    [TestClass]
    public class AdoMeasurementDaoTest : DaoBaseTest
    {
        private static AdoFactory factory = AdoFactory.Instance;
        private static readonly IMeasurementDao measurementDao = factory.GetMeasurementDao();
        private static readonly IStationDao stationDao = factory.GetStationDao();
        private static readonly IUserDao userDao = factory.GetUserDao();
        private static readonly ICountryDao countryDao = factory.GetCountryDao();
        private static readonly IProvinceDao provinceDao = factory.GetProvinceDao();
        private static readonly ICommunityDao communityDao = factory.GetCommunityDao();
        private static readonly IDistrictDao districtDao = factory.GetDistrictDao();
        private static readonly IAddressDao addressDao = factory.GetAddressDao();
        private static readonly IStationTypeDao stationTypeDao = factory.GetStationTypeDao();
        private static readonly IMeasurementTypeDao measurementTypeDao = factory.GetMeasurementTypeDao();
        private static readonly IUnitDao unitDao = factory.GetUnitDao();

        private static IList<Measurement> measurements = new List<Measurement>();

        [ClassInitialize]
        public static async Task ClassInitializeAsync(TestContext context)
        {
            User user = new User()
            {
                UserId = 23,
                FirstName = "Daniel",
                LastName = "Englisch",
                Email = "daniel@englis.ch",
                Password = "dhd36d36f68xj92"
            };

            await userDao.InsertAsync(user);

            Country country = new Country
            {
                CountryId = 33,
                Name = "MyCountry"

            };

            await countryDao.InsertAsync(country);

            Province province = new Province
            {
                ProvinceId = 66,
                CountryId = country.CountryId,
                Name = "MyProvince"
            };

            await provinceDao.InsertAsync(province);

            District district = new District
            {
                DistrictId = 54,
                ProvinceId = province.ProvinceId,
                Name = "MyDistrict"
            };

            await districtDao.InsertAsync(district);

            Community community = new Community
            {
                CommunityId = 74,
                DistrictId = district.DistrictId,
                Name = "MyCommunity"
            };

            await communityDao.InsertAsync(community);

            Address address = new Address
            {
                AddressId = 93,
                CommunityId = community.CommunityId,
                Location = "Waidhofnerstraße 34a",
                Zip = "332A"
            };

            await addressDao.InsertAsync(address);

            StationType stationType = new StationType
            {
                StationTypeId = 83,
                Name = "DeluxeStation"
            };

            await stationTypeDao.InsertAsync(stationType);

            Station station = new Station
            {
                StationId = 32,
                UserId = user.UserId,
                AddressId = address.AddressId,
                Name = "TemperaturStation",
                Latitude = 233.323M,
                Longitude = 32323.3333M,
                StationTypeId = stationType.StationTypeId
            };

            await stationDao.InsertAsync(station);

            MeasurementType measurementType = new MeasurementType
            {
                MeasurementTypeId = 43,
                Name = "Temperatur"
            };

            await measurementTypeDao.InsertAsync(measurementType);

            Unit unit = new Unit
            {
                UnitId = 34,
                Name = "Celcius"
            };

            await unitDao.InsertAsync(unit);

            Measurement m1 = new Measurement
            {
                MeasurementId = 44,
                MeasurementTypeId = measurementType.MeasurementTypeId,
                StationId = station.StationId,
                Value = 23.3,
                TimesStamp = DateTime.Now,
                UnitId = unit.UnitId
            };

            Measurement m2 = new Measurement
            {
                MeasurementId = 45,
                MeasurementTypeId = measurementType.MeasurementTypeId,
                StationId = station.StationId,
                Value = -0.3,
                TimesStamp = DateTime.Now,
                UnitId = unit.UnitId
            };

            Measurement m3 = new Measurement
            {
                MeasurementId = 46,
                MeasurementTypeId = measurementType.MeasurementTypeId,
                StationId = station.StationId,
                Value = 12.85,
                TimesStamp = DateTime.Now,
                UnitId = unit.UnitId
            };

            measurements.Add(m1);
            measurements.Add(m2);
            measurements.Add(m3);

            foreach (var m in measurements)
                await measurementDao.InsertAsync(m);

        }

        [ClassCleanup]
        public static async Task ClassCleanupAsync()
        {
            foreach (var m in measurements)
                await measurementDao.DeleteAsync(m.MeasurementId);

            await unitDao.DeleteAsync(34);
            await measurementTypeDao.DeleteAsync(43);
            await stationDao.DeleteAsync(32);
            await stationTypeDao.DeleteAsync(83);
            await addressDao.DeleteAsync(93);
            await communityDao.DeleteAsync(74);
            await districtDao.DeleteAsync(54);
            await provinceDao.DeleteAsync(66);
            await countryDao.DeleteAsync(33);
            await userDao.DeleteAsync(23);
        }

        [TestMethod]
        public async Task TestFindByStationIdAsync()
        {
            IEnumerable<Measurement> fetched = await measurementDao.FindByStationIdAsync(32);
            foreach(var m in measurements){
                CollectionAssert.Contains(fetched.ToList(), m);
            }

        }

        [TestMethod]
        public async Task TestFindByMeasurementTypeIdAsync()
        {
            throw new System.NotImplementedException();

        }

        [TestMethod]
        public async Task TestFindByUnitIdAsync()
        {
            throw new System.NotImplementedException();

        }

        [TestMethod]
        public async override Task TestFindByIdAsync()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public async override Task TestFindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public async override Task TestUpdateAsync()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public async override Task TestDeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public async override Task TestInsertAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}