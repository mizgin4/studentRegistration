using StudentSystem.Models;
using StudentSystem.Models.RequestModels;
using StudentSystem.Models.ResponseModels;


namespace StudentSystem.Services
{
    public class StudentService
    {
        private static readonly List<Students> _students = new List<Students> {

         new Students{id=1,name="James",surName="Brown",email="jamesb@student.com" },
         new Students{id=2,name="Mike",surName="Furry",email="mikefb@student.com" },
         new Students{id=3,name="Amy",surName="Smart",email="amys@student.com" }
        };
        private static readonly List<Courses> _courses = new List<Courses> {

         new Courses{id=1,courseName="Finance" },
         new Courses{id=2,courseName="Accounting" },
         new Courses{id=3,courseName="Chemistry" }
        };
        private static readonly List<OfferedExams> _offeredExams = new List<OfferedExams> {

         new OfferedExams{id=1,course_id=1,centre="Edinburgh",language="English",session="March",examDate=new DateTime(1,2,3),slot="morning" },
         new OfferedExams{id=2,course_id=1,centre="Edinburgh",language="Turkish",session="March",examDate=new DateTime(1,2,3),slot="afternoon" },
         new OfferedExams{id=3,course_id=2,centre="Orkney",language="French",session="August",examDate=new DateTime(1,2,3),slot="morning" },
         new OfferedExams{id=4,course_id=2,centre="Scottish Borders",language="Turkish",session="September",examDate=new DateTime(1,2,3),slot="afternoon" }
        };
        private static readonly List<RegisteredExamSessions> students = new List<RegisteredExamSessions> {

         new RegisteredExamSessions{id=1,exam_id=1,student_id=1 }
        };

        public Response Validate(Request request)
        {
            Response response = new Response();
            var studentExist = _students.Any(x => x.id == request.studentID);
            if (!studentExist)
            {
                return new Response() { mesaage = "Student can't found in the system" };
            }
            //Normally, I would loop the courses in the frontend with course_id as the key and course name
            //as the value. This way, when a student selects a course, I could have their course_id in the
            //backend and easily match it with any of the records
            var courseExist = _courses.Any(x => x.courseName.ToLower() == request.course.ToLower());
            if (!courseExist)
            {
                return new Response() { mesaage = "Course can't found in the system" };
            }
            var course = _courses.Where(x => x.courseName.ToLower() == request.course.ToLower()).First();

            var examExist = _offeredExams.Any(x => x.session == request.session && x.course_id == course.id
            && x.centre == request.centre && x.language == request.language);

            var exam = _offeredExams.Where(x => x.session == request.session && x.course_id == course.id
            && x.centre == request.centre && x.language == request.language).First();

            if (!examExist)
            {
                return new Response() { mesaage = "Looked exam session is not provided this semester" };
            }
            return new Response() { mesaage = "You are sucesfully registered.", centre = exam.centre,course=course.courseName,
            examDate=exam.examDate,language=exam.language,session=exam.session};
        }




    }
}
