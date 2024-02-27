using Autofac.Extras.Moq;
using Moq;
using PatientPortal.Api.Models.PatientModels;
using PatientPortal.Domain.Entities;
using PatientPortal.Domain.Enums;
using PatientPortal.Domain.Repositories.Patients;
using PatientPortal.Domain.UnitOfWork;
using Shouldly;

namespace PatientPortal.Api.Tests.Models;

public class PatientModelTests
{
    private AutoMock _mock;
    private Mock<IUnitOfWorks> _unitOfWorkMock;
    private Mock<IPatientsRepository> _patientRepositoryMock;
    private Mock<PatientModel> _patientModelMock;

    private PatientModel _patientModel;

    const int id = 1;

    [OneTimeSetUp]
    public void ClassSetup()
    {
        _mock = AutoMock.GetLoose();
    }

    [OneTimeTearDown]
    public void ClassCleanup()
    {
        _mock?.Dispose();
    }

    [SetUp]
    public void TestSetup()
    {
        _unitOfWorkMock = _mock.Mock<IUnitOfWorks>();
        _patientRepositoryMock = _mock.Mock<IPatientsRepository>();
        _patientModelMock = new Mock<PatientModel>(_unitOfWorkMock.Object);
        _patientModel = _mock.Create<PatientModel>();
    }

    [TearDown]
    public void TestCleanUp()
    {
        _unitOfWorkMock?.Reset();
        _patientRepositoryMock?.Reset();
        _patientModelMock?.Reset();
        _patientModel = null;
    }

    [Test, Category("Unit Test")]
    public async Task CreatePatient_PatientObjectNull_ThrowException()
    {
        await Should.ThrowAsync<ArgumentNullException>(
            async () => await _patientModel.CreatePatient(null));
    }

    [Test, Category("Unit Test")]
    public async Task CreatePatient_PatientNotNull_CreateNewPatient()
    {
        //Arrange
        var model = PrepareModelData();

        _unitOfWorkMock.Setup(x => x.PatientsRepository)
            .Returns(_patientRepositoryMock.Object)
            .Verifiable();

        _patientRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Patient>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

        //Act
        await _patientModel.CreatePatient(model);

        //Assert
        this.ShouldSatisfyAllConditions(
            () => _unitOfWorkMock.VerifyAll(),
            () => _patientRepositoryMock.VerifyAll());
    }

    [Test, Category("Unit Test")]
    public async Task UpdatePatientAsync_PatientObjectNull_ThrowException()
    {
        await Should.ThrowAsync<ArgumentNullException>(
            async () => await _patientModel.UpdatePatientAsync(1, null));
    }

    [Test, Category("Unit Test")]
    public async Task UpdatePatientAsync_PatientNotFound_ThrowException()
    {
        //Arrange
        var model = PrepareModelData();

        _unitOfWorkMock.Setup(x => x.PatientsRepository)
            .Returns(_patientRepositoryMock.Object)
            .Verifiable();

        _patientRepositoryMock.Setup(x => x.GetPatientEditInfoAsync(id, true))
            .ReturnsAsync((Patient)null)
            .Verifiable();

        //Act & Assert
        await Should.ThrowAsync<ArgumentException>(
            async () => await _patientModel.UpdatePatientAsync(id, model));
    }

    [Test, Category("Unit Test")]
    public async Task UpdatePatientAsync_PatientFound_UpdatePatientInfo()
    {
        //Arrange
        var model = PrepareModelData();
        var patient = PrepareEntity(model);

        _unitOfWorkMock.Setup(x => x.PatientsRepository)
            .Returns(_patientRepositoryMock.Object)
            .Verifiable();

        _patientRepositoryMock.Setup(x => x.GetPatientEditInfoAsync(id, true))
            .ReturnsAsync(patient)
            .Verifiable();

        _unitOfWorkMock.Setup(x => x.SaveAsync(CancellationToken.None))
            .Returns(Task.CompletedTask)
            .Verifiable();

        //Act
        await _patientModel.UpdatePatientAsync(id, model);

        //Assert
        this.ShouldSatisfyAllConditions(
            () => _unitOfWorkMock.VerifyAll(),
            () => _patientRepositoryMock.VerifyAll());
    }

    [Test, Category("Unit Test")]
    public async Task RemovePatientAsync_PatientNotFound_ThrowException()
    {
        //Arrange
        _unitOfWorkMock.Setup(x => x.PatientsRepository)
            .Returns(_patientRepositoryMock.Object)
            .Verifiable();

        _patientRepositoryMock.Setup(x => x.GetByIdAsync(id, true, CancellationToken.None))
            .ReturnsAsync((Patient)null)
            .Verifiable();

        //Act & Assert
        await Should.ThrowAsync<ArgumentException>(
            async () => await _patientModel.RemovePatientAsync(1));
    }

    [Test, Category("Unit Test")]
    public async Task RemovePatientAsync_PatientFound_DeletePatient()
    {
        //Arrange
        var model = PrepareModelData();
        var entity = PrepareEntity(model);

        _unitOfWorkMock.Setup(x => x.PatientsRepository)
            .Returns(_patientRepositoryMock.Object)
            .Verifiable();

        _patientRepositoryMock.Setup(x => x.GetByIdAsync(id, true, CancellationToken.None))
            .ReturnsAsync(entity)
            .Verifiable();

        _unitOfWorkMock.Setup(x => x.SaveAsync(CancellationToken.None))
            .Returns(Task.CompletedTask)
            .Verifiable();

        //Act
        await _patientModel.RemovePatientAsync(id);

        //Assert
        this.ShouldSatisfyAllConditions(
            () => _unitOfWorkMock.VerifyAll(),
            () => _patientRepositoryMock.VerifyAll());
    }

    private static PatientCreateModel PrepareModelData()
    {
        List<int> alleryList = [1, 2];
        List<int> ncdList = [2];
        return new PatientCreateModel("Test User", 1, Epilepsy.Yes, alleryList, ncdList);
    }

    private static Patient PrepareEntity(PatientCreateModel model)
    {
        var allergyDetails = new List<AllergiesDetail>();
        var ncdDetails = new List<NCDDetail>();

        if (model.SelectedNcds is not null)
        {
            foreach (var ncdId in model.SelectedNcds)
            {
                ncdDetails.Add(new NCDDetail
                {
                    NCDId = ncdId
                });
            }
        }

        if (model.SelectedAllergies is not null)
        {
            foreach (var allergyId in model.SelectedAllergies)
            {
                allergyDetails.Add(new AllergiesDetail
                {
                    AllergyId = allergyId,
                });
            }
        }

        return new Patient
        {
            Id = id,
            Name = model.Name,
            DiseaseInformationId = model.DiseasesId,
            IsEpilepsy = model.Epilepsy,
            NCDDetails = ncdDetails,
            AllergiesDetails = allergyDetails
        };
    }
}
