using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vize.Dtos;
using vize.Models;

namespace vize.Controllers
{
    [Route("api/Lessons")]
    [ApiController]
    
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public LessonController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
       
        public List<LessonDto> GetList()
        {
            var Lessons = _context.Lessons.ToList();
            var LessonDtos = _mapper.Map<List<LessonDto>>(Lessons);
            return LessonDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public LessonDto Get(int id)
        {
            var Lesson = _context.Lessons.Where(s => s.Id == id).SingleOrDefault();
            var LessonDto = _mapper.Map<LessonDto>(Lesson);
            return LessonDto;
        }
        [HttpGet]
        [Route("{id}/Exams")]
        public List<ExamDto> GetExams(int id)
        {
            var Exams = _context.Exams.Where(s => s.LessonId == id).ToList();
            var ExamDtos = _mapper.Map<List<ExamDto>>(Exams);
            return ExamDtos;
        }
        [HttpPost]
        
        public ResultDto Post(LessonDto dto)
        {
            if (_context.Lessons.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Ders Adı Kayıtlıdır!";
                return result;
            }
            var Lesson = _mapper.Map<Lesson>(dto);
            Lesson.Updated = DateTime.Now;
            Lesson.Created = DateTime.Now;
            _context.Lessons.Add(Lesson);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ders Eklendi";
            return result;
        }


        [HttpPut]
        
        public ResultDto Put(LessonDto dto)
        {
            var Lesson = _context.Lessons.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (Lesson == null)
            {
                result.Status = false;
                result.Message = "Ders Bulunamadı!";
                return result;
            }
            Lesson.Name = dto.Name;
            Lesson.IsActive = dto.IsActive;
            Lesson.Updated = DateTime.Now;

            _context.Lessons.Update(Lesson);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ders Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        
        public ResultDto Delete(int id)
        {
            var Lesson = _context.Lessons.Where(s => s.Id == id).SingleOrDefault();
            if (Lesson == null)
            {
                result.Status = false;
                result.Message = "Ders Bulunamadı!";
                return result;
            }
            _context.Lessons.Remove(Lesson);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ders Silindi";
            return result;
        }
    }
}
