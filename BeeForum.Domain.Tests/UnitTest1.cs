using BeeForum.Domain.UseCases.CreateTopic;

namespace BeeForum.Domain.Tests
{
    public class CreateTopicUseCaseShould
    {
        private readonly CreateTopicUseCase sut;

        public CreateTopicUseCaseShould()
        {
            sut = new CreateTopicUseCase;
        }

        [Fact]
        public void ThrowNotFoundForumException_WhenNoForum()
        {
            var forumId = Guid.Parse("031c8ee0 - 46b5 - 4f66 - 96f7 - c772a850962d");
            var authorId = Guid.Parse("adadc83d-195a-4dcc-9040-a490354d6996");

            sut.Execute(forumId, "Some Title", authorId, CancellationToken.None);
        }
    }
}