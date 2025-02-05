﻿using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IClassSubjectRepository
    {
        Task <List<ClassSubject>> GetSubjectsByClassIdAsync (int ClassId);
        Task <ClassSubject> CreateClassSubject (ClassSubject classSubject);
        Task<ClassSubject?> GetClassSubjectById(int classSubjectId);
    }
}
