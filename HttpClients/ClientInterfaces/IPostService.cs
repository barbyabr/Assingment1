﻿using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);

    Task<ICollection<Post>> GetAsync(
        string? userName,
        int? userId,
        string? titleContains,
        string? textContains
    );
    
    Task<PostBasicDto> GetByIdAsync(int id);
}