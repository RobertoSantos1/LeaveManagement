using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypesDetailsQueryTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetLeaveTypesDetailsQueryTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task GetLeaveTypeDetailsTest()
        {
            var handler = new GetLeaveTypeDetailsQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetLeaveTypeDetailsQuery(1), CancellationToken.None);

            result.ShouldBeOfType<LeaveTypeDetailsDto>();
        }
    }
}
