package com.example.BoardProject.DTO;

import com.example.BoardProject.Entity.Article;
import lombok.AllArgsConstructor;
import lombok.ToString;

import java.time.LocalDateTime;

@AllArgsConstructor
@ToString
public class ArticleForm {
    private Long id;
    private String title;
    private String content;

    public Article toEntity(){
        return new Article(id, title, content, LocalDateTime.now());
    }
}
