using System.Collections.Generic;

namespace iVertion.Application.DTOs
{
    public class PagedBaseResponseDTO<T>
    {
        public PagedBaseResponseDTO(int totalRegisters,  List<T> data) 
        {
            TotalRegisters = totalRegisters;
            Data = data;   
        }
        public int TotalRegisters { get; private set; }
        public List<T>? Data { get; private set; }
    }
}