using System;
using System.Collections.Generic;

namespace Secretary.UnitTests
{
    public class School
    {
        private readonly string name;
        private readonly string folderToTeach;

        private readonly IDictionary<SpecializationKey, object> specializations;
        private readonly IList<Enrollment> enrollments;

        public School(string name, string folderToTeach)
            : this(name, folderToTeach, new List<Enrollment>(), new Dictionary<SpecializationKey, object>() )
        {

        }

        public School(string name, string folderToTeach, IList<Enrollment> enrollments, IDictionary<SpecializationKey, object> specializations)
        {
            this.name = name;
            this.folderToTeach = folderToTeach;
            this.enrollments = enrollments;
            this.specializations = specializations;
            this.DefaultFileType = FileType.File;
        }

        public string Name { get { return name; } }
        public string Folder { get { return folderToTeach; } }

        public FileType DefaultFileType { get; set; }

        public Enrollment Enroll(Secretary student)
        {
            var enrollment = new Enrollment
            { 
                Secretary = student,
                FileType = DefaultFileType
            };
                            
            enrollments.Add(enrollment);
     
            return enrollment;
        }

        public void AddSpecialization<TENTITY>(Func<TENTITY, string> pathDelegate)
        {
            this.AddSpecialization(DefaultFileType, pathDelegate);
        }

        public void AddSpecialization<TENTITY>(FileType fileType, Func<TENTITY, string> pathDelegate)
        {
            var key = new SpecializationKey(typeof(TENTITY), fileType);
            specializations.Add(key, pathDelegate);
        }

        public IEnumerable<Secretary> GetGraduates()
        {
            foreach(var enrollment in enrollments)
            {
                if (enrollment.Type != null)
                {
                    var student = new SpecializedSecretary
                    {
                        AlmaMater = this.Name,
                        RootFolder = this.folderToTeach,
                        Specialization = enrollment.Type
                    };
                    yield return student;
                }
                else
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
}
