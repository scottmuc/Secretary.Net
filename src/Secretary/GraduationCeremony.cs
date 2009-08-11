using System.Collections.Generic;

namespace Secretary
{
    public class GraduationCeremony 
    {
        private readonly IList<Enrollment> enrollments;

        public GraduationCeremony(IList<Enrollment> enrollments)
        {
            this.enrollments = enrollments;
        }

        public IList<Secretary> GetGraduates()
        {
            var graduates = new List<Secretary>();

            foreach(var enrollment in enrollments)
            {
                var secretary = enrollment.Secretary;
                secretary.AlmaMater = enrollment.School.Name;
                secretary.RootFolder = enrollment.School.Folder;
                graduates.Add(secretary);
            }

            return graduates;
        }
    }
}
