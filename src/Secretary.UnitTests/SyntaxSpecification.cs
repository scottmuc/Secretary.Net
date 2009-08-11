using Rhino.Mocks;
using Xunit;

namespace Secretary.UnitTests
{
    public class SyntaxSpecification
    {
        [Fact]
        public void As_a_student_I_can_enroll_in_a_school()
        {
            var studentStub = MockRepository.GenerateStub<Secretary>();
            var schoolStub = MockRepository.GenerateStub<School>();

            schoolStub.Enroll(studentStub);
        }

        [Fact]
        public void As_a_student_I_can_specialized_in_File() 
        {
            var studentStub = MockRepository.GenerateStub<Secretary>();
            var schoolStub = MockRepository.GenerateStub<School>();

            schoolStub.Enroll(studentStub).SpecializingIn(FileType.File);
        }

        [Fact]
        public void As_a_student_I_can_enroll_for_an_entity() 
        {
            var studentStub = MockRepository.GenerateStub<Secretary>();
            var schoolStub = MockRepository.GenerateStub<School>();

            schoolStub.Enroll(studentStub).For<TestEntity>();
        }

        [Fact]
        public void As_a_student_I_can_specialize_in_File_for_Test_Entity()
        {
            var studentStub = MockRepository.GenerateStub<Secretary>();
            var schoolStub = MockRepository.GenerateStub<School>();

            schoolStub
                .Enroll(studentStub)
                .SpecializingIn(FileType.File)
                .For<TestEntity>();        
        }

        [Fact]
        public void As_a_new_student_I_can_enroll_in_TestEntity_school()
        {
            var student = new Secretary();
            var school = new School("TestEntitySchool", @"C:\");

            school.Enroll(student).SpecializingIn(FileType.Image).For<TestEntity>();
        }
    }
}