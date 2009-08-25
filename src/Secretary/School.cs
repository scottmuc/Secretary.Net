using System.Collections.Generic;

namespace Secretary
{
    public abstract class School
    {
        protected School(string name)
            : this(name, new List<Enrollment>(), new SpecializationCollection())
        {

        }

        protected School(string name, IList<Enrollment> enrollments, SpecializationCollection specializations)
        {
            Name = name;
            Enrollments = enrollments;
            Specializations = specializations;
        }

        public string Name { get; private set; }
        public SpecializationCollection Specializations { get; private set; }
        public IList<Enrollment> Enrollments { get; private set; }

        public abstract string BaseFilePath { get; }
        public abstract Location Location { get; }
        public abstract IEnrollment Enroll();
    }
}
