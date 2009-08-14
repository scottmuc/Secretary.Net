using System.Collections.Generic;

namespace Secretary
{
    public class School
    {
        private readonly string name;
        private readonly string folderToTeach;

        private readonly SpecializationCollection specializations;
        private readonly IList<Enrollment> enrollments;

        public School(string name, string folderToTeach)
            : this(name, folderToTeach, new List<Enrollment>(), new SpecializationCollection())
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

        public IList<Enrollment> Enrollments
        {
            get { return enrollments; }
        }

        public IEnrollment Enroll(Secretary student)
        {
            var enrollment = new Enrollment
            {
                FileType = FileType.Default,
                Secretary = student,
                School = this
            };
                            
            enrollments.Add(enrollment);
     
            return enrollment;
        }
    }
}
