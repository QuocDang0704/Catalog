using System;
namespace Catalog.Entities
{
    public record Item
    {
        //gõ nhanh prop
        // todo: init có thể sử dụng biểu thức tạo của người tạo để tạo đối tượng,
        // ! n sau đó khi tạo không thể sử đổi thuộc tính này
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }    
        public DateTimeOffset CreateDate { get; init; }   

    }
}