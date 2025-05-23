package com.example.firstproject.controller;

import com.example.firstproject.dto.ArticleForm;
import com.example.firstproject.entity.Article;
import com.example.firstproject.repository.ArticleRepository;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

@Slf4j
@Controller
public class ArticleController {
    @Autowired
    private ArticleRepository articleRepository;
    @GetMapping("/articles/new")
    public String newArticleForm(){
        return "articles/new";
    }

    //New Post
    @PostMapping("/articles")
    public String createArticle(ArticleForm form, Model model){
        log.info(form.toString());
        //System.out.println(form.toString());
        //1. DTO를 엔티티로 변환
        Article article = form.toEntity();
        log.info(article.toString());
        //System.out.println(article.toString());
        //2. 리파지터리로 엔티티를 DB에 저장
        Article saved = articleRepository.save(article);
        log.info(saved.toString());
        //System.out.println(saved.toString());
        //1. 모든 데이터 가져오기
        Iterable<Article> articleEntityList = articleRepository.findAll();
        //2. 모델에 데이터 등록하기
        model.addAttribute("articleList", articleEntityList);
        //3. 뷰 페이지 설정하기
        return "articles/index";
    }

    //Search
    @GetMapping("articles/{id}")
    public String show(@PathVariable Long id, Model model){
        log.info("id = " + id);
        //1. id를 조회해 데이터 가져오기
        Article articleEntity = articleRepository.findById(id).orElse(null);
        //2. 모델에 데이터 등록하기
        model.addAttribute("article", articleEntity);
        //3. 뷰 페이지 반환하기
        return "articles/show";
    }
    @GetMapping("articles/{id}_modify")
    public String modify(@PathVariable Long id, Model model){
        //1. id를 조회해 데이터 가져오기
        Article articleEntity = articleRepository.findById(id).orElse(null);
        //2. 모델에 데이터 등록하기
        model.addAttribute("article", articleEntity);
        //3. 뷰 페이지 반환하기
        return "articles/modify";
    }
    @GetMapping("articles/{id}_view")
    public String view(@PathVariable Long id, Model model){
        //1. id를 조회해 데이터 가져오기
        Article articleEntity = articleRepository.findById(id).orElse(null);
        //2. 모델에 데이터 등록하기
        model.addAttribute("article", articleEntity);
        //3. 뷰 페이지 반환하기
        return "articles/view";
    }
    @PostMapping("/articles/update")
    public String updateArticle(ArticleForm form, Model model){
        log.info(form.toString());
        Article article = form.toModifiedEntity();
        log.info(article.toString());
        Article articleEntity = articleRepository.findById(article.getId()).orElse(null);
        log.info(articleEntity.toString());
        if (articleEntity != null) {
            articleRepository.save(article);
        }
        return "redirect:/articles/"+articleEntity.getId()+"_view";
    }
    @GetMapping("/articles/{id}_delete")
    public String deleteArticle(@PathVariable Long id){
        Article articleEntity = articleRepository.findById(id).orElse(null);
        log.info(articleEntity.toString());
        if (articleEntity != null) {
            articleRepository.delete(articleEntity);
        }
        return "redirect:/articles";
    }
    //View
    @GetMapping("/articles")
    public String index(Model model){
        //1. 모든 데이터 가져오기
        Iterable<Article> articleEntityList = articleRepository.findAll();
        //2. 모델에 데이터 등록하기
        model.addAttribute("articleList", articleEntityList);
        //3. 뷰 페이지 설정하기
        return "articles/index";
    }
}
