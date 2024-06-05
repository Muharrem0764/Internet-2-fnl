using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vize.Dtos;
using vize.Models;

namespace vize.Controllers
{
    [Route("api/Exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public ExamController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ExamDto> GetList()
        {
            var Exams = _context.Exams.ToList();
            var ExamDtos = _mapper.Map<List<ExamDto>>(Exams);
            return ExamDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public ExamDto Get(int id)
        {
            var Exam = _context.Exams.Where(s => s.Id == id).SingleOrDefault();
            var ExamDto = _mapper.Map<ExamDto>(Exam);
            return ExamDto;
        }

        [HttpPost]
        public ResultDto Post(ExamDto dto)
        {
            if (_context.Exams.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Sınav Adı Kayıtlıdır!";
                return result;
            }
            var Exam = _mapper.Map<Exam>(dto);
            Exam.Updated = DateTime.Now;
            Exam.Created = DateTime.Now;
            Exam.Time= dto.Time;
            _context.Exams.Add(Exam);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Sınav Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(ExamDto dto)
        {
            var Exam = _context.Exams.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (Exam == null)
            {
                result.Status = false;
                result.Message = "Sınav Bulunamadı!";
                return result;
            }
            Exam.Name = dto.Name;
            Exam.IsActive = dto.IsActive;
            Exam.Time = dto.Time;
            Exam.Updated = DateTime.Now;
            Exam.LessonId = dto.LessonId;
            _context.Exams.Update(Exam);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Sınav Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var Exam = _context.Exams.Where(s => s.Id == id).SingleOrDefault();
            if (Exam == null)
            {
                result.Status = false;
                result.Message = "Sınav Bulunamadı!";
                return result;
            }
            _context.Exams.Remove(Exam);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Sınav Silindi";
            return result;
        }
    }
}
