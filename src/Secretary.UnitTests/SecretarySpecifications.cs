using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Secretary.UnitTests
{
    public class SecretarySpecifications
    {
        [Fact]
        public void CanCreateASchoolSpecializingInTestEntity()
        {
            School school = new School("Test Entity U");
            school.Specializations.Add(typeof(TestEntity), new Func<TestEntity, string>(e => e.Id.ToString()));

            Secretary student = new Secretary();

            school.Enroll(student).SpecializingIn(typeof(TestEntity));

            var secretary = school.GetGraduates().First();

            Assert.Equal("Test Entity U", secretary.AlmaMater);

            var specializedSecretary = secretary as SpecializedSecretary;

            Assert.NotNull(specializedSecretary);

            Assert.Equal(typeof(TestEntity), specializedSecretary.Specialization);

        }

    }

    public class School
    {
        private readonly string name;

        private readonly IDictionary<Type, object> specializations;
        private readonly IList<Enrollment> enrollments;

        public School(string name)
        {
            this.name = name;
            this.enrollments = new List<Enrollment>();
            this.specializations = new Dictionary<Type, object>();
        }

        public Enrollment Enroll(Secretary student)
        {
            var enrollment = new Enrollment(student);
                            
            enrollments.Add(enrollment);
     
            return enrollment;
        }

        public IDictionary<Type, object> Specializations { get { return specializations;  } }

        public string Name { get { return name; } }

        public IEnumerable<Secretary> GetGraduates()
        {
            foreach(var enrollment in enrollments)
            {
                if (enrollment.Type != null)
                {
                    var student = new SpecializedSecretary
                                      {
                                          AlmaMater = this.Name, 
                                          Specialization = enrollment.Type
                                      };
                    yield return student;
                }
                else
                {
                    var student = enrollment.Secretary;
                    student.AlmaMater = this.Name;
                    yield return student;
                }

            }
        }
    }

    public class Enrollment
    {
        public Secretary Secretary { get; private set; }
        public Type Type { get; private set; }

        public Enrollment(Secretary secretary)
        {
            this.Secretary = secretary;
        }

        public void SpecializingIn(Type type)
        {
            Type = type;
        }
    }

    public class Secretary
    {
        public string AlmaMater { get; set; }
    }

    public class SpecializedSecretary : Secretary
    {
        public Type Specialization { get; set; }        
    }
}