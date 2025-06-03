package com.example.BoardProject.DTO;

import com.example.BoardProject.Entity.Article;
import com.example.BoardProject.Entity.Comment;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.ToString;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@ToString
public class CommentForm {
    private Long id;
    private String nickname;
    private String comment;
    private String commentdate;
    private Long articleId;

    public static CommentForm createCommentForm(Comment comment){
        return new CommentForm(
                comment.getId(),
                comment.getNickname(),
                comment.getComment(),
                comment.getCommentdate(),
                comment.getArticle().getId()
                );
    }
}
