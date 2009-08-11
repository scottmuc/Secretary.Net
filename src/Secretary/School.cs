using System.Collections.Generic;

namespace Secretary.UnitTests
{
    public class School : ISchool
    {
        private readonly string name;
        private readonly string folderToTeach;

        private readonly SpecializationCollection specializations;
        private readonly IList<Enrollment> enrollments;

        public School(string name, string folderToTeach)
            : this(name, folderToTeach, new List<Enrollment>(), new SpecializationCollection { DefaultFileType = FileType.File })
        {

        }

        public School(string name, string folderToTeach, IList<Enrollment> enrollments, SpecializationCollection specializations)
        {
            this.name = name;
            this.folderToTeach = folderToTeach;
            this.enrollments = enrollments;
            this.specializations = specializations;
        }

        public string Name { get { return name; } }
        public string Folder { get { return folderToTeach; } }

        public SpecializationCollection Specializations
        {
            get { return specializations; }
        }

        public Enrollment Enroll(Secretary student)
        {
            var enrollment = new Enrollment
            { 
                Secretary = student,
            };
                            
            enrollments.Add(enrollment);
     
            return enrollment;
        }

        public IEnumerable<Secretary> GraduateAllEnrolled()
        {
            foreach(var enrollment in enrollments)
            {
                    var student = enrollment.Secretary;
                    student.AlmaMater = this.Name;
                    student.RootFolder = this.folderToTeach;
                    student.FileTypeHandled = enrollment.FileType;
                    yield return student;                
            }
        }
    }
}
