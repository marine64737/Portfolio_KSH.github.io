package com.example.BoardProject.Controller;

import com.example.BoardProject.DTO.ArticleForm;
import com.example.BoardProject.Entity.Article;
import com.example.BoardProject.Repository.BoardRepository;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.List;

@Slf4j
@Controller
public class ArticleController {
    @Autowired
    BoardRepository boardRepository;
    @GetMapping("/")
    public String index(Model model){
        List<Article> articleList = boardRepository.findAll(Sort.by(Sort.Direction.DESC, "id"));
        model.addAttribute("articleList", articleList);
        return "board/index";
    }
    @GetMapping("/board/new")
    public String post(){
        return "board/new";
    }
    @PostMapping("/")
    public String create(ArticleForm form, Model model){
        Article board = form.toEntity();
        log.info(board.toString());
        Article saved = boardRepository.save(board);
        log.info(saved.toString());
        List<Article> articleList = boardRepository.findAll(Sort.by(Sort.Direction.DESC, "id"));
        model.addAttribute("articleList", articleList);
        return "board/index";
    }
    @GetMapping("/board/{id}/view")
    public String view(@PathVariable Long id, Model model){
        Article board = boardRepository.findById(id).orElse(null);
        log.info(board.toString());
        Model saved = model.addAttribute("post", board);
        log.info(saved.toString());
        return "board/view";
    }
    @GetMapping("/board/{id}/modify")
    public String modify(@PathVariable Long id, Model model){
        Article board = boardRepository.findById(id).orElse(null);
        log.info(board.toString());
        Model saved = model.addAttribute("post", board);
        log.info(saved.toString());
        return "board/modify";
    }
    @PostMapping("/board/{id}/view")
    public String modified(ArticleForm form, Model model){
        Article article = form.toEntity();
        log.info(article.toString());
        Article saved = boardRepository.save(article);
        log.info(saved.toString());
        Model savedModel = model.addAttribute("post", saved);
        return "board/view";
    }
    @PostMapping("/board/{id}/delete")
    public String delete(@PathVariable Long id){
        boardRepository.deleteById(id);
        return "redirect:/";
    }
}
