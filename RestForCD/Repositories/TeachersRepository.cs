namespace RestForCD.Repositories
{
    public class TeachersRepository
    {
        private int _nextID;
        private List<Teacher> _teachers;
        public TeachersRepository()
        {
            _nextID = 1;
            _teachers = new List<Teacher>()
            {
                new Teacher() {Id = _nextID++, Name="Matilde", Salary=30000},
                new Teacher() {Id = _nextID++, Salary=30000, Name="Matilde"},
                new Teacher() {Id = _nextID++, Salary=30000, Name="Matilde"},
                new Teacher() {Id = _nextID++, Salary=30000, Name="Matilde"}

            };
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> result = new List<Teacher>(_teachers);
            return result;
        }

        public Teacher Add(Teacher newTeacher)
        {
            newTeacher.Validate();
            newTeacher.Id = _nextID++;
            _teachers.Add(newTeacher);
            return newTeacher;
        }

        public Teacher? Update(int id, Teacher updatesTeacher)
        {
            updatesTeacher.Validate();
            Teacher? teacherToBeUpdated = GetById(id);
            if (teacherToBeUpdated == null)
            {
                return null;
            }
            teacherToBeUpdated.Salary = updatesTeacher.Salary;
            teacherToBeUpdated.Name = updatesTeacher.Name;
            return teacherToBeUpdated;
        }

        public Teacher? GetById(int id)
        {
            return _teachers.Find(teacher => teacher.Id == id);
        }

        public Teacher Delete(int id)
        {
            Teacher? teacherToBeDeleted = GetById(id);
            if (teacherToBeDeleted == null)
            {
                return null;
            }
            _teachers.Remove(teacherToBeDeleted);
            return teacherToBeDeleted;
        }


    }
}
