package com.spac.questionnaire.controllers;

import com.spac.questionnaire.dao.Answer;
import com.spac.questionnaire.services.AnswerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("answers")
public class AnswerController {

    @Autowired
    AnswerService answerService;

    @GetMapping("allAnswers")
    public ResponseEntity<List<Answer>> getAllAnswers(){
        return answerService.getAllAnswers();
    }
}
