using BeeForum.Domain.Exceptions;
using BeeForum.Domain.UseCases.CreateTopic;
using FluentAssertions;
using Moq;
using Moq.Language.Flow;
using Topic = BeeForum.Domain.Models.Topic;

namespace BeeForum.Domain.Tests
{
    public class CreateTopicUsecaseShould
    {
        private readonly CreateTopicUseCase _sut;
        private readonly Mock<ICreateTopicStorage> _storage;
        private readonly ISetup<ICreateTopicStorage, Task<bool>> _forumExistsSetup;
        private readonly ISetup<ICreateTopicStorage, Task<Models.Topic>> _createTopicSetup;

        public CreateTopicUsecaseShould()
        {
            _storage = new();
            _forumExistsSetup = _storage.Setup(s => s.ForumExist(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
            _createTopicSetup = _storage.Setup(s => s.CreateTopic(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));
            _sut = new CreateTopicUseCase(_storage.Object);
        }
        [Fact]
        public async Task ThrowForumNotFoundException_WhenNoMatchingForum()
        {
            _forumExistsSetup.ReturnsAsync(false);
            var forumId = Guid.Parse("61473223-ec8a-4ffd-8f64-df58cc75b510");
            var authorId = Guid.Parse("70c565da-de2b-40a4-8105-1935b3516393");
            await _sut.Invoking(s => s.Execute(forumId, "SomeTitle", authorId, CancellationToken.None))
                .Should().ThrowAsync<ForumNotfoundException>();
            _storage.Verify(s => s.ForumExist((forumId), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task ReturnNewlyCreatedTopic()
        {
            _forumExistsSetup.ReturnsAsync(true);
            var expected = new Topic();
            _createTopicSetup.ReturnsAsync(expected);
            var forumId = Guid.Parse("492ab71e-8fc9-4066-8432-acc4f37ab246");
            var userId = Guid.Parse("e1462d9c-0710-4a8f-83ad-5b61dbbcf7e8");
            var actual = await _sut.Execute(forumId, "test", userId, CancellationToken.None);
            actual.Should().Be(expected);
            _storage.Verify(s => s.CreateTopic(forumId, userId, "test", It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}