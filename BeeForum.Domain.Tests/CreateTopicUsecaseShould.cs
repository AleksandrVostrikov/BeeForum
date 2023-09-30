using BeeForum.Domain.Exceptions;
using BeeForum.Domain.Models;
using BeeForum.Domain.UseCases.CreateTopic;
using BeeForum.Storage.Data;
using BeeForum.Storage.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Language.Flow;

namespace BeeForum.Domain.Tests
{
    public class CreateTopicUsecaseShould
    {
        private readonly ISetup<IMomenProvider, DateTimeOffset> _getNowSetup;
        private readonly CreateTopicUseCase _sut;
        private readonly ISetup<IGuidFactory, Guid> _createIdSetup;
        private readonly BeeForumDbContext _forumDbContext;
        
        public CreateTopicUsecaseShould()
        {
            var dbcontextOptionsBuilder = new DbContextOptionsBuilder<BeeForumDbContext>()
                .UseInMemoryDatabase(nameof(CreateTopicUsecaseShould));
            _forumDbContext = new BeeForumDbContext(dbcontextOptionsBuilder.Options);

            var guidFactory = new Mock<IGuidFactory>();
            _createIdSetup = guidFactory.Setup(f => f.Create());

            var momentProvider = new Mock<IMomenProvider>();
            _getNowSetup = momentProvider.Setup(p => p.Now);

            _sut = new CreateTopicUseCase(_forumDbContext, guidFactory.Object, momentProvider.Object);
        }
        [Fact]
        public async Task ThrowForumNotFoundException_WhenNoMatchingForum()
        {
            await _forumDbContext.Forums.AddAsync(new Storage.Models.Forum
            {
                Id = Guid.Parse("88bcbec9-ca94-4606-9eff-521705d15b3b"),
                Title = "Test"
            });
            await _forumDbContext.SaveChangesAsync();

            var forumId = Guid.Parse("61473223-ec8a-4ffd-8f64-df58cc75b510");
            var authorId = Guid.Parse("70c565da-de2b-40a4-8105-1935b3516393");

            await _sut.Invoking(s => s.Execute(forumId, "SomeTitle", authorId, CancellationToken.None))
                .Should().ThrowAsync<ForumNotfoundException>();
        }

        [Fact]
        public async Task ReturnNewlyCreatedTopic()
        {
            var forumId = Guid.Parse("492ab71e-8fc9-4066-8432-acc4f37ab246");
            var userId = Guid.Parse("e1462d9c-0710-4a8f-83ad-5b61dbbcf7e8");
            await _forumDbContext.Forums.AddAsync(new Storage.Models.Forum
            {
                Id = forumId,
                Title = "Test"
            });
            await _forumDbContext.Users.AddAsync(new User
            {
                Id = userId,
                Name = "Test"
            });
            await _forumDbContext.SaveChangesAsync();

            _createIdSetup.Returns(Guid.Parse("3e011381-d29f-4a7c-9ff9-4ce8dcac0935"));
            _getNowSetup.Returns(new DateTimeOffset(2023, 09, 30, 19, 28, 0, TimeSpan.FromHours(3)));

            var actual = await _sut.Execute(forumId, "test", userId, CancellationToken.None);
            var allTopics = await _forumDbContext.Topics.ToArrayAsync();
            allTopics.Should().BeEquivalentTo(new[]
            {
                new Storage.Models.Topic
                {
                ForumId = forumId,
                UserId = userId,
                Title = "test"
                } 
            }, cfg => cfg.Including(t=> t.Title).Including(t => t.ForumId).Including(t=> t.UserId));

            actual.Should().BeEquivalentTo(new Models.Topic
            {
                Id = Guid.Parse("3e011381-d29f-4a7c-9ff9-4ce8dcac0935"),
                Title = "test",
                Author = "Test",
                CreatedAt = new DateTimeOffset(2023, 09, 30, 19, 28, 0, TimeSpan.FromHours(3))
            });
        }
    }
}