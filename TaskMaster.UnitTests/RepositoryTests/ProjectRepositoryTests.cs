using MongoDB.Driver;
using Moq;
using TaskMaster.Core.Models;
using TaskMaster.Persistence.Data.Options;
using TaskMaster.Persistence.Repositories.Implementations;

namespace TaskMaster.UnitTests.RepositoryTests;

public class ProjectRepositoryTests
{

    private readonly Mock<IMongoOption> _mongoOptionMock;
    private readonly ProjectRepository _projectRepository;
    private readonly IMongoCollection<Project> _collection;

    public ProjectRepositoryTests()
    {
        _mongoOptionMock = new Mock<IMongoOption>();
        _projectRepository = new ProjectRepository(_mongoOptionMock.Object);
        var client = new MongoClient(_mongoOptionMock.Object.ConnectionString);
        var database = client.GetDatabase(_mongoOptionMock.Object.DatabaseName);
        _collection = database.GetCollection<Project>("Project");
    }
    [Fact]
    public async Task GetProjectsAsync_ShouldReturnAllProjects_WhenNoFilterIsPassed()
    {
        // Arrange
        var project1 = new Project { Name = "Project 1" };
        var project2 = new Project { Name = "Project 2" };
        var project3 = new Project { Name = "Project 3" };
        var projects = new List<Project> { project1, project2, project3 };
        await _collection.InsertManyAsync(projects);

        // Act
        var result = await _projectRepository.GetProjectsAsync();

        // Assert
        Assert.Equal(projects, result);
    }

    [Fact]
    public async Task GetProjectsAsync_ShouldReturnProjectsThatMatchTheFilter_WhenAFilterIsPassed()
    {
        // Arrange
        var project1 = new Project { Name = "Project 1" };
        var project2 = new Project { Name = "Project 2" };
        var project3 = new Project { Name = "Project 3" };
        var projects = new List<Project> { project1, project2, project3 };
        await _collection.InsertManyAsync(projects);

        // Act
        var result = await _projectRepository.GetProjectsAsync(p => p.Name.StartsWith("Project"));

        // Assert
        Assert.Equal(new List<Project> { project1, project2 }, result);
    }
}