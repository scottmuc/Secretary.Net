using System.Collections.Generic;

namespace Secretary
{
    /// <summary>
    /// Abstract School. Holds refeferences to all pieces of knowledge a secretary should know in order
    /// to locate a file. Contains abstract methods to delegate information to more specialized schools
    /// </summary>
    public abstract class School
    {
        protected School(string name)
            : this(name, new SpecializationCollection(), new List<Enrollment>())
        {

        }

        protected School(string name, SpecializationCollection specializations)
            : this(name, specializations, new List<Enrollment>())
        {

        }

        protected School(string name, SpecializationCollection specializations, IList<Enrollment> enrollments)
        {
            Name = name;
            Enrollments = enrollments;
            Specializations = specializations;
        }

        /// <summary>
        /// Name of the school.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Collection of FileType/Entity specializations the school can teach
        /// </summary>
        public SpecializationCollection Specializations { get; private set; }

        /// <summary>
        /// Contains all the enrollments of the school. These enrollments can then
        /// be graduated into fully trained secretaries.
        /// </summary>
        public IList<Enrollment> Enrollments { get; private set; }

        /// <summary>
        /// Absolute base path for the school. Abstracted so that urls or file systems paths can
        /// be used.
        /// </summary>
        public abstract string BaseFilePath { get; }

        /// <summary>
        /// Property to retrieve LocationContext that concrete school works with.
        /// </summary>
        public abstract Location Location { get; }

        /// <summary>
        /// Creates a secretary and enrolls them in the school
        /// </summary>
        /// <returns>An entry into the enrollment fluent API</returns>
        public IEnrollment Enroll()
        {
            var enrollment = new Enrollment
            {
                FileType = FileType.Default,
                Secretary = new Secretary(),
                School = this
            };

            Enrollments.Add(enrollment);

            return enrollment;
        }
    }
}
