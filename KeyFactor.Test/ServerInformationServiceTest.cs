using EasyCaching.Core;
using KeyFactor.Application;
using KeyFactorTest;
using Moq;
using System;
using System.Data.Common;

namespace KeyFactor.Test
{
    public class ServerInformationServiceTest
    {
        private Mock<IEasyCachingProvider> _provider;
        private IRemoteServerInformationService _remoteService = new FakeRemoteServerService();
        private IServerInformationService _service;
        
        public DataRecord[] InitializeData()
        {
            var cacheData = new List<DataRecord>();

            int index = 0;
            for (index = 0; index < 100; index++)
            {
                cacheData.Add(new DataRecord()
                {
                    ID = index,
                    CreationDate = FakeServiceDataHelper.getCurrentTime(),
                    Data = new byte[12]
                });
            }

            return cacheData.ToArray();
        }

        [Fact]
        public void Test_Empty_RemoteServer_Response()
        {
            _provider = new Mock<IEasyCachingProvider>(); 
            var emptyResponseService = new Mock<IRemoteServerInformationService>();
            _provider.Setup(_ => _.Get<DataRecord[]>("DataRecords")).Returns(CacheValue<DataRecord[]>.NoValue);
            emptyResponseService.Setup(_ => _.getRemoteRecords(FakeServiceDataHelper.getMinValue(), FakeServiceDataHelper.getCurrentTime(), 50)).Returns(new DataRecord[0]);
            _service = new ServerInformationService(_provider.Object, emptyResponseService.Object);
            var result = _service.getRecords(1, 50);

            Assert.Empty(result);
        }

        [Fact]
        public void Test_Empty_Cache_And_Not_Empty_RemoteServer_Response()
        {
            _provider = new Mock<IEasyCachingProvider>();

            _provider.Setup(_ => _.Get<DataRecord[]>("DataRecords")).Returns(CacheValue<DataRecord[]>.NoValue);
            
            _service = new ServerInformationService(_provider.Object, _remoteService);

            var result = _service.getRecords(1, 50);

            Assert.NotEmpty(result);
            Assert.Equal(50, result.Length);
        }

        [Fact]
        public void Test_Not_Empty_Cache_And_Not_Empty_RemoteServer_Response()
        {
            _provider = new Mock<IEasyCachingProvider>();
            _provider.Setup(_ => _.Get<DataRecord[]>("DataRecords"))
                .Returns(new CacheValue<DataRecord[]>(_remoteService.getRemoteRecords(FakeServiceDataHelper.getMinValue(), FakeServiceDataHelper.getCurrentTime(), 50), true));
            
            _service = new ServerInformationService(_provider.Object, _remoteService);
            var result = _service.getRecords(2, 50);
            Assert.NotEmpty(result);
            Assert.Equal(50, result.Length);
        }
    }
}